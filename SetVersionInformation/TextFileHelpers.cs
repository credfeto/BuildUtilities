// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextFileHelpers.cs" company="Twaddle Software">
//   Copyright (c) Twaddle Software
// </copyright>
// <summary>
//   The text file helpers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;

using JetBrains.Annotations;

#endregion

namespace SetVersionInformation
{
    /// <summary>
    /// The text file helpers.
    /// </summary>
    internal static class TextFileHelpers
    {
        #region Public Methods

        /// <summary>
        /// Reads the file contents line by line.
        /// </summary>
        /// <param name="filename">
        /// The file name.
        /// </param>
        /// <returns>
        /// The file content line by lines.
        /// </returns>
        [NotNull]
        public static IEnumerable<string> ReadFileContents([NotNull] string filename)
        {
            Contract.Requires(!string.IsNullOrEmpty(filename));

            Contract.Ensures(Contract.Result<IEnumerable<string>>() != null);

            using (var streamReader = new StreamReader(filename))
            {
                while (streamReader.Peek() != -1)
                {
                    yield return streamReader.ReadLine();
                }
            }
        }

        /// <summary>
        /// Writes the file contents.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <param name="outputLines">
        /// The output lines.
        /// </param>
        public static void WriteFileContents([NotNull] string fileName, [NotNull] List<string> outputLines)
        {
            Contract.Requires(!string.IsNullOrEmpty(fileName));
            Contract.Requires(outputLines != null);

            var linesLeft = outputLines.Count;
            using (var streamWriter = new StreamWriter(fileName))
            {
                foreach (var line in outputLines)
                {
                    --linesLeft;
                    if (linesLeft == 0)
                    {
                        streamWriter.Write(line);
                    }
                    else
                    {
                        streamWriter.WriteLine(line);
                    }
                }
            }
        }

        #endregion
    }
}