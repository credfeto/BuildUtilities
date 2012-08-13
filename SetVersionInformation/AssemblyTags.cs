// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyTags.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   The assembly tags.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Globalization;

using JetBrains.Annotations;

#endregion

namespace SetVersionInformation
{
    /// <summary>
    /// The assembly tags.
    /// </summary>
    public static class AssemblyTags
    {
        #region Public Methods

        /// <summary>
        /// Produces the AssemblyCompany attribute.
        /// </summary>
        /// <param name="formatTraits">
        /// The format traits.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <returns>
        /// The AssemblyCompany attribute.
        /// </returns>
        [NotNull]
        [SuppressMessage("Microsoft.Performance", "CA1801:ReviewUnusedParameters", Justification = "Parameters are part of the API used by reflection.")]
        public static string AssemblyCompany(
            [NotNull] IAssemblyInfoFormatTraits formatTraits, [NotNull] VersionProperties version)
        {
            Contract.Requires(formatTraits != null);
            Contract.Requires(version != null);

            return string.Format(CultureInfo.InvariantCulture, "(\"{0}\")", version.CompanyName);
        }

        /// <summary>
        /// Produces the AssemblyCopyright attribute.
        /// </summary>
        /// <param name="formatTraits">
        /// The format traits.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <returns>
        /// The AssemblyCopyright attribute.
        /// </returns>
        [NotNull]
        [SuppressMessage("Microsoft.Performance", "CA1801:ReviewUnusedParameters", Justification = "Parameters are part of the API used by reflection.")]
        public static string AssemblyCopyright(
            [NotNull] IAssemblyInfoFormatTraits formatTraits, [NotNull] VersionProperties version)
        {
            Contract.Requires(formatTraits != null);
            Contract.Requires(version != null);

            return string.Format(
                CultureInfo.InvariantCulture,
                "(\"Copyright © {0} {1}-{2}\")",
                version.CompanyName,
                version.CopyrightStartYear,
                DateTime.Now.Year);
        }

        /// <summary>
        /// Produces the AssemblyCulture attribute.
        /// </summary>
        /// <param name="formatTraits">
        /// The format traits.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <returns>
        /// The AssemblyCulture culture.
        /// </returns>
        [NotNull]
        [SuppressMessage("Microsoft.Performance", "CA1801:ReviewUnusedParameters", Justification = "Parameters are part of the API used by reflection.")]
        public static string AssemblyCulture(
            [NotNull] IAssemblyInfoFormatTraits formatTraits, [NotNull] VersionProperties version)
        {
            Contract.Requires(formatTraits != null);
            Contract.Requires(version != null);

            return string.Format(CultureInfo.InvariantCulture, "(\"{0}\")", string.Empty);
        }

        /// <summary>
        /// Produces the AssemblyFileVersion attribute.
        /// </summary>
        /// <param name="formatTraits">
        /// The format traits.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <returns>
        /// The AssemblyFileVersion attribute.
        /// </returns>
        [NotNull]
        [SuppressMessage("Microsoft.Performance", "CA1801:ReviewUnusedParameters", Justification = "Parameters are part of the API used by reflection.")]
        public static string AssemblyFileVersion(
            [NotNull] IAssemblyInfoFormatTraits formatTraits, [NotNull] VersionProperties version)
        {
            Contract.Requires(formatTraits != null);
            Contract.Requires(version != null);

            return AttributeFormattingHelpers.FormatFullVersionNumber(version);
        }

        /// <summary>
        /// Produces the AssemblyInformationalVersion attribute.
        /// </summary>
        /// <param name="formatTraits">
        /// The format traits.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <returns>
        /// The AssemblyInformationalVersion attribute.
        /// </returns>
        [NotNull]
        [SuppressMessage("Microsoft.Performance", "CA1801:ReviewUnusedParameters", Justification = "Parameters are part of the API used by reflection.")]
        public static string AssemblyInformationalVersion(
            [NotNull] IAssemblyInfoFormatTraits formatTraits, [NotNull] VersionProperties version)
        {
            Contract.Requires(formatTraits != null);
            Contract.Requires(version != null);

            return AttributeFormattingHelpers.FormatFullVersionNumber(version);
        }

