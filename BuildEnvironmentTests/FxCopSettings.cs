// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FxCopSettings.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   FxCop related unit tests.
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
    /// FxCop related unit tests.
    /// </summary>
    [TestFixture]
    [Ignore("Needs work to get this to work properly in VC2012")]
    public sealed class FxCopSettings
    {
        #region Constants and Fields

        /// <summary>
        /// The MSBuild reference for FxCop.
        /// </summary>
        private const string FxCopGlobalReference = @"$(ProgramFiles)\MSBuild\FxCop\Microsoft.FxCop.targets";

        /// <summary>
        /// The Solution Relative MSBuild reference for Stylecop.
        /// </summary>
        private const string FxCopSolutionRelativeReference = @"$(SolutionDir)\MSBuild\FxCop\Microsoft.FxCop.targets";

        #endregion

        #region Public Methods

        /// <summary>
        /// Checks that FxCop 'TreatErrorsAsWarnings' is set appropriately on all projects.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void FxCopErrorsAreWarningsSetAppropriatelyOnAllProjects()
        {
            ProjectHelpers.HasPropertyGroupSetting("FxCopTreatErrorsAsWarnings", false, true);
        }

        /// <summary>
        /// Checks that FxCop is enabled on all projects.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void FxCopIsEnabledOnAllProjects()
        {
            var references = new[] { FxCopGlobalReference, FxCopSolutionRelativeReference };

            ProjectHelpers.HasProjectImportReferece(
                "FxCop", references, IsProjectGrantedATemporaryStayOfExecutionFromHavingFxCopApplied);
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
        private static bool IsProjectGrantedATemporaryStayOfExecutionFromHavingFxCopApplied([NotNull] string filename)
        {
            Contract.Requires(!string.IsNullOrEmpty(filename));

            return
                GetExceptions().Any(exception => StringComparer.InvariantCultureIgnoreCase.Equals(exception, filename));
        }

        #endregion
    }
}