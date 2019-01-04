//-----------------------------------------------------------------------
// Source File: "ObjectList.cs"
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
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Template class for adding Type specific Methods and Properties to an otherwise Generic List.
    /// </summary>
    /// <remarks>
    /// Unlike the ToString() method for Generic Lists the implementation of 
    /// the ToString method in this class, calls the ToString method for each 
    /// Object contained in the list.
    /// <para> </para>
    /// If your derived class will only require the 'Default' Constructor, then
    /// you do not have to implement ANY constructors. 
    /// <para>However, if you require ANY Additional Constructors (base or otherwise),
    /// then you MUST implement ALL of the constructors defined here.</para>
    /// </remarks>
    /// <typeparam name="T">Object Type contained in the list</typeparam>
    public class ObjectList<T> : List<T>, IObjectList<T>
    {
        #region Fields

        /// <summary>Storage for the ToStringSeperator property.</summary>
        protected string m_ToStringSeperator = "\n";

        #endregion Fields

        #region Constructors

        // ***********************************************************************
        // NOTES:
        // ***********************************************************************
        // If your derived class will only require the 'Default' Constructor, then
        // you do not have to implement ANY constructors.  However, if you require
        // ANY Additional Constructors (base or otherwise), the you MUST implement
        // ALL of the constructors defined here.
        // ***********************************************************************
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public ObjectList() : base() { }

        /// <summary>
        /// Constructor used for making a duplicate of the list. 
        /// <para>Objects contained in the list are 'shared' among all duplicate lists. </para>
        /// <para>Null objects are included.</para>
        /// </summary>
        /// <param name="collection">Object list to duplicate.</param>
        public ObjectList(IEnumerable<T> collection) : base(collection) { }

        /// <summary>
        /// Constructor specifying the initial capacity of the list.
        /// </summary>
        /// <param name="initialSize">Initial capacity of the list.</param>
        public ObjectList(Int32 initialSize) : base(initialSize) { }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Seperator used between object.ToString() in the ToString() method. 
        /// <para>Default is "\n".</para>
        /// </summary>
        public virtual string ToStringSeperator
        {
            get { return m_ToStringSeperator; }
            set { m_ToStringSeperator = (string.IsNullOrEmpty(value) ? "\n" : value); }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns the result of calling the ToString method for each Object contained
        /// in the list, seperated by the ToStringSeperator property value.
        /// </summary>
        /// <returns>String representation of the objects containd in the list.</returns>
        public override string ToString()
        {
            string result = string.Empty;

            foreach (object o in this)
            {
                if (o == null)
                    continue;

                if (result.Length > 0)
                    result += ToStringSeperator;
                if (o != null)
                    result += o.ToString();
            }
            return result;
        }

        #endregion Methods
    }
}