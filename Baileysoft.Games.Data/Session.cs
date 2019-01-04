//-----------------------------------------------------------------------
// Source File: "Session.cs"
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
    using System;

    /// <summary>
    /// Session abstraction
    /// </summary>
    public class Session
    {
        #region Properties

        /// <summary>
        /// The session begin time
        /// </summary>
        public virtual DateTime StartTime { get; set; }

        /// <summary>
        /// The session end time
        /// </summary>
        public virtual DateTime EndTime { get; set; }

        /// <summary>
        /// The total playtime for the session
        /// </summary>
        public virtual string Total => CalculatePlayTime();

        #endregion

        #region Methods

        /// <summary>
        /// Calculates the playtime total for the session.
        /// </summary>
        /// <returns></returns>
        protected internal virtual string CalculatePlayTime()
        {
            var span = (EndTime - StartTime);
            var strDifference = span.ToString(@"hh\:mm\:ss");
            return strDifference;
        }

        #endregion
    }
}
