using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Drawing2D;
using MathNet.Numerics.LinearAlgebra;
using System.Security.AccessControl;
using System.Security.Cryptography;

namespace EnCode
{
    internal class Algorithm
    {
        public static string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static Dictionary<double, int> lib = new Dictionary<double, int>();

        public static void LIST_GCD26()
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
            double a1 = -1;
            try
            {
                a1 = lib[key_a];
            }
            catch
            {
                MessageBox.Show("Nhập lại khóa thỏa mãn GCD(a,26) = 1");
                return output;
            };
            if (flag) //(ax+b)%26
            {
                for (int i = 0; i < input.Length; i++)
                {
                    output += (char)((key_a * (input[i] - 'A') + key_b) % 26 + 'A');
                }
                return output;
            }
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
        public static Matrix<double> MATRANLIENHOP(Matrix<double> matrix)
        {
            var cofactorMatrix = Matrix<double>.Build.Dense(matrix.RowCount, matrix.RowCount);

            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.RowCount; j++)
                {
                    var minor = Matrix<double>.Build.Dense(matrix.RowCount - 1, matrix.RowCount - 1);
                    for (int row = 0; row < matrix.RowCount; row++)
                    {
                        for (int col = 0; col < matrix.RowCount; col++)
                        {
                            if (row != i && col != j)
                            {
                                int minorRow = row < i ? row : row - 1;
                                int minorCol = col < j ? col : col - 1;
                                minor[minorRow, minorCol] = matrix[row, col];
                            }
                        }
                    }
                    cofactorMatrix[i, j] = (int)Math.Pow(-1, i + j) * (int)(minor.Determinant() % 26);
                }
            }

            return cofactorMatrix;
        }

        public static double MOD(double a , int b = 26)
        {
            if (a >= 0)
            {
                return Math.Ceiling(a % b);
            }
            a = Math.Abs(a);
            double i = Math.Ceiling(a /b);
            return Math.Ceiling(a*(-1) + i*b)%b;
        }
        public static string HILL(string input , double[,] key , bool flag)
        {
            string output = "";
            int n = (int)Math.Sqrt(key.Length);
            List<string> stack = new List<string>();
            while (input.Length >= n)
            {
                stack.Add(input.Substring(0, n));
                input = input.Remove(0, n);
            }
            if (flag)
            {
                foreach (var x in stack)
                {
                    for (int j = 0; j < n; j++)
                    {
                        double tmp = 0;
                        for (int i = 0; i < n; i++)
                        {
                            tmp += key[i, j] * int.Parse((x[i] - 'A').ToString());
                        }
                        output += (char)(tmp % 26 + 'A');
                    }
                }
                return output;
            }
            Matrix<double> k = Matrix<double>.Build.DenseOfArray(key);
            if (!lib.ContainsKey(MOD(k.Determinant())))
            {
                MessageBox.Show("UCLN(det(k),26) != 1 nên không có k khả nghịch trên Z26");
                return output;
            }
            var k1 = MATRANLIENHOP(k).Transpose();
            for (int i = 0; i < k1.RowCount; i++)
            {
                for (int j = 0; j < k1.ColumnCount; j++)
                {
                    k1[i, j] = (k1[i, j] * lib[MOD(k.Determinant())]) % 26;
                    if (k1[i, j] < 0)
                    {
                        k1[i, j] += 26;
                    }
                }
            }
            foreach (var x in stack)
            {
                for (int j = 0; j < n; j++)
                {
                    double tmp = 0;
                    for (int i = 0; i < n; i++)
                    {
                        tmp += k1[i, j] * int.Parse((x[i] - 'A').ToString());
                    }
                    output += (char)(tmp % 26 + 'A');
                }
            }
            return output;
        }

        public static string THEOHANG(string input , int[] key , bool flag)
        {
            string output = "";
            List<string> stack = new List<string>();
            if (flag)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    string tmp = "";
                    for (int j = i; j < input.Length; j += key.Length)
                    {
                        tmp += input[j];
                    }
                    stack.Add(tmp);
                }
                for (int i = 1; i <= key.Length; i++)
                {
                    for(int j = 0; j  < key.Length; j++)
                    {
                        if (key[j] == i)
                        {
                            output += stack[j];
                        }
                    }
                }
                return output;
            }
            int[] dem = Enumerable.Repeat(0, key.Length).ToArray(); ;
            for (int i = 0; i < input.Length; i++)
            {
                dem[i % key.Length]++;
            }
            for (int i = 1; i <= key.Length; i++)
            {
                string tmp = "";
                for(int j = 0; j < key.Length; j++)
                {
                    if (key[j] == i)
                    {
                       tmp = input.Substring(0, dem[j]);
                       if(dem[j] < dem[0])
                       {
                            tmp += ' ';
                       }
                       input = input.Remove(0, dem[j]);
                    }
                }
                stack.Add(tmp);
            }
            for(int i = 0; i < dem[0]; i++)
            {
                for(int j = 0; j < key.Length; j++)
                {
                    if(stack[key[j] - 1][i] != ' ')
                    {
                        output += stack[key[j] - 1][i];
                    }
                }
            }
            return output;
        }

        public static string RAILFENCE(string input , bool flag)
        {
            string output = "";
            if(flag)
            {
                string str1 = "";
                string str2 = "";
                for(int i = 0; i < input.Length;i++)
                {
                    if(i%2==0)
                    {
                        str1 += input[i];
                    }
                    else
                    {
                        str2 += input[i];
                    }
                }
                return str1 + str2;
            }
            for(int i = 0; i < input.Length/2; i++)
            {
                output += input[i];
                output += input[i+input.Length/2+1];
            }
            if(input.Length%2!=0)
            {
                output += input[input.Length / 2];
            }
            return output;
        }
    }
}
