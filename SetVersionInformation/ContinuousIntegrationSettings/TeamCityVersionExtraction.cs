// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TeamCityVersionExtraction.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Team City Version Extraction.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.Contracts;

using JetBrains.Annotations;

#endregion

namespace SetVersionInformation.ContinuousIntegrationSettings
{
    /// <summary>
    /// Team City Version Extraction.
    /// </summary>
    internal static class TeamCityVersionExtraction
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

            ExtractBuildNumber(version);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Extracts the build number.
        /// </summary>
        /// <param name="version">
        /// The version.
        /// </param>
        private static void ExtractBuildNumber([NotNull] VersionProperties version)
        {
            Contract.Requires(version != null);

            var environment = Environment.GetEnvironmentVariable("CCNetNumericLabel") ?? string.Empty;

            int buildNumber;
            if (!int.TryParse(environment, out buildNumber))
            {
                buildNumber = 1;
            }

            version.CurrentBuildNumber = buildNumber;
        }

        #endregion
    }
}