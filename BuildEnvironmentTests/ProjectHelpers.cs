// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectHelpers.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   The project helpers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;

using JetBrains.Annotations;

using NUnit.Framework;

#endregion

namespace BuildEnvironmentTests
{
    /// <summary>
    /// The project helpers.
    /// </summary>
    internal static class ProjectHelpers
    {
        #region Public Methods

        /// <summary>
        /// Determines whether the project has the specific import referece.
        /// </summary>
        /// <param name="name">
        /// The name of the reference.
        /// </param>
        /// <param name="references">
        /// The references.
        /// </param>
        /// <param name="exceptionChecker">
        /// The exception checker.
        /// </param>
        public static void HasProjectImportReferece(
            [NotNull] string name,
            [NotNull] IEnumerable<string> references,
            [NotNull] Func<string, bool> exceptionChecker)
        {
            Contract.Requires(!string.IsNullOrEmpty(name));
            Contract.Requires(references != null);
            Contract.Requires(exceptionChecker != null);

            var projectsWithoutStyleCopReference = 0;

            var projectFieNames = FolderHelpers.AllCSharpProjects;
            foreach (var project in projectFieNames)
            {
                var doc = new XmlDocument();
                doc.Load(project);

                var nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("x", doc.DocumentElement.NamespaceURI);

                if (HasProjectReference(doc, nsmgr, references))
                {
                    continue;
                }

                var filename = Path.GetFileNameWithoutExtension(project);
                if (!exceptionChecker(filename))
                {
                    Console.WriteLine(" -- Project {0} does not use {1}!", project, name);
                    ++projectsWithoutStyleCopReference;
                }
                else
                {
                    Console.WriteLine(" -- Project {0} does not use {1} yet!", project, name);
                }
            }

            Assert.AreEqual(
                0,
                projectsWithoutStyleCopReference,
                string.Format(CultureInfo.InvariantCulture, "Expected All C# projects to be using {0}", name));
        }

        /// <summary>
        /// Determines whether all projects have the specified property set.
        /// </summary>
        /// <param name="settingPropertyGroupElementName">
        /// Name of the property group element.
        /// </param>
        /// <param name="expectedValue">
        /// The expected value.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        public static void HasPropertyGroupSetting(
            [NotNull] string settingPropertyGroupElementName, bool expectedValue, bool defaultValue)
        {
            Contract.Requires(!string.IsNullOrEmpty(settingPropertyGroupElementName));

            const string propertyGroupXpathQuery = "//x:Project/x:PropertyGroup";
            var projectsWithIncorrectTreatWarningsAsErrorsElement = 0;

            var projectFieNames = FolderHelpers.AllCodeProjects;
            foreach (var project in projectFieNames)
            {
                var doc = new XmlDocument();
                doc.Load(project);

                var nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("x", doc.DocumentElement.NamespaceURI);

                var nodes = doc.SelectNodes(propertyGroupXpathQuery, nsmgr);
                if (nodes != null)
                {
                    // find the global settings property group
                    var elementGlobalSettings = FindGlobalSettingsPropertyGroup(nodes);

                    var defaultSetting = defaultValue;
                    if (elementGlobalSettings != null)
                    {
                        var testNode = elementGlobalSettings.SelectSingleNode(
                            "x:" + settingPropertyGroupElementName, nsmgr);
                        if (testNode != null)
                        {
                            defaultSetting = StringComparer.InvariantCultureIgnoreCase.Equals(
                                testNode.InnerText, expectedValue.ToString());
                        }
                    }

                    foreach (XmlElement element in nodes)
                    {
                        if ((elementGlobalSettings != null)
                            &&
                            (element.GetAttribute("Condition").Trim()
                             == elementGlobalSettings.GetAttribute("Condition").Trim()))
                        {
                            continue;
                        }

                        var setting = defaultSetting;
                        var testNode = element.SelectSingleNode("x:" + settingPropertyGroupElementName, nsmgr);
                        if (testNode != null)
                        {
                            setting = StringComparer.InvariantCultureIgnoreCase.Equals(
                                testNode.InnerText, expectedValue.ToString());
                        }

                        if (setting)
                        {
                            continue;
                        }

                        var condition = element.GetAttribute("Condition").Trim();

                        Console.WriteLine(
                            " -- Project {0}, Configuration '{1}' has {3} set to '{2}'!",
                            project,
                            condition,
                            setting,
                            settingPropertyGroupElementName);
                        ++projectsWithIncorrectTreatWarningsAsErrorsElement;
                    }
                }
                else
                {
                    Console.WriteLine(
                        " -- Project {0} does not have a {1} element", project, settingPropertyGroupElementName);
                    ++projectsWithIncorrectTreatWarningsAsErrorsElement;
                }
            }

            var message = string.Format(
                CultureInfo.InvariantCulture,
                "Expected All C# projects to be have {0} set to {1}",
                settingPropertyGroupElementName,
                expectedValue);
            Assert.AreEqual(0, projectsWithIncorrectTreatWarningsAsErrorsElement, message);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the global settings property group.
        /// </summary>
        /// <param name="nodes">
        /// The nodes.
        /// </param>
        /// <returns>
        /// The global settings property group, if found; otherwise <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="nodes"/> is <c>null</c>.
        /// </exception>
        [CanBeNull]
        private static XmlElement FindGlobalSettingsPropertyGroup([NotNull] XmlNodeList nodes)
        {
            Contract.Requires(nodes != null);

            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }

            return (from XmlElement searchElement in nodes
                    let condition = searchElement.GetAttribute("Condition").Trim()
                    where string.IsNullOrEmpty(condition)
                    select searchElement).FirstOrDefault();
        }

        /// <summary>
        /// Determines whether the project contains one of the specified references..
        /// </summary>
        /// <param name="doc">
        /// The XML document.
        /// </param>
        /// <param name="nsmgr">
        /// The XML name space manager.
        /// </param>
        /// <param name="references">
        /// The references.
        /// </param>
        /// <returns>
        /// <c>true</c> if it does; otherwise, <c>false</c>.
        /// </returns>
        private static bool HasProjectReference([NotNull] XmlDocument doc, [NotNull] XmlNamespaceManager nsmgr, [NotNull] IEnumerable<string> references)
        {
            Contract.Requires(doc != null);
            Contract.Requires(nsmgr != null);
            Contract.Requires(references != null);

            foreach (var reference in references)
            {
                var xpathQuery = string.Format(
                    CultureInfo.InvariantCulture, "//x:Project/x:Import[@Project=\"{0}\"]", reference);
                var nodes = doc.SelectSingleNode(xpathQuery, nsmgr);
                if (nodes != null)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}