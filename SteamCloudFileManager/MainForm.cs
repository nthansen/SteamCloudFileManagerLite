using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using SteamCloudFileManager.interfaces;
using Narod.SteamGameFinder;
using System.Linq;
using Steamworks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Xml.Linq;


namespace SteamCloudFileManager
{
    public partial class MainForm : Form
    {
        IRemoteStorage storage;
        // Item1 = cloud name, Item2 = path on disk
        Queue<Tuple<string, string>> uploadQueue = new Queue<Tuple<string, string>>();

        List<SteamApp> cachedSteamAppList = null;
        readonly SteamGameLocator locator;
        readonly HttpClient httpClient;


        public MainForm()
        {
            InitializeComponent();
            locator = new SteamGameLocator();
            httpClient = new HttpClient();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                uint appId;
                if (string.IsNullOrWhiteSpace(appIdTextBox.Text))
                {
                    MessageBox.Show(this, "Please enter an App ID.", "Failed to connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!uint.TryParse(appIdTextBox.Text.Trim(), out appId))
                {
                    MessageBox.Show(this, "Please make sure the App ID you entered is valid.", "Failed to connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                storage = RemoteStorage.CreateInstance(uint.Parse(appIdTextBox.Text));
                //storage = new RemoteStorageLocal("remote", uint.Parse(appIdTextBox.Text));
                refreshButton.Enabled = true;
                uploadButton.Enabled = true;
                refreshButton_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Failed to connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (storage == null)
            {
                MessageBox.Show(this, "Not connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                List<IRemoteFile> files = storage.GetFiles();
                remoteListView.Items.Clear();
                foreach (IRemoteFile file in files)
                {
                    ListViewItem itm = new ListViewItem(new string[] { file.Name, file.Timestamp.ToString(), file.Size.ToString(), file.IsPersisted.ToString(), file.Exists.ToString() }) { Tag = file };
                    remoteListView.Items.Add(itm);
                }
                updateQuota();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Can't refresh." + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void updateQuota()
        {
            if (storage == null) throw new InvalidOperationException("Not connected");
            ulong totalBytes, availBytes;
            storage.GetQuota(out totalBytes, out availBytes);
            quotaLabel.Text = string.Format("{0}/{1} bytes used", totalBytes - availBytes, totalBytes);
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if (storage == null)
            {
                MessageBox.Show(this, "Not connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (remoteListView.SelectedIndices.Count != 1)
            {
                MessageBox.Show(this, "Please select only one file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            IRemoteFile file = remoteListView.SelectedItems[0].Tag as IRemoteFile;
            saveFileDialog1.FileName = Path.GetFileName(file.Name);
            if (saveFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    File.WriteAllBytes(saveFileDialog1.FileName, file.ReadAllBytes());
                    MessageBox.Show(this, "File downloaded.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "File download failed." + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (storage == null)
            {
                MessageBox.Show(this, "Not connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (remoteListView.SelectedIndices.Count == 0)
            {
                MessageBox.Show(this, "Please select files to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show(this, "Are you sure you want to delete the selected files?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No) return;

            bool allSuccess = true;

            foreach (ListViewItem item in remoteListView.SelectedItems)
            {
                IRemoteFile file = item.Tag as IRemoteFile;
                try
                {
                    bool success = file.Delete();
                    if (!success)
                    {
                        allSuccess = false;
                        MessageBox.Show(this, file.Name + " failed to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        item.Remove();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, file.Name + " failed to delete." + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            updateQuota();
            if (allSuccess) MessageBox.Show(this, "Files deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void remoteListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            downloadButton.Enabled = deleteButton.Enabled = (storage != null && remoteListView.SelectedIndices.Count > 0);
        }

        private void uploadBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            List<string> failedFiles = new List<string>();
            while (uploadQueue.Count > 0)
            {
                var uploadItem = uploadQueue.Dequeue();
                IRemoteFile file = storage.GetFile(uploadItem.Item1);
                try
                {
                    byte[] data = File.ReadAllBytes(uploadItem.Item2);
                    if (!file.WriteAllBytes(data))
                        failedFiles.Add(uploadItem.Item1);
                }
                catch (IOException)
                {
                    failedFiles.Add(uploadItem.Item1);
                }
            }

            e.Result = failedFiles;
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                disableUploadGui();
                foreach (var selectedFile in openFileDialog1.FileNames)
                {
                    uploadQueue.Enqueue(new Tuple<string, string>(Path.GetFileName(selectedFile).ToLowerInvariant(), selectedFile));
                }
                uploadBackgroundWorker.RunWorkerAsync();
            }
        }

        void disableUploadGui()
        {
            // Disables app switching, refresh, and upload button
            connectButton.Enabled = false;
            refreshButton.Enabled = false;
            uploadButton.Enabled = false;
            uploadButton.Text = "Uploading...";
        }

        void enableUploadGui()
        {
            connectButton.Enabled = true;
            refreshButton.Enabled = true;
            uploadButton.Enabled = true;
            uploadButton.Text = "Upload";
        }

        private void uploadBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var failedList = e.Result as List<string>;
            if (failedList.Count == 0)
            {
                MessageBox.Show(this, "Upload complete.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                failedList.Insert(0, "The following files have failed to upload:");
                MessageBox.Show(this, string.Join(Environment.NewLine, failedList), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            enableUploadGui();
            refreshButton_Click(this, EventArgs.Empty);
        }

        private void loadUserProfilesButton_Click(object sender, EventArgs e)
        {
            var steamGameLocator = new SteamGameLocator();
            var installLocation = steamGameLocator.getSteamInstallLocation();
            if (string.IsNullOrWhiteSpace(installLocation))
            {
                MessageBox.Show(this, "Unable to get Steam install location", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            userProfileList.DataSource = Directory.EnumerateDirectories($"{installLocation}\\userdata\\")
                                               .Select(dir => Path.GetFileName(dir))
                                               .ToList();
            userProfileList.Update();
        }

        private void userProfileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            gamesList.DataSource = null;
            gamesList.Update();
        }

        private async void loadLocalGamesButton_Click(object sender, EventArgs e)
        {
            var installLocation = locator.getSteamInstallLocation();
            if (string.IsNullOrWhiteSpace(installLocation))
            {
                MessageBox.Show(this, "Unable to get Steam install location", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var localAppIds = Directory.EnumerateDirectories($"{installLocation}\\userdata\\{userProfileList.SelectedValue}")
                                               .Select(dir => Path.GetFileName(dir))
                                               .ToList();

            if (cachedSteamAppList is null)
            {
                var remoteAppList = await httpClient.GetFromJsonAsync<SteamAppList>("https://api.steampowered.com/ISteamApps/GetAppList/v0002/");
                if (remoteAppList?.applist?.apps != null)
                {
                    cachedSteamAppList = remoteAppList.applist.apps;
                }
            }

            var matchingSteamApps = new List<SteamApp>();

            foreach (var localAppId in localAppIds)
            {
                var remoteAppSearchResult = cachedSteamAppList.FirstOrDefault(x => x.appid.ToString() == localAppId);
                if (remoteAppSearchResult is not null)
                {
                    matchingSteamApps.Add(remoteAppSearchResult);
                }
            }


            gamesList.DataSource = matchingSteamApps;
            gamesList.Update();
        }

        private void gamesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gamesList.SelectedItem is SteamApp selectedApp)
            {
                appIdTextBox.Text = selectedApp.appid.ToString();
                appIdTextBox.Update();
            }
        }
    }
}

record SteamApp(uint appid, string name)
{
    public override string ToString() => name;
};

record Applist(List<SteamApp> apps);

record SteamAppList(Applist applist);