// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TerminatesProgramAttribute.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Indicates that the marked method unconditionally terminates control flow execution.
//   For example, it could unconditionally throw exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;

#endregion

namespace JetBrains.Annotations
{
    /// <summary>
    /// Indicates that the marked method unconditionally terminates control flow execution.
    ///   For example, it could unconditionally throw exception.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class TerminatesProgramAttribute : Attribute
    {
    }
}