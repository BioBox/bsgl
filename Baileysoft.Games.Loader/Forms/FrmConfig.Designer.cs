namespace Baileysoft.Games.Loader.Forms
{
    partial class FrmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemGameTsp = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lvGames = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxMenuLvGames = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlGameAdd = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtArgs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGamePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGameTitle = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxMenuLvGamesFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuLvGamesLaunch = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuLvGamesShortcut = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuLvGamesDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuItemGameAddNewTsp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGameAddTsp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHelpGuideTsp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.ctxMenuLvGames.SuspendLayout();
            this.pnlGameAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemGameTsp,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(801, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemGameTsp
            // 
            this.MenuItemGameTsp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemGameAddNewTsp,
            this.toolStripSeparator2,
            this.MenuItemGameAddTsp});
            this.MenuItemGameTsp.Name = "MenuItemGameTsp";
            this.MenuItemGameTsp.Size = new System.Drawing.Size(50, 19);
            this.MenuItemGameTsp.Text = "Game";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemHelpGuideTsp});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusStripLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(801, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lvGames
            // 
            this.lvGames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvGames.ContextMenuStrip = this.ctxMenuLvGames;
            this.lvGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGames.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvGames.FullRowSelect = true;
            this.lvGames.GridLines = true;
            this.lvGames.Location = new System.Drawing.Point(0, 187);
            this.lvGames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvGames.MultiSelect = false;
            this.lvGames.Name = "lvGames";
            this.lvGames.ShowGroups = false;
            this.lvGames.Size = new System.Drawing.Size(801, 152);
            this.lvGames.TabIndex = 2;
            this.lvGames.UseCompatibleStateImageBehavior = false;
            this.lvGames.View = System.Windows.Forms.View.Details;
            this.lvGames.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.OnLvGamesColumnClick);
            this.lvGames.SelectedIndexChanged += new System.EventHandler(this.OnLvGamesSelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Game Title";
            this.columnHeader1.Width = 299;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Last Played";
            this.columnHeader2.Width = 274;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Total";
            this.columnHeader3.Width = 151;
            // 
            // ctxMenuLvGames
            // 
            this.ctxMenuLvGames.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            // Clicking this button causes Ubuntu to freeze
            #if !LINUX
            this.ctxMenuLvGamesLaunch,
            #endif
            this.ctxMenuLvGamesShortcut,
            this.ctxMenuLvGamesFolder,
            this.toolStripSeparator1,
            this.ctxMenuLvGamesDelete});
            this.ctxMenuLvGames.Name = "ctxMenuLvGames";
            this.ctxMenuLvGames.Size = new System.Drawing.Size(166, 120);
            this.ctxMenuLvGames.Opening += new System.ComponentModel.CancelEventHandler(this.OnCtxMenuLvGamesOpening);
            // 
            // pnlGameAdd
            // 
            this.pnlGameAdd.Controls.Add(this.btnDelete);
            this.pnlGameAdd.Controls.Add(this.btnClear);
            this.pnlGameAdd.Controls.Add(this.btnBrowse);
            this.pnlGameAdd.Controls.Add(this.BtnSave);
            this.pnlGameAdd.Controls.Add(this.pictureBox1);
            this.pnlGameAdd.Controls.Add(this.label4);
            this.pnlGameAdd.Controls.Add(this.txtKey);
            this.pnlGameAdd.Controls.Add(this.label3);
            this.pnlGameAdd.Controls.Add(this.txtArgs);
            this.pnlGameAdd.Controls.Add(this.label2);
            this.pnlGameAdd.Controls.Add(this.txtGamePath);
            this.pnlGameAdd.Controls.Add(this.label1);
            this.pnlGameAdd.Controls.Add(this.txtGameTitle);
            this.pnlGameAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGameAdd.Location = new System.Drawing.Point(0, 25);
            this.pnlGameAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlGameAdd.Name = "pnlGameAdd";
            this.pnlGameAdd.Size = new System.Drawing.Size(801, 162);
            this.pnlGameAdd.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Franklin Gothic Book", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(563, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 30);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.OnBtnDeleteClick);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Franklin Gothic Book", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(563, 69);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 30);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.OnBtnClearClick);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Font = new System.Drawing.Font("Franklin Gothic Book", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowse.Location = new System.Drawing.Point(563, 6);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(65, 30);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.OnBtnBrowseClick);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Enabled = false;
            this.BtnSave.Font = new System.Drawing.Font("Franklin Gothic Book", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSave.Location = new System.Drawing.Point(563, 37);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(65, 30);
            this.BtnSave.TabIndex = 5;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.OnBtnSaveClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Demi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(128, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Ref Key #";
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.ForeColor = System.Drawing.Color.Crimson;
            this.txtKey.Location = new System.Drawing.Point(209, 104);
            this.txtKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(347, 22);
            this.txtKey.TabIndex = 3;
            this.txtKey.Text = "544ED8F3-1C49-4582-B6C1-D6E132FDEA6A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Demi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Arguments (Optional)";
            // 
            // txtArgs
            // 
            this.txtArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArgs.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArgs.Location = new System.Drawing.Point(209, 73);
            this.txtArgs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtArgs.Name = "txtArgs";
            this.txtArgs.Size = new System.Drawing.Size(347, 22);
            this.txtArgs.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Demi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Game EXE Path";
            // 
            // txtGamePath
            // 
            this.txtGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGamePath.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGamePath.Location = new System.Drawing.Point(209, 42);
            this.txtGamePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGamePath.Name = "txtGamePath";
            this.txtGamePath.Size = new System.Drawing.Size(347, 22);
            this.txtGamePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Demi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Game Title";
            // 
            // txtGameTitle
            // 
            this.txtGameTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGameTitle.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGameTitle.Location = new System.Drawing.Point(209, 10);
            this.txtGameTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGameTitle.Name = "txtGameTitle";
            this.txtGameTitle.Size = new System.Drawing.Size(347, 22);
            this.txtGameTitle.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "disk.png");
            this.imageList1.Images.SetKeyName(1, "error.png");
            this.imageList1.Images.SetKeyName(2, "info.png");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // ctxMenuLvGamesFolder
            // 
            this.ctxMenuLvGamesFolder.Image = global::Baileysoft.Games.Loader.Properties.Resources.folder;
            this.ctxMenuLvGamesFolder.Name = "ctxMenuLvGamesFolder";
            this.ctxMenuLvGamesFolder.Size = new System.Drawing.Size(165, 22);
            this.ctxMenuLvGamesFolder.Text = "Game Folder";
            this.ctxMenuLvGamesFolder.Click += new System.EventHandler(this.OnCtxMenuLvGamesFolderClick);
            // 
            // ctxMenuLvGamesLaunch
            // 
            this.ctxMenuLvGamesLaunch.Image = global::Baileysoft.Games.Loader.Properties.Resources.play;
            this.ctxMenuLvGamesLaunch.Name = "ctxMenuLvGamesLaunch";
            this.ctxMenuLvGamesLaunch.Size = new System.Drawing.Size(165, 22);
            this.ctxMenuLvGamesLaunch.Text = "Launch Game";
            this.ctxMenuLvGamesLaunch.Click += new System.EventHandler(this.OnCtxMenuLvGamesLaunchClick);
            // 
            // ctxMenuLvGamesShortcut
            // 
            this.ctxMenuLvGamesShortcut.Image = global::Baileysoft.Games.Loader.Properties.Resources.shortcut;
            this.ctxMenuLvGamesShortcut.Name = "ctxMenuLvGamesShortcut";
            this.ctxMenuLvGamesShortcut.Size = new System.Drawing.Size(165, 22);
            this.ctxMenuLvGamesShortcut.Text = "Desktop Shortcut";
            this.ctxMenuLvGamesShortcut.Click += new System.EventHandler(this.OnCtxMenuLvGamesShortcutClick);
            // 
            // ctxMenuLvGamesDelete
            // 
            this.ctxMenuLvGamesDelete.Image = global::Baileysoft.Games.Loader.Properties.Resources.delete;
            this.ctxMenuLvGamesDelete.Name = "ctxMenuLvGamesDelete";
            this.ctxMenuLvGamesDelete.Size = new System.Drawing.Size(165, 22);
            this.ctxMenuLvGamesDelete.Text = "Delete Record";
            this.ctxMenuLvGamesDelete.Click += new System.EventHandler(this.OnCtxMenuLvGamesDeleteClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(634, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 162);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // StatusStripLabel
            // 
            this.StatusStripLabel.Image = global::Baileysoft.Games.Loader.Properties.Resources.info;
            this.StatusStripLabel.Name = "StatusStripLabel";
            this.StatusStripLabel.Size = new System.Drawing.Size(16, 16);
            // 
            // MenuItemGameAddNewTsp
            // 
            this.MenuItemGameAddNewTsp.Image = global::Baileysoft.Games.Loader.Properties.Resources.add;
            this.MenuItemGameAddNewTsp.Name = "MenuItemGameAddNewTsp";
            this.MenuItemGameAddNewTsp.Size = new System.Drawing.Size(165, 22);
            this.MenuItemGameAddNewTsp.Text = "Add New Game";
            this.MenuItemGameAddNewTsp.Click += new System.EventHandler(this.OnMenuItemGameAddNewTspClick);
            // 
            // MenuItemGameAddTsp
            // 
            this.MenuItemGameAddTsp.Image = global::Baileysoft.Games.Loader.Properties.Resources.panel;
            this.MenuItemGameAddTsp.Name = "MenuItemGameAddTsp";
            this.MenuItemGameAddTsp.Size = new System.Drawing.Size(165, 22);
            this.MenuItemGameAddTsp.Text = "Hide/Show Panel";
            this.MenuItemGameAddTsp.Click += new System.EventHandler(this.OnMenuItemGameAddTspClick);
            // 
            // MenuItemHelpGuideTsp
            // 
            this.MenuItemHelpGuideTsp.Image = global::Baileysoft.Games.Loader.Properties.Resources.pdf;
            this.MenuItemHelpGuideTsp.Name = "MenuItemHelpGuideTsp";
            this.MenuItemHelpGuideTsp.Size = new System.Drawing.Size(166, 22);
            this.MenuItemHelpGuideTsp.Text = "Quick Start Guide";
            this.MenuItemHelpGuideTsp.Click += new System.EventHandler(this.OnMenuItemHelpGuideTspClick);
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 361);
            this.Controls.Add(this.lvGames);
            this.Controls.Add(this.pnlGameAdd);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "FrmConfig";
            this.Text = "Baileysoft.Games.Loader.FrmConfig (Baileysoft 2017)";
            this.Load += new System.EventHandler(this.OnFrmConfigLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ctxMenuLvGames.ResumeLayout(false);
            this.pnlGameAdd.ResumeLayout(false);
            this.pnlGameAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGameTsp;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGameAddTsp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView lvGames;
        private System.Windows.Forms.Panel pnlGameAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGamePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGameTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtArgs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripStatusLabel StatusStripLabel;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGameAddNewTsp;
        private System.Windows.Forms.ContextMenuStrip ctxMenuLvGames;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuLvGamesLaunch;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuLvGamesShortcut;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuLvGamesDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHelpGuideTsp;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuLvGamesFolder;
    }
}