        /// <summary>
        /// Produces the AssemblyProduct attribute.
        /// </summary>
        /// <param name="formatTraits">
        /// The format traits.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <returns>
        /// The AssemblyProduct attribute.
        /// </returns>
        [NotNull]
        [SuppressMessage("Microsoft.Performance", "CA1801:ReviewUnusedParameters", Justification = "Parameters are part of the API used by reflection.")]
        public static string AssemblyProduct(
            [NotNull] IAssemblyInfoFormatTraits formatTraits, [NotNull] VersionProperties version)
        {
            Contract.Requires(formatTraits != null);
            Contract.Requires(version != null);

            return string.Format(CultureInfo.InvariantCulture, "(\"{0}\")", version.ProductName);
        }

        /// <summary>
        /// Produces the AssemblyTrademark attribute.
        /// </summary>
        /// <param name="formatTraits">
        /// The format traits.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <returns>
        /// The AssemblyTrademark attribute.
        /// </returns>
        [NotNull]
        [SuppressMessage("Microsoft.Performance", "CA1801:ReviewUnusedParameters", Justification = "Parameters are part of the API used by reflection.")]
        public static string AssemblyTrademark(
            [NotNull] IAssemblyInfoFormatTraits formatTraits, [NotNull] VersionProperties version)
        {
            Contract.Requires(formatTraits != null);
            Contract.Requires(version != null);

            return string.Format(CultureInfo.InvariantCulture, "(\"{0}\")", version.Trademark);
        }

        /// <summary>
        /// Produces the AssemblyVersion attribute.
        /// </summary>
        /// <param name="formatTraits">
        /// The format traits.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <returns>
        /// The AssemblyVersion attribute.
        /// </returns>
        [NotNull]
        [SuppressMessage("Microsoft.Performance", "CA1801:ReviewUnusedParameters", Justification = "Parameters are part of the API used by reflection.")]
        public static string AssemblyVersion(
            [NotNull] IAssemblyInfoFormatTraits formatTraits, [NotNull] VersionProperties version)
        {
            Contract.Requires(formatTraits != null);
            Contract.Requires(version != null);

            return string.Format(
                CultureInfo.InvariantCulture, "(\"{0}.{1}.{2}.{3}\")", version.Major, version.Minor, 0, 0);
        }

        /// <summary>
        /// Produces the CLSCompliant attribute.
        /// </summary>
        /// <param name="formatTraits">
        /// The format traits.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <returns>
        /// The CLSCompliant attribute.
        /// </returns>
        [NotNull]
        [SuppressMessage("StyleCopPlus.StyleCopPlusRules", "SP0100:AdvancedNamingRules", Justification = "Is the name of the .NET attribute.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Is the name of the .NET attribute.")]
        [SuppressMessage("Microsoft.Performance", "CA1801:ReviewUnusedParameters", Justification = "Parameters are part of the API used by reflection.")]
        public static string CLSCompliant(
            [NotNull] IAssemblyInfoFormatTraits formatTraits, [NotNull] VersionProperties version)
        {
            Contract.Requires(formatTraits != null);
            Contract.Requires(version != null);

            return string.Format(CultureInfo.InvariantCulture, "({0})", formatTraits.TrueKeyword);
        }

        /// <summary>
        /// Produces the ComVisible attribute.
        /// </summary>
        /// <param name="formatTraits">
        /// The format traits.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <returns>
        /// The ComVisible attribute.
        /// </returns>
        [NotNull]
        [SuppressMessage("Microsoft.Performance", "CA1801:ReviewUnusedParameters", Justification = "Parameters are part of the API used by reflection.")]
        public static string ComVisible(
            [NotNull] IAssemblyInfoFormatTraits formatTraits, [NotNull] VersionProperties version)
        {
            Contract.Requires(formatTraits != null);
            Contract.Requires(version != null);

            return string.Format(CultureInfo.InvariantCulture, "({0})", formatTraits.FalseKeyword);
        }

        /// <summary>
        /// Produces the NeutralResourcesLanguage attribute.
        /// </summary>
        /// <param name="formatTraits">
        /// The format traits.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <returns>
        /// The NeutralResourcesLanguage attribute.
        /// </returns>
        [NotNull]
        [SuppressMessage("Microsoft.Performance", "CA1801:ReviewUnusedParameters", Justification = "Parameters are part of the API used by reflection.")]
        public static string NeutralResourcesLanguage(
            [NotNull] IAssemblyInfoFormatTraits formatTraits, [NotNull] VersionProperties version)
        {
            Contract.Requires(formatTraits != null);
            Contract.Requires(version != null);

            return string.Format(
                CultureInfo.InvariantCulture, "(\"{0}\", UltimateResourceFallbackLocation.MainAssembly)", "en");
        }

        #endregion
        }
}