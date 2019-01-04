﻿//-----------------------------------------------------------------------
// Source File: "FrmConfig.cs"
// Create Date:  09/03/2017 12:00:00 PM
// Last Updated: 09/03/2017 12:09:00 PM
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
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Baileysoft.Games.Data;
    using Baileysoft.Games.Data.Repository;

    public partial class FrmConfig : Form
    {
        #region Fields

        private readonly ListViewColumnSorter _lvwColumnSorter = new ListViewColumnSorter();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmConfig()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates a desktop shortcut to launch the game
        /// </summary>
        /// <param name="game">The <see cref="Game"/> to create shortcut for</param>
        protected internal virtual void CreateDesktopShortcut(Game game)
        {
            var desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var linkName = Game.RemoveIllegalCharsFromFileName(game.Title);
            var linkPath = Path.Combine(desktopDir, linkName + ".lnk");
            var app = System.Reflection.Assembly.GetExecutingAssembly().Location;

            var shell = new IWshRuntimeLibrary.WshShell();
            var shortcut = shell.CreateShortcut(linkPath) as IWshRuntimeLibrary.IWshShortcut;
            shortcut.TargetPath = app;
            shortcut.WorkingDirectory = Application.StartupPath;
            shortcut.Arguments = game.Id.ToString();
            shortcut.IconLocation = game.Path.Replace('\\', '/');
            shortcut.Save();
        }

        /// <summary>
        /// Disables the textboxes.
        /// </summary>
        protected internal virtual void DisableTextBoxes()
        {
            txtGameTitle.ReadOnly = true;
            txtKey.ReadOnly = true;
            txtArgs.ReadOnly = true;
            txtGamePath.ReadOnly = true;
        }

        /// <summary>
        /// Enables the text boxes.
        /// </summary>
        protected internal virtual void EnableTextBoxes()
        {
            txtGameTitle.ReadOnly = false;
            txtArgs.ReadOnly = false;
            txtGamePath.ReadOnly = false;
        }

        /// <summary>
        /// Populate the lvGames listview from the data store.
        /// </summary>
        protected internal virtual void FillListView()
        {
            lvGames.Items.Clear();

            var gamesIdx = new Data.Games();
            Exception parseEx;
            if (!gamesIdx.TryParse(out parseEx))
            {
                SetErrorStatus("Parsing error occurred: " + parseEx.Message, false);
                return;
            }

            foreach (var game in gamesIdx)
            {
                var lvi = new ListViewItem(game.Title);
                var lvLastPlayed = new ListViewItem.ListViewSubItem();
                var lvTotal = new ListViewItem.ListViewSubItem();
                lvLastPlayed.Text = game.Sessions.Count == 0 ? "Never played" : game.Sessions.Last().EndTime.ToString("s");
                lvTotal.Text = game.Sessions.Count == 0 ? "Never played" : game.PlayTime.Total;
                lvi.SubItems.Add(lvLastPlayed);
                lvi.SubItems.Add(lvTotal);
                lvi.Tag = game;
                lvGames.Items.Add(lvi);
            }

            SetSuccessStatus($"Loaded '{ gamesIdx.Count }' game definitions into memory.");
        }

        /// <summary>
        /// Handler for Browse button.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> that triggered the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> relating to the event.</param>
        protected internal virtual void OnBtnBrowseClick(object sender, EventArgs e)
        {
            btnClear.PerformClick();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            openFileDialog1.Filter = "Executables (*.exe)|*.exe";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Select the game executable file";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (string.IsNullOrEmpty(openFileDialog1.FileName))
                        return;

                    txtGamePath.Text = openFileDialog1.FileName;
                    txtGameTitle.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    //SetSuccessStatus("Loaded query: " + openFileDialog1.FileName);
                    txtKey.Text = Guid.NewGuid().ToString();
                    BtnSave.Enabled = true;

                    EnableTextBoxes();
                }
                catch (Exception ex)
                {
                    //SetErrorStatus($"An error occurred: {ex.Message}.");
                }
            }
        }

        /// <summary>
        /// Handler for the Clear button.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> that triggered the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> relating to the event.</param>
        protected internal virtual void OnBtnClearClick(object sender, EventArgs e)
        {
            txtGamePath.Text = string.Empty;
            txtGameTitle.Text = string.Empty;
            txtArgs.Text = string.Empty;
            txtKey.Text = string.Empty;
            EnableTextBoxes();
            btnDelete.Enabled = false;

            SetSuccessStatus("Fields cleared. Click 'Browse' to add a new game.");
        }

        /// <summary>
        /// Handler for the Delete button.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> that triggered the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> relating to the event.</param>
        protected internal virtual void OnBtnDeleteClick(object sender, EventArgs e)
        {
            if (ShowPromptMsgBox("Are you sure you want to delete this game and all its history?", this.Text) == DialogResult.No)
                return;

            if (lvGames.SelectedItems.Count > 0)
            {
                var g = (Game)lvGames.SelectedItems[0].Tag;
                var gameRepo = new GameRepository();
                gameRepo.Delete(g);

                FillListView();
                SetSuccessStatus($"Deleted '{g.Title}' from the data store.");
                btnClear.PerformClick();
            }
        }

        /// <summary>
        /// Handler for the Save button.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> that triggered the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> relating to the event.</param>
        protected internal virtual void OnBtnSaveClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGameTitle.Text))
                SetErrorStatus("Game Title cannot be empty.", false);

            if (string.IsNullOrEmpty(txtGamePath.Text))
                SetErrorStatus("Game Path cannot be empty.", false);

            if (!File.Exists(txtGamePath.Text))
                SetErrorStatus("Game EXE file must exist.", false);

            var game = new Game();
            game.Title = txtGameTitle.Text;
            game.Path = txtGamePath.Text;
            game.Args = txtArgs.Text;
            game.Id = Guid.Parse(txtKey.Text);

            var gameRepo = new GameRepository();
            gameRepo.SaveOrUpdate(game);

            FillListView();
            btnClear.PerformClick();
            BtnSave.Enabled = false;

            Clipboard.SetText(game.Id.ToString());
            SetSuccessStatus($"Saved '{game.Title}'. Game Ref Key copied to clipboard.");
        }

        /// <summary>
        /// Handler for the Click event of the delete menu item in ctxContextMenu
        /// </summary>
        /// <param name="sender">The <see cref="object"/> that triggered the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> relating to the event.</param>
        protected internal virtual void OnCtxMenuLvGamesDeleteClick(object sender, EventArgs e)
        {
            OnBtnDeleteClick(sender, e);
        }

        /// <summary>
        /// Handler for the click event of the 'Game Folder' menu item in LvGames context menu.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> that triggered the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> relating to the event.</param>
        protected internal virtual void OnCtxMenuLvGamesFolderClick(object sender, EventArgs e)
        {
            if (lvGames.SelectedItems.Count > 0)
            {
                var g = (Game)lvGames.SelectedItems[0].Tag;
                var folder = Path.GetDirectoryName(g.Path);
                if (!Directory.Exists(folder))
                {
                    SetErrorStatus($"Directory not found: {folder}", false);
                    return;
                }

                Process.Start(folder);
                SetSuccessStatus($"Opened folder: '{folder}'");
            }
        }

        /// <summary>
        /// Handler for the Click event of the launch menu item in ctxContextMenu
        /// </summary>
        /// <param name="sender">The <see cref="object"/> that triggered the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> relating to the event.</param>
        protected internal virtual void OnCtxMenuLvGamesLaunchClick(object sender, EventArgs e)
        {
            if (lvGames.SelectedItems.Count > 0)
            {
                var g = (Game)lvGames.SelectedItems[0].Tag;
                SetSuccessStatus($"Launched game: {g.Title} [{g.Id}]");
                Program.Main(new string[] { g.Id.ToString() });
                FillListView();
            }
        }

        /// <summary>
        /// Handler for the Opening event of ctxMenuLvGames control
        /// </summary>
        /// <param name="sender">The <see cref="object"/> that triggered the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> relating to the event.</param>
        protected internal virtual void OnCtxMenuLvGamesOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ctxMenuLvGamesDelete.Enabled = lvGames.SelectedItems.Count > 0;
            ctxMenuLvGamesLaunch.Enabled = lvGames.SelectedItems.Count > 0;
            ctxMenuLvGamesShortcut.Enabled = lvGames.SelectedItems.Count > 0;
        }

        /// <summary>
        /// Handler for the Click event of the 'Dsktop Shortcut' menu item in the ctxMenuLvGames control
        /// </summary>
        /// <param name="sender">The <see cref="object"/> that triggered the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> relating to the event.</param>
        protected internal virtual void OnCtxMenuLvGamesShortcutClick(object sender, EventArgs e)
        {
            if (lvGames.SelectedItems.Count > 0)
            {
                var g = (Game)lvGames.SelectedItems[0].Tag;
                CreateDesktopShortcut(g);
                SetSuccessStatus($"Created desktop shortcut for game: '{g.Title}'");
            }
        }

        /// <summary>
        /// Handler for the Form_Load event
        /// </summary>
        /// <param name="sender">The <see cref="object"/> that triggered the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> relating to the event.</param>
        protected internal virtual void OnFrmConfigLoad(object sender, System.EventArgs e)
        {
            FillListView();
            lvGames.ListViewItemSorter = _lvwColumnSorter;
        }

        /// <summary>
        /// Handler for the ColumnClick event in the lvGames <see cref="ListView"/>.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> that triggered the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> relating to the event.</param>
        protected internal virtual void OnLvGamesColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == _lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                _lvwColumnSorter.Order = (_lvwColumnSorter.Order == SortOrder.Ascending)
                    ? SortOrder.Descending
                    : SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _lvwColumnSorter.SortColumn = e.Column;
                _lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lvGames.Sort();
        }

        /// <summary>
        /// Handler for the SelectedIndexChanged event in the lvGames <see cref="ListView"/>.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> that triggered the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> relating to the event.</param>
        protected internal virtual void OnLvGamesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGames.SelectedItems.Count == 0)
                return;

            var selected = (Game)lvGames.SelectedItems[0].Tag;
            txtArgs.Text = selected.Args;
            txtGamePath.Text = selected.Path;
            txtGameTitle.Text = selected.Title;
            txtKey.Text = selected.Id.ToString();
            DisableTextBoxes();
            btnDelete.Enabled = true;

            var msg = (!string.IsNullOrEmpty(selected.PlayTime.TotalFormatted))
                ? $"{selected.Title} played: {selected.PlayTime.TotalFormatted}"
                : $"{selected.Title} has never been played.";

            SetSuccessStatus(msg);
        }

        /// <summary>
        /// Handler for the Game > Add New Game menu item.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> that triggered the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> relating to the event.</param>
        protected internal virtual void OnMenuItemGameAddNewTspClick(object sender, EventArgs e)
        {
            btnBrowse.PerformClick();
        }

        /// <summary>
        /// Handler for the Game > Hide/Show Panel menu item.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> that triggered the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> relating to the event.</param>
        protected internal virtual void OnMenuItemGameAddTspClick(object sender, System.EventArgs e)
        {
            pnlGameAdd.Visible = (!pnlGameAdd.Visible);
        }

        /// <summary>
        /// Handler for the Help > QuickStart guide menu item.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> that triggered the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> relating to the event.</param>
        protected internal virtual void OnMenuItemHelpGuideTspClick(object sender, EventArgs e)
        {
            var path = Path.Combine(Application.StartupPath, "QuickStart.pdf");
            if (!File.Exists(path))
            {
                SetErrorStatus("Couldn't find quickStart guide.", false);
                return;
            }
            Process.Start(path);
            SetSuccessStatus($"Opened guide: '{path}'");
        }

        /// <summary>
        /// Report a failed activity in the status bar
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="showMsgBox">Display the messageBox</param>
        protected internal virtual void SetErrorStatus(string message, bool showMsgBox)
        {
            message = message.Replace("\r", "-").Replace("\n", "-");
            StatusStripLabel.Image = global::Baileysoft.Games.Loader.Properties.Resources.error;
            var truncMessage = message;

            //var strLimit = int.Parse(Settings.GetValue(Settings.Strings.STATUSLENGTHLIMIT, "100"));
            var strLimit = 100;
            if (message.Length > strLimit && WindowState != FormWindowState.Maximized)
                truncMessage = message.Substring(0, strLimit);

            StatusStripLabel.Text = truncMessage;

            if (showMsgBox)
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Report a successful activity in the status bar
        /// </summary>
        /// <param name="message">The message to display.</param>
        protected internal virtual void SetSuccessStatus(string message)
        {
            StatusStripLabel.Image = global::Baileysoft.Games.Loader.Properties.Resources.info;
            var truncMessage = message;

            var strLimit = 100;

            if (message.Length > strLimit && WindowState != FormWindowState.Maximized)
                truncMessage = message.Substring(0, strLimit);

            StatusStripLabel.Text = truncMessage;
        }

        /// <summary>
        /// Dialog Prompt
        /// </summary>
        /// <param name="message">Text to display.</param>
        /// <param name="title">Message box title text</param>
        /// <returns><see cref="DialogResult"/></returns>
        [DebuggerNonUserCode]
        protected internal virtual DialogResult ShowPromptMsgBox(string message, string title)
        {
            return MessageBox.Show(
                ((message == null) ? string.Empty : message),
                ((title == null) ? string.Empty : title),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }

        #endregion Methods
    }
}