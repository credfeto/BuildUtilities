// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocalizationRequiredAttribute.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Indicates that marked element should be localized or not.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.CodeAnalysis;

#endregion

namespace JetBrains.Annotations
{
    /// <summary>
    /// Indicates that marked element should be localized or not.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public sealed class LocalizationRequiredAttribute : Attribute
    {
        #region Constants and Fields

        /// <summary>
        /// The _required.
        /// </summary>
        private readonly bool _required;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizationRequiredAttribute"/> class.
        /// </summary>
        /// <param name="required">
        /// <c>true</c> if a element should be localized; otherwise, <c>false</c>.
        /// </param>
        public LocalizationRequiredAttribute(bool required)
        {
            _required = required;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether a element should be localized.
        /// </summary>
        /// <value>
        /// <c>true</c> if a element should be localized; otherwise, <c>false</c>.
        /// </value>
        [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments",
            Justification = "ReSharper's own API.")]
        public bool Required
        {
            get
            {
                return _required;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns whether the value of the given object is equal to the current <see cref="LocalizationRequiredAttribute"/>.
        /// </summary>
        /// <param name="obj">
        /// The object to test the value equality of.
        /// </param>
        /// <returns>
        /// <c>true</c> if the value of the given object is equal to that of the current; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals([CanBeNull] object obj)
        {
            var attribute = obj as LocalizationRequiredAttribute;
            return attribute != null && attribute._required == _required;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="LocalizationRequiredAttribute"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return _required.GetHashCode();
        }

        #endregion
    }
}