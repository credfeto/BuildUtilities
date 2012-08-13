// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;

using JetBrains.Annotations;

using SetVersionInformation.ContinuousIntegrationSettings;

#endregion

namespace SetVersionInformation
{
    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        #region Methods

        /// <summary>
        /// Gets the root folder.
        /// </summary>
        /// <param name="commandLineArguments">
        /// The command line arguments.
        /// </param>
        /// <returns>
        /// The get root folder.
        /// </returns>
        [NotNull]
        private static string GetRootFolder([NotNull] string[] commandLineArguments)
        {
            Contract.Requires(commandLineArguments != null);

            Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

            var rootFolder = CommandLine.GetValue(commandLineArguments, "RootFolder");
            if (!string.IsNullOrEmpty(rootFolder))
            {
                return rootFolder;
            }

            rootFolder = Environment.GetEnvironmentVariable("CCNetWorkingDirectory");
            if (!string.IsNullOrEmpty(rootFolder))
            {
                return rootFolder;
            }

            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// Loads the default version properties.
        /// </summary>
        /// <returns>
        /// The default version properties.
        /// </returns>
        [NotNull]
        private static VersionProperties LoadDefaultVersionProperties()
        {
            Contract.Ensures(Contract.Result<VersionProperties>() != null);
            var now = DateTime.Now;

            return new VersionProperties
                {
                    Major = 1,
                    Minor = 0,
                    SubversionRevision = 0,
                    CurrentBuildNumber = 1,
                    CompanyName = "Twaddle Software",
                    CopyrightStartYear = 1997,
                    ProductName = "Build Utilities",
                    Trademark = string.Empty,
                    CurrentBuildDate = string.Format(CultureInfo.InvariantCulture, @"{0:dd-MM-yyyy}", now),
                    CurrentBuildTime = string.Format(CultureInfo.InvariantCulture, @"{0:hh:MM:ss}", now)
                };
        }

        /// <summary>
        /// Loads the version information.
        /// </summary>
        /// <param name="commandLineArguments">
        /// The command line arguments.
        /// </param>
        /// <returns>
        /// The version properties.
        /// </returns>
        [NotNull]
        private static VersionProperties LoadVersionInformation([NotNull] string[] commandLineArguments)
        {
            Contract.Requires(commandLineArguments != null);

            Contract.Ensures(Contract.Result<VersionProperties>() != null);

            var version = LoadDefaultVersionProperties();

            if (CommandLine.HasParameter(commandLineArguments, "UseCruiseControl"))
            {
                CruiseControlVersionExtraction.Load(version);
            }
            else if (CommandLine.HasParameter(commandLineArguments, "UseTeamCity"))
            {
                TeamCityVersionExtraction.Load(version);
            }

            if (CommandLine.HasParameter(commandLineArguments, "CompanyName"))
            {
                version.CompanyName = CommandLine.GetValue(commandLineArguments, "CompanyName");
            }

            if (CommandLine.HasParameter(commandLineArguments, "ProductName"))
            {
                version.ProductName = CommandLine.GetValue(commandLineArguments, "ProductName");
            }

            if (CommandLine.HasParameter(commandLineArguments, "Trademark"))
            {
                version.Trademark = CommandLine.GetValue(commandLineArguments, "Trademark");
            }

            if (CommandLine.HasParameter(commandLineArguments, "CopyrightStartYear"))
            {
                var startYearText = CommandLine.GetValue(commandLineArguments, "CopyrightStartYear");

                int startYear;
                if (int.TryParse(startYearText, out startYear))
                {
                    version.CopyrightStartYear = startYear;
                }
            }

            return version;
        }

        /// <summary>
        /// The main program entry point.
        /// </summary>
        /// <param name="args">
        /// The command line arguments.
        /// </param>
        /// <returns>
        /// 0 if successful; otherwise an error code.
        /// </returns>
        private static int Main([NotNull] string[] args)
        {
            Contract.Requires(args != null);

            try
            {
                var version = LoadVersionInformation(args);

                Console.WriteLine(
                    "Version Number: {0}.{1}.{2}.{3}",
                    version.Major,
                    version.Minor,
                    version.SubversionRevision,
                    version.CurrentBuildNumber);

                var rootFolder = GetRootFolder(args);

                var updater = new AssemblyInfoUpdater();

                FolderProcessor.ProcessFilesInFolder(
                    rootFolder, directory => updater.ProcessFolderContents(directory, version));

                return 0;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unexpected Exception : {0}", exception.Message);
                Console.WriteLine("Exception Type : {0}", exception.GetType().FullName);
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(exception.StackTrace);
                return 1;
            }
        }

        #endregion
    }
}