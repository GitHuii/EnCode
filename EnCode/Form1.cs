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

namespace EnCode
{
    public partial class Form1 : Form
    {

        Dictionary<int, int> lib = new Dictionary<int, int>();
        public Form1()
        {
            InitializeComponent();
        }
        string bangchucai = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private void button1_Click(object sender, EventArgs e)
        {
            //NGUYENVIETHUY
            //TMAEKTBOKZNAE
            //K=6
            string input = richTextBox1.Text;
            string output = "";
            if (radioButton1.Checked)
            {
                for(int i = 0; i< input.Length;i++)
                {
                    output += (char)((input[i] - 'A' + int.Parse(textBox1.Text))%26 + 'A');
                }
                richTextBox2.Text = output;
            }
            if(radioButton2.Checked)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    output += (char)(((input[i] - 'A' - int.Parse(textBox1.Text) + 26) % 26) + 'A');
                }
                richTextBox2.Text = output;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lib.Add(1, 1);
            lib.Add(3, 9);
            lib.Add(5, 21);
            lib.Add(7, 15);
            lib.Add(9, 3);
            lib.Add(11, 19);
            lib.Add(15, 7);
            lib.Add(17, 23);
            lib.Add(19, 11);
            lib.Add(21, 5);
            lib.Add(23, 17);
            lib.Add(25, 25);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Random rand = new Random();
            textBox2.Text = new string(bangchucai.OrderBy(c => rand.Next()).ToArray());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = richTextBox4.Text;
            string output = "";
            if (radioButton4.Checked == true)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    output += textBox2.Text[(input[i] - 'A')];
                }
                richTextBox3.Text = output;
            }

            //ZPBYJRSKFLXQNWVDHMGUTOIAEC    khoa
            //MEETMEAFTERTHETOGAPARTY
            //NJJUNJZRUJMUKJUVSZDZMUE      
            if (radioButton3.Checked == true)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    int pos = 0;
                    for(int j = 0; j < textBox2.Text.Length; j++)
                    {
                        if (input[i] == textBox2.Text[j])
                        {
                            pos = j;
                        }
                    }
                    output += bangchucai[pos];
                }
                richTextBox3.Text = output;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string input = richTextBox6.Text;
            string output = "";
            if (radioButton6.Checked == true)
            {
                string key = textBox3.Text;
                string tmp = bangchucai;
                bool isHaveIJ = false;
                for (int i = 0; i < key.Length; i++)
                {
                    if (key[i] == 'J' || key[i] == 'I')
                    {
                        tmp = tmp.Replace("I", "");
                        tmp = tmp.Replace("J", "");
                        isHaveIJ = true;
                    }
                    else
                    {
                        tmp = tmp.Replace(key[i].ToString(), "");
                    }
                }
                if (isHaveIJ == false)
                {
                    tmp = tmp.Replace("J", "");
                }
                key = key + tmp;
                char[,] matrix = new char[5, 5];
                for (int i = 0; i < key.Length; i++)
                {
                    matrix[i / 5, i % 5] = key[i];
                }
                List<string> stack = new List<string>();
                while(input.Length > 1)
                {
                    if (input[0] == input[1])
                    {
                        stack.Add(input[0].ToString() + 'X');
                        input = input.Remove(0, 1);
                        continue;
                    }
                    if (input[0] != input[1])
                    {
                        stack.Add(input[0].ToString() + input[1].ToString());
                        input = input.Remove(0, 2);
                        continue;
                    }
                }
                if(input.Length == 1)
                {
                    stack.Add(input+'X');
                }
                for(int i = 0; i < stack.Count; i++)
                {
                    int i0 = 0, j0 = 0;
                    int i1 = 0, j1 = 0;
                    for(int j = 0; j < 5; j++)
                    {
                        for(int k = 0; k < 5; k++)
                        {
                            if (matrix[j,k] == stack[i][0])
                            {
                                i0 = j;
                                j0 = k;
                            }
                            if (matrix[j, k] == stack[i][1])
                            {
                                i1 = j;
                                j1 = k;
                            }
                        }
                    }
                    if(i0==i1)
                    {
                        output += matrix[i0, (j0 + 1) % 5];
                        output += matrix[i1, (j1 + 1) % 5];
                    }
                    if (j0 == j1)
                    {
                        output += matrix[(i0+1)%5, j0];
                        output += matrix[(i1+1)%5, j1];
                    }
                    else
                    {
                        output += matrix[i0, j1];
                        output += matrix[i1, j0];
                    }
                }
                richTextBox5.Text = output;
            }
            //THUONGMAIDIENTU
            //MINH
            //YETPMLIMAMNCHCHSSZ
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string input = richTextBox8.Text;
            string output = "";
            int a = int.Parse(textBox4.Text);
            int b = int.Parse(textBox5.Text);
            //HANOIMUATHU
            //k 5 3
            //MDQVRLZDUMZ
            if (radioButton8.Checked == true) //(ax+b)%26
            {
                for(int i = 0; i < input.Length;i++)
                {
                    output += (char)((a * (input[i]-'A') + b) % 26 + 'A');
                }
                richTextBox7.Text = output;
            }
            if (radioButton7.Checked == true) //a1(y-b)%26
            {
                int a1 = lib[a];
                for (int i = 0; i < input.Length; i++)
                {
                    output += (char)((a1 * ((input[i] - 'A')+26 - b)) % 26 + 'A');
                }
                richTextBox7.Text = output;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //MEETMEATSUNSET
            //CIPHER
            //OMTAQVCBHBRJGB
            string input = richTextBox10.Text;
            string output = "";
            string key = textBox6.Text;
            if (radioButton10.Checked == true)
            {
                for(int i = 0; i < input.Length;i++)
                {
                    output += (char)( ((input[i] - 'A') + (textBox6.Text[i % textBox6.Text.Length]-'A'))%26 + 'A');
                }
                richTextBox9.Text = output;
            }
            if (radioButton9.Checked == true)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    output += (char)(((input[i] - 'A') - (textBox6.Text[i % textBox6.Text.Length] - 'A')+ 26) % 26 + 'A');
                }
                richTextBox9.Text = output;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/Huii.FB");
        }
    }
}
