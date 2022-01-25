using DLWMS.WinForms.DB;
using DLWMS.WinForms.Helpers;
using DLWMS.WinForms.P5;
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
    public partial class frmNoviStudent : Form
    {
        KonekcijaNaBazu _baza = DLWMSdb.Baza;
        private Student _student;
       
        public frmNoviStudent(Student student = null)
        {
            InitializeComponent();
            _student = student?? new Student();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                _student.Ime = txtIme.Text;
                _student.Prezime = txtPrezime.Text;
                _student.DatumRodjenja = dtpDatumRodjenja.Value;
                _student.Email = txtEmail.Text;
                _student.Lozinka = txtLozinka.Text;
                _student.Aktivan = cbAktivan.Checked;
                _student.GodinaStudija = int.Parse(cmbGodinaStudija.SelectedItem.ToString());
                _student.Indeks = txtIndeks.Text;
                _student.Slika = ImageHelper.FromImageToByte(pbSlika.Image);
                if (_student.Id == 0)
                    _baza.Studenti.Add(_student);
                else
                    _baza.Entry(_student).State = System.Data.Entity.EntityState.Modified;
                _baza.SaveChanges();
                DialogResult = DialogResult.OK;
            }
        }

        private bool Validiraj()
        {
            return Validator.ValidirajKontrolu(txtIme, errorProvider1, Poruke.ObaveznaVrijednost)
                && Validator.ValidirajKontrolu(txtPrezime, errorProvider1, Poruke.ObaveznaVrijednost)
                && Validator.ValidirajKontrolu(txtIndeks, errorProvider1, Poruke.ObaveznaVrijednost)
                && Validator.ValidirajKontrolu(txtEmail, errorProvider1, Poruke.ObaveznaVrijednost)
                && Validator.ValidirajKontrolu(txtLozinka,  errorProvider1, Poruke.ObaveznaVrijednost)
                && Validator.ValidirajKontrolu(cmbGodinaStudija, errorProvider1, Poruke.ObaveznaVrijednost)
                && Validator.ValidirajKontrolu(pbSlika,errorProvider1, Poruke.ObaveznaVrijednost);
        }

        private void frmNoviStudent_Load(object sender, EventArgs e)
        {
            if(_student.Id == 0)
            {
                GenerisiIndeks();
                GenerisiLozinku();
            }
            else
            {
                txtIme.Text = _student.Ime;
                txtPrezime.Text = _student.Prezime;
                dtpDatumRodjenja.Value = _student.DatumRodjenja;
                txtEmail.Text = _student.Email;
                txtLozinka.Text = _student.Lozinka;
                cbAktivan.Checked = _student.Aktivan;
                cmbGodinaStudija.Text = _student.GodinaStudija.ToString();
                txtIndeks.Text = _student.Indeks;
                pbSlika.Image = ImageHelper.FromByteToImage(_student.Slika);
            }
        }

        private void GenerisiLozinku()
        {
            string pw = "1nugazsbfz3uin108sf12fsa";
            string lozinka = "";
            var rand = new Random();
            for (int i = 0; i < 8; i++)
            {
                lozinka += pw[rand.Next(0, pw.Length)];
            }
            txtLozinka.Text = lozinka;
        }

        private void GenerisiIndeks()
        {
            txtIndeks.Text = $"IB{(DateTime.Now.Year - 2000) * 10000 + _baza.Studenti.Count() + 1}";
        }

        private void txtIme_TextChanged(object sender, EventArgs e)
        {
            GenerisiEmail();
        }

        private void GenerisiEmail()
        {
            txtEmail.Text = $"{txtIme.Text.ToLower()}.{txtPrezime.Text.ToLower()}@edu.fit.ba";
        }

        private void txtPrezime_TextChanged(object sender, EventArgs e)
        {
            GenerisiEmail();
        }

        private void btnUcitajSliku_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbSlika.Image = Image.FromFile(openFileDialog1.FileName);
                txtPutanja.Text = openFileDialog1.FileName;
            }
        }
    }
}
