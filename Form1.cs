using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Diagnostics;
using System.Net.Http;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace UpdaterMain
{
    public partial class Form1 : Form
    {
        int langSel;
        private string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./data/config.ini");

        public Form1()
        {
            CleanTempFolder();
            InitializeComponent();
            LoadConfig();

            if (langSel == 1)
            {
                label1.Text = "Looking for new program update";
                Cancel.Text = "Cancel";
            }

            CheckConnection();
        }

        private void LoadConfig()
        {
            if (File.Exists(configPath))
            {
                string[] lines = File.ReadAllLines(configPath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        switch (parts[0])
                        {
                            case "langSel":
                                langSel = int.Parse(parts[1]);
                                break;
                        }
                    }
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseAfterDelay();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            CloseAfterDelay();
        }

        private void CleanTempFolder()
        {
            string tempFolderPath = Path.GetTempPath();

            if (Directory.Exists(tempFolderPath))
            {
                string[] tempFiles = Directory.GetFiles(tempFolderPath);
                foreach (string tempFile in tempFiles)
                {
                    try
                    {
                        File.Delete(tempFile);
                    }
                    catch (Exception)
                    {
                        // return
                    }
                }

                string[] tempDirs = Directory.GetDirectories(tempFolderPath);
                foreach (string tempDir in tempDirs)
                {
                    try
                    {
                        Directory.Delete(tempDir, true); // Usu� katalog wraz z zawarto�ci�
                    }
                    catch (Exception)
                    {
                        // Obs�u� ewentualny b��d usuwania katalogu
                    }
                }
            }

        }


        private async void CheckConnection()
        {

            if (langSel == 1)
            {
                downStatus.Text = "Checking for updates...";
            }
            if (langSel == 0)
            {
                downStatus.Text = "Sprawdzanie dost�pno�ci aktualizacji...";
            }


            if (CheckServerAvailability("windowsbase.pl"))
            {
                CheckVersion();
            }
            else
            {
                if (langSel == 1)
                {
                    MessageBox.Show("There was a problem while connecting to the update server. Make sure you have a working Internet connection or contact technical support available at: www.windowsbase.pl", "Connection error", MessageBoxButtons.OK);
                }
                if (langSel == 0)
                {
                    MessageBox.Show("Wyst�pi� problem podczas po��czenia z serwerem aktualizacji. Upewnij si�, czy masz dzia�aj�ce po��czenie z Internetem lub skontaktuj si� z pomoc� techniczn� dost�pn� pod adresem: www.windowsbase.pl", "B��d po��czenia", MessageBoxButtons.OK);
                }
                OpenMainApp();
                CloseAfterDelay();
            }
        }

        private bool CheckServerAvailability(string serverAddress)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(serverAddress);

                return reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                return false;
            }
        }

        private void OpenMainApp()
        {
            string appPath = Path.Combine(Application.StartupPath, "ytdl-gui.exe");
            Process.Start(appPath);
        }


        private async Task CheckVersion()
        {
            string remoteVersionFileUrl = "https://windowsbase.pl/uploads/apps/ydlp-gui/version.txt";
            string localVersionFilePath = Path.Combine(Application.StartupPath, "./data/update/version.txt");

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string remoteVersionFileContent = await client.GetStringAsync(remoteVersionFileUrl);
                    string[] remoteVersionLines = remoteVersionFileContent.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    string remoteVersion = "";
                    string updateUrl = "";

                    foreach (string line in remoteVersionLines)
                    {
                        string[] parts = line.Split(new[] { ':' }, 2);
                        if (parts.Length == 2)
                        {
                            remoteVersion = parts[0].Trim('"');
                            updateUrl = parts[1].Trim('"');
                        }
                    }

                    string localVersion = File.ReadAllText(localVersionFilePath).Trim();

                    if (string.Compare(remoteVersion, localVersion) > 0)
                        await DownloadFiles(updateUrl);
                    else
                    {
                        progressBar1.Style = ProgressBarStyle.Marquee;
                        progressBar1.MarqueeAnimationSpeed = 10;
                        if (langSel == 1)
                        {
                            downStatus.Text = "Checking for updates...";
                        }
                        if (langSel == 0)
                        {
                            downStatus.Text = "Sprawdzanie dost�pno�ci aktualizacji...";
                        }
                        OpenMainApp();
                        CloseAfterDelay();
                    }
                }
            }
            catch (HttpRequestException)
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 10;
                if (langSel == 1)
                {
                    downStatus.Text = "Checking for updates...";
                }
                if (langSel == 0)
                {
                    downStatus.Text = "Sprawdzanie dost�pno�ci aktualizacji...";
                }
                OpenMainApp();
                CloseAfterDelay();
            }
        }

        private async Task DownloadFiles(string url)
        {
            string fileName = Path.GetFileName(url);
            string fileTempPath = Path.Combine(Path.GetTempPath(), fileName);

            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += Client_DownloadProgressChanged;
                client.DownloadFileCompleted += (sender, e) => Client_DownloadFileCompleted(sender, e, fileName);
                await client.DownloadFileTaskAsync(new Uri(url), fileTempPath);
            }

            Client_DownloadFileCompleted(this, new AsyncCompletedEventArgs(null, false, null), fileName);
        }

        private async void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e, string fileName)
        {
            progressBar1.MarqueeAnimationSpeed = 10;
            progressBar1.Style = ProgressBarStyle.Marquee;
            if (langSel == 1)
            {
                downStatus.Text = "Installing updates...";
            }
            if (langSel == 0)
            {
                downStatus.Text = "Instalowanie aktualizacji...";
            }

            await Task.Delay(2000);

            try
            {
                string udataTempFolder = Path.Combine(Path.GetTempPath(), "udata"); // %temp/udata - set folder
                Directory.CreateDirectory(udataTempFolder);

                string destinationPath = Path.Combine(udataTempFolder, fileName);
                string sourcePath = Path.Combine(Path.GetTempPath(), fileName);

                if (File.Exists(destinationPath))
                {
                    File.Delete(destinationPath);
                }

                File.Move(sourcePath, destinationPath);

                string extractFolder = udataTempFolder;

                // Wypakuj archiwum
                using (ZipArchive archive = ZipFile.OpenRead(destinationPath))
                {
                    archive.ExtractToDirectory(extractFolder);
                }

                // Usu� przeniesiony plik z folderu %temp%/udata
                File.Delete(destinationPath);

                // Przenie� zawarto�� folderu udata do folderu programu
                string programFolder = Application.StartupPath;

                // Przenie� pliki i foldery z folderu udata do folderu programu
                MoveDirectory(extractFolder, programFolder);

                await Task.Delay(2000);

                if (langSel == 1)
                {
                    downStatus.Text = "Finishing...";
                }
                if (langSel == 0)
                {
                    downStatus.Text = "Ko�czenie instalacji...";
                }


                System.Threading.Thread.Sleep(4000);
                labelPercentage.Visible = false;
                OpenMainApp();
                CloseAfterDelay();
            }
            catch (Exception ex)
            {
                CleanTempFolder();
                CloseAfterDelay();
            }
        }

        private void MoveDirectory(string source, string target)
        {
            var sourceInfo = new DirectoryInfo(source);
            var targetInfo = new DirectoryInfo(target);

            // Przenie� pliki z folderu �r�d�owego do folderu docelowego
            foreach (var file in sourceInfo.GetFiles())
            {
                string targetFilePath = Path.Combine(target, file.Name);

                // Nadpisz plik je�li ju� istnieje, ale pomi� je�li jest otwarty
                if (File.Exists(targetFilePath))
                {
                    try
                    {
                        File.Delete(targetFilePath);
                        file.MoveTo(targetFilePath);
                    }
                    catch (IOException)
                    {
                        // Plik jest otwarty, pomi� go
                    }
                }
                else
                {
                    file.MoveTo(targetFilePath);
                }
            }

            // Przenie� podfoldery z folderu �r�d�owego do folderu docelowego
            foreach (var directory in sourceInfo.GetDirectories())
            {
                string targetDirectoryPath = Path.Combine(target, directory.Name);

                if (!Directory.Exists(targetDirectoryPath))
                    Directory.CreateDirectory(targetDirectoryPath);

                MoveDirectory(directory.FullName, targetDirectoryPath);
            }
        }


        private async void CloseAfterDelay()
        {
            CleanTempFolder();
            await Task.Delay(3000);
            Environment.Exit(0);
            Application.Exit();
        }


        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            labelPercentage.Text = e.ProgressPercentage + "%";

            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = Math.Round(totalBytes / 1024 / 1024);

            if (langSel == 1)
            {
                downStatus.Text = "Downloading package data: " + percentage + " MiB";
            }
            if (langSel == 0)
            {
                downStatus.Text = "Pobieranie plik�w aktualizacji: " + percentage + " MiB";
            }

        }

    }
}
