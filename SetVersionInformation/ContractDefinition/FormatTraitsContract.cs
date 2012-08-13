// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormatTraitsContract.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   The format traits contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.Contracts;

#endregion

namespace SetVersionInformation.ContractDefinition
{
    /// <summary>
    /// The format traits contract.
    /// </summary>
    [ContractClassFor(typeof(IAssemblyInfoFormatTraits))]
    internal abstract class FormatTraitsContract : IAssemblyInfoFormatTraits
    {
        #region Properties

        /// <summary>
        /// Gets the assembly keyword.
        /// </summary>
        /// <value>
        /// The assembly keyword.
        /// </value>
        public string AssemblyKeyword
        {
            get
            {
                Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));

                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the close attribute text.
        /// </summary>
        /// <value>
        /// The close attribute text.
        /// </value>
        public string CloseAttributeText
        {
            get
            {
                Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));

                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the false keyword.
        /// </summary>
        /// <value>
        /// The false keyword.
        /// </value>
        public string FalseKeyword
        {
            get
            {
                Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));

                throw new NotImplementedException();
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
                Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));

                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the open attribute text.
        /// </summary>
        /// <value>
        /// The open attribute text.
        /// </value>
        public string OpenAttributeText
        {
            get
            {
                Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));

                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the true keyword.
        /// </summary>
        /// <value>
        /// The true keyword.
        /// </value>
        public string TrueKeyword
        {
            get
            {
                Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));

                throw new NotImplementedException();
            }
        }

        #endregion
    }
}