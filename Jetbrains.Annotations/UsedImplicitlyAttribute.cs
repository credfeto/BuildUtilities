// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsedImplicitlyAttribute.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Indicates that the marked symbol is used implicitly (e.g. via reflection, in external library),
//   so this symbol will not be marked as unused (as well as by other usage inspections).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.CodeAnalysis;

#endregion

namespace JetBrains.Annotations
{
    /// <summary>
    /// Indicates that the marked symbol is used implicitly (e.g. via reflection, in external library),
    ///   so this symbol will not be marked as unused (as well as by other usage inspections).
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public sealed class UsedImplicitlyAttribute : Attribute
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UsedImplicitlyAttribute"/> class.
        /// </summary>
        [UsedImplicitly]
        public UsedImplicitlyAttribute()
            : this(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsedImplicitlyAttribute"/> class.
        /// </summary>
        /// <param name="useKindFlags">
        /// The use kind flags.
        /// </param>
        /// <param name="targetFlags">
        /// The target flags.
        /// </param>
        [UsedImplicitly]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags",
            Justification = "ReSharper's own API")]
        public UsedImplicitlyAttribute(ImplicitUseKindFlags useKindFlags, ImplicitUseTargetFlags targetFlags)
        {
            UseKindFlags = useKindFlags;
            TargetFlags = targetFlags;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsedImplicitlyAttribute"/> class.
        /// </summary>
        /// <param name="useKindFlags">
        /// The use kind flags.
        /// </param>
        [UsedImplicitly]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags",
            Justification = "ReSharper's own API")]
        public UsedImplicitlyAttribute(ImplicitUseKindFlags useKindFlags)
            : this(useKindFlags, ImplicitUseTargetFlags.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsedImplicitlyAttribute"/> class.
        /// </summary>
        /// <param name="targetFlags">
        /// The target flags.
        /// </param>
        [UsedImplicitly]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags",
            Justification = "ReSharper's own API")]
        public UsedImplicitlyAttribute(ImplicitUseTargetFlags targetFlags)
            : this(ImplicitUseKindFlags.Default, targetFlags)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets value indicating what is meant to be used.
        /// </summary>
        /// <value>
        /// The target flags.
        /// </value>
        [UsedImplicitly]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags",
            Justification = "ReSharper's own API")]
        public ImplicitUseTargetFlags TargetFlags
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets UseKindFlags.
        /// </summary>
        /// <value>
        /// The use kind flags.
        /// </value>
        [UsedImplicitly]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags",
            Justification = "ReSharper's own API")]
        public ImplicitUseKindFlags UseKindFlags
        {
            get;
            private set;
        }

        #endregion
    }
}