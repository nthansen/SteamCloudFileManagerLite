namespace SteamCloudFileManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            remoteListView = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            label1 = new System.Windows.Forms.Label();
            appIdTextBox = new System.Windows.Forms.TextBox();
            connectButton = new System.Windows.Forms.Button();
            refreshButton = new System.Windows.Forms.Button();
            quotaLabel = new System.Windows.Forms.Label();
            deleteButton = new System.Windows.Forms.Button();
            downloadButton = new System.Windows.Forms.Button();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            uploadButton = new System.Windows.Forms.Button();
            uploadBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            loadUserProfilesButton = new System.Windows.Forms.Button();
            userProfileList = new System.Windows.Forms.ComboBox();
            loadLocalGamesButton = new System.Windows.Forms.Button();
            gamesList = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // remoteListView
            // 
            remoteListView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            remoteListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            remoteListView.FullRowSelect = true;
            remoteListView.Location = new System.Drawing.Point(18, 47);
            remoteListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            remoteListView.Name = "remoteListView";
            remoteListView.Size = new System.Drawing.Size(1075, 369);
            remoteListView.TabIndex = 0;
            remoteListView.UseCompatibleStateImageBehavior = false;
            remoteListView.View = System.Windows.Forms.View.Details;
            remoteListView.SelectedIndexChanged += remoteListView_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 196;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Timestamp";
            columnHeader2.Width = 161;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Size";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Is Persisted";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Exists";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(14, 20);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 15);
            label1.TabIndex = 1;
            label1.Text = "AppID:";
            // 
            // appIdTextBox
            // 
            appIdTextBox.Location = new System.Drawing.Point(68, 16);
            appIdTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            appIdTextBox.Name = "appIdTextBox";
            appIdTextBox.Size = new System.Drawing.Size(116, 23);
            appIdTextBox.TabIndex = 2;
            // 
            // connectButton
            // 
            connectButton.Location = new System.Drawing.Point(191, 14);
            connectButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            connectButton.Name = "connectButton";
            connectButton.Size = new System.Drawing.Size(88, 27);
            connectButton.TabIndex = 3;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Enabled = false;
            refreshButton.Location = new System.Drawing.Point(286, 14);
            refreshButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new System.Drawing.Size(88, 27);
            refreshButton.TabIndex = 4;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // quotaLabel
            // 
            quotaLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            quotaLabel.Location = new System.Drawing.Point(380, 10);
            quotaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            quotaLabel.Name = "quotaLabel";
            quotaLabel.Size = new System.Drawing.Size(713, 27);
            quotaLabel.TabIndex = 5;
            quotaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            deleteButton.Enabled = false;
            deleteButton.Location = new System.Drawing.Point(108, 424);
            deleteButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new System.Drawing.Size(88, 27);
            deleteButton.TabIndex = 6;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // downloadButton
            // 
            downloadButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            downloadButton.Enabled = false;
            downloadButton.Location = new System.Drawing.Point(14, 424);
            downloadButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new System.Drawing.Size(88, 27);
            downloadButton.TabIndex = 7;
            downloadButton.Text = "Download";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += downloadButton_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "All files|*";
            saveFileDialog1.Title = "Save remote file as...";
            // 
            // openFileDialog1
            // 
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "Select files to upload";
            // 
            // uploadButton
            // 
            uploadButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            uploadButton.Enabled = false;
            uploadButton.Location = new System.Drawing.Point(203, 424);
            uploadButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            uploadButton.Name = "uploadButton";
            uploadButton.Size = new System.Drawing.Size(88, 27);
            uploadButton.TabIndex = 8;
            uploadButton.Text = "Upload";
            uploadButton.UseVisualStyleBackColor = true;
            uploadButton.Click += uploadButton_Click;
            // 
            // uploadBackgroundWorker
            // 
            uploadBackgroundWorker.DoWork += uploadBackgroundWorker_DoWork;
            uploadBackgroundWorker.RunWorkerCompleted += uploadBackgroundWorker_RunWorkerCompleted;
            // 
            // loadUserProfilesButton
            // 
            loadUserProfilesButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            loadUserProfilesButton.Location = new System.Drawing.Point(520, 16);
            loadUserProfilesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loadUserProfilesButton.Name = "loadUserProfilesButton";
            loadUserProfilesButton.Size = new System.Drawing.Size(120, 27);
            loadUserProfilesButton.TabIndex = 9;
            loadUserProfilesButton.Text = "Load User Profiles";
            loadUserProfilesButton.UseVisualStyleBackColor = true;
            loadUserProfilesButton.Click += loadUserProfilesButton_Click;
            // 
            // userProfileList
            // 
            userProfileList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            userProfileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            userProfileList.FormattingEnabled = true;
            userProfileList.Items.AddRange(new object[] { "test", "test1", "test2", "test3", "test4" });
            userProfileList.Location = new System.Drawing.Point(648, 17);
            userProfileList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            userProfileList.Name = "userProfileList";
            userProfileList.Size = new System.Drawing.Size(178, 23);
            userProfileList.TabIndex = 10;
            userProfileList.SelectedIndexChanged += userProfileList_SelectedIndexChanged;
            // 
            // loadLocalGamesButton
            // 
            loadLocalGamesButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            loadLocalGamesButton.Location = new System.Drawing.Point(590, 424);
            loadLocalGamesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loadLocalGamesButton.Name = "loadLocalGamesButton";
            loadLocalGamesButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            loadLocalGamesButton.Size = new System.Drawing.Size(120, 27);
            loadLocalGamesButton.TabIndex = 11;
            loadLocalGamesButton.Text = "Load Local Games";
            loadLocalGamesButton.UseVisualStyleBackColor = true;
            loadLocalGamesButton.Click += loadLocalGamesButton_Click;
            // 
            // gamesList
            // 
            gamesList.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            gamesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            gamesList.FormattingEnabled = true;
            gamesList.Items.AddRange(new object[] { "test", "test1", "test2", "test3", "test4" });
            gamesList.Location = new System.Drawing.Point(718, 424);
            gamesList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gamesList.Name = "gamesList";
            gamesList.Size = new System.Drawing.Size(374, 23);
            gamesList.TabIndex = 12;
            gamesList.SelectedIndexChanged += gamesList_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1107, 464);
            Controls.Add(gamesList);
            Controls.Add(loadLocalGamesButton);
            Controls.Add(userProfileList);
            Controls.Add(loadUserProfilesButton);
            Controls.Add(uploadButton);
            Controls.Add(downloadButton);
            Controls.Add(deleteButton);
            Controls.Add(remoteListView);
            Controls.Add(quotaLabel);
            Controls.Add(refreshButton);
            Controls.Add(connectButton);
            Controls.Add(appIdTextBox);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Steam Cloud File Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListView remoteListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox appIdTextBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label quotaLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button uploadButton;
        private System.ComponentModel.BackgroundWorker uploadBackgroundWorker;
        private System.Windows.Forms.Button loadUserProfilesButton;
        private System.Windows.Forms.ComboBox userProfileList;
        private System.Windows.Forms.Button loadLocalGamesButton;
        private System.Windows.Forms.ComboBox gamesList;
    }
}

