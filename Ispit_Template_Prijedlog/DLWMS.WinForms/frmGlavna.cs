using DLWMS.WinForms.DB;
using DLWMS.WinForms.IB200002;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms
{
    public partial class frmGlavna : Form
    {
        KonekcijaNaBazu _baza = DLWMSdb.Baza;
        string filterImePrezime = "";
        public frmGlavna()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void frmGlavna_Load(object sender, EventArgs e)
        {
            try
            {
                lblInfo.Text = $"Broj studenata u bazi: {DB.DLWMSdb.Baza.Studenti.Count()}";
                UcitajPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException?.Message);
            }
        }

        private void UcitajPodatke()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Filtriraj();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Reports.frmIzvjestaj().Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabrani = dataGridView1.SelectedRows[0].DataBoundItem as Student;
            if(e.ColumnIndex == 4)
            {
                var frmP = new frmPolozeni(odabrani);
                frmP.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frmNovi = new frmNoviStudent();
            if(frmNovi.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var _student = dataGridView1.SelectedRows[0].DataBoundItem as Student;
            var frmMod = new frmNoviStudent(_student);
            if (frmMod.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }
        private List<Student> Filtriraj()
        {
            var lista = _baza.Studenti.Where(s => 
           filterImePrezime == "" || s.Ime.ToLower().Contains(filterImePrezime) || s.Prezime.ToLower().Contains(filterImePrezime)).ToList();
            return lista;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filterImePrezime = textBox1.Text.ToLower();
            UcitajPodatke();
        }
    }
}
