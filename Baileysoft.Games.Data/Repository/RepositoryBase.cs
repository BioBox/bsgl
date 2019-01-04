//-----------------------------------------------------------------------
// Source File: "RepositoryBase.cs"
// Create Date:  09/03/2017 02:30:00 PM
// Last Updated: 09/03/2017 02:30:00 PM
// Authors(s): Neal Bailey <nealbailey@hotmail.com>
//-----------------------------------------------------------------------
// GNU GENERAL PUBLIC LICENSE
//-----------------------------------------------------------------------
// Revision: Version 3, 29 June 2007
// Copyright © 2007 Free Software Foundation, Inc. http://fsf.org/
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//  REFERENCE: http://www.gnu.org/licenses/
//-----------------------------------------------------------------------
// Copyright (c) 2010-2017 Baileysoft Solutions
//-----------------------------------------------------------------------
namespace Baileysoft.Games.Data.Repository
{
    using System.IO;
    using System.Reflection;
    using System.Xml.Linq;

    /// <summary>
    /// Base class for data repositories.
    /// </summary>
    public class RepositoryBase
    {
        #region Properties

        /// <summary>
        /// The file path to the database file.
        /// </summary>
        public virtual string DatabaseFilePath { get; set; }

        /// <summary>
        /// The repository's XDocument
        /// </summary>
        public static XDocument Document { get; private set; } = null;

        #endregion

        #region Methods

        /// <summary>
        /// Loads the repository from the specified file.
        /// </summary>
        /// <param name="databaseFilePath">The database file path.</param>
        public static void Load(string databaseFilePath)
        {
            if (Document == null)
                Document = XDocument.Load(databaseFilePath);
        }

        /// <summary>
        /// Get the path to the external rule file.
        /// </summary>
        /// <exception cref="System.ArgumentException">The exception that is thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.</exception>
        /// <exception cref="System.IO.PathTooLongException">The exception that is thrown when a pathname or filename is longer than the system-defined maximum length.</exception>
        /// <exception cref="System.NullReferenceException">The exception that is thrown when there is an attempt to dereference a null object reference.</exception>
        /// <returns><see cref="string"/></returns>
        protected internal virtual string GetDatabaseFilePath()
        {
            var assem = Assembly.GetExecutingAssembly();
            var dir = Path.GetDirectoryName(assem.Location);
            DatabaseFilePath = Path.Combine(dir, "index.xml");
            return DatabaseFilePath;
        }

        #endregion

        #region Structures

        /// <summary>
        /// Strongly-typed sort order values.
        /// </summary>
        public struct SortOrder
        {
            /// <summary>
            /// Descending sort order constant.
            /// </summary>
            public const string DESCENDING = "Descending";
            /// <summary>
            /// Ascending sort order constant.
            /// </summary>
            public const string ASCENDING = "Ascending";
        }

        #endregion
    }
}