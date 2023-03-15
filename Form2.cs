using CefSharp.WinForms;
using CefSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Learn
{
    public partial class Form2 : Form
    {
        public ChromiumWebBrowser chromeBrowser;

        public void InitializeChromium()
        {
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("https://google.com");
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }
        public Form2()
        {
            InitializeComponent();

            InitializeChromium();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            progressBar1.Show();
            progressBar1.Style = ProgressBarStyle.Continuous;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1(); // Create new instance of the new form.

            mainForm.Show(); // Show it
            //chromeBrowser.Delete();
            this.Close(); // Hide the current form.
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (Cef.IsInitialized)
            {
                while (progressBar1.Value != 100)
                {
                    progressBar1.Value += 10;
                    Thread.Sleep(100);
                }
                if (progressBar1.Value == 100)
                {
                    progressBar1.Hide();
                    timer1.Stop();
                }
            }
            else
            {
                //progressBar1.Value = 0;
            }
        }
    }
}
