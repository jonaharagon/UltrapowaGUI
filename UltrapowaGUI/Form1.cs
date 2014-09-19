using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Collections;


namespace UltrapowaGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = @"ucsconf.config";
            doc.Load(path);
            IEnumerator ie = doc.SelectNodes("/appSettings/add").GetEnumerator();

            while (ie.MoveNext())
            {
                if ((ie.Current as XmlNode).Attributes["key"].Value == "startingGems")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox1.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "startingGold")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox2.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "startingElixir")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox3.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "startingDarkElixir")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox4.Text;
                }
            }

            doc.Save(path);
            MessageBox.Show("The config file is updated. U might restart the server now.");
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.ultrapowa.com");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://julianpro6.bplaced.net/gui/");
        }

        private void button5_Click(object sender, EventArgs e)
        {


            string title = "Found a version.";
            string message = "Ultrapowa v0.4.0 is the newest version.";
            MessageBox.Show(message,title,MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"ucslog.txt", string.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Ultrapowa Clash Server.exe");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
            {
                if (myProc.ProcessName == "Ultrapowa Clash Server")
                {
                    myProc.Kill();
                }
            }
 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string pathToReadmeTxt = @"readme.txt";
            if (File.Exists(pathToReadmeTxt))
            {
                System.Diagnostics.Process.Start("readme.txt");
            }
            else
            {
                MessageBox.Show("Nope, couldn't find the readme.txt file. Maybe u deleted it?");
            }
            
        }
    }
}
