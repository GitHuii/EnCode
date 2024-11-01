using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EnCode
{
    internal class Algorithm
    {
        public static string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string CEASAR(string input , int key , bool flag)
        {
            string output = "";
            if (flag)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    output += (char)((input[i] - 'A' + key) % 26 + 'A');
                }
                return output;
            }
            for (int i = 0; i < input.Length; i++)
            {
                output += (char)(((input[i] - 'A' - key + 26) % 26) + 'A');
            }
            return output;
        }
        
        public static string THAYTHE(string input , string key , bool flag)
        {
            string output = "";
            if (flag)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    output += key[(input[i] - 'A')];
                }
                return output;
            }
            for (int i = 0; i < input.Length; i++)
            {
                int pos = 0;
                for (int j = 0; j < key.Length; j++)
                {
                    if (input[i] == key[j])
                    {
                        pos = j;
                    }
                }
                output += Alphabet[pos];
            }
            return output;
        }

        public static string PLAYFAIR(string input , string key , bool flag)
        {
            string output = "";
            if (flag)
            {
                string tmp = Alphabet;
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
                while (input.Length > 1)
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
                if (input.Length == 1)
                {
                    stack.Add(input + 'X');
                }
                for (int i = 0; i < stack.Count; i++)
                {
                    int i0 = 0, j0 = 0;
                    int i1 = 0, j1 = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (matrix[j, k] == stack[i][0])
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
                    if (i0 == i1)
                    {
                        output += matrix[i0, (j0 + 1) % 5];
                        output += matrix[i1, (j1 + 1) % 5];
                    }
                    if (j0 == j1)
                    {
                        output += matrix[(i0 + 1) % 5, j0];
                        output += matrix[(i1 + 1) % 5, j1];
                    }
                    else
                    {
                        output += matrix[i0, j1];
                        output += matrix[i1, j0];
                    }
                }
            }
            return output;
        }

        public static string AFFINE(string input , int key_a , int key_b , bool flag)
        {
            string output = "";
            if (flag) //(ax+b)%26
            {
                for (int i = 0; i < input.Length; i++)
                {
                    output += (char)((key_a * (input[i] - 'A') + key_b) % 26 + 'A');
                }
                return output;
            }


            Dictionary<int, int> lib = new Dictionary<int, int>();
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
            int a1 = -1;
            try
            {
                a1 = lib[key_a];
            }
            catch
            {
                MessageBox.Show("Nhập lại khóa thỏa mãn GCD(a,26) = 1");
                return output;
            };
            for (int i = 0; i < input.Length; i++)//a1(y-b)%26
            {
                output += (char)((a1 * ((input[i] - 'A') + 26 - key_b)) % 26 + 'A');
            }
            return output;
        }
        public static string VIGENERE(string input , string key , bool flag)
        {
            string output = "";
            if (flag)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    output += (char)(((input[i] - 'A') + (key[i % key.Length] - 'A')) % 26 + 'A');
                }
                return output;
            }
            for (int i = 0; i < input.Length; i++)
            {
                output += (char)(((input[i] - 'A') - (key[i % key.Length] - 'A') + 26) % 26 + 'A');
            }
            return output;
        }

        public static string HILL(string input , int[,] key , bool flag)
        {
            string output = "";

            return output;
        }
    }
}
