// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotNullAttribute.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Indicates that the value of marked element could never be <c>null</c>.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;

#endregion

namespace JetBrains.Annotations
{
    /// <summary>
    /// Indicates that the value of marked element could never be <c>null</c>.
    /// </summary>
    [AttributeUsage(
        AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Delegate
        | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class NotNullAttribute : Attribute
    {
    }
}