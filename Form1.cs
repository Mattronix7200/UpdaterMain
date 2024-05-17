using System.Diagnostics;
using System.IO.Compression;
using System.Net.NetworkInformation;
using System.Net;
using System;
using System.Windows.Forms;

namespace UpdaterMain
{
    public partial class Form1 : Form
    {
        int langSel;
        int languageSelected;
        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./data/config.ini");

        public Form1()
        {
            InitializeComponent();
            LoadConfig();
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
            else
            {
                MessageBox.Show("Missing config data or language file corrupted...", "Error", MessageBoxButtons.OK);
            }
            if (langSel == 1)
            {
                languageSelected = 1;

            }
            if (langSel == 0)
            {
                languageSelected = 0;
            }
        }



        private async Task<bool> CheckServerAvailability(string serverAddress)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = await ping.SendPingAsync(serverAddress, 5000);

                return reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                return false;
            }
        }

        private async void CheckConnection()
        {
            await Task.Delay(3000);

            if (await CheckServerAvailability("windowsbase.pl"))
            {
                arr1.Visible = true;
                arr1.Enabled = true;
                stat1.Enabled = true;
                stat1.Visible = true;

                arr2.Visible = false;
                arr2.Enabled = false;
                stat2.Enabled = false;

                arr3.Visible = false;
                arr3.Enabled = false;
                stat3.Enabled = false;

                arr4.Visible = false;
                arr4.Enabled = false;
                stat4.Enabled = false;

                arr5.Enabled = false;
                arr5.Visible = false;
                stat5.Enabled = false;


                runUpdate();
            }
            else
            {
                if (languageSelected == 1)
                {
                    MessageBox.Show("There was a problem while connecting to the update server. Make sure you have a working Internet connection or contact technical support available at: www.windowsbase.pl", "Connection error", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Wyst¹pi³ problem podczas po³¹czenia z serwerem aktualizacji. Upewnij siê, czy masz dzia³aj¹ce po³¹czenie z Internetem lub skontaktuj siê z pomoc¹ techniczn¹ dostêpn¹ pod adresem: www.windowsbase.pl", "B³¹d po³¹czenia", MessageBoxButtons.OK);
                }

                this.Close();
            }
        }

        private void step2Anim()
        {
            arr2.Visible = true;
            arr2.Enabled = true;
            stat2.Enabled = true;
            stat2.Visible = true;

            arr1.Visible = false;
            arr1.Enabled = false;
            stat1.Enabled = false;

            arr3.Visible = false;
            arr3.Enabled = false;
            stat3.Enabled = false;

            arr4.Visible = false;
            arr4.Enabled = false;
            stat4.Enabled = false;

            arr5.Enabled = false;
            arr5.Visible = false;
            stat5.Enabled = false;

        }

        private void step3Anim()
        {
            arr3.Visible = true;
            arr3.Enabled = true;
            stat3.Enabled = true;
            stat3.Visible = true;

            arr1.Visible = false;
            arr1.Enabled = false;
            stat1.Enabled = false;

            arr2.Visible = false;
            arr2.Enabled = false;
            stat2.Enabled = false;

            arr4.Visible = false;
            arr4.Enabled = false;
            stat4.Enabled = false;

            arr5.Enabled = false;
            arr5.Visible = false;
            stat5.Enabled = false;

        }

        private void step4Anim()
        {
            arr4.Visible = true;
            arr4.Enabled = true;
            stat4.Enabled = true;
            stat4.Visible = true;

            arr1.Visible = false;
            arr1.Enabled = false;
            stat1.Enabled = false;

            arr2.Visible = false;
            arr2.Enabled = false;
            stat2.Enabled = false;

            arr3.Visible = false;
            arr3.Enabled = false;
            stat3.Enabled = false;

            arr5.Enabled = false;
            arr5.Visible = false;
            stat5.Enabled = false;

        }

        private void step5Anim()
        {
            arr5.Visible = true;
            arr5.Enabled = true;
            stat5.Enabled = true;
            stat5.Visible = true;

            arr1.Visible = false;
            arr1.Enabled = false;
            stat1.Enabled = false;

            arr2.Visible = false;
            arr2.Enabled = false;
            stat2.Enabled = false;

            arr3.Visible = false;
            arr3.Enabled = false;
            stat3.Enabled = false;

            arr4.Enabled = false;
            arr4.Visible = false;
            stat4.Enabled = false;

        }



        public async void runUpdate()
        {
            try
            {
                Process controler = new Process();
                controler.StartInfo.FileName = Path.Combine(appDirectory, "./bin/pccontrol.bat");
                controler.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                controler.StartInfo.CreateNoWindow = true;
                controler.Start();


                string updateDirectory = Path.Combine(appDirectory, "./data/update");
                string localVersionFilePath = Path.Combine(updateDirectory, "version.txt");
                if (!File.Exists(localVersionFilePath))
                {
                    if (languageSelected == 1)
                    {
                        controler.Kill();
                        MessageBox.Show("An error occurred while checking for updates", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        controler.Kill();
                        MessageBox.Show("Wyst¹pi³ b³¹d podczas sprawdzania aktualizacji", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.Close();
                }

                step2Anim();

                string localVersion = File.ReadAllText(localVersionFilePath).Trim();
                string remoteVersionFileUrl = "https://windowsbase.pl/uploads/apps/ydlp-gui/version.txt";
                WebClient webClient = new();
                string remoteVersionFileContent = webClient.DownloadString(remoteVersionFileUrl);
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

                if (remoteVersion == null || updateUrl == null)
                {
                    if (languageSelected == 1)
                    {
                        controler.Kill();
                        MessageBox.Show("An error occurred while checking for updates", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        controler.Kill();
                        MessageBox.Show("Wyst¹pi³ b³¹d podczas sprawdzania aktualizacji", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.Close();
                    return;
                }

                await Task.Delay(3000);
                step3Anim();

                if (localVersion == remoteVersion)
                {
                    if (languageSelected == 1)
                    {
                        controler.Kill();
                        MessageBox.Show("No updates available, you have the latest version of the program: " + remoteVersion, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        controler.Kill();
                        MessageBox.Show("Brak dostêpnych aktualizacji, posiadasz najnowsz¹ wersjê programu: " + remoteVersion, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                    return;
                }
                await Task.Delay(3000);
                step4Anim();
                progressBar1.Visible = true;
                downStatus.Visible = true;
                downStatus.Enabled = true;
                if (languageSelected == 1)
                {
                    downStatus.Text = "Downloading file data...";
                }
                else
                {
                    downStatus.Text = "Pobieranie plików aktualizacji...";
                }
                progressBar1.Value = 33;
                string tempDirectory = Path.GetTempPath();
                string tempZipFilePath = Path.Combine(tempDirectory, "update.zip");
                string tempExtractDirectory = Path.Combine(tempDirectory, "ytdlupdate");

                Stopwatch stopwatch = new Stopwatch();

                webClient.DownloadProgressChanged += (s, e) =>
                {
                    if (e.ProgressPercentage == 0)
                        stopwatch.Start();
                    else
                    {
                        double speed = e.BytesReceived / 1024d / 1024d / stopwatch.Elapsed.TotalSeconds;
                        if (languageSelected == 1)
                        {
                            downStatus.Text = $"Downloading data: {e.BytesReceived / 1024.0 / 1024.0:0.00} MB / {e.TotalBytesToReceive / 1024.0 / 1024.0:0.00} MB @ {speed:0.00} MB/s";
                        }
                        else
                        {
                            downStatus.Text = $"Pobieranie danych: {e.BytesReceived / 1024.0 / 1024.0:0.00} MB / {e.TotalBytesToReceive / 1024.0 / 1024.0:0.00} MB @ {speed:0.00} MB/s";
                        }
                        progressBar1.Value = 33 + (int)(e.ProgressPercentage * 0.33);
                    }
                };

                await webClient.DownloadFileTaskAsync(new Uri(updateUrl), tempZipFilePath);
                stopwatch.Stop();

                await Task.Delay(3000);
                step5Anim();

                if (Directory.Exists(tempExtractDirectory))
                {
                    Directory.Delete(tempExtractDirectory, true);
                }

                if (languageSelected == 1)
                {
                    downStatus.Text = "Instalacja aktualizacji...";
                }
                else
                {
                    downStatus.Text = "Installing updates...";
                }

                progressBar1.Value = 66;
                await Task.Run(() => ZipFile.ExtractToDirectory(tempZipFilePath, tempExtractDirectory));

                foreach (string file in Directory.GetFiles(tempExtractDirectory))
                {
                    string fileName = Path.GetFileName(file);
                    string destFilePath = Path.Combine(appDirectory, fileName);
                    File.Copy(file, destFilePath, true);
                }
                if (languageSelected == 1)
                {
                    downStatus.Text = "Instalacja aktualizacji...";
                }
                else
                {
                    downStatus.Text = "Little housekeeping...";
                }

                progressBar1.Value = 100;
                await Task.Delay(3000);
                File.Delete(tempZipFilePath);

                string exePath = Path.Combine(appDirectory, "ytdl-gui.exe");
                Process.Start(exePath);

                controler.Kill();
                Application.Exit();
            }
            catch (Exception ex)
            {
                if (languageSelected == 1)
                {
                    MessageBox.Show($"An error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Wyst¹pi³ b³¹d: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (languageSelected == 1)
            {
                label1.Text = "Please wait";
                stat1.Text = "Checking internet connection...";
                stat2.Text = "Connecting to server...";
                stat3.Text = "Checking for updates...";
                stat4.Text = "Downloading updates...";
                stat5.Text = "Installing updates...";
            }
            else
            {
               // do nothing ...
            }

        }
    }
}
