using DLWMS.WinForms.Entiteti;
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
    public partial class frmNoviScanIspitaIB200002 : Form
    {
        KonekcijaNaBazu _baza = DLWMSdb.Baza;
        private Student _student;


        public frmNoviScanIspitaIB200002(Student student)
        {
            InitializeComponent();
            _student = student;
        }

        private void frmNoviScanIspitaIB200002_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = _baza.Predmet.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                byte[] slika = null;
                if (pictureBox1.Image != null)
                {
                    slika = ImageHelper.FromImageToByte(pictureBox1.Image);
                }
                var noviScan = new KorisniciIspitiScan()
                {
                    Student = _student,
                    Predmet = comboBox1.SelectedItem as Predmet,
                    Varanje = checkBox1.Checked,
                    Napomena = textBox1.Text,
                    SkeniranIspit = slika,
                };
                _baza.KorisniciIspitiScan.Add(noviScan);
                _baza.SaveChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool Validiraj()
        {
            return Validator.ValidirajKontrolu(comboBox1, errorProvider1, "Obavezno polje!") &&
                Validator.ValidirajKontrolu(textBox1, errorProvider1, "Obavezno polje!") &&
                Validator.ValidirajKontrolu(pictureBox1, errorProvider1, "Obavezno polje!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
