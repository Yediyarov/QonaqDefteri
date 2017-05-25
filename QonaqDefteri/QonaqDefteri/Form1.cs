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

namespace QonaqDefteri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FileInfo f;
        string fileN = "";
        Dictionary<string, string> serhAd = new Dictionary<string, string>();

        private void button2_Click(object sender, EventArgs e)
        {
            var fileName = textBox1.Text + ".txt";
            StreamWriter sw = f.AppendText();
            serhAd.Add(textBox4.Text,textBox2.Text);
            foreach (KeyValuePair<string, string> keyValue in serhAd)
            {
                if (!comboBox1.Items.Contains(keyValue.Key))
                {
                    comboBox1.Items.Add(keyValue.Key);
                }
            }
            sw.WriteLine(textBox4.Text);
            sw.WriteLine(textBox3.Text);
            sw.WriteLine(textBox2.Text);
            sw.WriteLine("===============================================");
            sw.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            fileN = textBox1.Text + ".txt";
            f = new FileInfo(fileN);
         
            var fileName = textBox1.Text + ".txt";
            if (!File.Exists(fileN))
            {
                File.Create(fileName).Close();
                MessageBox.Show(String.Format("{0} fayli ugurla yaradildi!", fileName));
            }
            else
            {
                MessageBox.Show(String.Format("{0} fayli movcuddur!", fileName));
            }
            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

            //MessageBox.Show(comboBox1.SelectedIndex.ToString());
            foreach (var item in serhAd)
            {
                if (item.Key == comboBox1.SelectedItem.ToString())
                {
                    textBox5.Text = item.Value;
                }
            }
        }
    }
}
