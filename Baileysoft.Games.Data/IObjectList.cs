//-----------------------------------------------------------------------
// Source File: "IObjectList.cs"
// Create Date: 6/8/2017 3:31:08 PM
// Last Updated: 6/8/2017 3:31:08 PM
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
// Copyright (c) 2014-2017 Baileysoft Solutions
//-----------------------------------------------------------------------
namespace Baileysoft.Games.Data
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface that encapulates the generic <see cref="ICollection{T}"/> interfaces. 
    /// <para>Additionally it defines the ToStringSeperator property that may be used to delimit individual items within the collection when the ToString() method is called.</para>
    /// </summary>
    /// <typeparam name="T">Object Type contained in this collection.</typeparam>
    public interface IObjectList<T> : IList<T>, IEnumerable<T>, ICollection<T>
    {
        #region Properties

        /// <summary>
        /// Seperator used between object.ToString() in the ToString() method.
        /// </summary>
        /// <remarks>Default is "\n".</remarks>
        string ToStringSeperator
        {
            get; set;
        }

        #endregion Properties
    }
}