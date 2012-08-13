// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidConfigurationException.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   The invalid configuration exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

using JetBrains.Annotations;

#endregion

namespace SetVersionInformation
{
    /// <summary>
    /// The invalid configuration exception.
    /// </summary>
    [Serializable]
    public sealed class InvalidConfigurationException : Exception
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidConfigurationException"/> class.
        /// </summary>
        public InvalidConfigurationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidConfigurationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidConfigurationException([NotNull] string message)
            : base(message)
        {
            Contract.Requires(!string.IsNullOrEmpty(message));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidConfigurationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public InvalidConfigurationException([NotNull] string message, [NotNull] Exception innerException)
            : base(message, innerException)
        {
            Contract.Requires(!string.IsNullOrEmpty(message));
            Contract.Requires(innerException != null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidConfigurationException"/> class.
        /// </summary>
        /// <param name="info">
        /// The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="info"/> parameter is <see langword="null"/>.
        /// </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">
        /// The class name is <see langword="null"/> or <see cref="P:System.Exception.HResult"/> is zero (0).
        /// </exception>
        private InvalidConfigurationException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Contract.Requires(info != null);
        }

        #endregion
    }
}