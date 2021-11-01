using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOXO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int Brojac { get; set; }

        private void Igraj(object sender)
        {
            if (sender is Button) {
                var dugme = sender as Button;
                if (dugme.Text == "")
                {
                    if (Brojac % 2 != 0)
                        dugme.Text = "X";
                    else
                        dugme.Text = "O";
                    Brojac++;
                    if (KrajIgre())
                        StatusDugmica(false);
                }
            }
            
        }
        private void StatusDugmica(bool enabled, bool resetText = false, bool resetColor=false)
        {
            foreach(var kontrola in this.Controls)
            {
                if(kontrola is Button)
                {
                    var dugme = kontrola as Button;
                    if(dugme!= button10)
                    {
                        dugme.Enabled = enabled;
                        dugme.Text = resetText ? "" : dugme.Text;
                        if (resetColor)
                        {
                            dugme.UseVisualStyleBackColor = true;
                            Brojac = 0;
                        }
                    }
                }
            }
        }
        private bool KrajIgre()
        {
            return ProvjeriRedove() || ProvjeriKolone() || ProvjeriDijagonale();
        }
        private bool Pobjeda(Button button1, Button button2, Button button3)
        {
            if (button1.Text != "")
            {
                if (button1.Text == button2.Text && button1.Text == button3.Text)
                {
                    button1.BackColor = button2.BackColor = button3.BackColor = Color.Blue;
                    return true;
                }
            }
            return false;
        }
        private bool ProvjeriRedove()
        {
            return Pobjeda(button1, button2, button3) ||
                Pobjeda(button4, button5, button6) ||
                Pobjeda(button7, button8, button9);
        }
        private bool ProvjeriKolone()
        {
            return Pobjeda(button1, button4, button7) ||
                Pobjeda(button2, button5, button8) ||
                Pobjeda(button3, button6, button9);
        }
        private bool ProvjeriDijagonale()
        {
            return Pobjeda(button1, button5, button9) ||
                Pobjeda(button3, button5, button7);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Igraj(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Igraj(sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Igraj(sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Igraj(sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Igraj(sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Igraj(sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Igraj(sender);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Igraj(sender);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Igraj(sender);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            StatusDugmica(true, true, true);
        }
    }
}
