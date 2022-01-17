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
    public partial class frmNovaPorukaIB200002 : Form
    {
        private Korisnik _odabrani;
        KonekcijaNaBazu _baza = DLWMS.DB;
        public frmNovaPorukaIB200002(Korisnik odabrani)
        {
            InitializeComponent();
            _odabrani = odabrani;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                byte[] slika = null;
                if (pictureBox1.Image != null)
                    slika = ImageHelper.FromImageToByte(pictureBox1.Image);

                var novaPoruka = new KorisniciPoruke()
                {
                    Korisnik = _odabrani,
                    Poruka = textBox2.Text,
                    Datum = DateTime.Now,
                    Slika = slika,
                };
                _baza.KorisniciPoruke.Add(novaPoruka);
                _baza.SaveChanges();
                Close();
                DialogResult = DialogResult.OK;
            }
        }

        private bool Validiraj()
        {
            return Validator.ObaveznoPolje(textBox2, errorProvider1, "Obavezno polje");
        }

        private void frmNovaPorukaIB200002_Load(object sender, EventArgs e)
        {
            textBox1.Text = _odabrani.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }
    }
}
