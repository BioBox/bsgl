//-----------------------------------------------------------------------
// Source File: "Game.cs"
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Game abstraction
    /// </summary>
    public class Game
    {
        #region Properties

        /// <summary>
        /// The unique Guid identifier for this game
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// The physical file location of this game
        /// </summary>
        public virtual string Path { get; set; } = string.Empty;

        /// <summary>
        /// The arguments to pass to the game executable
        /// </summary>
        public virtual string Args { get; set; } = string.Empty;

        /// <summary>
        /// The collection of sessions
        /// </summary>
        public virtual List<Session> Sessions { get; set; } = new List<Session>();

        /// <summary>
        /// The playtime calculations for this game
        /// </summary>
        public virtual PlayTime PlayTime { get; set; } = new PlayTime();

        /// <summary>
        /// The Game's title
        /// </summary>
        public virtual string Title { get; set; } = string.Empty;

        #endregion

        #region Methods

        /// <summary>
        /// Remove illegal characters from file name.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.</exception>
        /// <returns><see cref="string"/></returns>
        public static string RemoveIllegalCharsFromFileName(string fileName)
        {
            return string.Join("", fileName.Split(System.IO.Path.GetInvalidFileNameChars()));
        }

        /// <summary>
        /// Try to save the game session instance.
        /// </summary>
        /// <param name="indexFile">The game definition file</param>
        /// <param name="session">The active <see cref="Session"/></param>
        /// <param name="exception">The first occurring <see cref="Exception"/></param>
        /// <returns>A <see cref="bool"/> flag to indicate the success or failure of the operation</returns>
        public virtual bool TrySaveSessionStartEndDates(string indexFile, Session session, out Exception exception)
        {
            var result = false;
            exception = null;
            try
            {
                SaveSessionStartEndDates(indexFile, session);
                result = true;
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            return result;
        }

        /// <summary>
        /// Save the game session instance.
        /// </summary>
        /// <param name="indexFile">The game definition file</param>
        /// <param name="session">The active <see cref="Session"/></param>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The exception that is thrown when the value of an argument is outside the allowable range of values as defined by the invoked method.</exception>
        /// <exception cref="System.FormatException">The exception that is thrown when the format of an argument does not meet the parameter specifications of the invoked method.</exception>
        public virtual void SaveSessionStartEndDates(string indexFile, Session session)
        {
            Sessions.Add(session);
            CalculatePlayTime();

            var gameRepo = new GameRepository(indexFile);
            gameRepo.SaveOrUpdate(this);
        }

        /// <summary>
        /// Calculates the total playtime for the game (all sessions).
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.</exception>
        /// <exception cref="System.FormatException">The exception that is thrown when the format of an argument does not meet the parameter specifications of the invoked method.</exception>
        /// <exception cref="System.OverflowException">The exception that is thrown when an arithmetic, casting, or conversion operation in a checked context results in an overflow.</exception>
        public virtual void CalculatePlayTime()
        {
            var spans = Sessions.Select(session => session.EndTime - session.StartTime).ToList();
            var total = spans.Aggregate(TimeSpan.Zero, (subtotal, t) => subtotal.Add(t));
            var totalHours = ((total.Days * 24) + total.Hours);
            PlayTime.TotalFormatted = string.Format("{0} hours, {1:%m} minutes, {1:%s} seconds", totalHours, total);
            PlayTime.Total = $"{totalHours:00}:{total.Minutes:00}:{total.Seconds:00}";
        }

        public override string ToString()
        {
            return (string.IsNullOrEmpty(Title) ? base.ToString() : Title);
        }

        #endregion

        #region Structures

        /// <summary>
        /// Strongly named constants
        /// </summary>
        public struct Keys
        {
            public const string Id = "Id";
            public const string Path = "Path";
            public const string Playtime = "Playtime";
            public const string Title = "Title";
        }

        #endregion
    }
}
