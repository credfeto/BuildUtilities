// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CruiseControlVersionExtraction.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   The cruise control version extraction.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.Contracts;
using System.Globalization;

using JetBrains.Annotations;

#endregion

namespace SetVersionInformation.ContinuousIntegrationSettings
{
    /// <summary>
    /// The cruise control version extraction.
    /// </summary>
    internal static class CruiseControlVersionExtraction
    {
        #region Public Methods

        /// <summary>
        /// Loads from cruise control environment variables.
        /// </summary>
        /// <param name="version">
        /// The version.
        /// </param>
        public static void Load([NotNull] VersionProperties version)
        {
            Contract.Requires(version != null);

            var currentBuildLabel = Environment.GetEnvironmentVariable("CCNetLabel");

            ExtractMajorVersion(currentBuildLabel, version);

            ExtractMinorVersion(currentBuildLabel, version);

            ExtractBuildNumber(version);

            ExtractBuildDate(version);

            ExtractBuildTime(version);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Extracts the build date.
        /// </summary>
        /// <param name="version">
        /// The version.
        /// </param>
        private static void ExtractBuildDate([NotNull] VersionProperties version)
        {
            Contract.Requires(version != null);

            version.CurrentBuildDate = Environment.GetEnvironmentVariable("CCNetBuildDate") ?? string.Empty;
        }

        /// <summary>
        /// Extracts the build number.
        /// </summary>
        /// <param name="version">
        /// The version.
        /// </param>
        private static void ExtractBuildNumber([NotNull] VersionProperties version)
        {
            Contract.Requires(version != null);

            version.CurrentBuildNumber = Convert.ToInt32(
                Environment.GetEnvironmentVariable("CCNetNumericLabel"), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Extracts the build time.
        /// </summary>
        /// <param name="version">
        /// The version.
        /// </param>
        private static void ExtractBuildTime([NotNull] VersionProperties version)
        {
            Contract.Requires(version != null);

            version.CurrentBuildTime = Environment.GetEnvironmentVariable("CCNetBuildTime") ?? string.Empty;
        }

        /// <summary>
        /// Extracts the major version.
        /// </summary>
        /// <param name="currentBuildLabel">
        /// The current build label.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        private static void ExtractMajorVersion([CanBeNull] string currentBuildLabel, [NotNull] VersionProperties version)
        {
            Contract.Requires(version != null);

            if (!string.IsNullOrEmpty(currentBuildLabel))
            {
                var num = currentBuildLabel.IndexOf('-');
                if (num != -1)
                {
                    var length = currentBuildLabel.Substring(checked(num + 1)).IndexOf('-');
                    if (length != -1)
                    {
                        version.Major = int.Parse(
                            currentBuildLabel.Substring(checked(num + 1), length), CultureInfo.CurrentCulture);
                    }
                }
            }

            version.Major = 1;
        }

        /// <summary>
        /// Extracts the minor version.
        /// </summary>
        /// <param name="currentBuildLabel">
        /// The current build label.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        private static void ExtractMinorVersion([CanBeNull] string currentBuildLabel, [NotNull] VersionProperties version)
        {
            Contract.Requires(version != null);

            if (!string.IsNullOrEmpty(currentBuildLabel))
            {
                var num1 = currentBuildLabel.IndexOf('-');
                if (num1 != -1)
                {
                    var num2 = currentBuildLabel.Substring(checked(num1 + 1)).IndexOf('-');
                    if (num2 != -1)
                    {
                        var num3 = checked(num1 + num2 + 1);
                        var length = currentBuildLabel.Substring(checked(num3 + 1)).IndexOf('-');
                        if (length == -1)
                        {
                            length = currentBuildLabel.Substring(checked(num3 + 1)).IndexOf('.');
                        }

                        if (length != -1)
                        {
                            version.Minor = int.Parse(
                                currentBuildLabel.Substring(checked(num3 + 1), length), CultureInfo.CurrentCulture);
                        }
                    }
                }
            }

            version.Minor = 0;
        }

        #endregion
    }
}