// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StylecopSettings.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   StyleCop related unit tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;

using JetBrains.Annotations;

using NUnit.Framework;

#endregion

namespace BuildEnvironmentTests
{
    /// <summary>
    /// StyleCop related unit tests.
    /// </summary>
    [TestFixture]
    [Ignore("Needs work to get this to work properly in VC2012")]
    public sealed class StyleCopSettings
    {
        #region Constants and Fields

        /// <summary>
        /// The MSBuild reference for StyleCop.
        /// </summary>
        private const string StyleCopGlobalReference =
            @"$(ProgramFiles)\MSBuild\StyleCop\Microsoft.StyleCop.targets";

        /// <summary>
        /// The Solution Relative MSBuild reference for Stylecop.
        /// </summary>
        private const string StyleCopSolutionRelativeReference =
            @"$(SolutionDir)\MSBuild\StyleCop\Microsoft.StyleCop.targets";

        #endregion

        #region Public Methods

        /// <summary>
        /// Checks that StyleCop 'TreatErrorsAsWarnings' is set appropriately on all projects.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void StyleCopErrorsAreWarningsSetAppropriatelyOnAllProjects()
        {
            ProjectHelpers.HasPropertyGroupSetting("StyleCopTreatErrorsAsWarnings", false, true);
        }

        /// <summary>
        /// Checks that StyleCop is enabled on all projects.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void StyleCopIsEnabledOnAllProjects()
        {
            var references = new[] { StyleCopGlobalReference, StyleCopSolutionRelativeReference };

            ProjectHelpers.HasProjectImportReferece(
                "Stylecop", references, IsProjectGrantedATemporaryStayOfExecutionFromHavingStyleCopApplied);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the exceptions.
        /// </summary>
        /// <returns>
        /// The list of exceptions.
        /// </returns>
        [NotNull]
        private static IEnumerable<string> GetExceptions()
        {
            Contract.Ensures(Contract.Result<IEnumerable<string>>() != null);

            // Should not be any exceptions. Apart from projects that have
            // been converted from VB to C# that have not yet managed to
            // build cleanly with stylecop, and these should only be here
            // for a short period of time.
            return new[] { "~~~~~~~~~" };
        }

        /// <summary>
        /// Determines whether the project is granted a temporary stay of execution from having StyleCop applied.
        /// </summary>
        /// <param name="filename">
        /// The filename.
        /// </param>
        /// <returns>
        /// <c>true</c> if it is; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsProjectGrantedATemporaryStayOfExecutionFromHavingStyleCopApplied(
            [NotNull] string filename)
        {
            Contract.Requires(!string.IsNullOrEmpty(filename));

            return
                GetExceptions().Any(exception => StringComparer.InvariantCultureIgnoreCase.Equals(exception, filename));
        }

        #endregion
    }
}