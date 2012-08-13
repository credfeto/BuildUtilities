// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectFiles.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Various tests on the content of project files.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

using JetBrains.Annotations;

using NUnit.Framework;

#endregion

namespace BuildEnvironmentTests
{
    /// <summary>
    /// Various tests on the content of project files.
    /// </summary>
    [TestFixture]
    public sealed class ProjectFiles
    {
        #region Public Methods

        /// <summary>
        /// Tests for extra files in Source control that don't need to be there.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void NoExtraFiles()
        {
            var searchPath = FolderHelpers.RootPath;

            Console.WriteLine("Processing Projects in and under {0}", searchPath);

            var errorFiles = new List<string>();

            var thereWereNoErrors = ProcessFolder(true, searchPath, errorFiles, CheckForAdditionalFiles);
            Assert.IsTrue(thereWereNoErrors, ErrorMessage("Extra files were found", errorFiles));
        }

        /// <summary>
        /// Tests for files that should be present, but are not - and would therefore fail the build.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void NoMissingFiles()
        {
            var searchPath = FolderHelpers.RootPath;

            Console.WriteLine("Processing Projects in and under {0}", searchPath);

            var errorFiles = new List<string>();

            var thereWereNoErrors = ProcessFolder(true, searchPath, errorFiles, CheckForMissingFiles);
            Assert.IsTrue(thereWereNoErrors, ErrorMessage("Missing files were found", errorFiles));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks for additional files.
        /// </summary>
        /// <param name="projectFiles">
        /// The project files.
        /// </param>
        /// <param name="folderFiles">
        /// The folder files.
        /// </param>
        /// <param name="errorFiles">
        /// The error files.
        /// </param>
        /// <returns>
        /// True if there were additional files found.
        /// </returns>
        private static bool CheckForAdditionalFiles(
            [NotNull] List<string> projectFiles, [NotNull] List<string> folderFiles, [NotNull] List<string> errorFiles)
        {
            Contract.Requires(projectFiles != null);
            Contract.Requires(folderFiles != null);
            Contract.Requires(errorFiles != null);

            var extraFilesFound = false;

            foreach (var file in
                folderFiles.Where(file => !projectFiles.Contains(file.ToLowerInvariant())).Where(
                    file => !IsIgnoreExtraFile(file)))
            {
                extraFilesFound = true;
                Console.WriteLine("-- Extra file {0}", file);
                errorFiles.Add(file);
            }

            if (!extraFilesFound)
            {
                Console.WriteLine("-- No extra files found!");
            }

            return extraFilesFound;
        }

        /// <summary>
        /// Checks for missing files.
        /// </summary>
        /// <param name="projectFiles">
        /// The project files.
        /// </param>
        /// <param name="folderFiles">
        /// The folder files.
        /// </param>
        /// <param name="errorFiles">
        /// The error files.
        /// </param>
        /// <returns>
        /// True if there were missing files.
        /// </returns>
        private static bool CheckForMissingFiles(
            [NotNull] List<string> projectFiles, [NotNull] List<string> folderFiles, [NotNull] List<string> errorFiles)
        {
            Contract.Requires(projectFiles != null);
            Contract.Requires(folderFiles != null);
            Contract.Requires(errorFiles != null);

            var extraFilesFound = false;
            foreach (var file in
                projectFiles.Where(file => !folderFiles.Contains(file.ToLowerInvariant())).Where(
                    file => !IsIgnoreExtraFile(file)))
            {
                extraFilesFound = true;
                Console.WriteLine("-- Missing file {0}", file);
                errorFiles.Add(file);
            }

            if (!extraFilesFound)
            {
                Console.WriteLine("-- No missing files found!");
            }

            return extraFilesFound;
        }

        /// <summary>
        /// Builds up the error message string for the assert.
        /// </summary>
        /// <param name="messageText">
        /// The message text.
        /// </param>
        /// <param name="files">
        /// The files.
        /// </param>
        /// <returns>
        /// Text to display in the assert.
        /// </returns>
        [NotNull]
        private static string ErrorMessage([NotNull] string messageText, [NotNull] IEnumerable<string> files)
        {
            Contract.Requires(!string.IsNullOrEmpty(messageText));
            Contract.Requires(files != null);
            Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

            var stringBuilder = new StringBuilder();

            stringBuilder.Append(messageText);
            stringBuilder.Append(":");

            foreach (var file in files)
            {
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(file);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Gets the files in project folder.
        /// </summary>
        /// <param name="projectFolder">
        /// The project folder.
        /// </param>
        /// <param name="masks">
        /// The masks to include.
        /// </param>
        /// <returns>
        /// List of files in the folder.
        /// </returns>
        [NotNull]
        private static List<string> GetFilesInProjectFolder([NotNull] string projectFolder, [NotNull] string[] masks)
        {
            Contract.Requires(!string.IsNullOrEmpty(projectFolder));
            Contract.Requires(masks != null);
            Contract.Ensures(Contract.Result<List<string>>() != null);

            var currentFolder = new DirectoryInfo(projectFolder);
            if (FolderHelpers.IsExcludedFolder(currentFolder.Name))
            {
                return new List<string>();
            }

            var folderFiles =
                (from filespec in masks
                 from file in currentFolder.GetFiles(filespec)
                 select file.FullName.ToLowerInvariant()).ToList();

            folderFiles.AddRange(
                currentFolder.GetDirectories().SelectMany(
                    directory => GetFilesInProjectFolder(directory.FullName, masks)));

            return folderFiles;
        }

        /// <summary>
        /// Determines whether to ignore the file.
        /// </summary>
        /// <param name="fileName">
        /// Name of the file.
        /// </param>
        /// <returns>
        /// <c>True</c> to ignore]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsIgnoreExtraFile([NotNull] string fileName)
        {
            // Not ours
            Contract.Requires(!string.IsNullOrEmpty(fileName));

            return fileName.Contains("\\debug\\") || fileName.Contains("\\release\\");
        }

        /// <summary>
        /// Processes the C# project.
        /// </summary>
        /// <param name="projectFolder">
        /// The project folder.
        /// </param>
        /// <param name="projectFileName">
        /// Name of the project file.
        /// </param>
        /// <param name="errorFiles">
        /// The error files.
        /// </param>
        /// <param name="chk">
        /// The check to perform.
        /// </param>
        /// <returns>
        /// True if there were no errors.
        /// </returns>
        private static bool ProcessCSharpProject(
            [NotNull] string projectFolder,
            [NotNull] string projectFileName,
            [NotNull] List<string> errorFiles,
            [NotNull] Func<List<string>, List<string>, List<string>, bool> chk)
        {
            Contract.Requires(!string.IsNullOrEmpty(projectFolder));
            Contract.Requires(!string.IsNullOrEmpty(projectFileName));
            Contract.Requires(errorFiles != null);
            Contract.Requires(chk != null);

            Console.WriteLine("Project {0}", projectFileName);

            var projectFiles = new List<string>();

            // open file, extract all the .cs's from it
            var reader = new XmlTextReader(projectFileName);
            while (reader.Read())
            {
                if (XmlNodeType.Element == reader.NodeType)
                {
                    if (reader.Name == "Compile")
                    {
                        var relativeFileName = reader.GetAttribute("Include");
                        var fullPath = projectFolder + "\\" + relativeFileName;

                        var file = new FileInfo(fullPath);

                        projectFiles.Add(file.FullName.ToLowerInvariant());
                    }
                }
            }

            // work out what is in the folder
            string[] masks = { "*.cs" };
            var folderFiles = GetFilesInProjectFolder(projectFolder, masks);

            var errors = chk(projectFiles, folderFiles, errorFiles);
            Console.WriteLine();

            return !errors;
        }

        /// <summary>
        /// Processes the folder.
        /// </summary>
        /// <param name="processCs">
        /// If set to <c>true</c> process C# files.
        /// </param>
        /// <param name="startingFolder">
        /// The starting folder.
        /// </param>
        /// <param name="errorFiles">
        /// The error files.
        /// </param>
        /// <param name="chk">
        /// The check to perform.
        /// </param>
        /// <returns>
        /// True if there were no errors.
        /// </returns>
        private static bool ProcessFolder(
            bool processCs,
            [NotNull] string startingFolder,
            [NotNull] List<string> errorFiles,
            [NotNull] Func<List<string>, List<string>, List<string>, bool> chk)
        {
            Contract.Requires(!string.IsNullOrEmpty(startingFolder));
            Contract.Requires(errorFiles != null);
            Contract.Requires(chk != null);

            var ok = true;

            var currentFolder = new DirectoryInfo(startingFolder);
            if (FolderHelpers.IsExcludedFolder(currentFolder.Name))
            {
                return true;
            }

            if (processCs)
            {
                ok = currentFolder.GetFiles("*.csproj").Aggregate(
                    ok,
                    (current, file) => current & ProcessCSharpProject(startingFolder, file.FullName, errorFiles, chk));
            }

            return currentFolder.GetDirectories("*.*").Aggregate(
                ok, (current, folder) => current & ProcessFolder(processCs, folder.FullName, errorFiles, chk));
        }

        #endregion
    }
}