namespace VideoGameMusicDownloader
{
    partial class MainWindow
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
            if ( disposing && (components != null) )
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
            this.OpenWebsiteButton = new System.Windows.Forms.Button();
            this.AlbumAddressTextBox = new System.Windows.Forms.TextBox();
            this.AlbumDownloadInformationButton = new System.Windows.Forms.Button();
            this.AlbumInfoNameValueLabel = new System.Windows.Forms.Label();
            this.TracksListDataGridView = new System.Windows.Forms.DataGridView();
            this.DownloadStartButton = new System.Windows.Forms.Button();
            this.DownloadCreateSubfolderCheckBox = new System.Windows.Forms.CheckBox();
            this.DownloadLocationTextBox = new System.Windows.Forms.TextBox();
            this.DownloadSelectLocationButton = new System.Windows.Forms.Button();
            this.AlbumAddressLabel = new System.Windows.Forms.Label();
            this.AlbumInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.AlbumInfoDateKeyLabel = new System.Windows.Forms.Label();
            this.AlbumInfoDateValueLabel = new System.Windows.Forms.Label();
            this.AlbumInfoSizeKeyLabel = new System.Windows.Forms.Label();
            this.AlbumInfoSizeValueLabel = new System.Windows.Forms.Label();
            this.AlbumInfoTrackCountKeyLabel = new System.Windows.Forms.Label();
            this.AlbumInfoTrackCountValueLabel = new System.Windows.Forms.Label();
            this.AlbumInfoNameKeyLabel = new System.Windows.Forms.Label();
            this.DownloadGropuBox = new System.Windows.Forms.GroupBox();
            this.DownloadOpenLocationButton = new System.Windows.Forms.Button();
            this.DownloadLocationLabel = new System.Windows.Forms.Label();
            this.ProgressTrackValueLabel = new System.Windows.Forms.Label();
            this.ProgressOverallValueLabel = new System.Windows.Forms.Label();
            this.ProgressTrackProgressBar = new System.Windows.Forms.ProgressBar();
            this.ProgressTrackLabel = new System.Windows.Forms.Label();
            this.ProgressOverallProgressBar = new System.Windows.Forms.ProgressBar();
            this.ProgressOverallLabel = new System.Windows.Forms.Label();
            this.TrackListLabel = new System.Windows.Forms.Label();
            this.AlbumSourceGroupBox = new System.Windows.Forms.GroupBox();
            this.ProgressGroupBox = new System.Windows.Forms.GroupBox();
            this.ProgressCancelButton = new System.Windows.Forms.Button();
            this.CopyrightLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TracksListDataGridView)).BeginInit();
            this.AlbumInfoGroupBox.SuspendLayout();
            this.DownloadGropuBox.SuspendLayout();
            this.AlbumSourceGroupBox.SuspendLayout();
            this.ProgressGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenWebsiteButton
            // 
            this.OpenWebsiteButton.Location = new System.Drawing.Point(9, 19);
            this.OpenWebsiteButton.Name = "OpenWebsiteButton";
            this.OpenWebsiteButton.Size = new System.Drawing.Size(390, 23);
            this.OpenWebsiteButton.TabIndex = 0;
            this.OpenWebsiteButton.Text = "Open Website in external Browser";
            this.OpenWebsiteButton.UseVisualStyleBackColor = true;
            this.OpenWebsiteButton.Click += new System.EventHandler(this.OpenWebsiteButton_Click);
            // 
            // AlbumAddressTextBox
            // 
            this.AlbumAddressTextBox.Location = new System.Drawing.Point(9, 61);
            this.AlbumAddressTextBox.Name = "AlbumAddressTextBox";
            this.AlbumAddressTextBox.Size = new System.Drawing.Size(390, 20);
            this.AlbumAddressTextBox.TabIndex = 1;
            this.AlbumAddressTextBox.TextChanged += new System.EventHandler(this.AlbumAddressTextBox_TextChanged);
            this.AlbumAddressTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AlbumAddressTextBox_KeyDown);
            this.AlbumAddressTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AlbumAddressTextBox_MouseDoubleClick);
            // 
            // AlbumDownloadInformationButton
            // 
            this.AlbumDownloadInformationButton.Location = new System.Drawing.Point(9, 87);
            this.AlbumDownloadInformationButton.Name = "AlbumDownloadInformationButton";
            this.AlbumDownloadInformationButton.Size = new System.Drawing.Size(390, 23);
            this.AlbumDownloadInformationButton.TabIndex = 2;
            this.AlbumDownloadInformationButton.Text = "Download Album Information";
            this.AlbumDownloadInformationButton.UseVisualStyleBackColor = true;
            this.AlbumDownloadInformationButton.Click += new System.EventHandler(this.AlbumDownloadInformationButton_Click);
            // 
            // AlbumInfoNameValueLabel
            // 
            this.AlbumInfoNameValueLabel.AutoSize = true;
            this.AlbumInfoNameValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlbumInfoNameValueLabel.Location = new System.Drawing.Point(3, 29);
            this.AlbumInfoNameValueLabel.Name = "AlbumInfoNameValueLabel";
            this.AlbumInfoNameValueLabel.Size = new System.Drawing.Size(0, 13);
            this.AlbumInfoNameValueLabel.TabIndex = 4;
            // 
            // TracksListDataGridView
            // 
            this.TracksListDataGridView.AllowUserToAddRows = false;
            this.TracksListDataGridView.AllowUserToDeleteRows = false;
            this.TracksListDataGridView.AllowUserToResizeColumns = false;
            this.TracksListDataGridView.AllowUserToResizeRows = false;
            this.TracksListDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.TracksListDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.TracksListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TracksListDataGridView.Location = new System.Drawing.Point(430, 28);
            this.TracksListDataGridView.MultiSelect = false;
            this.TracksListDataGridView.Name = "TracksListDataGridView";
            this.TracksListDataGridView.ReadOnly = true;
            this.TracksListDataGridView.RowHeadersVisible = false;
            this.TracksListDataGridView.RowTemplate.Height = 16;
            this.TracksListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TracksListDataGridView.Size = new System.Drawing.Size(385, 253);
            this.TracksListDataGridView.TabIndex = 5;
            // 
            // DownloadStartButton
            // 
            this.DownloadStartButton.Location = new System.Drawing.Point(6, 87);
            this.DownloadStartButton.Name = "DownloadStartButton";
            this.DownloadStartButton.Size = new System.Drawing.Size(393, 23);
            this.DownloadStartButton.TabIndex = 6;
            this.DownloadStartButton.Text = "Start Download";
            this.DownloadStartButton.UseVisualStyleBackColor = true;
            this.DownloadStartButton.Click += new System.EventHandler(this.TracksDownloadButton_Click);
            // 
            // DownloadCreateSubfolderCheckBox
            // 
            this.DownloadCreateSubfolderCheckBox.AutoSize = true;
            this.DownloadCreateSubfolderCheckBox.Checked = true;
            this.DownloadCreateSubfolderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DownloadCreateSubfolderCheckBox.Location = new System.Drawing.Point(262, 65);
            this.DownloadCreateSubfolderCheckBox.Name = "DownloadCreateSubfolderCheckBox";
            this.DownloadCreateSubfolderCheckBox.Size = new System.Drawing.Size(137, 17);
            this.DownloadCreateSubfolderCheckBox.TabIndex = 7;
            this.DownloadCreateSubfolderCheckBox.Text = "Create Album Subfolder";
            this.DownloadCreateSubfolderCheckBox.UseVisualStyleBackColor = true;
            // 
            // DownloadLocationTextBox
            // 
            this.DownloadLocationTextBox.Location = new System.Drawing.Point(6, 32);
            this.DownloadLocationTextBox.Name = "DownloadLocationTextBox";
            this.DownloadLocationTextBox.Size = new System.Drawing.Size(393, 20);
            this.DownloadLocationTextBox.TabIndex = 8;
            // 
            // DownloadSelectLocationButton
            // 
            this.DownloadSelectLocationButton.Location = new System.Drawing.Point(6, 58);
            this.DownloadSelectLocationButton.Name = "DownloadSelectLocationButton";
            this.DownloadSelectLocationButton.Size = new System.Drawing.Size(149, 23);
            this.DownloadSelectLocationButton.TabIndex = 9;
            this.DownloadSelectLocationButton.Text = "Select Download Location";
            this.DownloadSelectLocationButton.UseVisualStyleBackColor = true;
            this.DownloadSelectLocationButton.Click += new System.EventHandler(this.DownloadSelectLocationButton_Click);
            // 
            // AlbumAddressLabel
            // 
            this.AlbumAddressLabel.AutoSize = true;
            this.AlbumAddressLabel.Location = new System.Drawing.Point(6, 45);
            this.AlbumAddressLabel.Name = "AlbumAddressLabel";
            this.AlbumAddressLabel.Size = new System.Drawing.Size(146, 13);
            this.AlbumAddressLabel.TabIndex = 10;
            this.AlbumAddressLabel.Text = "Enter full album address here:";
            // 
            // AlbumInfoGroupBox
            // 
            this.AlbumInfoGroupBox.Controls.Add(this.AlbumInfoDateKeyLabel);
            this.AlbumInfoGroupBox.Controls.Add(this.AlbumInfoDateValueLabel);
            this.AlbumInfoGroupBox.Controls.Add(this.AlbumInfoSizeKeyLabel);
            this.AlbumInfoGroupBox.Controls.Add(this.AlbumInfoSizeValueLabel);
            this.AlbumInfoGroupBox.Controls.Add(this.AlbumInfoTrackCountKeyLabel);
            this.AlbumInfoGroupBox.Controls.Add(this.AlbumInfoTrackCountValueLabel);
            this.AlbumInfoGroupBox.Controls.Add(this.AlbumInfoNameKeyLabel);
            this.AlbumInfoGroupBox.Controls.Add(this.AlbumInfoNameValueLabel);
            this.AlbumInfoGroupBox.Location = new System.Drawing.Point(12, 138);
            this.AlbumInfoGroupBox.Name = "AlbumInfoGroupBox";
            this.AlbumInfoGroupBox.Size = new System.Drawing.Size(408, 143);
            this.AlbumInfoGroupBox.TabIndex = 11;
            this.AlbumInfoGroupBox.TabStop = false;
            this.AlbumInfoGroupBox.Text = "Album Information";
            // 
            // AlbumInfoDateKeyLabel
            // 
            this.AlbumInfoDateKeyLabel.AutoSize = true;
            this.AlbumInfoDateKeyLabel.Location = new System.Drawing.Point(3, 106);
            this.AlbumInfoDateKeyLabel.Name = "AlbumInfoDateKeyLabel";
            this.AlbumInfoDateKeyLabel.Size = new System.Drawing.Size(67, 13);
            this.AlbumInfoDateKeyLabel.TabIndex = 14;
            this.AlbumInfoDateKeyLabel.Text = "Date Added:";
            // 
            // AlbumInfoDateValueLabel
            // 
            this.AlbumInfoDateValueLabel.AutoSize = true;
            this.AlbumInfoDateValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlbumInfoDateValueLabel.Location = new System.Drawing.Point(3, 119);
            this.AlbumInfoDateValueLabel.Name = "AlbumInfoDateValueLabel";
            this.AlbumInfoDateValueLabel.Size = new System.Drawing.Size(0, 13);
            this.AlbumInfoDateValueLabel.TabIndex = 13;
            // 
            // AlbumInfoSizeKeyLabel
            // 
            this.AlbumInfoSizeKeyLabel.AutoSize = true;
            this.AlbumInfoSizeKeyLabel.Location = new System.Drawing.Point(3, 76);
            this.AlbumInfoSizeKeyLabel.Name = "AlbumInfoSizeKeyLabel";
            this.AlbumInfoSizeKeyLabel.Size = new System.Drawing.Size(57, 13);
            this.AlbumInfoSizeKeyLabel.TabIndex = 12;
            this.AlbumInfoSizeKeyLabel.Text = "Total Size:";
            // 
            // AlbumInfoSizeValueLabel
            // 
            this.AlbumInfoSizeValueLabel.AutoSize = true;
            this.AlbumInfoSizeValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlbumInfoSizeValueLabel.Location = new System.Drawing.Point(3, 89);
            this.AlbumInfoSizeValueLabel.Name = "AlbumInfoSizeValueLabel";
            this.AlbumInfoSizeValueLabel.Size = new System.Drawing.Size(0, 13);
            this.AlbumInfoSizeValueLabel.TabIndex = 11;
            // 
            // AlbumInfoTrackCountKeyLabel
            // 
            this.AlbumInfoTrackCountKeyLabel.AutoSize = true;
            this.AlbumInfoTrackCountKeyLabel.Location = new System.Drawing.Point(3, 46);
            this.AlbumInfoTrackCountKeyLabel.Name = "AlbumInfoTrackCountKeyLabel";
            this.AlbumInfoTrackCountKeyLabel.Size = new System.Drawing.Size(95, 13);
            this.AlbumInfoTrackCountKeyLabel.TabIndex = 10;
            this.AlbumInfoTrackCountKeyLabel.Text = "Number of Tracks:";
            // 
            // AlbumInfoTrackCountValueLabel
            // 
            this.AlbumInfoTrackCountValueLabel.AutoSize = true;
            this.AlbumInfoTrackCountValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlbumInfoTrackCountValueLabel.Location = new System.Drawing.Point(3, 59);
            this.AlbumInfoTrackCountValueLabel.Name = "AlbumInfoTrackCountValueLabel";
            this.AlbumInfoTrackCountValueLabel.Size = new System.Drawing.Size(0, 13);
            this.AlbumInfoTrackCountValueLabel.TabIndex = 9;
            // 
            // AlbumInfoNameKeyLabel
            // 
            this.AlbumInfoNameKeyLabel.AutoSize = true;
            this.AlbumInfoNameKeyLabel.Location = new System.Drawing.Point(3, 16);
            this.AlbumInfoNameKeyLabel.Name = "AlbumInfoNameKeyLabel";
            this.AlbumInfoNameKeyLabel.Size = new System.Drawing.Size(38, 13);
            this.AlbumInfoNameKeyLabel.TabIndex = 8;
            this.AlbumInfoNameKeyLabel.Text = "Name:";
            // 
            // DownloadGropuBox
            // 
            this.DownloadGropuBox.Controls.Add(this.DownloadOpenLocationButton);
            this.DownloadGropuBox.Controls.Add(this.DownloadLocationLabel);
            this.DownloadGropuBox.Controls.Add(this.DownloadCreateSubfolderCheckBox);
            this.DownloadGropuBox.Controls.Add(this.DownloadStartButton);
            this.DownloadGropuBox.Controls.Add(this.DownloadLocationTextBox);
            this.DownloadGropuBox.Controls.Add(this.DownloadSelectLocationButton);
            this.DownloadGropuBox.Location = new System.Drawing.Point(12, 287);
            this.DownloadGropuBox.Name = "DownloadGropuBox";
            this.DownloadGropuBox.Size = new System.Drawing.Size(408, 118);
            this.DownloadGropuBox.TabIndex = 12;
            this.DownloadGropuBox.TabStop = false;
            this.DownloadGropuBox.Text = "Download";
            // 
            // DownloadOpenLocationButton
            // 
            this.DownloadOpenLocationButton.Location = new System.Drawing.Point(161, 58);
            this.DownloadOpenLocationButton.Name = "DownloadOpenLocationButton";
            this.DownloadOpenLocationButton.Size = new System.Drawing.Size(95, 23);
            this.DownloadOpenLocationButton.TabIndex = 11;
            this.DownloadOpenLocationButton.Text = "Open Location";
            this.DownloadOpenLocationButton.UseVisualStyleBackColor = true;
            this.DownloadOpenLocationButton.Click += new System.EventHandler(this.DownloadOpenLocationButton_Click);
            // 
            // DownloadLocationLabel
            // 
            this.DownloadLocationLabel.AutoSize = true;
            this.DownloadLocationLabel.Location = new System.Drawing.Point(3, 16);
            this.DownloadLocationLabel.Name = "DownloadLocationLabel";
            this.DownloadLocationLabel.Size = new System.Drawing.Size(282, 13);
            this.DownloadLocationLabel.TabIndex = 10;
            this.DownloadLocationLabel.Text = "Specify Location where downloaded Tracks will be stored:";
            // 
            // ProgressTrackValueLabel
            // 
            this.ProgressTrackValueLabel.AutoSize = true;
            this.ProgressTrackValueLabel.Location = new System.Drawing.Point(75, 49);
            this.ProgressTrackValueLabel.Name = "ProgressTrackValueLabel";
            this.ProgressTrackValueLabel.Size = new System.Drawing.Size(24, 13);
            this.ProgressTrackValueLabel.TabIndex = 17;
            this.ProgressTrackValueLabel.Text = "0 %";
            // 
            // ProgressOverallValueLabel
            // 
            this.ProgressOverallValueLabel.AutoSize = true;
            this.ProgressOverallValueLabel.Location = new System.Drawing.Point(75, 16);
            this.ProgressOverallValueLabel.Name = "ProgressOverallValueLabel";
            this.ProgressOverallValueLabel.Size = new System.Drawing.Size(24, 13);
            this.ProgressOverallValueLabel.TabIndex = 16;
            this.ProgressOverallValueLabel.Text = "0 %";
            // 
            // ProgressTrackProgressBar
            // 
            this.ProgressTrackProgressBar.ForeColor = System.Drawing.Color.LimeGreen;
            this.ProgressTrackProgressBar.Location = new System.Drawing.Point(9, 65);
            this.ProgressTrackProgressBar.Name = "ProgressTrackProgressBar";
            this.ProgressTrackProgressBar.Size = new System.Drawing.Size(366, 12);
            this.ProgressTrackProgressBar.TabIndex = 15;
            // 
            // ProgressTrackLabel
            // 
            this.ProgressTrackLabel.AutoSize = true;
            this.ProgressTrackLabel.Location = new System.Drawing.Point(3, 49);
            this.ProgressTrackLabel.Name = "ProgressTrackLabel";
            this.ProgressTrackLabel.Size = new System.Drawing.Size(78, 13);
            this.ProgressTrackLabel.TabIndex = 14;
            this.ProgressTrackLabel.Text = "Current Track: ";
            // 
            // ProgressOverallProgressBar
            // 
            this.ProgressOverallProgressBar.ForeColor = System.Drawing.Color.LimeGreen;
            this.ProgressOverallProgressBar.Location = new System.Drawing.Point(9, 32);
            this.ProgressOverallProgressBar.Name = "ProgressOverallProgressBar";
            this.ProgressOverallProgressBar.Size = new System.Drawing.Size(366, 12);
            this.ProgressOverallProgressBar.Step = 1;
            this.ProgressOverallProgressBar.TabIndex = 13;
            // 
            // ProgressOverallLabel
            // 
            this.ProgressOverallLabel.AutoSize = true;
            this.ProgressOverallLabel.Location = new System.Drawing.Point(6, 16);
            this.ProgressOverallLabel.Name = "ProgressOverallLabel";
            this.ProgressOverallLabel.Size = new System.Drawing.Size(66, 13);
            this.ProgressOverallLabel.TabIndex = 12;
            this.ProgressOverallLabel.Text = "Total Album:";
            // 
            // TrackListLabel
            // 
            this.TrackListLabel.AutoSize = true;
            this.TrackListLabel.Location = new System.Drawing.Point(427, 12);
            this.TrackListLabel.Name = "TrackListLabel";
            this.TrackListLabel.Size = new System.Drawing.Size(57, 13);
            this.TrackListLabel.TabIndex = 13;
            this.TrackListLabel.Text = "Track List:";
            // 
            // AlbumSourceGroupBox
            // 
            this.AlbumSourceGroupBox.Controls.Add(this.OpenWebsiteButton);
            this.AlbumSourceGroupBox.Controls.Add(this.AlbumAddressTextBox);
            this.AlbumSourceGroupBox.Controls.Add(this.AlbumDownloadInformationButton);
            this.AlbumSourceGroupBox.Controls.Add(this.AlbumAddressLabel);
            this.AlbumSourceGroupBox.Location = new System.Drawing.Point(12, 12);
            this.AlbumSourceGroupBox.Name = "AlbumSourceGroupBox";
            this.AlbumSourceGroupBox.Size = new System.Drawing.Size(408, 120);
            this.AlbumSourceGroupBox.TabIndex = 14;
            this.AlbumSourceGroupBox.TabStop = false;
            this.AlbumSourceGroupBox.Text = "Album Source";
            // 
            // ProgressGroupBox
            // 
            this.ProgressGroupBox.Controls.Add(this.ProgressCancelButton);
            this.ProgressGroupBox.Controls.Add(this.ProgressTrackValueLabel);
            this.ProgressGroupBox.Controls.Add(this.ProgressOverallProgressBar);
            this.ProgressGroupBox.Controls.Add(this.ProgressOverallValueLabel);
            this.ProgressGroupBox.Controls.Add(this.ProgressOverallLabel);
            this.ProgressGroupBox.Controls.Add(this.ProgressTrackProgressBar);
            this.ProgressGroupBox.Controls.Add(this.ProgressTrackLabel);
            this.ProgressGroupBox.Location = new System.Drawing.Point(430, 287);
            this.ProgressGroupBox.Name = "ProgressGroupBox";
            this.ProgressGroupBox.Size = new System.Drawing.Size(385, 118);
            this.ProgressGroupBox.TabIndex = 15;
            this.ProgressGroupBox.TabStop = false;
            this.ProgressGroupBox.Text = "Progress";
            // 
            // ProgressCancelButton
            // 
            this.ProgressCancelButton.Location = new System.Drawing.Point(9, 87);
            this.ProgressCancelButton.Name = "ProgressCancelButton";
            this.ProgressCancelButton.Size = new System.Drawing.Size(366, 23);
            this.ProgressCancelButton.TabIndex = 18;
            this.ProgressCancelButton.Text = "Cancel";
            this.ProgressCancelButton.UseVisualStyleBackColor = true;
            this.ProgressCancelButton.Click += new System.EventHandler(this.ProgressCancelButton_Click);
            // 
            // CopyrightLabel
            // 
            this.CopyrightLabel.Location = new System.Drawing.Point(12, 408);
            this.CopyrightLabel.Name = "CopyrightLabel";
            this.CopyrightLabel.Size = new System.Drawing.Size(803, 16);
            this.CopyrightLabel.TabIndex = 16;
            this.CopyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(827, 427);
            this.Controls.Add(this.CopyrightLabel);
            this.Controls.Add(this.ProgressGroupBox);
            this.Controls.Add(this.AlbumSourceGroupBox);
            this.Controls.Add(this.TrackListLabel);
            this.Controls.Add(this.DownloadGropuBox);
            this.Controls.Add(this.AlbumInfoGroupBox);
            this.Controls.Add(this.TracksListDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.TracksListDataGridView)).EndInit();
            this.AlbumInfoGroupBox.ResumeLayout(false);
            this.AlbumInfoGroupBox.PerformLayout();
            this.DownloadGropuBox.ResumeLayout(false);
            this.DownloadGropuBox.PerformLayout();
            this.AlbumSourceGroupBox.ResumeLayout(false);
            this.AlbumSourceGroupBox.PerformLayout();
            this.ProgressGroupBox.ResumeLayout(false);
            this.ProgressGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenWebsiteButton;
        private System.Windows.Forms.TextBox AlbumAddressTextBox;
        private System.Windows.Forms.Button AlbumDownloadInformationButton;
        private System.Windows.Forms.Label AlbumInfoNameValueLabel;
        private System.Windows.Forms.DataGridView TracksListDataGridView;
        private System.Windows.Forms.Button DownloadStartButton;
        private System.Windows.Forms.CheckBox DownloadCreateSubfolderCheckBox;
        private System.Windows.Forms.TextBox DownloadLocationTextBox;
        private System.Windows.Forms.Button DownloadSelectLocationButton;
        private System.Windows.Forms.Label AlbumAddressLabel;
        private System.Windows.Forms.GroupBox AlbumInfoGroupBox;
        private System.Windows.Forms.Label AlbumInfoNameKeyLabel;
        private System.Windows.Forms.Label AlbumInfoDateKeyLabel;
        private System.Windows.Forms.Label AlbumInfoDateValueLabel;
        private System.Windows.Forms.Label AlbumInfoSizeKeyLabel;
        private System.Windows.Forms.Label AlbumInfoSizeValueLabel;
        private System.Windows.Forms.Label AlbumInfoTrackCountValueLabel;
        private System.Windows.Forms.Label AlbumInfoTrackCountKeyLabel;
        private System.Windows.Forms.GroupBox DownloadGropuBox;
        private System.Windows.Forms.Label TrackListLabel;
        private System.Windows.Forms.GroupBox AlbumSourceGroupBox;
        private System.Windows.Forms.Label DownloadLocationLabel;
        private System.Windows.Forms.Button DownloadOpenLocationButton;
        private System.Windows.Forms.Label ProgressOverallLabel;
        private System.Windows.Forms.ProgressBar ProgressOverallProgressBar;
        private System.Windows.Forms.ProgressBar ProgressTrackProgressBar;
        private System.Windows.Forms.Label ProgressTrackLabel;
        private System.Windows.Forms.Label ProgressOverallValueLabel;
        private System.Windows.Forms.Label ProgressTrackValueLabel;
        private System.Windows.Forms.GroupBox ProgressGroupBox;
        private System.Windows.Forms.Button ProgressCancelButton;
        private System.Windows.Forms.Label CopyrightLabel;
    }
}

