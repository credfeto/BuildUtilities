// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CanBeNullAttribute.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Indicates that the value of marked element could be <c>null</c> sometimes, so the check for <c>null</c> is necessary before its usage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;

#endregion

namespace JetBrains.Annotations
{
    /// <summary>
    /// Indicates that the value of marked element could be <c>null</c> sometimes, so the check for <c>null</c> is necessary before its usage.
    /// </summary>
    [AttributeUsage(
        AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Delegate
        | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class CanBeNullAttribute : Attribute
    {
    }
}