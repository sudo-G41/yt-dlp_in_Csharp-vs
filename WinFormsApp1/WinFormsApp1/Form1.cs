using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

using System.Net;
using System.IO;

namespace youtube
{
    public partial class Form1 : Form
    {
        Boolean downloadOk = false;
        Boolean downloadingFlag = false;
        public Form1()
        {
            InitializeComponent();

            urlTextBox.TextChanged += urlTextBoxTextChanged;
            downloadpathBtn.Click += downloadpathBtnClick;
            downloadBtn.Click += downloadBtnClick;
        }
        private void urlTextBoxTextChanged(object sender, EventArgs e)
        {
            if (urlTextBox.Text.Length > 16)
            {
                String[] strArray = urlTextBox.Text.Split('/');
                if (strArray.Length != 4)
                {
                    return;
                }
                if (String.Compare(strArray[2], "youtu.be", false) == 0 || String.Compare(strArray[2], "www.youtube.com", false) == 0)
                {
                    Console.WriteLine(strArray[2]);
                    strArray = strArray[3].Split('=');
                    this.thumbnailPictureBox.Image = getImageURL(strArray[strArray.Length - 1]);
                }
            }
        }
        private Image getImageURL(String url)
        {
            url = "https://img.youtube.com/vi/" + url + "/0.jpg";
            Console.WriteLine(url);
            using (WebClient client = new WebClient())
            {
                byte[] img;
                try
                {
                    img = client.DownloadData(url);
                }
                catch (System.Exception)
                {
                    return null;
                    throw;
                }
                using (MemoryStream mes = new MemoryStream(img))
                {
                    Image i = Image.FromStream(mes);
                    downloadOk = true;
                    return i;
                }
            }
        }

        private void downloadBtnClick(object sender, EventArgs e)
        {
            Console.WriteLine("download Click");
            if (downloadingFlag)
            {
                System.Windows.Forms.MessageBox.Show("잠시만 기다려 주세요.");
                return;
            }
            if (downloadOk && downloadpathTextBox.Text.Length > 0)
            {
                this.thumbnailPictureBox.Image = null;
                String option = "-o \"" + downloadpathTextBox.Text + "\\%(title)s.%(ext)s\" " + urlTextBox.Text + " -v";
                Process yt = new Process();
            #if DEBUG
                String ytdirpath = "C:\\Users\\IntegetC\\source\\repos\\WinFormsApp1\\WinFormsApp1";
                yt.StartInfo.FileName = ytdirpath+ "/yt-dlp.exe";
                Console.WriteLine("DEBUG 모드");
            #else
                yt.StartInfo.FileName = Application.StartupPath + "/yt-dlp.exe";
                Console.WriteLine("release 모드");
            #endif
                yt.StartInfo.Arguments = option;
                yt.StartInfo.CreateNoWindow = true;
                yt.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                yt.Start();
                this.donwloading.Font = new Font(this.donwloading.Font.Name, 30);
                this.donwloading.Visible = true;
                this.thumbnailPictureBox.Visible = false;
                downloadingFlag = true;
                while (!yt.HasExited)
                {
                    switch (this.donwloading.Text)
                    {
                        case "Downloading":
                            Delay(1000);
                            this.donwloading.Text = "Downloading.";
                            break;
                        case "Downloading.":
                            Delay(1000);
                            this.donwloading.Text = "Downloading..";
                            break;
                        case "Downloading..":
                            Delay(1000);
                            this.donwloading.Text = "Downloading...";
                            break;
                        case "Downloading...":
                            Delay(1000);
                            this.donwloading.Text = "Downloading";
                            break;
                    }
                }

                downloadOk = false;
                downloadingFlag = false;
                urlTextBox.Text = "";
                this.donwloading.Visible = false;
                this.thumbnailPictureBox.Visible = true;
                MessageBox.Show("저장완료");
            }
            else if (downloadOk)
            {
                MessageBox.Show("저장할 위치를 선택해 주세요");
            }
            else
            {
                MessageBox.Show("Youtube 주소를 입력해 주세요");
                Console.WriteLine("아니 왜 이거 잘 안되?");
            }
        }

        private void downloadpathBtnClick(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;//폴더 선택 활성화
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                downloadpathTextBox.Text = dialog.FileName + "\\download";
            }
        }

        private void MousePointXY(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Sender : {0}", ((Form)sender).Text);
            Console.WriteLine("X : {0}, Y : {1}", e.X, e.Y);
            Console.WriteLine("Button : {0}, Clicks : {1}", e.Button, e.Clicks);
            Console.WriteLine();
            Console.WriteLine(this.donwloading.Font.Size.ToString());
        }
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

    }
}
