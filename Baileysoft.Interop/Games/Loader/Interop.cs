//-----------------------------------------------------------------------
// Source File: "Interop.cs"
// Create Date:  12/28/2015 11:30:00 AM
// Last Updated: 12/28/2015 11:30:00 AM
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
    using System.Runtime.InteropServices;

    /// <summary>
    /// Wrapper for native API calls
    /// </summary>
    public class Interop
    {
        #region Fields

        /// <summary>
        /// Closes the window.
        /// </summary>
        public const int SC_CLOSE = 0xF060;

        /// <summary>
        /// Message pump for Window system command messages.
        /// </summary>
        public const int WM_SYSCOMMAND = 0x0112;

        /// <summary>
        /// Hides the window and activates another window.
        /// </summary>
        public const int SW_HIDE = 0;

        /// <summary>
        /// Activates the window and displays it in its current size and position.
        /// </summary>
        public const int SW_SHOW = 5;

        #endregion Fields

        #region Methods

        /// <summary>
        /// API used to find the native window handle of the 3DM dialog.
        /// </summary>
        /// <param name="lpClassName">Windows class name</param>
        /// <param name="lpWindowName">Title bar text.</param>
        /// <returns><see cref="int"/> - Window handle.</returns>
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// Retrieves a handle to the foreground window (the window with which the user is currently working). 
        /// The system assigns a slightly higher priority to the thread that creates the foreground window than it does to other threads.
        /// </summary>
        /// <returns><see cref="IntPtr"/></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// Sends a windows processing message to a windows form
        /// </summary>
        /// <param name="handle">The handle on the form</param>
        /// <param name="message">the message being sent</param>
        /// <param name="wParam">a parameter used to set the messae code</param>
        /// <param name="lParam">a string that can be used for processing a new command</param>
        /// <returns><see cref="int"/></returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        /// <summary>
        /// Brings the thread that created the specified window into the foreground and activates the window. Keyboard input is 
        /// directed to the window,  and various visual cues are changed for the user. The system assigns a slightly higher priority 
        /// to the thread that created the foreground window than it does to other threads.
        /// </summary>
        /// <param name="hWnd">A handle to the window that should be activated and brought to the foreground.</param>
        /// <returns><see cref="IntPtr"/></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetForegroundWindow(int hWnd);

        /// <summary>
        /// Retrieves the window handle used by the console associated with the calling process.
        /// </summary>
        /// <returns>The return value is a handle to the window used by the console associated with the calling process or NULL if there is no such associated console.</returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();

        /// <summary>
        /// Sets the specified window's show state.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="nCmdShow">Controls how the window is to be shown. </param>
        /// <returns>If the window was previously visible, the return value is nonzero otherwise zero.</returns>
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        #endregion Methods
    }
}