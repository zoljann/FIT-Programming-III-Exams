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
    public partial class BazaPodataka : Form
    {
        public BazaPodataka()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false; //da se ne generisu kolone same
            dgvPredmeti.AutoGenerateColumns = false;
            dgvStudentPredmeti.AutoGenerateColumns = false;
        }

        private void BazaPodataka_Load(object sender, EventArgs e)
        {
            UcitajStudente();
            UcitajPredmete();
        }
        public void UcitajPredmete()
        {
            dgvPredmeti.DataSource = null;
            dgvPredmeti.DataSource = InMemoryDB.predmeti;
        }
        public void UcitajStudente(List<Student> podaci = null)
        {
            dataGridView1.DataSource = null; //refresh
            dataGridView1.DataSource = podaci?? InMemoryDB.studenti;
        }

        //Editovanje
        private void dgvStudenti_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var student = dataGridView1.SelectedRows[0].DataBoundItem as Student;  //vraca objekat toga reda i mi ga pohranjujemo u student
            var modifikuj = new Modifikacija(student);
            if (modifikuj.ShowDialog() == DialogResult.OK) //provjeravamo da li je dialog prosao OK, ako jeste ucitava studente
                UcitajStudente();
                
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //pretraga
        {
            var filter = textBox1.Text;
            var rezultat = new List<Student>(); //nova lista koju saljemo 
            foreach (var student in InMemoryDB.studenti)
            {
                if (student.Ime.ToLower().Contains(filter) || student.Prezime.ToLower().Contains(filter)) 
                    rezultat.Add(student);
            }
            UcitajStudente(rezultat); //posaljemo listu i refreshujemo
        }

        private void btnDodajPredmet(object sender, EventArgs e) //na klik dodavanje predmeta otvaramo formu za predmet
        {
            var frmPredmet = new Predmeti();
            frmPredmet.Show();
        }

        private void dgvStudenti_CellClick(object sender, DataGridViewCellEventArgs e) //na klik kolone u dgvStudentPredmeti pohranjujemo listu predmeta koje on vidi
        {
            var student = dataGridView1.SelectedRows[0].DataBoundItem as Student;
            dgvStudentPredmeti.DataSource = null;
            dgvStudentPredmeti.DataSource = student.StudentPredmeti;
            UcitajPredmete(); //naci bolju alternativu za refresh u dgv da ne bude ovdje
        }
    }
}
