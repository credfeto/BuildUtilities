// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImplicitUseKindFlags.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   The implicit use kind flags.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.CodeAnalysis;

#endregion

namespace JetBrains.Annotations
{
    /// <summary>
    /// The implicit use kind flags.
    /// </summary>
    [Flags]
    [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags",
        Justification = "ReSharper's own API")]
    public enum ImplicitUseKindFlags
    {
        /// <summary>
        /// The default.
        /// </summary>
        Default = Access | Assign | Instantiated,

        /// <summary>
        /// Only entity marked with attribute considered used.
        /// </summary>
        Access = 1,

        /// <summary>
        /// Indicates implicit assignment to a member.
        /// </summary>
        Assign = 2,

        /// <summary>
        /// Indicates implicit instantiation of a type.
        /// </summary>
        Instantiated = 4,
    }
}