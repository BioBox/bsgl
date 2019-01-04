//-----------------------------------------------------------------------
// Source File: "Games.cs"
// Create Date:  09/02/2017 02:30:00 PM
// Last Updated: 09/02/2017 02:30:00 PM
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
namespace Baileysoft.Games.Data
{
    using Baileysoft.Games.Data.Repository;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Xml.Linq;

    /// <summary>
    /// Games abstraction
    /// </summary>
    public class Games : ObjectList<Game>
    {
        #region Properties

        /// <summary>
        /// The index file with all the game definitions
        /// </summary>
        public virtual string IndexFile { get; private set; }

        /// <summary>
        /// The definition file version
        /// </summary>
        public virtual double Revision { get; set; }

        #endregion

        /// <summary>
        /// Populate this collection with the games in the index
        /// </summary>
        /// <exception cref="System.ArgumentException">The exception that is thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.</exception>
        /// <exception cref="System.IO.FileNotFoundException">The exception that is thrown when an attempt to access a file that does not exist on disk fails.</exception>
        /// <exception cref="System.IO.PathTooLongException">The exception that is thrown when a pathname or filename is longer than the system-defined maximum length.</exception>
        /// <exception cref="System.FormatException">The exception that is thrown when the format of an argument does not meet the parameter specifications of the invoked method.</exception>
        /// <exception cref="System.NullReferenceException">The exception that is thrown when there is an attempt to dereference a null object reference.</exception>
        /// <exception cref="System.OverflowException">The exception that is thrown when an arithmetic, casting, or conversion operation in a checked context results in an overflow.</exception>
        public virtual void Parse()
        {
            SetRulesFilePath();

            if (!File.Exists(IndexFile))
                throw new FileNotFoundException("Unable to locate games definition: {0}", IndexFile);

            var xdoc = XDocument.Load(IndexFile);
            var xAttribute = xdoc.Root?.Attribute("revision");
            if (xAttribute != null)
                Revision = double.Parse(xAttribute.Value);

            var gameRepo = new GameRepository(IndexFile);
            AddRange(gameRepo.Get(Game.Keys.Title, GameRepository.SortOrder.ASCENDING));
        }

        /// <summary>
        /// Try to populate this collection with the games in the index
        /// </summary>
        /// <param name="exception">The first occurring <see cref="Exception"/></param>
        /// <returns>A <see cref="bool"/> flag to indicate the success or failure of the operation</returns>
        public virtual bool TryParse(out Exception exception)
        {
            var result = false;
            exception = null;
            try
            {
                Parse();
                result = true;
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            return result;
        }

        /// <summary>
        /// Get the path to the external rule file.
        /// </summary>
        /// <exception cref="System.ArgumentException">The exception that is thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.</exception>
        /// <exception cref="System.IO.PathTooLongException">The exception that is thrown when a pathname or filename is longer than the system-defined maximum length.</exception>
        /// <exception cref="System.NullReferenceException">The exception that is thrown when there is an attempt to dereference a null object reference.</exception>
        /// <returns><see cref="string"/></returns>
        protected internal virtual void SetRulesFilePath()
        {
            var assem = Assembly.GetExecutingAssembly();
            var dir = Path.GetDirectoryName(assem.Location);
            IndexFile = Path.Combine(dir, "index.xml");
        }
    }
}
