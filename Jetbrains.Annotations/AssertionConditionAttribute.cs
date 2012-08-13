// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssertionConditionAttribute.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Indicates the condition parameter of the assertion method.
//   The method itself should be marked by <see cref="AssertionMethodAttribute" /> attribute.
//   The mandatory argument of the attribute is the assertion type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;

#endregion

namespace JetBrains.Annotations
{
    /// <summary>
    /// Indicates the condition parameter of the assertion method.
    ///   The method itself should be marked by <see cref="AssertionMethodAttribute"/> attribute.
    ///   The mandatory argument of the attribute is the assertion type.
    /// </summary>
    /// <seealso cref="AssertionConditionType"/>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public sealed class AssertionConditionAttribute : Attribute
    {
        #region Constants and Fields

        /// <summary>
        /// The my condition type.
        /// </summary>
        private readonly AssertionConditionType _conditionType;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AssertionConditionAttribute"/> class.
        ///   Initializes new instance of AssertionConditionAttribute.
        /// </summary>
        /// <param name="conditionType">
        /// Specifies condition type.
        /// </param>
        public AssertionConditionAttribute(AssertionConditionType conditionType)
        {
            _conditionType = conditionType;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets condition type.
        /// </summary>
        /// <value>
        /// The condition type.
        /// </value>
        public AssertionConditionType ConditionType
        {
            get
            {
                return _conditionType;
            }
        }

        #endregion
    }
}