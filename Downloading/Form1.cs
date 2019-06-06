using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Downloading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient wc = new WebClient();
                string url = richTextBox1.Text;
                int pointNumber = url.LastIndexOf(".");
                int slashNumber = url.LastIndexOf("/");
                string fileExtension = url.Substring(pointNumber);
                string save_path = Directory.GetCurrentDirectory();
                string name = url.Substring(slashNumber, (pointNumber - slashNumber));

                wc.DownloadFile(url, save_path + name + fileExtension);
                label2.Text = "success";

                pictureBox1.Image = new Bitmap(save_path + name + fileExtension);
            }
            catch(Exception exception)
            {
                label2.Text = exception.Message;
            }
        }
    }
}   
