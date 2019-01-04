//-----------------------------------------------------------------------
// Source File: "CommandLineParser.cs"
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

    /// <summary>
    /// Console application command line parser.
    /// </summary>
    public class CommandLineParser
    {
        #region Fields

        /// <summary>
        /// Description of available command line arguments.
        /// </summary>
        public const string COMMAND_LINE_HEADER = 
            "Baileysoft.Games.Loader:\r\n" +
            "    Copyright 2017 Baileysoft Solutions. \r\n\r\n";

        /// <summary>
        /// Description of available command line arguments.
        /// </summary>
        public const string COMMAND_LINE_SYNTAX = 
            "Command line arguments:\r\n" +
            "    [id] The guid value for the target game. \r\n" +
            "    [/?] syntax help.\r\n";

        /// <summary>
        /// Description of available command line arguments.
        /// </summary>
        public const string EMPTY_GUID_MESSAGE = 
            "Game ID cannot be empty:\r\n" +
            "    Valid:   Baileysoft.Games.Loader.exe FF2867EC-4435-4706-BD3E-134E5E8E20FA \r\n" +
            "    Invalid: Baileysoft.Games.Loader.exe 00000000-0000-0000-0000-000000000000 \r\n";

        private const string ARG_HELP = "/?";

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public CommandLineParser()
        {
            Initialize();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public CommandLineParser(string[] args)
        {
            Initialize();
            if (args != null)
                Parse(args);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Indicates that command line syntax is to be displayed.
        /// </summary>
        public virtual bool Help { get; set; }

        /// <summary>
        /// The provided game ID guid
        /// </summary>
        public virtual Guid Id { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Initializes class properties.
        /// </summary>
        protected internal virtual void Initialize()
        {
            Help = false;
        }

        /// <summary>
        /// Parses (processes) command line arguments.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        protected internal virtual void Parse(string[] args)
        {
            foreach (var arg in args)
                Parse(arg);
        }

        /// <summary>
        /// Parses (processes) a single command line argument.
        /// </summary>
        /// <param name="arg">Command line argument.</param>
        /// <exception cref="System.ArgumentException">The exception that is thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The exception that is thrown when the value of an argument is outside the allowable range of values as defined by the invoked method.</exception>
        protected internal virtual void Parse(string arg)
        {
            Console.WriteLine(COMMAND_LINE_HEADER);
            if (string.IsNullOrEmpty(arg))
                return;

            if (arg.StartsWith(ARG_HELP, StringComparison.OrdinalIgnoreCase))
            {
                Help = true;
            }

            Guid tempGuid;
            if (Guid.TryParse(arg, out tempGuid))
                Id = new Guid(arg);
        }

        #endregion Methods
    }
}