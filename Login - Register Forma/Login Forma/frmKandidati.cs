using Login_Forma.DB;
using Login_Forma.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Forma
{
    public partial class frmKandidati : Form
    {
        public frmKandidati()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void frmKandidati_Load(object sender, EventArgs e)
        {
            UcitajKandidate();
        }

        private void UcitajKandidate()
        {
            try
            {
                KonekcijaNaBazu db = new KonekcijaNaBazu();
                dataGridView1.DataSource = db.Kandidati.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}" +$"{ex.InnerException?.Message}");
                //dodajemo i innerexception, dodajemo ? da provjerimo da li je null da ne bi doslo do errora

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
                {
                    KonekcijaNaBazu db = new KonekcijaNaBazu();
                    var noviKandidat = new Kandidat()
                    {
                        Ime = textBox1.Text,
                        Prezime = textBox2.Text,
                        Email = textBox3.Text
                    };
                    db.Kandidati.Add(noviKandidat);
                    db.SaveChanges(); //obavezno moramo spasiti inace se nece aplicirati na pravu bazu
                    UcitajKandidate();
                }
                else
                    MessageBox.Show("Prazno polje!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} + {Environment.NewLine}" + $"{ex.InnerException?.Message}");
                throw;
            }
           
        }
    }
}
