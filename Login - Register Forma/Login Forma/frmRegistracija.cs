using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_Forma.Storage;
using Login_Forma.Files;
using Login_Forma.Helperi;
using Login_Forma.DB;

namespace Login_Forma
{
    public partial class frmRegistracija : Form
    {
        KonekcijaNaBazu db = new KonekcijaNaBazu();
        public frmRegistracija()
        {
            InitializeComponent();

        }
        private bool Validiraj()
        {
            return Validacija.ValidirajKontrolu(imeBox, Poruke.PrazanProstor, errorP) &&
                Validacija.ValidirajKontrolu(prezimBox, Poruke.PrazanProstor, errorP) &&
                Validacija.ValidirajKontrolu(brojIndeksaBox, Poruke.PrazanProstor, errorP) &&
                Validacija.ValidirajKontrolu(korisnickoImeBox, Poruke.PrazanProstor, errorP) &&
                Validacija.ValidirajKontrolu(lozinkaBox, Poruke.PrazanProstor, errorP) &&
                Validacija.ValidirajKontrolu(comboBox2, Poruke.PrazanProstor, errorP);
        }
        private void registracijaBtn_Click(object sender, EventArgs e) //klikom na dugme da se pohrane podaci o studentu i isti spasi u InMemoryDB
        {
            if (Validiraj())
            {
                var student = new Student()
                {
                   // ID = InMemoryDB.studenti.Count + 1, //ID je sada autonumber u pravoj bazi
                    Ime = imeBox.Text,
                    Prezime = prezimBox.Text,
                    KorisnickoIme = korisnickoImeBox.Text,
                    Lozinka = lozinkaBox.Text,
                    GodinaStudija = comboBox1.SelectedIndex + 1,
                    BrojIndeksa = brojIndeksaBox.Text,
                    SlikaStudenta = ImageHelper.FromImageToByte(pictureBox1.Image),
                    DatumRodjenja = dateTimeBox.Value,
                    StudentSpol = comboBox2.SelectedItem as Spol
                };
                //InMemoryDB.studenti.Add(student); ne dodajemo u inmemory nego u pravu bazu
                db.Studenti.Add(student);
                db.SaveChanges();
                MessageBox.Show(Poruke.UspjesnoRegistrovan);
                Close();
            }
    }

        private void imeBox_TextChanged(object sender, EventArgs e) //naredne 3 funkcije generisanje korisnickog imena putem imena i prezimena
        {
            GenerisiKorisnickoIme();
        }

        private void GenerisiKorisnickoIme()
        {
           korisnickoImeBox.Text = $"{imeBox.Text}.{prezimBox.Text}".ToLower();
        }

        private void prezimBox_TextChanged(object sender, EventArgs e)
        {
            GenerisiKorisnickoIme();
        }

        private void korisnickoImeBox_TextChanged(object sender, EventArgs e) //ukoliko postoji isto korisnicko ime u bazi da textBox pocrveni
        {
            foreach (var student in db.Studenti)
            {
            if(korisnickoImeBox.Text == student.KorisnickoIme)
                {
                    korisnickoImeBox.BackColor = Color.Red;
                    return;
                }
            }
            korisnickoImeBox.BackColor = Color.Empty;
        }

        private void button1_Click(object sender, EventArgs e) //na klik ucitavanje slike da se otvori dialog za preuzimanje stvari sa kompa
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName); //ako je dialog prosao OK tj ako je nesto upload ta se prikaze na pictureBox1
            }
        }

        private void Registracija_Load(object sender, EventArgs e) //na ucitavanje registracijske forme da se auto generise broj indeksa
        {
            GenerisiBrojIndeksa();
        }

        private void GenerisiBrojIndeksa()
        {
            brojIndeksaBox.Text = $"IB{(DateTime.Now.Year - 2000) * 10000 + db.Studenti.Count()+1}";
        }
    }
}
