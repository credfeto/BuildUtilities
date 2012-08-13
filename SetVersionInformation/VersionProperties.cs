// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VersionProperties.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   The version properties.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Reflection;

using JetBrains.Annotations;

#endregion

namespace SetVersionInformation
{
    /// <summary>
    /// The version properties.
    /// </summary>
    public sealed class VersionProperties
    {
        #region Constants and Fields

        /// <summary>
        /// The _company name.
        /// </summary>
        [NotNull]
        private string _companyName = CurrentAssemblyCompanyName;

        /// <summary>
        /// The start year for the copyright date.
        /// </summary>
        private int _copyrightStartYear = 1990;

        /// <summary>
        /// The current build date.
        /// </summary>
        [NotNull]
        private string _currentBuildDate;

        /// <summary>
        /// The current build number.
        /// </summary>
        private int _currentBuildNumber;

        /// <summary>
        /// The current build time.
        /// </summary>
        [NotNull]
        private string _currentBuildTime;

        /// <summary>
        /// The major.
        /// </summary>
        private int _major = 1;

        /// <summary>
        /// The minor.
        /// </summary>
        private int _minor;

        /// <summary>
        /// The product name.
        /// </summary>
        [NotNull]
        private string _productName = CurrentAssemblyProductName;

        /// <summary>
        /// The subversion revision.
        /// </summary>
        private int _subversionRevision;

        /// <summary>
        /// The trademark, if any.
        /// </summary>
        [CanBeNull]
        private string _trademark = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Company Name.
        /// </summary>
        /// <value>
        /// The company name.
        /// </value>
        [NotNull]
        public string CompanyName
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

                return _companyName;
            }

            set
            {
                Contract.Requires(!string.IsNullOrEmpty(value));

                _companyName = value;
            }
        }

        /// <summary>
        /// Gets or sets Copyright Start Year.
        /// </summary>
        /// <value>
        /// The copyright start year.
        /// </value>
        public int CopyrightStartYear
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 1990);

                return _copyrightStartYear;
            }

            set
            {
                Contract.Requires(value >= 1990);

                _copyrightStartYear = value;
            }
        }

        /// <summary>
        /// Gets or sets the Current Build Date.
        /// </summary>
        /// <value>
        /// The current build date.
        /// </value>
        [NotNull]
        public string CurrentBuildDate
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

                return _currentBuildDate;
            }

            set
            {
                Contract.Requires(!string.IsNullOrEmpty(value));

                _currentBuildDate = value;
            }
        }

        /// <summary>
        /// Gets or sets Current Build Number.
        /// </summary>
        /// <value>
        /// The current build number.
        /// </value>
        public int CurrentBuildNumber
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);

                return _currentBuildNumber;
            }

            set
            {
                Contract.Requires(value >= 0);

                _currentBuildNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets Current Build Time.
        /// </summary>
        /// <value>
        /// The current build time.
        /// </value>
        [NotNull]
        public string CurrentBuildTime
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

                return _currentBuildTime;
            }

            set
            {
                Contract.Requires(!string.IsNullOrEmpty(value));

                _currentBuildTime = value;
            }
        }

        /// <summary>
        /// Gets or sets major version.
        /// </summary>
        /// <value>
        /// The major version.
        /// </value>
        public int Major
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() > 0);

                return _major;
            }

            set
            {
                Contract.Requires(value > 0);

                _major = value;
            }
        }

        /// <summary>
        /// Gets or sets minor version.
        /// </summary>
        /// <value>
        /// The minor version.
        /// </value>
        public int Minor
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);

                return _minor;
            }

            set
            {
                Contract.Requires(value >= 0);

                _minor = value;
            }
        }

        /// <summary>
        /// Gets or sets the Product Name.
        /// </summary>
        /// <value>
        /// The product name.
        /// </value>
        [NotNull]
        public string ProductName
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

                return _productName;
            }

            set
            {
                Contract.Requires(!string.IsNullOrEmpty(value));

                _productName = value;
            }
        }

        /// <summary>
        /// Gets or sets the Sub-version revision.
        /// </summary>
        /// <value>
        /// The sub-version revision.
        /// </value>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "May change later.")]
        public int SubversionRevision
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);

                return _subversionRevision;
            }

            set
            {
                Contract.Requires(value >= 0);

                _subversionRevision = value;
            }
        }

        /// <summary>
        /// Gets or sets the Trademark.
        /// </summary>
        /// <value>
        /// The trademark.
        /// </value>
        [CanBeNull]
        public string Trademark
        {
            get
            {
                Contract.Ensures(Contract.Result<string>() != null);

                return _trademark;
            }

            set
            {
                Contract.Requires(value != null);

                _trademark = value;
            }
        }

        /// <summary>
        /// Gets the name of the current assembly's company.
        /// </summary>
        /// <value>
        /// The name of the current assembly's company.
        /// </value>
        [NotNull]
        private static string CurrentAssemblyCompanyName
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(
                    typeof(AssemblyCompanyAttribute), false);
                return attributes.Length == 0 ? "Twaddle Software" : ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        /// <summary>
        /// Gets the name of the current assembly's product name.
        /// </summary>
        /// <value>
        /// The name of the current assembly's product name.
        /// </value>
        [NotNull]
        private static string CurrentAssemblyProductName
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(
                    typeof(AssemblyProductAttribute), false);
                return attributes.Length == 0 ? "Build Utilities" : ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The object Invariant.
        /// </summary>
        [UsedImplicitly]
        [ContractInvariantMethod]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Invoked by Code Contracts")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Invoked by Code Contracts, non static accesses")]
        private void ObjectInvariant()
        {
            Contract.Invariant(_copyrightStartYear >= 1990);
            Contract.Invariant(_major > 0);
            Contract.Invariant(_minor >= 0);
            Contract.Invariant(_subversionRevision >= 0);
            Contract.Invariant(_currentBuildNumber >= 0);
            Contract.Invariant(_trademark != null);
            Contract.Invariant(!string.IsNullOrEmpty(_companyName));
            Contract.Invariant(!string.IsNullOrEmpty(_productName));
        }

        #endregion
    }
}