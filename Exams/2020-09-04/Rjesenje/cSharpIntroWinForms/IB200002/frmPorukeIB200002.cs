using cSharpIntroWinForms.IB200002.Izvjestaj;
using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms.IB200002
{
    public partial class frmPorukeIB200002 : Form
    {
        private Korisnik _odabrani;
        KonekcijaNaBazu _baza = DLWMS.DB;

        public frmPorukeIB200002(Korisnik odabrani)
        {
            InitializeComponent();
            _odabrani = odabrani;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void frmPorukeIB200002_Load(object sender, EventArgs e)
        {
            lblImePrezime.Text = _odabrani.ToString();
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _baza.KorisniciPoruke.Where(k => k.Korisnik.Id == _odabrani.Id).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frmNova = new frmNovaPorukaIB200002(_odabrani);
            if(frmNova.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabranaPoruka = dataGridView1.SelectedRows[0].DataBoundItem as KorisniciPoruke;
            if (e.ColumnIndex == 3)
            {
                if (MessageBox.Show("Jeste li sigurni?", "Obavijest", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _baza.KorisniciPoruke.Remove(odabranaPoruka);
                    _baza.SaveChanges();
                    UcitajPodatke();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var listaOdabranog = _baza.KorisniciPoruke.Where(k => k.Korisnik.Id == _odabrani.Id).ToList();
            var frmIzvj = new frmIzvjestajIB200002(listaOdabranog);
            frmIzvj.Show();
        }
    }
}
