using DLWMS.WinForms.Entiteti;
using DLWMS.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DLWMS.WinForms.Forme
{
    public partial class frmStudenti : Form
    {
        KonekcijaNaBazu _baza = DLWMSdb.Baza;
        string znak;
        int filterOcjena;

        public frmStudenti()
        {
            InitializeComponent();
            dgvStudenti.AutoGenerateColumns = false;
        }

        private void frmStudenti_Load(object sender, EventArgs e)
        {
            UcitajPodatkeOStudentima();
        }

        private void btnNoviStudent_Click(object sender, EventArgs e)
        {          
            PrikaziFormu(new frmNoviStudent());
            UcitajPodatkeOStudentima();
        }

        private void UcitajPodatkeOStudentima(List<Student> studenti = null)
        {
            dgvStudenti.DataSource = null;
            dgvStudenti.DataSource = Filtriraj();
        }

        private void PrikaziFormu(Form form)
        {
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void dgvStudenti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var student = dgvStudenti.SelectedRows[0].DataBoundItem as Student;
            Form form = null;
            if (student != null)
            {
                if (e.ColumnIndex == 6) 
                    form = new frmStudentiPredmeti(student);
                else
                    form = new frmNoviStudent(student);
                PrikaziFormu(form);

                UcitajPodatkeOStudentima();
            }
        }

        private List<Student> Filtriraj()
        {
            var datumOd = dateTimePicker1.Value.Date;
            var datumDo = dateTimePicker2.Value.Date;

            var listaPoDatumu = _baza.StudentiPredmeti.Where(d => d.Datum >= datumOd && d.Datum <= datumDo).ToList();
            var listaPoDatumuOcjeni = new List<StudentiPredmeti>();
                switch (znak)
            {
                case ">":
                    listaPoDatumuOcjeni = listaPoDatumu.Where(o => o.Ocjena > filterOcjena).ToList();
                    break;
                case ">=":
                    listaPoDatumuOcjeni = listaPoDatumu.Where(o => o.Ocjena >= filterOcjena).ToList();
                    break;
                case "<":
                    listaPoDatumuOcjeni = listaPoDatumu.Where(o => o.Ocjena < filterOcjena).ToList();
                    break;
                case "<=":
                    listaPoDatumuOcjeni = listaPoDatumu.Where(o => o.Ocjena <= filterOcjena).ToList();
                    break;
                case "=":
                    listaPoDatumuOcjeni = listaPoDatumu.Where(o => o.Ocjena == filterOcjena).ToList();
                    break;
            }

            var student = listaPoDatumuOcjeni.Select(s => s.Student).Distinct().ToList();
            if (listaPoDatumuOcjeni.Count != 0)
            {
                lblBrojStudenata.Text = $"Broj studenata: {student.Count()}";
                lblProsjecnaOcjena.Text = $"Prosjecna ocjena: {listaPoDatumuOcjeni.Average(o => o.Ocjena)}";
            }
            else
            {
                lblBrojStudenata.Text = "Trenutno nema pohranjenih studenata";
                lblProsjecnaOcjena.Text = $"Prosjek je trenutno 0";
            }

            return student;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Validiraj())
                znak = comboBox1.SelectedItem.ToString();

            UcitajPodatkeOStudentima();
        }

        private bool Validiraj()
        {
            return Validator.ValidirajKontrolu(comboBox1, errorProvider1, "Obavezno polje!") &&
                Validator.ValidirajKontrolu(comboBox2, errorProvider1, "Obavezni polje!");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Validiraj())
            filterOcjena = int.Parse(comboBox2.SelectedItem.ToString());

            UcitajPodatkeOStudentima();
        }
    }
}
