// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyInfoUpdater.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   The assembly info updater.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using SetVersionInformation.Properties;

#endregion

namespace SetVersionInformation
{
    /// <summary>
    ///     The assembly info updater.
    /// </summary>
    internal class AssemblyInfoUpdater
    {
        #region Constants and Fields

        /// <summary>
        ///     The file formatters.
        /// </summary>
        [NotNull] private readonly List<IAssemblyInfoFormatTraits> _formatters;

        /// <summary>
        ///     The tags to modify.
        /// </summary>
        [NotNull] private readonly Dictionary<string, Func<IAssemblyInfoFormatTraits, VersionProperties, string>>
            _tagsToModify;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AssemblyInfoUpdater" /> class.
        /// </summary>
        /// <exception cref="InvalidConfigurationException">No Tags Defined.</exception>
        /// <exception cref="InvalidConfigurationException">No File Formats.</exception>
        public AssemblyInfoUpdater()
        {
            _tagsToModify = AssemblyInfoTagHelper.TagsToModify;
            if (!_tagsToModify.Any())
            {
                throw new InvalidConfigurationException("No Tags Defined.");
            }

            _formatters = AssemblyInfoTagHelper.FileFormats;
            if (!_formatters.Any())
            {
                throw new InvalidConfigurationException("No File Formats.");
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     The process folder contents.
        /// </summary>
        /// <param name="directoryInfo">
        ///     The directory info.
        /// </param>
        /// <param name="version">
        ///     The version.
        /// </param>
        public void ProcessFolderContents([NotNull] DirectoryInfo directoryInfo, [NotNull] VersionProperties version)
        {
            Contract.Requires(directoryInfo != null);
            Contract.Requires(version != null);

            foreach (IAssemblyInfoFormatTraits fileFormat in _formatters)
            {
                FileInfo[] files = directoryInfo.GetFiles(fileFormat.FileSpecification);
                foreach (FileInfo file in files)
                {
                    ProcessAssemblyInfoFile(file.FullName, fileFormat, version);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Determines whether the line contains the tag.
        /// </summary>
        /// <param name="tagName">
        ///     The tag name.
        /// </param>
        /// <param name="formatTraits">
        ///     The format traits.
        /// </param>
        /// <param name="line">
        ///     The line to check.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if the line contains the tag; <see langword="false" />, otherwise.
        /// </returns>
        private static bool IsLineOfTag(
            [NotNull] string tagName, [NotNull] IAssemblyInfoFormatTraits formatTraits, [NotNull] string line)
        {
            Contract.Requires(!string.IsNullOrEmpty(tagName));
            Contract.Requires(formatTraits != null);
            Contract.Requires(!string.IsNullOrEmpty(line));

            var supportedFormats = new[]
                {
                    @"{0}{1}:{2}{3}", @"{0}{1}:{2}(", @"{0}{1}:{2}Attribute{3}", @"{0}{1}:{2}Attribute(",
                    @"{0}{1} :{2}{3}", @"{0}{1} :{2}(", @"{0}{1} :{2}Attribute{3}", @"{0}{1} :{2}Attribute(",
                    @"{0}{1}: {2}{3}", @"{0}{1}: {2}(", @"{0}{1}: {2}Attribute{3}", @"{0}{1}: {2}Attribute(",
                    @"{0}{1} : {2}{3}", @"{0}{1} : {2}(", @"{0}{1} : {2}Attribute{3}", @"{0}{1} : {2}Attribute("
                };

            return
                supportedFormats.Any(
                    format =>
                    line.StartsWith(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            format,
                            formatTraits.OpenAttributeText,
                            formatTraits.AssemblyKeyword,
                            tagName,
                            formatTraits.CloseAttributeText),
                        StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///     The get tag formatter.
        /// </summary>
        /// <param name="formatTraits">
        ///     The format traits.
        /// </param>
        /// <param name="line">
        ///     The line search for the tag in.
        /// </param>
        /// <returns>
        ///     The tag formatter for the line.
        /// </returns>
        [CanBeNull]
        private KeyValuePair<string, Func<IAssemblyInfoFormatTraits, VersionProperties, string>>? GetTagFormatter(
            [NotNull] IAssemblyInfoFormatTraits formatTraits, [CanBeNull] string line)
        {
            Contract.Requires(formatTraits != null);

            if (string.IsNullOrEmpty(line))
            {
                return null;
            }

            foreach (var item in _tagsToModify)
            {
                if (IsLineOfTag(item.Key, formatTraits, line))
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        ///     The output missing attributes.
        /// </summary>
        /// <param name="formatTraits">The format traits.</param>
        /// <param name="version">The version.</param>
        /// <param name="outputText">The output text.</param>
        /// <param name="alreadyWrittenTags">The already written tags.</param>
        private void OutputMissingAttributes(
            [NotNull] IAssemblyInfoFormatTraits formatTraits,
            [NotNull] VersionProperties version,
            [NotNull] List<string> outputText,
            [NotNull] ReadOnlyCollection<string> alreadyWrittenTags)
        {
            Contract.Requires(formatTraits != null);
            Contract.Requires(version != null);
            Contract.Requires(outputText != null);
            Contract.Requires(alreadyWrittenTags != null);

            foreach (var current in _tagsToModify)
            {
                if (!alreadyWrittenTags.Contains(current.Key))
                {
                    Console.WriteLine(Resources.AssemblyInfoUpdater_OutputMissingAttributes_____Adding_Missing_Attribute___0_, current.Key);
                    string str = current.Value(formatTraits, version);
                    outputText.Add(str);
                }
            }
        }

        /// <summary>
        ///     The process assembly info file.
        /// </summary>
        /// <param name="fileName">
        ///     The file name.
        /// </param>
        /// <param name="formatTraits">
        ///     The format traits.
        /// </param>
        /// <param name="version">
        ///     The version.
        /// </param>
        private void ProcessAssemblyInfoFile(
            [NotNull] string fileName,
            [NotNull] IAssemblyInfoFormatTraits formatTraits,
            [NotNull] VersionProperties version)
        {
            Contract.Requires(!string.IsNullOrEmpty(fileName));
            Contract.Requires(formatTraits != null);
            Contract.Requires(version != null);

            Console.WriteLine(Resources.AssemblyInfoUpdater_ProcessAssemblyInfoFile_Found_File___0_, fileName);
            IEnumerable<string> fileContents = TextFileHelpers.ReadFileContents(fileName);

            var outputLines = new List<string>();

            ReadOnlyCollection<string> updatedAttributes =
                UpdateExistingAttributes(fileContents, formatTraits, version, outputLines).ToList().AsReadOnly();
            OutputMissingAttributes(formatTraits, version, outputLines, updatedAttributes);

            TextFileHelpers.WriteFileContents(fileName, outputLines);
        }

        /// <summary>
        ///     The update existing attributes.
        /// </summary>
        /// <param name="fileContents">The file contents.</param>
        /// <param name="formatTraits">The format traits.</param>
        /// <param name="version">The version.</param>
        /// <param name="outputText">The output text.</param>
        /// <returns>
        ///     Collection of tags that were written.
        /// </returns>
        [NotNull]
        private IEnumerable<string> UpdateExistingAttributes(
            [NotNull] IEnumerable<string> fileContents,
            [NotNull] IAssemblyInfoFormatTraits formatTraits,
            [NotNull] VersionProperties version,
            [NotNull] List<string> outputText)
        {
            Contract.Requires(fileContents != null);
            Contract.Requires(formatTraits != null);
            Contract.Requires(version != null);
            Contract.Requires(outputText != null);

            Contract.Ensures(Contract.Result<IEnumerable<string>>() != null);

            foreach (string current in fileContents)
            {
                KeyValuePair<string, Func<IAssemblyInfoFormatTraits, VersionProperties, string>>? tagFormatter =
                    GetTagFormatter(formatTraits, current);
                if (tagFormatter.HasValue)
                {
                    KeyValuePair<string, Func<IAssemblyInfoFormatTraits, VersionProperties, string>> keyValuePair =
                        tagFormatter.Value;
                    string str = keyValuePair.Value(formatTraits, version);
                    outputText.Add(str);
                    yield return keyValuePair.Key;
                }
                else
                {
                    outputText.Add(current);
                }
            }
        }

        /// <summary>
        ///     The object Invariant.
        /// </summary>
        [UsedImplicitly]
        [ContractInvariantMethod]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "Invoked by Code Contracts")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
            Justification = "Invoked by Code Contracts, non static accesses")]
        private void ObjectInvariant()
        {
            Contract.Invariant(_tagsToModify != null);
            Contract.Invariant(_formatters != null);
        }

        #endregion
    }
}