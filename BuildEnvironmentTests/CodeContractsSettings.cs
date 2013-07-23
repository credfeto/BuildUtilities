// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeContractsSettings.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   The code contracts settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System.Diagnostics.CodeAnalysis;

using NUnit.Framework;

#endregion

namespace BuildEnvironmentTests
{
    /// <summary>
    /// The code contracts settings.
    /// </summary>
    [TestFixture]
    public sealed class CodeContractsSettings
    {
        #region Public Methods

        /// <summary>
        /// Checks if the 'CodeContractsArithmeticObligations' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsArithmeticObligations()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsArithmeticObligations", true, false);
        }

        /// <summary>
        /// Checks if the 'CodeContractsBoundsObligations' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsBoundsObligations()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsBoundsObligations", true, false);
        }

        /// <summary>
        /// Checks if the 'CodeContractsCacheAnalysisResults' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsCacheAnalysisResults()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsCacheAnalysisResults", true, false);
        }

        /// <summary>
        /// Checks if the 'CodeContractsEmitXMLDocs' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsEmitXmlDocs()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsEmitXMLDocs", true, false);
        }

        /// <summary>
        /// Checks if the 'CodeContractsEnableRuntimeChecking' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsEnableRuntimeChecking()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsEnableRuntimeChecking", true, false);
        }

        /// <summary>
        /// Checks if the 'CodeContractsEnumObligations' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsEnumObligations()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsEnumObligations", true, false);
        }

        /// <summary>
        /// Checks if the 'CodeContractsNonNullObligations' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsNonNullObligations()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsNonNullObligations", true, false);
        }

        /// <summary>
        /// Checks if the 'CodeContractsRedundantAssumptions' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsRedundantAssumptions()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsRedundantAssumptions", false, true);
        }

        /// <summary>
        /// Checks if the 'CodeContractsRunCodeAnalysis' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsRunCodeAnalysis()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsRunCodeAnalysis", true, false);
        }

        /// <summary>
        /// Checks if the 'CodeContractsRunInBackground' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsRunInBackground()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsRunInBackground", false, true);
        }

        /// <summary>
        /// Checks if the 'CodeContractsRuntimeCallSiteRequires' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsRuntimeCallSiteRequires()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsRuntimeCallSiteRequires", false, true);
        }

        /// <summary>
        /// Checks if the 'CodeContractsRuntimeOnlyPublicSurface' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsRuntimeOnlyPublicSurface()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsRuntimeOnlyPublicSurface", false, true);
        }

        /// <summary>
        /// Checks if the 'CodeContractsRuntimeSkipQuantifiers' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsRuntimeSkipQuantifiers()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsRuntimeSkipQuantifiers", false, true);
        }

        /// <summary>
        /// Checks if the 'CodeContractsRuntimeThrowOnFailure' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsRuntimeThrowOnFailure()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsRuntimeThrowOnFailure", true, false);
        }

        /// <summary>
        /// Checks if the 'CodeContractsShowSquigglies' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsUnderlineErrors()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsShowSquigglies", false, false);
        }

        /// <summary>
        /// Checks if the 'CodeContractsUseBaseLine' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsUseBaseline()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsUseBaseLine", false, true);
        }

        /// <summary>
        /// Checks if the 'CodeContractsSuggestAssumptions' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsSuggestAssumptions()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsSuggestAssumptions", false, true);
        }

        /// <summary>
        /// Checks if the 'CodeContractsSuggestRequires' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsSuggestRequires()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsSuggestRequires", true, false);
        }

        /// <summary>
        /// Checks if the 'CodeContractsSuggestEnsures' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        [Ignore("Setting not available in VS2012")]
        public void CodeContractsSuggestEnsures()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsSuggestEnsures", true, false);
        }

        /// <summary>
        /// Checks if the 'CodeContractsSuggestObjectInvariants' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsSuggestObjectInvariants()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsSuggestObjectInvariants", true, false);
        }

        /// <summary>
        /// Checks if the 'CodeContractsInferRequires' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsInferRequires()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsInferRequires", false, true);
        }

        /// <summary>
        /// Checks if the 'CodeContractsInferEnsures' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsInferEnsures()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsInferEnsures", false, true);
        }

        /// <summary>
        /// Checks if the 'CodeContractsInferObjectInvariants' setting is set correctly.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void CodeContractsInferObjectInvariants()
        {
            ProjectHelpers.HasPropertyGroupSetting("CodeContractsInferObjectInvariants", false, true);
        }

        #endregion
    }
}