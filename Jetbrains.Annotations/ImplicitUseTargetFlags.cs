// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImplicitUseTargetFlags.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Specify what is considered used implicitly when marked with <see cref="MeansImplicitUseAttribute" /> or <see cref="UsedImplicitlyAttribute" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.CodeAnalysis;

#endregion

namespace JetBrains.Annotations
{
    /// <summary>
    /// Specify what is considered used implicitly when marked with <see cref="MeansImplicitUseAttribute"/> or <see cref="UsedImplicitlyAttribute"/>.
    /// </summary>
    [Flags]
    [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags",
        Justification = "ReSharper's own API")]
    public enum ImplicitUseTargetFlags
    {
        /// <summary>
        /// The default.
        /// </summary>
        Default = Itself,

        /// <summary>
        /// The itself.
        /// </summary>
        Itself = 1,

        /// <summary>
        /// Members of entity marked with attribute are considered used.
        /// </summary>
        Members = 2,

        /// <summary>
        /// Entity marked with attribute and all its members considered used.
        /// </summary>
        WithMembers = Itself | Members
    }
}