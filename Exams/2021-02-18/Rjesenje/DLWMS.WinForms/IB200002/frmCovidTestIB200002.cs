using DLWMS.WinForms.Entiteti;
using DLWMS.WinForms.Helpers;
using DLWMS.WinForms.Izvjestaji;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms.IB200002
{
    public partial class frmCovidTestIB200002 : Form
    {
        KonekcijaNaBazu _baza = DLWMSdb.Baza; 
        public frmCovidTestIB200002()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void frmCovidTestIB200002_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = _baza.Studenti.ToList();
            UcitajPodatke();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidirajDatum())
            {
                var noviTest = new StudentiCovidTestovi()
                {
                    Student = comboBox1.SelectedItem as Student,
                    Datum = dateTimePicker1.Value,
                    Rezultat = comboBox2.Text,
                    NalazDostavljen = checkBox1.Checked
                };
                _baza.StudentiCovidTestovi.Add(noviTest);
                _baza.SaveChanges();
                UcitajPodatke();
            }
            else
                MessageBox.Show("Vec je unesen test za navedenog korisnika na isti datum!");
        }
       

        private bool ValidirajDatum()
        {
            var odabraniStudent = comboBox1.SelectedItem as Student;
            foreach (var student in _baza.StudentiCovidTestovi)
            {
                if (student.Datum.Date == dateTimePicker1.Value.Date && student.Student.Id == odabraniStudent.Id)
                    return false;
            }
                return true;
        }

        private void UcitajPodatke()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _baza.StudentiCovidTestovi.ToList();
            if (_baza.StudentiCovidTestovi.Count() != 0)
            {
                lblBrojTestova.Text = $"Broj testova: {_baza.StudentiCovidTestovi.Count()}";
            }
            else
                lblBrojTestova.Text = "Nema testova!";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni da želite obrisati sve podatke o COVID testovima?", "Obavijest", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _baza.StudentiCovidTestovi.RemoveRange(_baza.StudentiCovidTestovi);
                _baza.SaveChanges();
                UcitajPodatke();
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            Action action = () => UcitajPodatke();
            await Task.Run(() => { 
            if (textBox1.Text != "")
            {
                int brojac = int.Parse(textBox1.Text);
                var rand = new Random();
                for (int i = 0; i < brojac; i++)
                {
                    var noviTest = new StudentiCovidTestovi()
                    {
                        Student = _baza.Studenti.ToList().ElementAt(rand.Next(1, 6)),
                        Datum = DateTime.Now,
                        Rezultat = rand.NextDouble() > 0.5 ? "Negativan" : "Pozitivan",
                        NalazDostavljen = rand.NextDouble() > 0.5
                    };
                    _baza.StudentiCovidTestovi.Add(noviTest);
                    _baza.SaveChanges();
                }
                    BeginInvoke(action);
                    MessageBox.Show($"Uspjesno generisano {brojac} testova");
                }
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var listaTestova = _baza.StudentiCovidTestovi.ToList();
            var frmIzvj = new frmIzvjestaji(listaTestova);
            frmIzvj.Show();
        }
    }
}
