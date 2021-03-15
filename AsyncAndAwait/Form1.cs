using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAndAwait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int CountChars()
        {
            int count = 0;
            using (StreamReader reader = new StreamReader(@"D:\Temp\Data.txt"))
            {
                string content = reader.ReadToEnd();
                count = content.Length;

                Thread.Sleep(5000);
            }
            return count;
        }
        private async void btnProcess_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(CountChars);
            task.Start();

            lblCount.Text = "Processing file, Please wait...";
            int count = await task;
            lblCount.Text = count.ToString() + " characters in the file ";
        }
    }
}
