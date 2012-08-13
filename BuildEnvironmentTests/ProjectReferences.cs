// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectReferences.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Checks project references.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

using JetBrains.Annotations;

using NUnit.Framework;

#endregion

namespace BuildEnvironmentTests
{
    /// <summary>
    /// Checks project references.
    /// </summary>
    [TestFixture]
    public sealed class ProjectReferences
    {
        #region Constants and Fields

        /// <summary>
        /// The shared assemblies folder.
        /// </summary>
        private const string SharedAssembliesFolder = @"Assemblies";

        /// <summary>
        /// Regular expression to find  project references.
        /// </summary>
        private static readonly Regex RegExFindRef =
            new Regex(
                "^\\s*<Reference Include=\\\"(?<Assembly>[a-zA-Z0-9.]*), Version=(?<Version>[0-9.]*), "
                + "Culture=[a-zA-Z0-9]*, PublicKeyToken=[0-9a-fA-F]*, processorArchitecture=[a-zA-Z0-9.]*\\\">"
                + Environment.NewLine + "^\\s*<SpecificVersion>[a-zA-Z0-9.]*</SpecificVersion>" + Environment.NewLine
                + "^\\s*<HintPath>(?<HintPath>.*)</HintPath>" + Environment.NewLine + "^\\s*</Reference>",
                RegularExpressionOptions);

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the test context which provides
        ///   information about and functionality for the current test run.
        /// </summary>
        /// <value>
        /// The test context.
        /// </value>
        public TestContext TestContext
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the regular expression options.
        /// </summary>
        /// <value>
        /// The regular expression options.
        /// </value>
        private static RegexOptions RegularExpressionOptions
        {
            get
            {
                return RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.CultureInvariant
                       | RegexOptions.ExplicitCapture;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Checks that all Non project references are in the Shared assemblies folder.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void AllNonProjectReferencesIncorrectLocation()
        {
            var searchPath = FolderHelpers.RootPath;
            var referencesOk = CheckProjectReferences(Path.GetFullPath(searchPath), SharedAssembliesFolder);
            Assert.IsTrue(referencesOk, "Some invalid references found");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks the project references.
        /// </summary>
        /// <param name="searchPath">
        /// The search path.
        /// </param>
        /// <param name="permittedAssemblyPath">
        /// The permitted assembly path.
        /// </param>
        /// <returns>
        /// True if everything was OK.
        /// </returns>
        private static bool CheckProjectReferences([NotNull] string searchPath, [NotNull] string permittedAssemblyPath)
        {
            Contract.Requires(!string.IsNullOrEmpty(searchPath));
            Contract.Requires(!string.IsNullOrEmpty(permittedAssemblyPath));

            var projectFiles = Directory.GetFiles(searchPath, "*.csproj", SearchOption.AllDirectories);
            var refsOk = true;
            foreach (var path in projectFiles)
            {
                var text = File.ReadAllText(path);
                var matches = RegExFindRef.Matches(text);

                if (matches.Count <= 0)
                {
                    continue;
                }

                var resolvedProjectPath = Path.GetFullPath(path);
                var badReferences = 0;
                foreach (Match match in matches)
                {
                    var hintPath = match.Groups["HintPath"].Value;
                    var resolvedDllPath =
                        Path.GetFullPath(Path.Combine(Path.GetDirectoryName(resolvedProjectPath), hintPath));

                    // Check the referenced assembly path
                    bool fileMissing;
                    if ((!(fileMissing = !File.Exists(resolvedDllPath)))
                        && resolvedDllPath.Contains(permittedAssemblyPath))
                    {
                        continue;
                    }

                    if (badReferences == 0)
                    {
                        Console.WriteLine(
                            string.Format(
                                CultureInfo.CurrentCulture,
                                "Project '{0}': [{1}]",
                                Path.GetFileNameWithoutExtension(resolvedProjectPath),
                                resolvedProjectPath));
                        badReferences++;
                        refsOk = false;
                    }

                    Console.WriteLine(
                        string.Format(
                            CultureInfo.CurrentCulture,
                            "  Assembly {0} referenced at '{1}'{2}",
                            match.Groups["Assembly"],
                            resolvedDllPath,
                            fileMissing ? " but is missing." : "."));
                }
            }

            if (!refsOk)
            {
                Console.WriteLine(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        "\r\nNB: All assembly references should be valid and either project references or direct references against the '{0}' folder of this library.",
                        permittedAssemblyPath));
            }

            return refsOk;
        }

        #endregion
    }
}