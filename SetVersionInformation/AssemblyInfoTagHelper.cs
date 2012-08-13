// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyInfoTagHelper.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Tag helper for determining the tags to write.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Reflection;

using JetBrains.Annotations;

#endregion

namespace SetVersionInformation
{
    /// <summary>
    /// Tag helper for determining the tags to write.
    /// </summary>
    internal static class AssemblyInfoTagHelper
    {
        #region Properties

        /// <summary>
        /// Gets the file formats.
        /// </summary>
        /// <value>
        /// The file formats.
        /// </value>
        [NotNull]
        public static List<IAssemblyInfoFormatTraits> FileFormats
        {
            get
            {
                Contract.Ensures(Contract.Result<List<IAssemblyInfoFormatTraits>>() != null);

                return FileFormatTypes.Select(Activator.CreateInstance).OfType<IAssemblyInfoFormatTraits>().ToList();
            }
        }

        /// <summary>
        /// Gets the tags that should be modified.
        /// </summary>
        /// <value>
        /// The tags to modify.
        /// </value>
        [NotNull]
        public static Dictionary<string, Func<IAssemblyInfoFormatTraits, VersionProperties, string>> TagsToModify
        {
            get
            {
                Contract.Ensures(
                    Contract.Result<Dictionary<string, Func<IAssemblyInfoFormatTraits, VersionProperties, string>>>()
                    != null);

                var methods = typeof(AssemblyTags).GetMethods(BindingFlags.Static | BindingFlags.Public);
                var dictionary = new Dictionary<string, Func<IAssemblyInfoFormatTraits, VersionProperties, string>>();
                foreach (var method in methods)
                {
                    Console.WriteLine("Found Tag : {0}", method.Name);

                    dictionary.Add(method.Name, CreateMethodInvoker(method));
                }

                return dictionary;
            }
        }

        /// <summary>
        /// Gets the file format types.
        /// </summary>
        /// <value>
        /// List of file format types.
        /// </value>
        [NotNull]
        private static IEnumerable<Type> FileFormatTypes
        {
            get
            {
                Contract.Ensures(Contract.Result<IEnumerable<Type>>() != null);

                var types = Assembly.GetExecutingAssembly().GetTypes();

                foreach (var type in types)
                {
                    if (type.IsAbstract)
                    {
                        continue;
                    }

                    var interfaces = type.GetInterfaces();
                    foreach (var item in interfaces)
                    {
                        if (item == typeof(IAssemblyInfoFormatTraits))
                        {
                            yield return type;
                        }
                    }
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The creates the delegate that will be invoked.
        /// </summary>
        /// <param name="method">
        /// The method to execute.
        /// </param>
        /// <returns>
        /// The delegate that will execute the method.
        /// </returns>
        [NotNull]
        private static Func<IAssemblyInfoFormatTraits, VersionProperties, string> CreateMethodInvoker(
            [NotNull] MethodInfo method)
        {
            Contract.Requires(method != null);

            return (formatTraits, version) => ProduceTag(method, formatTraits, version);
        }

        /// <summary>
        /// The produces the tags to put in the file.
        /// </summary>
        /// <param name="method">
        /// The method to invoke.
        /// </param>
        /// <param name="formatTraits">
        /// The format traits.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <returns>
        /// The tag that should be written into the file.
        /// </returns>
        [NotNull]
        private static string ProduceTag(
            [NotNull] MethodInfo method,
            [NotNull] IAssemblyInfoFormatTraits formatTraits,
            [NotNull] VersionProperties version)
        {
            Contract.Requires(method != null);
            Contract.Requires(formatTraits != null);
            Contract.Requires(version != null);

            var formattedValues = method.Invoke(null, new object[2] { formatTraits, version }) as string;

            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}{1}: {2}{3}{4}",
                formatTraits.OpenAttributeText,
                formatTraits.AssemblyKeyword,
                method.Name,
                formattedValues,
                formatTraits.CloseAttributeText);
        }

        #endregion
    }
}