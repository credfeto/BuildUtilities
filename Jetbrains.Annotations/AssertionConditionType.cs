// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssertionConditionType.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Specifies assertion type. If the assertion method argument satisfies the condition, then the execution continues.
//   Otherwise, execution is assumed to be halted.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JetBrains.Annotations
{
    /// <summary>
    /// Specifies assertion type. If the assertion method argument satisfies the condition, then the execution continues.
    ///   Otherwise, execution is assumed to be halted.
    /// </summary>
    public enum AssertionConditionType
    {
        /// <summary>
        /// Indicates that the marked parameter should be evaluated to true.
        /// </summary>
        IsTrue = 0,

        /// <summary>
        /// Indicates that the marked parameter should be evaluated to false.
        /// </summary>
        IsFalse = 1,

        /// <summary>
        /// Indicates that the marked parameter should be evaluated to null value.
        /// </summary>
        IsNull = 2,

        /// <summary>
        /// Indicates that the marked parameter should be evaluated to not null value.
        /// </summary>
        IsNotNull = 3,
    }
}