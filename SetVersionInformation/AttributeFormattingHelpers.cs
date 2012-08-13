// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttributeFormattingHelpers.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   The attribute formatting helpers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System.Diagnostics.Contracts;
using System.Globalization;

using JetBrains.Annotations;

#endregion

namespace SetVersionInformation
{
    /// <summary>
    /// The attribute formatting helpers.
    /// </summary>
    internal static class AttributeFormattingHelpers
    {
        #region Public Methods

        /// <summary>
        /// Formats the full version number.
        /// </summary>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <returns>
        /// The full version number.
        /// </returns>
        [NotNull]
        public static string FormatFullVersionNumber([NotNull] VersionProperties version)
        {
            Contract.Requires(version != null);

            return string.Format(
                CultureInfo.InvariantCulture,
                "(\"{0}.{1}.{2}.{3}\")",
                version.Major,
                version.Minor,
                version.SubversionRevision,
                version.CurrentBuildNumber);
        }

        #endregion
    }
}