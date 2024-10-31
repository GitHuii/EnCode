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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static EnCode.Algorithm;

namespace EnCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            radioButton6.Checked = true;
            radioButton8.Checked = true;
            radioButton10.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //NGUYENVIETHUY
            //K=6
            //TMAEKTBOKZNAE
            richTextBox2.Text = CEASAR(richTextBox1.Text, int.Parse(textBox1.Text),radioButton1.Checked);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            textBox2.Text = new string(Alphabet.OrderBy(c => rand.Next()).ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MEETMEAFTERTHETOGAPARTY
            //ZPBYJRSKFLXQNWVDHMGUTOIAEC
            //NJJUNJZRUJMUKJUVSZDZMUE
            richTextBox3.Text = THAYTHE(richTextBox4.Text, textBox2.Text , radioButton4.Checked);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //THUONGMAIDIENTU
            //MINH
            //YETPMLIMAMNCHCHSSZ
            richTextBox5.Text = PLAYFAIR(richTextBox6.Text, textBox3.Text , radioButton6.Checked);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //HANOIMUATHU
            //k 5 3
            //MDQVRLZDUMZ
            richTextBox7.Text = AFFINE(richTextBox8.Text, int.Parse(textBox4.Text), int.Parse(textBox5.Text), radioButton8.Checked);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //MEETMEATSUNSET
            //CIPHER
            //OMTAQVCBHBRJGB
            richTextBox9.Text = VIGENERE(richTextBox10.Text,textBox6.Text, radioButton10.Checked);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/Huii.FB");
        }
    }
}
