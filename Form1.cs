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

namespace Calculator
{
    public partial class MyForm : Form
    {
        public delegate decimal PerformCalculation(decimal x, decimal y);

        public MyForm()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text + "0";
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text + "1";
         
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            MainBox.Text ="";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text + "2";
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        { 
            MainBox.Text = MainBox.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text + "9";
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text + ",";
        }
       

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text + "=";
            
            PerformCalculation[] calculation = { multiplication, division, addition, subtraction};
            List<decimal> a = new List<decimal>();  // list for nambers
            List <char> splus = new List<char> ();
            string d = "";
            
            string plus = "x/+-=,";

            for (int i = 0; i < MainBox.Text.Length-1; i++)
            {
                if (MainBox.Text[i] == plus[0] ||
                    MainBox.Text[i] == plus[1] ||
                    MainBox.Text[i] == plus[2] ||
                    MainBox.Text[i] == plus[3] ||
                    MainBox.Text[i] == plus[4] ||
                    MainBox.Text[i] == plus[5]
                    )
                {
                    if (MainBox.Text[i + 1] == plus[0] ||
                        MainBox.Text[i + 1] == plus[1] ||
                        MainBox.Text[i + 1] == plus[2] ||
                        MainBox.Text[i + 1] == plus[3] ||
                        MainBox.Text[i + 1] == plus[4] ||
                        MainBox.Text[i + 1] == plus[5]
                        )
                    {
                        MessageBox.Show($"Error: are several signs contract for {i+1} symbols");
                        return;
                    }
                }
            }
            for (int i = 0; i < MainBox.Text.Length; i++)
            {
                
                if (MainBox.Text[i] == plus[0] ||
                    MainBox.Text[i] == plus[1] ||
                    MainBox.Text[i] == plus[2] ||
                    MainBox.Text[i] == plus[3] ||
                    MainBox.Text[i] == plus[4]
                    )
                    {
                        decimal s = Convert.ToDecimal(d);
                        splus.Add(MainBox.Text[i]);
                        a.Add(s);
                        d = "";
                    }  
                    else
                    {
                        d = d + MainBox.Text[i];
                    }
                    
                
            }

            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < a.Count-1; )
                {
                    Int16 z=0;
                    for (int j = k*2; j<k*2+2; j++)
                    if (splus[i] != plus[j] ) z++;
                    else
                    {
                        a[i] = calculation[j](a[i] , a[i + 1]);
                        a.RemoveAt(i + 1);
                        splus.RemoveAt(i);
                    }
                    if (z == 2) i++;
                }
            }

            MainBox.Text = "";
           
            MainBox.Text =  a[0].ToString();
        }

        private decimal multiplication(decimal a, decimal b)
        {
            a = a*b;
            return a;
        }

        private decimal division(decimal a, decimal b)
        {
            a = a / b;
            return a;
        }

        private decimal addition(decimal a, decimal b)
        {
            a = a + b;
            return a;
        }

        private decimal subtraction(decimal a, decimal b)
        {
            a = a - b;
            return a;
        }


        private void buttonDivision_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text + "/";
        }

        private void buttonMultiplication_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text + "x";
        }

        private void buttonАddition_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text + "+";
        }

        private void buttonSubtraction_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text + "-";
        }

        private void delete_Click(object sender, EventArgs e)
        {
            MainBox.Text = MainBox.Text.Substring(0, MainBox.Text.Length - 1);
        }
    }
}
