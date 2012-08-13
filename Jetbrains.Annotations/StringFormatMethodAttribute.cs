// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringFormatMethodAttribute.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Indicates that marked method builds string by format pattern and (optional) arguments.
//   Parameter, which contains format string, should be given in constructor.
//   The format string should be in <see cref="string.Format(IFormatProvider,string,object[])" /> -like form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

#endregion

namespace JetBrains.Annotations
{
    /// <summary>
    /// Indicates that marked method builds string by format pattern and (optional) arguments.
    ///   Parameter, which contains format string, should be given in constructor.
    ///   The format string should be in <see cref="string.Format(IFormatProvider,string,object[])"/> -like form.
    /// </summary>
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class StringFormatMethodAttribute : Attribute
    {
        #region Constants and Fields

        /// <summary>
        /// The my format parameter name.
        /// </summary>
        private readonly string _formatParameterName;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StringFormatMethodAttribute"/> class.
        ///   Initializes new instance of StringFormatMethodAttribute.
        /// </summary>
        /// <param name="formatParameterName">
        /// Specifies which parameter of an annotated method should be treated as format-string.
        /// </param>
        public StringFormatMethodAttribute([NotNull] string formatParameterName)
        {
            Contract.Requires(!string.IsNullOrEmpty(formatParameterName));

            _formatParameterName = formatParameterName;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets format parameter name.
        /// </summary>
        /// <value>
        /// The format parameter name.
        /// </value>
        [NotNull]
        public string FormatParameterName
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

                return _formatParameterName;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The object invariant.
        /// </summary>
        [ContractInvariantMethod]
        [UsedImplicitly]
        [SuppressMessage("SubMain.CodeItRight.Rules.Performance", "PE00004:RemoveUnusedPrivateMethods", Justification = "Invoked by Code Contracts")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Invoked by Code Contracts")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Invoked by Code Contracts, non static accesses")]
        private void ObjectInvariant()
        {
            Contract.Invariant(!string.IsNullOrEmpty(_formatParameterName));
        }

        #endregion
    }
}