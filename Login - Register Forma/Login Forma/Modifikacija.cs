using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_Forma.Files;
using Login_Forma.Storage;
namespace Login_Forma
{
    public partial class Modifikacija : Form
    {
        private Student student; //novi objekat tipa student kojeg dočekujemo na formi
        public Modifikacija(Student student = null) //postaviti na null zbog provjere ispod
        {
            InitializeComponent();
            this.student = student ?? new Student(); //prilikom loadanja forme ako je student bio null znaci da pravimo novog, ako ukoliko je postojao samo modifikujemo
        }

        private void Modifikacija_Load(object sender, EventArgs e) //na load forme ucitaj podatke o vec postojecem studentu
        {
            UcitajPodatkeOStudentu();
           
        }

        private void UcitajPodatkeOStudentu()
        {
                imeBox.Text = student.Ime;
                prezimBox.Text = student.Prezime;
                korisnickoImeBox.Text = student.KorisnickoIme;
                lozinkaBox.Text = student.Lozinka;
                brojIndeksaBox.Text = student.BrojIndeksa;
                comboBox1.Text = student.GodinaStudija.ToString(); //jedan od nacina za pohranjivanje comboboxa
                pictureBox1.Image = student.SlikaStudenta;
                comboBox2.SelectedItem = student.StudentSpol; //ne ocitaje spasavanje na promjenu spola ERROR
        }
       
        private void sacuvajBtn_Click(object sender, EventArgs e)
        {
                student.Ime = imeBox.Text;
                student.Prezime = prezimBox.Text;
                student.KorisnickoIme = korisnickoImeBox.Text;
                student.Lozinka = lozinkaBox.Text;
                student.BrojIndeksa = brojIndeksaBox.Text;
                student.GodinaStudija = comboBox1.SelectedIndex+1;  //jedan od nacina za pohranjivanje comboboxa
                student.SlikaStudenta = pictureBox1.Image;
                student.StudentSpol = comboBox2.SelectedItem as Spol; //drugi nacin za pohranu comboBoxa, ovo je kada imamo u InMemoryDB listu a ne onu koju hardkodiramo
                MessageBox.Show(Poruke.UspjesnoEditovan);
                this.DialogResult = DialogResult.OK; //vraca dialog result kao OK da bi se kasnije refreshovalo nakon modifikacije
                Close();
            
            }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName); //ako je dialog prosao OK tj ako je nesto upload da se prikaze na pictureBox1
            }
        }
    }
    }

