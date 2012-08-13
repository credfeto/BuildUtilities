// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderHelpers.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Folder helper methods and properties.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;

using JetBrains.Annotations;

#endregion

namespace BuildEnvironmentTests
{
    /// <summary>
    /// Folder helper methods and properties.
    /// </summary>
    internal static class FolderHelpers
    {
        #region Constants and Fields

        /// <summary>
        /// The name of the file containing the Solus Solution.
        /// </summary>
        private const string SolutionFilename = "Settings.FxCop";

        #endregion

        #region Properties

        /// <summary>
        /// Gets all the C# projects.
        /// </summary>
        /// <value>
        /// All the C# projects.
        /// </value>
        [NotNull]
        public static IEnumerable<string> AllCSharpProjects
        {
            get
            {
                Contract.Ensures(Contract.Result<IEnumerable<string>>() != null);

                return Directory.GetFiles(RootPath, @"*.csproj", SearchOption.AllDirectories);
            }
        }

        /// <summary>
        /// Gets all the code projects.
        /// </summary>
        /// <value>
        /// All the code projects.
        /// </value>
        [NotNull]
        public static IEnumerable<string> AllCodeProjects
        {
            get
            {
                Contract.Ensures(Contract.Result<IEnumerable<string>>() != null);

                var projects = new List<string>(AllCSharpProjects);
                projects.AddRange(AllVisualBasicProjects);

                return projects;
            }
        }

        /// <summary>
        /// Gets all the Visual Basic projects.
        /// </summary>
        /// <value>
        /// All the Visual Basic projects.
        /// </value>
        [NotNull]
        public static IEnumerable<string> AllVisualBasicProjects
        {
            get
            {
                Contract.Ensures(Contract.Result<IEnumerable<string>>() != null);

                return Directory.GetFiles(RootPath, @"*.vbproj", SearchOption.AllDirectories);
            }
        }

        /// <summary>
        /// Gets the root path.
        /// </summary>
        /// <value>
        /// The root path.
        /// </value>
        /// <exception cref="NotSupportedException">
        /// Parent folder could not be found.
        /// </exception>
        [NotNull]
        public static string RootPath
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

                var filename = Assembly.GetExecutingAssembly().CodeBaseUrlAsFileName();

                var objAssemblyFileInformation = new FileInfo(filename);

                var dir = objAssemblyFileInformation.Directory;
                if (dir == null)
                {
                    throw new NotSupportedException("Parent folder could not be found");
                }

                // Walk up the tree until the Solus.sln project can be found
                while (dir != null && !IsRootFolder(dir))
                {
                    dir = dir.Parent;
                }

                if (dir == null)
                {
                    throw new NotSupportedException("Parent folder could not be found");
                }

                Console.WriteLine(@"Using Base Directory: {0}", dir.FullName);

                return dir.FullName;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Determines whether the folder should be excluded.
        /// </summary>
        /// <param name="name">
        /// The folder name.
        /// </param>
        /// <returns>
        /// <c>true</c> if it should be excluded; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsExcludedFolder([NotNull] string name)
        {
            Contract.Requires(!string.IsNullOrEmpty(name));

            return StringComparer.InvariantCultureIgnoreCase.Equals(name, ".svn")
                   || StringComparer.InvariantCultureIgnoreCase.Equals(name, ".git")
                   || StringComparer.InvariantCultureIgnoreCase.Equals(name, "Precompiled");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Codes the name of the base URL as file.
        /// </summary>
        /// <param name="assembly">
        /// The assembly.
        /// </param>
        /// <returns>
        /// Filename of the assembly.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="assembly"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// This is deliberately a copy as BuildEnviornment tests should not build any other assemblies than itself.
        /// </remarks>
        [NotNull]
        [SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings",
            Justification = "All methods that use this method require a string.")]
        private static string CodeBaseUrlAsFileName([NotNull] this Assembly assembly)
        {
            Contract.Requires(assembly != null);

            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }

            const string filePrefix = "file:///";
            var fileName = assembly.CodeBase;

            if (fileName.StartsWith(filePrefix, StringComparison.OrdinalIgnoreCase))
            {
                fileName = fileName.Remove(0, filePrefix.Length).Replace('/', '\\');
            }

            return fileName;
        }

        /// <summary>
        /// Checks to see if the named folder is the Build Root folder.
        /// </summary>
        /// <param name="directory">
        /// The directory.
        /// </param>
        /// <returns>
        /// The root folder.
        /// </returns>
        private static bool IsRootFolder([NotNull] DirectoryInfo directory)
        {
            Contract.Requires(directory != null);

            return directory.GetFiles(SolutionFilename).Any();
        }

        #endregion
    }
}