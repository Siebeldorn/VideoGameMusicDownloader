using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Reflection;

namespace VideoGameMusicDownloader
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            var assEntry = System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            Text = assEntry.FileDescription + " v" + assEntry.FileVersion;
            CopyrightLabel.Text = assEntry.LegalCopyright;

            TracksListDataGridView.Font = new Font("Consolas", 8.0f, FontStyle.Regular);
            TracksListDataGridView.Columns.AddRange(
                new DataGridViewColumn[] 
                {  
                    new DataGridViewTextBoxColumn() { Name = "columnNumber", HeaderText = "#", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader },
                    new DataGridViewTextBoxColumn() { Name = "columnTitle", HeaderText = "Title", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                    new DataGridViewTextBoxColumn() { Name = "columnDuration", HeaderText = "Duration", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader },
                    new DataGridViewTextBoxColumn() { Name = "columnSize", HeaderText = "Size", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader }
                });

            TrackDownloadClient = new WebClient();
            TrackDownloadClient.DownloadProgressChanged += TrackDownloadClient_DownloadProgressChanged;
            TrackDownloadClient.DownloadDataCompleted += TrackDownloadClient_DownloadDataCompleted;

            RestoreConfig();

            Reset();
        }

        private void Reset()
        {
            CurrentAlbum = null;

            AlbumInfoNameValueLabel.Text = "";
            AlbumInfoTrackCountValueLabel.Text = "";
            AlbumInfoSizeValueLabel.Text = "";
            AlbumInfoDateValueLabel.Text = "";
            TracksListDataGridView.Rows.Clear();

            ProgressOverallValueLabel.Text = ProgressTrackValueLabel.Text = "0 %";
            ProgressOverallProgressBar.Value = ProgressTrackProgressBar.Value = 0;

            DownloadGropuBox.Enabled = ProgressGroupBox.Enabled = false;
        }

        private void OpenWebsiteButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://downloads.khinsider.com/");
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveConfig();
        }

        private void AlbumDownloadInformationButton_Click(object sender, EventArgs e)
        {
            try
            {
                Reset();

                if ( AlbumAddressTextBox.Text.Trim().Length == 0 )
                {
                    ShowError("Please enter an Album address!");
                    return;
                }

                var uri = new Uri(AlbumAddressTextBox.Text);
                var baseAddress = uri.Scheme + "://" + uri.Host;

                if ( (CurrentAlbum = CreateAlbumFromWeb(uri)) == null )
                    return;

                AlbumInfoNameValueLabel.Text = CurrentAlbum.Name;
                AlbumInfoTrackCountValueLabel.Text = CurrentAlbum.TrackCount.ToString();
                AlbumInfoSizeValueLabel.Text = BytesToMbString(CurrentAlbum.SizeInBytes);
                AlbumInfoDateValueLabel.Text = CurrentAlbum.Date;

                var matches = TrackRegex.Matches(CurrentAlbum.Source);
                var dataIndex = 0;
                var dataCountPerTrack = matches.Count >= 4 && matches[3].Groups["data"].Value.ToLowerInvariant().EndsWith("mb") ? 4 : 3;
                foreach ( Match trackMatch in matches )
                {
                    if ( trackMatch.Success )
                    {
                        var path = baseAddress + Uri.UnescapeDataString(trackMatch.Groups["path"].Value);
                        var data = trackMatch.Groups["data"].Value;

                        switch ( dataIndex )
                        {
                            case 0:
                                CurrentAlbum.Tracks.Add(new Track() { Title = HttpUtility.HtmlDecode(data), Address = new Uri(path) });
                                break;
                            case 1:
                                CurrentAlbum.Tracks.LastOrDefault().Duration = data;
                                break;
                            case 2:
                                CurrentAlbum.Tracks.LastOrDefault().SizeInBytes = MbStringToBytes(data);
                                break;
                            default:
                                // ignore additional data
                                break;

                        }
                    }
                    dataIndex = (dataIndex + 1) % dataCountPerTrack;
                }

                var number = 1;
                foreach ( var track in CurrentAlbum.Tracks )
                {
                    TracksListDataGridView.Rows.Add(number.ToString(), track.Title, track.Duration, BytesToMbString(track.SizeInBytes));
                    number++;
                }

                DownloadGropuBox.Enabled = ProgressGroupBox.Enabled = true;
            }
            catch ( Exception ex )
            {
                ShowEx("Failed to download album and tracks information", ex);
            }
        }

        private void ShowError(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowEx(string text, Exception ex)
        {
            ShowError(text + ":\n\n" + ex.Message);
        }

        private long MbStringToBytes(string mb)
        {
            return (long)(double.Parse(mb.Substring(0, mb.IndexOf(' ')), System.Globalization.CultureInfo.InvariantCulture) * 1024 * 1024);
        }

        private double BytesToMb(long bytes)
        {
            return bytes / 1024.0f / 1024.0f;
        }

        private string BytesToMbString(long bytes)
        {
            return (Math.Round(BytesToMb(bytes), 2)).ToString("0.00") + " MB";
        }

        private void DownloadOpenLocationButton_Click(object sender, EventArgs e)
        {
            if ( Directory.Exists(DownloadLocationTextBox.Text) )
                System.Diagnostics.Process.Start("explorer.exe", DownloadLocationTextBox.Text);
            else
                ShowError("Unable to open download location folder!");
        }

        private void SetDataGridRowColor(Color color, DataGridViewRow specificRow = null, string trackTitle = null)
        {
            if ( specificRow != null )
                foreach ( DataGridViewCell cell in specificRow.Cells )
                    cell.Style.BackColor = color;
            else if ( trackTitle != null )
            {
                foreach ( DataGridViewRow row in TracksListDataGridView.Rows )
                    if ( string.Equals(row.Cells[1].Value as string, trackTitle) )
                        foreach ( DataGridViewCell cell in row.Cells )
                            cell.Style.BackColor = color;
            }
        }

        private Album CreateAlbumFromWeb(Uri uri)
        {
            try
            {
                var client = new WebClient();
                Byte[] pageData = client.DownloadData(uri);
                string pageHtml = Encoding.ASCII.GetString(pageData);

                var statsMatch = AlbumStatsRegex.Match(pageHtml);
                if ( !statsMatch.Success )
                    throw new HttpException("Unable to extract album information from page source");

                return new Album()
                {
                    Address = uri,
                    Source = pageHtml,
                    Name = statsMatch.Groups["name"].Value,
                    TrackCount = int.Parse(statsMatch.Groups["files"].Value),
                    SizeInBytes = MbStringToBytes(statsMatch.Groups["size"].Value),
                    Date = statsMatch.Groups["date"].Value
                };
            }
            catch ( Exception ex )
            {
                ShowEx("Failed to download album information", ex);
            }

            return null;
        }

        private Album CurrentAlbum;

        private static Regex AlbumStatsRegex = new Regex(@"
            Album\sname:\s<b>(?<name>.*)</b><br>
            (\s|\t)*Number\sof\sFiles:\s<b>(?<files>.*)</b><br>
            (\s|\t)*Total\sFilesize:\s<b>(?<size>.*)</b><br>
            (\s|\t)*Date\sadded:\s<b>(?<date>.*)</b><br>",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

        private static Regex TrackRegex = new Regex(@"<a href=""(?<path>[a-zA-Z0-9/\-_.%]+.mp3)""[^>]*>(?<data>[^<]+)</a>",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex TrackUriRegex = new Regex(@"<audio.*src=""(?<file>.*)""></audio>", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private class Album
        {
            public Uri Address;
            public string Source;
            public string Name;
            public long SizeInBytes;
            public string Date;
            public int TrackCount;
            public List<Track> Tracks = new List<Track>();
        }

        private class Track
        {
            public Uri Address;
            public string Title;
            public string Duration;
            public long SizeInBytes;
        }

        private class DownloadProgressData
        {
            public List<Track> RemainingTracks;
            public Track CurrentTrack;
            public long TrackBytes;
            public long TrackTotalBytes;
            public long AlbumBytes;
            public string FolderPath;
            public string Filename;
            public int Step;
        }

        private DownloadProgressData DownloadData;

        private WebClient TrackDownloadClient;

        private void TracksDownloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                // reset track list colors
                foreach ( DataGridViewRow row in TracksListDataGridView.Rows )
                    SetDataGridRowColor(SystemColors.Control, row, null);

                // determine and create target output folder
                var folder = DownloadLocationTextBox.Text;
                if ( DownloadCreateSubfolderCheckBox.Checked )
                {
                    var name = CurrentAlbum.Name;
                    foreach ( var c in Path.GetInvalidPathChars() )
                        name = name.Replace(c, '_');
                    folder = Path.Combine(folder, name);
                }
                if ( !Directory.Exists(folder) )
                    Directory.CreateDirectory(folder);

                // create object for holding progress relevant data during download
                DownloadData = new DownloadProgressData()
                {
                    FolderPath = folder,
                    RemainingTracks = new List<Track>(CurrentAlbum.Tracks)
                };

                // deactivate form and start
                TaskbarUtils.SetProgressState(Handle, TaskbarUtils.ProgressState.Normal);
                TaskbarUtils.SetProgressValue(Handle, 0, (ulong)CurrentAlbum.SizeInBytes);
                SetFormEnabled(false);
                StartDownload();
            }
            catch ( Exception ex )
            {
                ShowEx("Failed to start download", ex);
            }
        }

        private void StartDownload()
        {
            if ( DownloadData.RemainingTracks.Count > 0 )
            {
                DownloadData.CurrentTrack = DownloadData.RemainingTracks[0];
                DownloadData.RemainingTracks.RemoveAt(0);
                DownloadData.TrackBytes = 0;
                DownloadData.Step = 0;

                UpdateProgressUI();
                TrackDownloadClient.DownloadDataAsync(DownloadData.CurrentTrack.Address);
            }
            else
            {
                ProgressOverallValueLabel.Text = ProgressTrackValueLabel.Text = "100 %";
                ProgressOverallProgressBar.Value = ProgressTrackProgressBar.Value = 100;
                SetFormEnabled(true);

                TaskbarUtils.SetProgressState(Handle, TaskbarUtils.ProgressState.NoProgress);
                TaskbarUtils.Flash(Handle);
            }
        }

        private void SetFormEnabled(bool isEnabled)
        {
            AlbumSourceGroupBox.Enabled = AlbumInfoGroupBox.Enabled = DownloadGropuBox.Enabled = isEnabled;
        }

        private void UpdateProgressUI()
        {
            var albumAbs = string.Format("{0:0.00} MB of {1:0.00} MB", (DownloadData.AlbumBytes / 1024.0f / 1024.0f), (CurrentAlbum.SizeInBytes / 1024.0f / 1024.0f));
            var albumProgress = Math.Min(100, (int)(DownloadData.AlbumBytes * 1.0f / CurrentAlbum.SizeInBytes * 100));
            ProgressOverallProgressBar.Value = albumProgress;
            ProgressOverallValueLabel.Text = string.Format("{0} % ({1})", albumProgress, albumAbs);

            var trackTotal = DownloadData.TrackTotalBytes > 0 ? DownloadData.TrackTotalBytes : DownloadData.CurrentTrack.SizeInBytes;
            var trackProgress = Math.Min(100, (int)(DownloadData.TrackBytes * 1.0f / trackTotal * 100));
            ProgressTrackProgressBar.Value = trackProgress;
            ProgressTrackValueLabel.Text = string.Format("{0} % of {1}", trackProgress, DownloadData.CurrentTrack.Title);

            TaskbarUtils.SetProgressValue(Handle, (ulong)DownloadData.AlbumBytes, (ulong)CurrentAlbum.SizeInBytes);
        }

        void TrackDownloadClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if ( e.Cancelled )
            {
                TaskbarUtils.SetProgressState(Handle, TaskbarUtils.ProgressState.NoProgress);
                SetFormEnabled(true);
                SetDataGridRowColor(Color.LightCoral, null, DownloadData.CurrentTrack.Title);
            }
            else if ( e.Error != null )
            {
                TaskbarUtils.SetProgressState(Handle, TaskbarUtils.ProgressState.Error);
                TaskbarUtils.Flash(Handle);
                ShowEx("Failed to download track", e.Error);
                TaskbarUtils.SetProgressState(Handle, TaskbarUtils.ProgressState.NoProgress);
                SetFormEnabled(true);
            }
            else
            {
                if ( DownloadData.Step++ == 0 )
                {
                    string page = Encoding.ASCII.GetString(e.Result);
                    var match = TrackUriRegex.Match(page);
                    if ( match.Success )
                    {
                        var filepath = match.Groups["file"].Value;
                        var index = filepath.LastIndexOf('/');
                        if ( index >= 0 )
                        {
                            DownloadData.Filename = Uri.UnescapeDataString(filepath.Substring(index + 1));
                            TrackDownloadClient.DownloadDataAsync(new Uri(filepath));
                        }
                    }
                }
                else
                {
                    // write track to disk
                    File.WriteAllBytes(Path.Combine(DownloadData.FolderPath, DownloadData.Filename), e.Result);

                    // mark track in list as finished
                    SetDataGridRowColor(ProgressTrackProgressBar.ForeColor, null, DownloadData.CurrentTrack.Title);

                    // download next
                    StartDownload();
                }
            }
        }

        void TrackDownloadClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if ( DownloadData.Step == 1 )
            {
                var diff = e.BytesReceived - DownloadData.TrackBytes;
                DownloadData.TrackTotalBytes = e.TotalBytesToReceive;
                DownloadData.TrackBytes = e.BytesReceived;
                DownloadData.AlbumBytes += diff;

                UpdateProgressUI();
            }
        }

        private void ProgressCancelButton_Click(object sender, EventArgs e)
        {
            if ( TrackDownloadClient != null )
                TrackDownloadClient.CancelAsync();
        }

        private void DownloadSelectLocationButton_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            dialog.SelectedPath = Directory.Exists(DownloadLocationTextBox.Text) ? DownloadLocationTextBox.Text : System.Environment.CurrentDirectory;
            dialog.ShowNewFolderButton = true;

            var res = dialog.ShowDialog();
            if ( res == System.Windows.Forms.DialogResult.OK )
                DownloadLocationTextBox.Text = dialog.SelectedPath;
        }

        #region Configuration

        [DataContract]
        private class Configuration
        {
            public Configuration(string loc, bool createSub)
            {
                DownloadLocation = loc;
                DownloadCreateSubfolder = createSub;
            }

            [DataMember]
            public string DownloadLocation;

            [DataMember]
            public bool DownloadCreateSubfolder;
        }

        private Configuration Config;

        private string BuildConfigPath()
        {
            return Path.Combine(System.Environment.CurrentDirectory, Path.GetFileNameWithoutExtension(GetType().Assembly.Location) + ".cfg");
        }

        private void RestoreConfig()
        {
            try
            {
                var filepath = BuildConfigPath();
                if ( File.Exists(filepath) )
                {
                    var ser = new DataContractJsonSerializer(typeof(Configuration));
                    using ( var file = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read) )
                        Config = ser.ReadObject(file) as Configuration;
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Failed to load configuration from file:\n\n" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if ( Config == null )
            {
                string musicFolder;
                try
                {
                    musicFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyMusic, Environment.SpecialFolderOption.Create);
                }
                catch
                {
                    musicFolder = System.Environment.CurrentDirectory;
                }

                if ( !string.IsNullOrWhiteSpace(musicFolder) )
                {
                    musicFolder = Path.Combine(musicFolder, "Video Game Music");
                    if ( !Directory.Exists(musicFolder) )
                        Directory.CreateDirectory(musicFolder);
                }
                Config = new Configuration(musicFolder, true);
            }

            DownloadLocationTextBox.Text = Config.DownloadLocation;
            DownloadCreateSubfolderCheckBox.Checked = Config.DownloadCreateSubfolder;
        }

        private void SaveConfig()
        {
            try
            {
                Config.DownloadLocation = DownloadLocationTextBox.Text;
                Config.DownloadCreateSubfolder = DownloadCreateSubfolderCheckBox.Checked;

                var ser = new DataContractJsonSerializer(typeof(Configuration));
                ser.WriteObject(File.Create(BuildConfigPath()), Config);
            }
            catch
            { }
        }

        #endregion Configuration
    }
}
