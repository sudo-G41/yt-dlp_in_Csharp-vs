using System.Windows.Forms;

namespace youtube
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);//창 사이즈 조절
            this.Text = "Form1";
            this.FormBorderStyle=FormBorderStyle.FixedSingle;//창 사이즈 고정

            btn1 = new Button();
            btn1.Name = "btn1";
            btn1.Text = "???";
            btn1.Location = new System.Drawing.Point(100, 20);
            btn1.Size = new System.Drawing.Size(200,30);
            
            btn2 = new Button();
            btn2.Name = "btn2";
            btn2.Text = "File";
            btn2.Location = new System.Drawing.Point(100, 70);
            btn2.Size = new System.Drawing.Size(200,30);
            
            thumbnailBtn = new Button();
            thumbnailBtn.Name = "thumbnailBtn";
            thumbnailBtn.Text = "File";
            thumbnailBtn.Location = new System.Drawing.Point(200, 70);
            thumbnailBtn.Size = new System.Drawing.Size(200,30);
            
            thumbnailPicbox = new PictureBox();
            thumbnailPicbox.Name = "thumbnailPicbox";
            thumbnailPicbox.Location = new System.Drawing.Point(200, 100);
            thumbnailPicbox.Size = new System.Drawing.Size(486,360);

            this.Controls.Add(btn1);
            this.Controls.Add(btn2);
            this.Controls.Add(thumbnailBtn);
            this.Controls.Add(thumbnailPicbox);

            this.MouseDown += new MouseEventHandler(MousePointXY);
        }

        private Button btn1;
        private Button btn2;
        private Button thumbnailBtn;
        private PictureBox thumbnailPicbox;
        #endregion
    }
}