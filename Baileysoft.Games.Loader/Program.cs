//-----------------------------------------------------------------------
// Source File: "Program.cs"
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
namespace Baileysoft.Games.Loader
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using Baileysoft.Games.Data;
    using Baileysoft.Games.Loader.Forms;

    /// <summary>
    /// Startup object
    /// </summary>
    public class Program
    {
        #region Methods

        /// <summary>
        /// Application Entry Point
        /// </summary>
        /// <param name="args">Argument array</param>
        /// <returns>An <see cref="int"/> exit code</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The exception that is thrown when the value of an argument is outside the allowable range of values as defined by the invoked method.</exception>
        /// <exception cref="System.OutOfMemoryException">The exception that is thrown when there is not enough memory to continue the execution of a program.</exception>
        /// <exception cref="System.IO.IOException">The exception that is thrown when an I/O error occurs.</exception>
        [STAThread]
        public static int Main(string[] args)
        {
            //Hide the console
            //var handle = Interop.GetConsoleWindow();
            //Interop.ShowWindow(handle, Interop.SW_HIDE);

            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("No arguments received. Launching configuration utility.");
                    var frmConfig = new FrmConfig();
                    frmConfig.ShowDialog();
                    frmConfig.StartPosition = FormStartPosition.CenterScreen;
                    return 0;
                }

                var parser = new CommandLineParser(args);
                if (parser.Help)
                {
                    Console.WriteLine(CommandLineParser.COMMAND_LINE_SYNTAX);
                    Console.ReadLine();
                    return 1;
                }

                if (parser.Id == Guid.Empty)
                {
                    Console.WriteLine(CommandLineParser.EMPTY_GUID_MESSAGE);
                    Console.ReadLine();
                    return 1;
                }

                var o = new Program();
                o.Execute(parser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }
            return 0;
        }

        /// <summary>
        /// Execute the application logic
        /// </summary>
        /// <param name="parser"></param>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.</exception>
        /// <exception cref="System.FormatException">The exception that is thrown when the format of an argument does not meet the parameter specifications of the invoked method.</exception>
        /// <exception cref="System.IO.IOException">The exception that is thrown when an I/O error occurs.</exception>
        public virtual void Execute(CommandLineParser parser)
        {
            // Parse the game definition file
            Exception parseEx;
            var index = new Games();
            if (!index.TryParse(out parseEx))
            {
                Console.WriteLine("An error occurred parsing the games index file:");
                Console.WriteLine("  '{0}'", parseEx.Message);
                return;
            }

            // Launch the game from the definition file that matches the provided guid
            foreach (var game in index.Where(game => game.Id == parser.Id))
            {
                var session = new Session();
                session.StartTime = DateTime.Now;
                Console.WriteLine("Session Start Time: {0}", session.StartTime.ToString("s"));

                Exception gameEx;
                if (!TryCreateGameProcess(game, out gameEx))
                {
                    Console.WriteLine("An error occurred launching the game:");
                    Console.WriteLine("  '{0}'", gameEx.Message);
                    continue;
                }

                session.EndTime = DateTime.Now;
                Console.WriteLine("Session End Time: {0}", session.EndTime.ToString("s"));
                if (!game.TrySaveSessionStartEndDates(index.IndexFile, session, out gameEx))
                {
                    Console.WriteLine("An error occurred saving gameplay session data:");
                    Console.WriteLine("  '{0}'", gameEx.Message);
                    continue;
                }
            }
        }

        /// <summary>
        /// Try to populate this collection with the games in the index
        /// </summary>
        /// <param name="game">The game to load</param>
        /// <param name="exception">The first occurring <see cref="Exception"/></param>
        /// <returns>A <see cref="bool"/> flag to indicate the success or failure of the operation</returns>
        public virtual bool TryCreateGameProcess(Game game, out Exception exception)
        {
            var result = false;
            exception = null;
            try
            {
                CreateGameProcess(game);
                result = true;
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            return result;
        }

        /// <summary>
        /// Starts the game process. 
        /// </summary>
        /// <param name="game">The game to load</param>
        /// <returns>A <see cref="bool"/> flag to indicate success or failure of the operation.</returns>
        /// <exception cref="System.ArgumentException">The exception that is thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="System.IO.FileNotFoundException">The exception that is thrown when an attempt to access a file that does not exist on disk fails.</exception>
        protected internal virtual void CreateGameProcess(Game game)
        {
            if (!File.Exists(game.Path))
                throw new FileNotFoundException("Game binary does not exist: '{0}'", game.Path);

            var name = Path.GetFileName(game.Path);
            Console.WriteLine("Hooking process: {0} [{1}]", name, game.Id);

            var startInfo = new ProcessStartInfo
            {
                WorkingDirectory = Directory.GetParent(game.Path).FullName,
                FileName = name,
                Arguments = game.Args
            };
            try
            {
                var p = Process.Start(startInfo);
                p.WaitForExit();
            }
            /*When Process.Start(ProcessStartInfo) is called in Unix it invokes gvfs-open,
            which may not work for some applications.
            In that case, execute the game in the old-fashioned way.*/
            catch
            {
                Process.Start(game.Path + game.Args).WaitForExit();
            }
        }

        #endregion Methods
    }
}