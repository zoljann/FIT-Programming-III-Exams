using DLWMS.WinForms.Helpers;
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
    public partial class frmPretragaIB200002 : Form
    {
        string filterImePrezime = "";
        KonekcijaNaBazu _baza = DLWMSdb.Baza;
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
        List<StudentiStatistika> Filtriraj()
        {
            var lista = new List<StudentiStatistika>();
            var studenti = _baza.StudentiPredmeti.Where(s => filterImePrezime=="" || s.Student.Ime.ToLower().Contains(filterImePrezime) ||
            s.Student.Prezime.ToLower().Contains(filterImePrezime)).Select(s=>s.Student).Distinct().ToList();
           
            for (int i = 0; i < studenti.Count(); i++)
            {
                var noviStudentStatistika = new StudentiStatistika()
                {
                    Student = studenti[i],
                    BrojPolozenih = _baza.StudentiPredmeti.ToList().Where(s=>s.Student.Id == studenti[i].Id).Count(),
                    PolozeniPredmeti = string.Join(";", _baza.StudentiPredmeti.ToList().Where(s=>s.Student.Id == studenti[i].Id).Select(p=>p.Predmet)),
                    Prosjek = _baza.StudentiPredmeti.ToList().Where(s=>s.Student.Id == studenti[i].Id).Average(o=>o.Ocjena),
                };
                lista.Add(noviStudentStatistika);
            }
            if (lista.Count() != 0)
            {
                lblProsjek.Text = lista.Average(p => p.Prosjek).ToString();
                var student = lista.OrderByDescending(p => p.Prosjek).First();
                lblImePrezime.Text = $"{student.Student}";
            }
            else
            {
                lblProsjek.Text = "0";
                lblImePrezime.Text = "NOT_SET";
            }
            return lista;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filterImePrezime = textBox1.Text.ToLower();
            UcitajPodatke();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabraniStudent = (dataGridView1.SelectedRows[0].DataBoundItem as StudentiStatistika).Student;
            if(e.ColumnIndex == 4)
            {
                var frmScan = new frmScanIspitaIB200002(odabraniStudent);
                frmScan.Show();
            }
        }

        private async void button1_Click(object sender, EventArgs e) //Threading
        {
            List<string> _samoglasnici = new List<string> { "a", "e", "i", "o", "u" };
            List<string> _znakovi = new List<string> { "?", "!", "<", ">", "*" };
            var unos = textBox2.Text.ToLower();
            int samoglasnici = 0;
            int suglasnici = 0;
            int znakovi = 0;
            await Task.Run(() =>
            {
            samoglasnici = unos.Where(s => _samoglasnici.Contains(s.ToString())).Count();
            znakovi = unos.Where(z => _znakovi.Contains(z.ToString())).Count();
            suglasnici = unos.Length - samoglasnici - znakovi;
            });
            Action action = new Action(() => txtInfo.Text = $"Sadrzaj info: {Environment.NewLine}" +
             $"\tSamoglasnika: {samoglasnici} {Environment.NewLine}" +
             $"\tSuglasnika: {suglasnici} {Environment.NewLine}" +
             $"\tZnakova: {znakovi}");
            BeginInvoke(action);
        }
    }
}
