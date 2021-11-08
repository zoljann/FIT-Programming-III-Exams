using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double FirstNumber;
        string Operacija;
        private void btnOne_Click(object sender, EventArgs e)
        {
            if(txtBox1.Text == "0" && txtBox1.Text!= null)
            {
                txtBox1.Text = "1";
            }
            else
            {
                txtBox1.Text = txtBox1.Text + 1;
            }
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            if (txtBox1.Text == "0" && txtBox1.Text != null)
            {
                txtBox1.Text = "2";
            }
            else
            {
                txtBox1.Text = txtBox1.Text + 2;
            }
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            if (txtBox1.Text == "0" && txtBox1.Text != null)
            {
                txtBox1.Text = "3";
            }
            else
            {
                txtBox1.Text = txtBox1.Text + 3;
            }
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            if (txtBox1.Text == "0" && txtBox1.Text != null)
            {
                txtBox1.Text = "4";
            }
            else
            {
                txtBox1.Text = txtBox1.Text + 4;
            }
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            if (txtBox1.Text == "0" && txtBox1.Text != null)
            {
                txtBox1.Text = "5";
            }
            else
            {
                txtBox1.Text = txtBox1.Text + 5;
            }
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            if (txtBox1.Text == "0" && txtBox1.Text != null)
            {
                txtBox1.Text = "6";
            }
            else
            {
                txtBox1.Text = txtBox1.Text + 6;
            }
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            if (txtBox1.Text == "0" && txtBox1.Text != null)
            {
                txtBox1.Text = "7";
            }
            else
            {
                txtBox1.Text = txtBox1.Text + 7;
            }
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            if (txtBox1.Text == "0" && txtBox1.Text != null)
            {
                txtBox1.Text = "8";
            }
            else
            {
                txtBox1.Text = txtBox1.Text + 8;
            }
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            if (txtBox1.Text == "0" && txtBox1.Text != null)
            {
                txtBox1.Text = "9";
            }
            else
            {
                txtBox1.Text = txtBox1.Text + 9;
            }
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
                txtBox1.Text = txtBox1.Text + 1;
        }

        private void btnSabiranje_Click(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(txtBox1.Text);
            txtBox1.Text = "0";
            Operacija = "+";
        }

        private void btnOduzimanje_Click(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(txtBox1.Text);
            txtBox1.Text = "0";
            Operacija = "-";
        }

        private void btnMnozenje_Click(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(txtBox1.Text);
            txtBox1.Text = "0";
            Operacija = "*";
        }

        private void btnDjeljenje_Click(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(txtBox1.Text);
            txtBox1.Text = "0";
            Operacija = "/";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtBox1.Text = "0";
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            txtBox1.Text = txtBox1.Text + ".";
        }

        private void btnJednako_Click(object sender, EventArgs e)
        {
            double SecondNumber;
            double Rezultat;
            SecondNumber = Convert.ToDouble(txtBox1.Text);
            switch (Operacija)
            {
                case "+":
                    Rezultat = (FirstNumber + SecondNumber);
                    txtBox1.Text = Convert.ToString(Rezultat);
                    FirstNumber = Rezultat;
                    break;
                case "-":
                    Rezultat = (FirstNumber - SecondNumber);
                    txtBox1.Text = Convert.ToString(Rezultat);
                    FirstNumber = Rezultat;
                    break;
                case "*":
                    Rezultat = (FirstNumber * SecondNumber);
                    txtBox1.Text = Convert.ToString(Rezultat);
                    FirstNumber = Rezultat; 
                    break;
                case "/":
                    if (SecondNumber == 0)
                    {
                        txtBox1.Text = "Ne mozes dijeliti sa 0!";

                    }
                    else
                    {
                        Rezultat = (FirstNumber / SecondNumber);
                        txtBox1.Text = Convert.ToString(Rezultat);
                        FirstNumber = Rezultat;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
