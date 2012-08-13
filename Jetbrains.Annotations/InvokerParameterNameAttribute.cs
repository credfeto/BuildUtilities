// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvokerParameterNameAttribute.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Indicates that the function argument should be string literal and match one of the parameters of the caller function.
//   For example, <see cref="ArgumentNullException" /> has such parameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;

#endregion

namespace JetBrains.Annotations
{
    /// <summary>
    /// Indicates that the function argument should be string literal and match one of the parameters of the caller function.
    ///   For example, <see cref="ArgumentNullException"/> has such parameter.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public sealed class InvokerParameterNameAttribute : Attribute
    {
    }
}