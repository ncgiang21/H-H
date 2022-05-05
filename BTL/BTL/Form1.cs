using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BTL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadProcessList();
        }
        void loadProcessList()
        {
            listView.Items.Clear();
            Process[] processesList = Process.GetProcesses();
            foreach (Process process in processesList)
            {
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.Tag = process;
                listView.Items.Add(item);
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            string text = tb.Text;
            Process process = new Process();
            process.StartInfo.FileName = text;
            process.Start();
            loadProcessList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void stop_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView.SelectedItems[0];
            Process process = (Process)item.Tag;
            process.Kill();
            loadProcessList();
        }
    }
}
