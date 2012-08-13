// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssertionMethodAttribute.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Indicates that the marked method is assertion method, i.e. it halts control flow if one of the conditions is satisfied.
//   To set the condition, mark one of the parameters with <see cref="AssertionConditionAttribute" /> attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;

#endregion

namespace JetBrains.Annotations
{
    /// <summary>
    /// Indicates that the marked method is assertion method, i.e. it halts control flow if one of the conditions is satisfied.
    ///   To set the condition, mark one of the parameters with <see cref="AssertionConditionAttribute"/> attribute.
    /// </summary>
    /// <seealso cref="AssertionConditionAttribute"/>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class AssertionMethodAttribute : Attribute
    {
    }
}