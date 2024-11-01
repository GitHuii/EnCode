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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static EnCode.Algorithm;

namespace EnCode
{
    public partial class Form1 : Form
    {
        string[] Label_content = { "Bản Rõ", "Bản Mã" };
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
            radioButton12.Checked = true;
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = Label_content[0];
            label2.Text = Label_content[1];
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = Label_content[1];
            label2.Text = Label_content[0];
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label10.Text = Label_content[0];
            label9.Text = Label_content[1];
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label10.Text = Label_content[1];
            label9.Text = Label_content[0];
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = Label_content[0];
            label14.Text = Label_content[1];
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = Label_content[1];
            label14.Text = Label_content[0];
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            label20.Text = Label_content[0];
            label19.Text = Label_content[1];
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            label20.Text = Label_content[1];
            label19.Text = Label_content[0];
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            label23.Text = Label_content[0];
            label22.Text = Label_content[1];
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            label23.Text = Label_content[1];
            label22.Text = Label_content[0];
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            label26.Text = Label_content[0];
            label25.Text = Label_content[1];
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            label26.Text = Label_content[1];
            label25.Text = Label_content[0];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int n = richTextBox13.Lines.Length;
            int[,] key = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] tmp = richTextBox13.Lines[i].Split(' ');
                for (int j = 0; j < n; j++)
                {
                    key[i,j] = int.Parse(tmp[j]);
                }
            }
            richTextBox11.Text = HILL(richTextBox12.Text,key, radioButton12.Checked);
        }
    }
}
