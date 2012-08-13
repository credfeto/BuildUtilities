// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CSharpFormatTraits.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   C# file format traits.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;

using JetBrains.Annotations;

#endregion

namespace SetVersionInformation.FileFormat
{
    /// <summary>
    /// C# file format traits.
    /// </summary>
    internal sealed class CSharpFormatTraits : IAssemblyInfoFormatTraits
    {
        #region Properties

        /// <summary>
        /// Gets the assembly keyword.
        /// </summary>
        /// <value>
        /// The assembly keyword.
        /// </value>
        [NotNull]
        public string AssemblyKeyword
        {
            get
            {
                return "assembly";
            }
        }

        /// <summary>
        /// Gets the close attribute text.
        /// </summary>
        /// <value>
        /// The close attribute text.
        /// </value>
        [NotNull]
        public string CloseAttributeText
        {
            get
            {
                return "]";
            }
        }

        /// <summary>
        /// Gets a value indicating whether empty constructors should have parentheses.
        /// </summary>
        /// <value>
        /// <c>true</c> if empty constructors should have parentheses; otherwise, <c>false</c>.
        /// </value>
        public bool EmptyConstructorShouldHaveParentheses
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the false keyword.
        /// </summary>
        /// <value>
        /// The false keyword.
        /// </value>
        [NotNull]
        public string FalseKeyword
        {
            get
            {
                return "false";
            }
        }

        /// <summary>
        /// Gets the file specification to determine which files to process.
        /// </summary>
        /// <value>
        /// The file specification.
        /// </value>
        public string FileSpecification
        {
            get
            {
                return "AssemblyInfo.cs";
            }
        }

        /// <summary>
        /// Gets the open attribute text.
        /// </summary>
        /// <value>
        /// The open attribute text.
        /// </value>
        [NotNull]
        public string OpenAttributeText
        {
            get
            {
                return "[";
            }
        }

        /// <summary>
        /// Gets the true keyword.
        /// </summary>
        /// <value>
        /// The true keyword.
        /// </value>
        [NotNull]
        public string TrueKeyword
        {
            get
            {
                return "true";
            }
        }

        #endregion
    }
}