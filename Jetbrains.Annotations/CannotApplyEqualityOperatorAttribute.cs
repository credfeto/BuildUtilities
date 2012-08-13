// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CannotApplyEqualityOperatorAttribute.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Indicates that the value of marked type (or its derivatives) cannot be compared using '==' or '!=' operators.
//   There is only exception to compare with <c>null</c>, it is permitted.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;

#endregion

namespace JetBrains.Annotations
{
    /// <summary>
    /// Indicates that the value of marked type (or its derivatives) cannot be compared using '==' or '!=' operators.
    ///   There is only exception to compare with <c>null</c>, it is permitted.
    /// </summary>
    [AttributeUsage(Usage, AllowMultiple = false, Inherited = true)]
    public sealed class CannotApplyEqualityOperatorAttribute : Attribute
    {
        #region Constants and Fields

        /// <summary>
        /// The attribute usage.
        /// </summary>
        internal const AttributeTargets Usage =
            AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct;

        #endregion
    }
}