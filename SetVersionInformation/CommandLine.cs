// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandLine.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   The command line parser.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.Contracts;
using System.Linq;

using JetBrains.Annotations;

#endregion

namespace SetVersionInformation
{
    /// <summary>
    /// The command line parser.
    /// </summary>
    internal static class CommandLine
    {
        #region Public Methods

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="commandLineArguments">
        /// The command line arguments.
        /// </param>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <returns>
        /// The get value.
        /// </returns>
        [NotNull]
        public static string GetValue([NotNull] string[] commandLineArguments, [NotNull] string parameterName)
        {
            Contract.Requires(commandLineArguments != null);
            Contract.Requires(!string.IsNullOrEmpty(parameterName));

            var fullParameterName = "-" + parameterName + ":";

            foreach (var argument in commandLineArguments)
            {
                if (argument.StartsWith(fullParameterName, StringComparison.OrdinalIgnoreCase))
                {
                    return argument.Substring(fullParameterName.Length);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Checks to see if the specific parameter is defined.
        /// </summary>
        /// <param name="commandLineArguments">
        /// The command line arguments.
        /// </param>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <returns>
        /// The has parameter.
        /// </returns>
        public static bool HasParameter([NotNull] string[] commandLineArguments, [NotNull] string parameterName)
        {
            Contract.Requires(commandLineArguments != null);
            Contract.Requires(!string.IsNullOrEmpty(parameterName));

            var fullParameterName = "-" + parameterName;
            var fullParameterNameWithValue = fullParameterName + ":";

            return
                commandLineArguments.Any(
                    argument => ParameterDefined(argument, fullParameterName, fullParameterNameWithValue));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether the parameter is defined.
        /// </summary>
        /// <param name="argument">
        /// The argument.
        /// </param>
        /// <param name="fullParameterName">
        /// The full parameter name.
        /// </param>
        /// <param name="fullParameterNameWithValue">
        /// The full parameter name with value.
        /// </param>
        /// <returns>
        /// The parameter defined.
        /// </returns>
        private static bool ParameterDefined(
            [NotNull] string argument, [NotNull] string fullParameterName, [NotNull] string fullParameterNameWithValue)
        {
            Contract.Requires(!string.IsNullOrEmpty(argument));
            Contract.Requires(!string.IsNullOrEmpty(fullParameterName));
            Contract.Requires(!string.IsNullOrEmpty(fullParameterNameWithValue));

            return StringComparer.InvariantCultureIgnoreCase.Equals(argument, fullParameterName)
                   || argument.StartsWith(fullParameterNameWithValue, StringComparison.OrdinalIgnoreCase);
        }

        #endregion
    }
}