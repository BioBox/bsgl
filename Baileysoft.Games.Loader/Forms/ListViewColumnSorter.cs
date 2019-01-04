//-----------------------------------------------------------------------
// Source File: "ListViewColumnSorter.cs"
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
namespace Baileysoft.Games.Loader.Forms
{
    using System;
    using System.Collections;
    using System.Windows.Forms;

    /// <summary>
    /// IComparer object for sorting WinForms ListView controls
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        #region Fields

        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private readonly CaseInsensitiveComparer _objectCompare;

        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int _columnToSort;

        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder _orderOfSort;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            _columnToSort = 0;

            // Initialize the sort order to 'none'
            _orderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            _objectCompare = new CaseInsensitiveComparer();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public virtual SortOrder Order
        {
            set { _orderOfSort = value; }
            get { return _orderOfSort; }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public virtual int SortColumn
        {
            set { _columnToSort = value; }
            get { return _columnToSort; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        /// <exception cref="System.ArgumentException">The exception that is thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The exception that is thrown when the value of an argument is outside the allowable range of values as defined by the invoked method.</exception>
        /// <exception cref="System.NullReferenceException">The exception that is thrown when there is an attempt to dereference a null object reference.</exception>
        public virtual int Compare(object x, object y)
        {
            // Cast the objects to be compared to ListViewItem objects
            var listviewX = (ListViewItem)x;
            var listviewY = (ListViewItem)y;

            if (listviewX == null || listviewY == null)
                throw new NullReferenceException("objectX and objectY cannot be null");

            // Compare the two items
            var compareResult = _objectCompare.Compare(listviewX.SubItems[_columnToSort].Text, listviewY.SubItems[_columnToSort].Text);

            // Calculate correct return value based on object comparison
            switch (_orderOfSort)
            {
                case SortOrder.Ascending:
                    // Ascending sort is selected, return normal result of compare operation
                    return compareResult;
                case SortOrder.Descending:
                    // Descending sort is selected, return negative result of compare operation
                    return (-compareResult);
                default:
                    return 0;
            }
        }

        #endregion Methods
    }
}