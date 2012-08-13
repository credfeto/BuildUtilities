// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectSettings.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Project file setting tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml;

using JetBrains.Annotations;

using NUnit.Framework;

#endregion

namespace BuildEnvironmentTests
{
    /// <summary>
    /// Project file setting tests.
    /// </summary>
    [TestFixture]
    public sealed class ProjectSettings
    {
        #region Public Methods

        /// <summary>
        /// Checks that Project 'TreatErrorsAsWarnings' is set appropriately on all projects.
        /// </summary>
        [Test]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Unit Test Method.")]
        public void TreatWarningsAsErrorsSetAppropriatelyOnAllProjects()
        {
            const string settingPropertyGroupElementName = "TreatWarningsAsErrors";

            ProjectHelpers.HasPropertyGroupSetting(settingPropertyGroupElementName, true, false);
        }

        #endregion
    }
}