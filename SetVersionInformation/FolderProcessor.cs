// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderProcessor.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   The folder processor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.Contracts;
using System.IO;

using JetBrains.Annotations;

#endregion

namespace SetVersionInformation
{
    /// <summary>
    /// The folder processor.
    /// </summary>
    internal static class FolderProcessor
    {
        #region Public Methods

        /// <summary>
        /// The process files in folder.
        /// </summary>
        /// <param name="folder">
        /// The folder to process.
        /// </param>
        /// <param name="filesProcessor">
        /// The files processor.
        /// </param>
        public static void ProcessFilesInFolder([NotNull] string folder, [NotNull] Action<DirectoryInfo> filesProcessor)
        {
            Contract.Requires(!string.IsNullOrEmpty(folder));
            Contract.Requires(filesProcessor != null);

            var directoryInfo = new DirectoryInfo(folder);
            if (!directoryInfo.Exists)
            {
                return;
            }

            Console.WriteLine("Processing files in {0}", folder);
            var directories = directoryInfo.GetDirectories();
            foreach (var directory in directories)
            {
                if (IsExcludedFolder(directory.Name))
                {
                    continue;
                }

                ProcessFilesInFolder(directory.FullName, filesProcessor);
            }

            filesProcessor(directoryInfo);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether the folder should be excluded.
        /// </summary>
        /// <param name="name">
        /// The folder name.
        /// </param>
        /// <returns>
        /// <c>true</c> if it should be excluded; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsExcludedFolder([NotNull] string name)
        {
            Contract.Requires(!string.IsNullOrEmpty(name));

            return StringComparer.InvariantCultureIgnoreCase.Equals(name, ".svn")
                   || StringComparer.InvariantCultureIgnoreCase.Equals(name, ".git");
        }

        #endregion
    }
}