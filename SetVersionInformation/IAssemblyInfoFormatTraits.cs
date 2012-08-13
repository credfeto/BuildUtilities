// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAssemblyInfoFormatTraits.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Traits for formatting version information attributes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System.Diagnostics.Contracts;

using JetBrains.Annotations;

using SetVersionInformation.ContractDefinition;

#endregion

namespace SetVersionInformation
{
    /// <summary>
    /// Traits for formatting version information attributes.
    /// </summary>
    [ContractClass(typeof(FormatTraitsContract))]
    public interface IAssemblyInfoFormatTraits
    {
        #region Properties

        /// <summary>
        /// Gets the assembly keyword.
        /// </summary>
        /// <value>
        /// The assembly keyword.
        /// </value>
        [NotNull]
        string AssemblyKeyword
        {
            get;
        }

        /// <summary>
        /// Gets the close attribute text.
        /// </summary>
        /// <value>
        /// The close attribute text.
        /// </value>
        [NotNull]
        string CloseAttributeText
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether empty constructors should have parentheses.
        /// </summary>
        /// <value>
        /// <c>true</c> if empty constructors should have parentheses; otherwise, <c>false</c>.
        /// </value>
        bool EmptyConstructorShouldHaveParentheses
        {
            get;
        }

        /// <summary>
        /// Gets the <see langword="false"/> keyword.
        /// </summary>
        /// <value>
        /// The <see langword="false"/> keyword.
        /// </value>
        [NotNull]
        string FalseKeyword
        {
            get;
        }

        /// <summary>
        /// Gets the file specification to determine which files to process.
        /// </summary>
        /// <value>
        /// The file specification.
        /// </value>
        [NotNull]
        string FileSpecification
        {
            get;
        }

        /// <summary>
        /// Gets the open attribute text.
        /// </summary>
        /// <value>
        /// The open attribute text.
        /// </value>
        [NotNull]
        string OpenAttributeText
        {
            get;
        }

        /// <summary>
        /// Gets the <see langword="true"/> keyword.
        /// </summary>
        /// <value>
        /// The <see langword="true"/> keyword.
        /// </value>
        [NotNull]
        string TrueKeyword
        {
            get;
        }

        #endregion
    }
}