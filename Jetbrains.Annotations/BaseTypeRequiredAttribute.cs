// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseTypeRequiredAttribute.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   When applied to target attribute, specifies a requirement for any type which is marked with
//   target attribute to implement or inherit specific type or types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

#endregion

namespace JetBrains.Annotations
{
    /// <summary>
    /// When applied to target attribute, specifies a requirement for any type which is marked with
    ///   target attribute to implement or inherit specific type or types.
    /// </summary>
    /// <example>
    /// <code>
    /// [BaseTypeRequired(typeof(IComponent)] // Specify requirement
    ///     public class ComponentAttribute : Attribute
    ///     {}
    ///
    ///     [Component] // ComponentAttribute requires implementing IComponent interface
    ///     public class MyComponent : IComponent
    ///     {}
    ///   </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    [BaseTypeRequired(typeof(Attribute))]
    [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments", Justification = "Its not really a positional argument")]
    public sealed class BaseTypeRequiredAttribute : Attribute
    {
        #region Constants and Fields

        /// <summary>
        /// The my base types.
        /// </summary>
        [NotNull]
        private readonly Type[] _baseTypes;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTypeRequiredAttribute"/> class.
        /// </summary>
        /// <param name="baseType">
        /// The base type type.
        /// </param>
        public BaseTypeRequiredAttribute([NotNull] Type baseType)
        {
            Contract.Requires(baseType != null);

            _baseTypes = new[] { baseType };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTypeRequiredAttribute"/> class.
        /// </summary>
        /// <param name="baseTypes">
        /// Specifies which types are required.
        /// </param>
        [CLSCompliant(false)]
        public BaseTypeRequiredAttribute([NotNull] params Type[] baseTypes)
        {
            Contract.Requires(baseTypes != null);

            Contract.Requires(baseTypes.Length > 0);

            _baseTypes = baseTypes;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets enumerations of specified base types.
        /// </summary>
        /// <value>
        /// The base types.
        /// </value>
        [NotNull]
        public IEnumerable<Type> BaseTypes
        {
            get
            {
                Contract.Ensures(Contract.Result<IEnumerable<Type>>() != null);

                return _baseTypes;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The object invariant.
        /// </summary>
        [ContractInvariantMethod]
        [UsedImplicitly]
        [SuppressMessage("SubMain.CodeItRight.Rules.Performance", "PE00004:RemoveUnusedPrivateMethods",
            Justification = "Invoked by Code Contracts")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Invoked by Code Contracts")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Invoked by Code Contracts, non static accesses")]
        private void ObjectInvariant()
        {
            Contract.Invariant(_baseTypes != null);
        }

        #endregion
    }
}