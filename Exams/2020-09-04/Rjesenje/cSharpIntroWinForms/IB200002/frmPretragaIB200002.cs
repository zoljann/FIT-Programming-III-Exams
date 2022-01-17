using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms.IB200002
{
    public partial class frmPretragaIB200002 : Form
    {
        KonekcijaNaBazu _baza = DLWMS.DB;
        string filterPredmet = "";
        public frmPretragaIB200002()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void frmPretragaIB200002_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Filtriraj();
        }

        private object Filtriraj()
        {
            var lista = _baza.KorisniciPredmeti.Where(s => (filterPredmet == "" || s.Predmet.Naziv.ToLower().Contains(filterPredmet))).ToList();
            if (lista.Count() != 0)
            {
                lblProsjekPrikazanih.Text = $"Prosjek prikazanih ocjena: {lista.Average(o => o.Ocjena)}";
            }
            else
            {
                lblProsjekPrikazanih.Text = "Nema ucitanih studenta!";
            }

            return lista;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filterPredmet = textBox1.Text.ToLower();
            UcitajPodatke();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabrani = (dataGridView1.SelectedRows[0].DataBoundItem as KorisniciPredmeti).Korisnik;
            if (e.ColumnIndex == 4)
            {
                var frmPoruke = new frmPorukeIB200002(odabrani);
                frmPoruke.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                Thread thread = new Thread(Sumiraj);
                var unos = long.Parse(textBox2.Text);
                thread.Start(unos);
            }
        }
        private void Sumiraj(object obj)
        {
            var unos = long.Parse(obj.ToString());
            long suma = 0;
            for (int i = 0; i < unos; i++)
                suma += i;
            Action action = () => lblSuma.Text = suma.ToString();
            BeginInvoke(action);
        }
    }
}
