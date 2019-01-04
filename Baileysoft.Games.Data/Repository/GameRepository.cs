//-----------------------------------------------------------------------
// Source File: "GameRepository.cs"
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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    /// <summary>
    /// The repository for working with game data objects.
    /// </summary>
    public class GameRepository : RepositoryBase
    {
        #region Constructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public GameRepository() : this(null) { }

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="databaseFilePath">The database file path.</param>
        public GameRepository(string databaseFilePath)
        {
            DatabaseFilePath = databaseFilePath ?? GetDatabaseFilePath();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Deletes a game object from the data store.
        /// </summary>
        /// <param name="game">The game to delete</param>
        /// <exception cref="System.InvalidOperationException">The exception that is thrown when a method call is invalid for the object's current state.</exception>
        public virtual void Delete(Game game)
        {
            Load(DatabaseFilePath);
            string xpqf = $"games/game[@id='{game.Id}']";
            var xGame = Document.XPathSelectElement(xpqf);
            xGame?.Remove();

            Document.Save(DatabaseFilePath);
        }

        /// <summary>
        /// Gets all the game objects in the data store.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="Game"/> objects.</returns>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.</exception>
        /// <exception cref="System.FormatException">The exception that is thrown when the format of an argument does not meet the parameter specifications of the invoked method.</exception>
        /// <exception cref="System.OverflowException">The exception that is thrown when an arithmetic, casting, or conversion operation in a checked context results in an overflow.</exception>
        public virtual List<Game> Get()
        {
            Load(DatabaseFilePath);

            var games = new List<Game>();

            // Get Game elements
            var xGames = from g in Document.Elements("games").Elements("game") select g;
            foreach (var xGame in xGames)
            {
                var game = new Game
                {
                    Id = new Guid(Convert.ToString(xGame.Attribute("id").Value)),
                    Title = Convert.ToString(xGame.Element("title").Value),
                    Path = Convert.ToString(xGame.Element("path").Value),
                    Args = Convert.ToString(xGame.Element("args").Value)
                };

                // Get Game.Sessions.Session elements
                foreach (var xSession in xGame.Elements("sessions").Elements("session"))
                {
                    var session = new Session
                    {
                        StartTime = DateTime.Parse(xSession.Attribute("start").Value),
                        EndTime = DateTime.Parse(xSession.Attribute("end").Value)
                    };
                    game.Sessions.Add(session);
                }

                game.PlayTime = new PlayTime
                {
                    Total = Convert.ToString(xGame.Element("playtime").Attribute("total").Value),
                    TotalFormatted = Convert.ToString(xGame.Element("playtime").Attribute("formatted").Value)
                };

                if (string.IsNullOrEmpty(game.PlayTime.Total))
                    game.CalculatePlayTime();

                games.Add(game);
            }

            return games;
        }

        /// <summary>
        /// Gets all the game objects in the data store.
        /// </summary>
        /// <param name="sortExpression">The sort expression (e.g. Title)</param>
        /// <param name="sortOrder">The sort order (e.g. Ascending)</param>
        /// <returns>A sorted <see cref="List{T}"/> of <see cref="Game"/> objects.</returns>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.</exception>
        /// <exception cref="System.FormatException">The exception that is thrown when the format of an argument does not meet the parameter specifications of the invoked method.</exception>
        /// <exception cref="System.OverflowException">The exception that is thrown when an arithmetic, casting, or conversion operation in a checked context results in an overflow.</exception>
        public virtual List<Game> Get(string sortExpression, string sortOrder)
        {
            var games = Get();

            if (string.IsNullOrEmpty(sortOrder))
                sortOrder = SortOrder.ASCENDING;

            if (games.Count > 0)
            {
                switch (sortExpression)
                {
                    case Game.Keys.Title: games = games.OrderBy(g => g.Title).ToList<Game>(); break;
                    case Game.Keys.Id: games = games.OrderBy(g => g.Id.ToString()).ToList<Game>(); break;
                    case Game.Keys.Playtime: games = games.OrderBy(g => g.PlayTime.Total).ToList<Game>(); break;
                    case Game.Keys.Path: games = games.OrderBy(g => g.Path).ToList<Game>(); break;
                    default: games = games.OrderBy(g => g.Title).ToList<Game>(); break;
                }
                if (sortOrder == SortOrder.DESCENDING)
                    games.Reverse();
            }

            return games;
        }

        /// <summary>
        /// Gets a single <see cref="Game"/> based on it's path
        /// </summary>
        /// <param name="path">The game path</param>
        /// <returns>A <see cref="Game"/> if found, null otherwise</returns>
        /// <exception cref="System.ArgumentException">The exception that is thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.</exception>
        /// <exception cref="System.FormatException">The exception that is thrown when the format of an argument does not meet the parameter specifications of the invoked method.</exception>
        /// <exception cref="System.OverflowException">The exception that is thrown when an arithmetic, casting, or conversion operation in a checked context results in an overflow.</exception>
        public virtual Game GetByPath(string path)
        {
            return Get().SingleOrDefault(g => g.Path.IndexOf(path, StringComparison.CurrentCultureIgnoreCase) > -1);
        }

        /// <summary>
        /// Gets a single <see cref="Game"/> based on it's path
        /// </summary>
        /// <param name="id">The game id</param>
        /// <returns>A <see cref="Game"/> if found, null otherwise</returns>
        /// <exception cref="System.ArgumentException">The exception that is thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.</exception>
        /// <exception cref="System.FormatException">The exception that is thrown when the format of an argument does not meet the parameter specifications of the invoked method.</exception>
        /// <exception cref="System.OverflowException">The exception that is thrown when an arithmetic, casting, or conversion operation in a checked context results in an overflow.</exception>
        public virtual Game GetById(Guid id)
        {
            return Get().SingleOrDefault(g => g.Id == id);
        }

        /// <summary>
        /// Save the game session instance.
        /// </summary>
        /// <param name="game">The game to insert or update</param>
        /// <exception cref="System.ArgumentOutOfRangeException">The exception that is thrown when the value of an argument is outside the allowable range of values as defined by the invoked method.</exception>
        /// <exception cref="System.ArgumentException">The exception that is thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.</exception>
        /// <exception cref="System.FormatException">The exception that is thrown when the format of an argument does not meet the parameter specifications of the invoked method.</exception>
        /// <exception cref="System.OverflowException">The exception that is thrown when an arithmetic, casting, or conversion operation in a checked context results in an overflow.</exception>
        public virtual void SaveOrUpdate(Game game)
        {
            // Associate existing game to passed in instance (if game already exists)
            var oGame = GetById(game.Id);
            //if (oGame == null)
            //    oGame = GetByPath(game.Path);

            if (oGame != null && oGame?.Id != game.Id)
            {
                game.Id = oGame.Id;
                if (game.Sessions.Count == 0)
                    game.Sessions = oGame.Sessions;
            }

            Load(DatabaseFilePath);
            string xpqf = $"games/game[@id='{game.Id}']";
            var xGame = Document.XPathSelectElement(xpqf);

            if (xGame == null)
                xGame = CreateNewEntry(game);

            xGame.RemoveNodes();

            var titleXe = new XElement("title", new XCData(game.Title));
            var pathXe = new XElement("path", new XCData(game.Path));
            var argsXe = new XElement("args", new XCData(game.Args));
            var sessionsXe = new XElement("sessions");

            foreach (var session in game.Sessions)
            {
                var sessionXe = new XElement("session");
                sessionXe.Add(new XAttribute("start", session.StartTime.ToString("s")));
                sessionXe.Add(new XAttribute("end", session.EndTime.ToString("s")));
                sessionXe.Add(new XAttribute("total", session.CalculatePlayTime()));
                sessionsXe.Add(sessionXe);
            }

            var playTimeXe = new XElement("playtime");
            playTimeXe.Add(new XAttribute("total", game.PlayTime.Total));
            playTimeXe.Add(new XAttribute("formatted", game.PlayTime.TotalFormatted));

            xGame.Add(titleXe);
            xGame.Add(pathXe);
            xGame.Add(argsXe);
            xGame.Add(sessionsXe);
            xGame.Add(playTimeXe);

            Document.Save(DatabaseFilePath);
        }

        /// <summary>
        /// Create a new <see cref="XElement"/> game fragment.
        /// </summary>
        /// <param name="game">The game to add</param>
        /// <returns><see cref="XElement"/></returns>
        protected internal virtual XElement CreateNewEntry(Game game)
        {
            var gamesXe = Document.Element("games");
            var gameXe = new XElement("game");
            gameXe.SetAttributeValue("id", game.Id);
            gamesXe.Add(gameXe);
            return gameXe;
        }

        #endregion
    }
}
