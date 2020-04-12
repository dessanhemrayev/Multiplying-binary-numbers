using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
           
            panel4.Visible = false;
        }

        string DecToBin(int n)
        {
            string str="";
            int m = 0;
            while (n>0)
            {
                m = n % 2;
                str += m.ToString();
                n = n / 2;
            }
            string s2 = "";

            for (int i = str.Length-1; i >=0 ; i--)
            {
                s2 =s2+ str[i];
            }

            return s2;

        }

        string Dlina(string s1, string s2)
        { 
            int kl = 0; //длина первого кода

            string s = "";
            kl = s1.Length - s2.Length;
            
        for(int i=0;i<kl;i++)
            {
                s += "0";
            }

            return s+s2;
        }

        string Add(string x, string y)
        {
            string z = "";
            char p = '0';//Перенос при сложении двух разрядов
            if (x.Length != y.Length)
            {

                x = x.PadLeft(y.Length, '0');
                y = y.PadLeft(x.Length, '0');

            }

            for (int i = y.Length - 1; i >= 0; i--)
            {
                if (y[i] == '0' && x[i] == '0' && p == '0') { z = '0' + z; p = '0'; continue; }
                if (y[i] == '0' && x[i] == '0' && p == '1') { z = '1' + z; p = '0'; continue; }
                if (y[i] == '1' && x[i] == '0' && p == '0') { z = '1' + z; p = '0'; continue; }
                if (y[i] == '1' && x[i] == '0' && p == '1') { z = '0' + z; p = '1'; continue; }
                if (y[i] == '0' && x[i] == '1' && p == '0') { z = '1' + z; p = '0'; continue; }
                if (y[i] == '0' && x[i] == '1' && p == '1') { z = '0' + z; p = '1'; continue; }
                if (y[i] == '1' && x[i] == '1' && p == '0') { z = '0' + z; p = '1'; continue; }
                if (y[i] == '1' && x[i] == '1' && p == '1') { z = '1' + z; p = '1'; continue; }
            }
            return z;
        }
      
        string Multipline(string a, string b)
        {
            string rez = "";
            for (int i = 0; i < a.Length+b.Length; i++)
            {
                rez += "0";
            }
                       
            for (int i = b.Length - 1; i >= 0; i--)
            {
                if (b[i] == '1') rez = Add(rez, a);
                a = a + '0'; // Это сдвиг
            }

            return rez;
        }

        string inverse(string s)
        {
            int[] tr = new int[s.Length];
            string res="";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i]=='1')
                {
                    tr[i] = 0;
                }
                else
                    tr[i] = 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                res += tr[i].ToString();
            }

            return res;
        }


        string dopolnitel(string s)
        {
            string res = "";
            string res1 = "";
            int[] tr = new int[s.Length];
           
            for (int i = 0; i < s.Length; i++)
            {
                if (i == s.Length-1) { tr[i] = 1; res1 += tr[i].ToString(); }
                else
                {
                    tr[i] = 0;
                    res1 += tr[i].ToString();
                }
            }

            res = Add(s, res1);

            return res;
        }


        string BinToDec(string s) 
        {
            
            double sum = 0;
            for (int i = 0; i< s.Length; i++)
            {
                sum += Convert.ToInt32(s[i].ToString()) * Math.Pow(2, s.Length-1-i);

            }
            return sum.ToString(); 
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b;
            int k, l;

            a = Convert.ToInt32(textBox1.Text);
            b = Convert.ToInt32(textBox2.Text);
            k=a;
            l =b ;
            string s1 = "", s2 = "", s11 = "0", s22 = "0";

            if (a < 0) 
            {
                a *= -1;
                s11 = "1";
                s1 = DecToBin(a);
            }
            else { s1 = DecToBin(a); }
            if (b < 0)
            {
                b *= -1;
                s22 = "1";
                s2 = DecToBin(b);
            }
            else { s2 = DecToBin(b); }
           
            int kk= 0; //длина второго кода

            if (s1.Length > s2.Length) 
            {
                s2 = Dlina(s1,s2);

            }
            else
            {
                s1 = Dlina(s2, s1);
            }
            int znak = Convert.ToInt16(s11) ^ Convert.ToInt16(s22);
            string otw = "";

          
            if (radioButton1.Checked==true)
            {
                label5.Text = label5.Text + s11 + "." + s1;
                label6.Text = label6.Text + s22 + "." + s2;

                if (k>0 && l > 0)
                {
                    panel1.Visible = true;
                    panel2.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = false;
                    label8.Text = s1;
                    label9.Text = s2;
                    label13.Text = label9.Text;
                    label15.Text = label8.Text;
                    otw= Multipline(s1, s2);
                    label11.Text = otw;
                    label20.Text = znak.ToString();
                    label24.Text = znak.ToString() + "." + otw;
                    if (znak == 0) 
                    {
                        label22.Text = BinToDec(otw);
                    }
                    else
                    {
                        label22.Text = "-"+BinToDec(otw);
                    }
                }
               else
                 if (k > 0 && l < 0)

                {
                    panel1.Visible = true;
                    panel2.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = false;

                    label8.Text = s1;
                    string st2 = inverse(s2); // обратный код
                    label9.Text =st2;
                    label13.Text = label8.Text;
                    label15.Text = label9.Text;
                    otw = Multipline(s1, st2);
                    label11.Text = otw;
                    string s_space = "";
                    for (int i = 0; i < otw.Length-s1.Length; i++)
                    {
                        s_space += "0";
                    }
                    string st3 = s_space + s1;
                    label26.Text = st3;

                    string st4 = Add(otw, st3);

                    label29.Text = st4;

                    string st5 = inverse(st4);
                    label32.Text = st5;  //переход в обратный код
                    string st6 = "";

                    s1=s1.PadRight(st4.Length, '0');
                    label35.Text = s1;
                    st6 = Add(st5, "0"+s1);
                    label37.Text = st6;
                    string st7 = "1";
                    string st8 = "";
                    string result = "";
                    if (st6.Length > st4.Length && st6[0] == '1') 
                    {
                        st7 = st7.PadLeft(st6.Length, '0');
                        label39.Text = st7;
                        for (int i = 1; i < st6.Length; i++)
                        {
                            st8 += st6[i].ToString();
                        }
                        result = Add(st8, st7);
                        label41.Text = result;

                    }
                    label20.Text = znak.ToString();
                    label24.Text = znak.ToString() + "." + result;
                    if (znak == 0)
                    {
                        label22.Text = BinToDec(result);
                    }
                    else
                    {
                        label22.Text = "-" + BinToDec(result);

                    }

                }

                else if (k < 0 && l > 0)
                {
                    panel1.Visible = false;
                    panel2.Visible = true;
                    panel3.Visible = false;
                    panel4.Visible = false;
                    string st1 = inverse(s1); // обратный код
                    label82.Text = st1;
                    string st2 = s2; // обратный код

                    label80.Text = s2;
                    label76.Text = label82.Text;
                    label74.Text = label80.Text;
                    otw = Multipline(st1, s2);
                    label78.Text = otw;

                    string st3 = inverse(otw);//переход в обратный код
                    s2 = s2.PadRight(st3.Length, '0');
                    label57.Text = st3;
                    label55.Text = s2;

                    string st4 = "";
                    string st5 = "1";
                    string st6 = "";
                    string result = "";
                    
                    st4 = Add(st3, "0" + s2);
                    label53.Text = st4;

                    if (st4.Length > st3.Length && st4[0] == '1')
                    {
                        st5 = st5.PadLeft(st4.Length, '0');
                        label51.Text = st5;
                        for (int i = 1; i < st4.Length; i++)
                        {
                            st6 += st4[i].ToString();
                        }
                        result = Add(st6, st5);
                        label49.Text = result;
                    }
                    st2= st2.PadLeft(result.Length, '0');
                    string st7 = inverse(st2);
                    st7=st7.PadLeft(result.Length, '0');
                    label60.Text = st7;

                    string ss1 = Add(result,'0'+st7);
                    label84.Text = ss1;

                    string ss2 = "";
                    string result2 = "";
                 
                    if (ss1.Length > result.Length && ss1[0] == '1')
                    {
                        st5 = st5.PadLeft(ss1.Length, '0');
                        label64.Text = st5;
                        for (int i = 1; i < ss1.Length; i++)
                        {
                            ss2 += ss1[i].ToString();
                        }
                        result2 = Add(ss2, st5);
                        label87.Text = result2;
                    }

                    label70.Text = znak.ToString();
                    label66.Text = znak.ToString() + "." + result2;
                    if (znak == 0)
                    {
                        label68.Text = BinToDec(result2);
                    }
                    else
                    {
                        label68.Text = "-" + BinToDec(result2);

                    }


                }

            }
           else
                if(radioButton2.Checked == true)
            {
                label5.Text = label5.Text + s11 + "." + s1;
                label6.Text = label6.Text + s22 + "." + s2;
                if (k > 0 && l > 0)
                {
                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = true;
                    panel4.Visible = false;


                    label99.Text = s1;
                    label97.Text = s2;
                    label93.Text = s1;
                    label91.Text = s2;
                    label113.Text = znak.ToString();

                    
                    otw = Multipline(s1, s2);
                    label95.Text = otw;
                    label109.Text = znak.ToString() + "." + otw;
                    if (znak == 0)
                    {
                        label111.Text = BinToDec(otw);
                    }
                    else
                    {
                        label111.Text = "-" + BinToDec(otw);

                    }



                }
                else
                if (k > 0 && l < 0)
                {
                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = true;
                    panel4.Visible = false;

                    label99.Text = s1;
                    label97.Text =dopolnitel(inverse(s2));
                    label93.Text = s1;
                    label91.Text = dopolnitel(inverse(s2));
                    label113.Text = znak.ToString();

                    label105.Text = "А2n";

                    string dop1= dopolnitel(inverse(s2)); 
                    string res1= Multipline(s1, dop1);
                    string res2 = "";
                    
                    label95.Text = res1;
                    s1 = s1.PadRight(res1.Length, '0');

                    string st1 = dopolnitel(inverse(res1)); ;
                    res2 = Add(st1, s1);
                    label106.Text = st1;
                    label104.Text = s1;
                    label102.Text = res2;

                    label109.Text = znak.ToString() + "." + res2;
                    if (znak == 0)
                    {
                        label111.Text = BinToDec(res2);
                    }
                    else
                    {
                        label111.Text = "-" + BinToDec(res2);

                    }



                }
                else

                if (k < 0 && l > 0)
                {
                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = true;
                    panel4.Visible = false;

                    label99.Text = dopolnitel(inverse(s1));
                    label97.Text = s2;
                    label93.Text = dopolnitel(inverse(s1));
                    label91.Text = s2;
                    label113.Text = znak.ToString();

                    label105.Text = "B2n";

                    string dop1 = dopolnitel(inverse(s1));
                    string res1 = Multipline(s2, dop1);
                    string res2 = "";

                    label95.Text = res1;
                    s2 = s2.PadRight(res1.Length, '0');

                    string st1 = dopolnitel(inverse(res1)); ;
                    res2 = Add(st1, s2);
                    label106.Text = st1;
                    label104.Text = s2;
                    label102.Text = res2;

                    label109.Text = znak.ToString() + "." + res2;
                    if (znak == 0)
                    {
                        label111.Text = BinToDec(res2);
                    }
                    else
                    {
                        label111.Text = "-" + BinToDec(res2);

                    }





                }
                else
                    if (k < 0 && l < 0)
                {
                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = true;

                    label139.Text = dopolnitel(inverse(s1));
                    label137.Text = dopolnitel(inverse(s2));
                    label133.Text = dopolnitel(inverse(s1));
                    label131.Text = dopolnitel(inverse(s2));
                    label121.Text = znak.ToString();

                  

                    string dop1 = dopolnitel(inverse(s1));
                    string dop2= dopolnitel(inverse(s2));
                    string res1 = Multipline(dop1, dop2);
                    string res2 = "";
                label135.Text = res1;
                    label148.Text = res1;

                    label126.Text = dopolnitel(inverse(s1));
                    label124.Text = dopolnitel(inverse(s2));

                    string sum = Add(dop1, dop2);
                    label115.Text = sum;
                    string r_sum = dopolnitel(inverse(sum));
                    label141.Text = r_sum;
               
                    r_sum = r_sum.PadRight(res1.Length, '0');
                    label146.Text = r_sum;
                    res2 = Add(res1, r_sum);

                    label143.Text = res2;

                    label117.Text = znak.ToString() + "." + res2;
                    if (znak == 0)
                    {
                        label119.Text = BinToDec(res2);
                    }
                    else
                    {
                        label119.Text = "-" + BinToDec(res2);

                    }


                }





            }
            else
            {
                MessageBox.Show("Выберите режим", "Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;

            // panel1
            textBox1.Text = "";
            textBox2.Text = "";
            label5.Text = "";
            label6.Text = "";
            label8.Text = "";
            label9.Text = "";
            label13.Text = "";
            label15.Text = "";
            label11.Text = "";
                       
            label11.Text = "";
            label20.Text = "";
            label22.Text = "";
            label24.Text = "";

            label26.Text = "";
            label29.Text = "";
            label32.Text = "";
            label35.Text = "";
            label37.Text = "";
            label39.Text = "";
            label41.Text = "";

            // panel2

          
            label80.Text = "";
            label82.Text = "";
            label76.Text = "";
            label74.Text = "";
            label78.Text = "";
            label84.Text = "";
            label64.Text = "";

            label87.Text = "";
            label66.Text = "";
            label70.Text = "";
            label68.Text = "";
            label60.Text = "";
            label57.Text = "";
            label55.Text = "";
            label53.Text = "";
            label51.Text = "";
            label49.Text = "";

            //panel3


            label99.Text = "";
            label97.Text = "";
            label93.Text = "";
            label91.Text = "";
            label95.Text = "";
            label106.Text = "";
            label104.Text = "";
            label113.Text = "";
            label109.Text = "";
            label111.Text = "";

            //panel4

            label139.Text = "";
            label137.Text = "";
            label133.Text = "";
            label131.Text = "";
            label135.Text = "";
            label126.Text = "";
            label124.Text = "";
            label115.Text = "";
            label126.Text = "";

            label141.Text = "";
            label143.Text = "";
            label146.Text = "";

            label148.Text = "";
            label121.Text = "";
            label117.Text = "";
            label119.Text = "";


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
