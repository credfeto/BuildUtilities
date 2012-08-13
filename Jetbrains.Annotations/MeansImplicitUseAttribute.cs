// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MeansImplicitUseAttribute.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   Should be used on attributes and causes ReSharper to not mark symbols marked with such attributes as unused (as well as by other usage inspections).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.CodeAnalysis;

#endregion

namespace JetBrains.Annotations
{
    /// <summary>
    /// Should be used on attributes and causes ReSharper to not mark symbols marked with such attributes as unused (as well as by other usage inspections).
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class MeansImplicitUseAttribute : Attribute
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MeansImplicitUseAttribute"/> class.
        /// </summary>
        [UsedImplicitly]
        public MeansImplicitUseAttribute()
            : this(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeansImplicitUseAttribute"/> class.
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
        public MeansImplicitUseAttribute(ImplicitUseKindFlags useKindFlags, ImplicitUseTargetFlags targetFlags)
        {
            UseKindFlags = useKindFlags;
            TargetFlags = targetFlags;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeansImplicitUseAttribute"/> class.
        /// </summary>
        /// <param name="useKindFlags">
        /// The use kind flags.
        /// </param>
        [UsedImplicitly]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags",
            Justification = "ReSharper's own API")]
        public MeansImplicitUseAttribute(ImplicitUseKindFlags useKindFlags)
            : this(useKindFlags, ImplicitUseTargetFlags.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeansImplicitUseAttribute"/> class.
        /// </summary>
        /// <param name="targetFlags">
        /// The target flags.
        /// </param>
        [UsedImplicitly]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags",
            Justification = "ReSharper's own API")]
        public MeansImplicitUseAttribute(ImplicitUseTargetFlags targetFlags)
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