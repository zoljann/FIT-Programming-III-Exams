using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_Forma.DB;
using Login_Forma.Files;
using Login_Forma.Storage;

namespace Login_Forma
{
    public partial class frmBazaPodataka : Form
    {
        KonekcijaNaBazu db = new KonekcijaNaBazu();
        public frmBazaPodataka()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false; //da se ne generisu kolone same
        }

        private void BazaPodataka_Load(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        public void UcitajStudente(List<Student> podaci = null)
        {
            dataGridView1.DataSource = null; //refresh
            //dataGridView1.DataSource = podaci ?? InMemoryDB.studenti;
            dataGridView1.DataSource = podaci ?? db.Studenti.ToList();
        }

        //Editovanje
        private void dgvStudenti_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var student = dataGridView1.SelectedRows[0].DataBoundItem as Student;  //vraca objekat toga reda i mi ga pohranjujemo u student
            if (e.ColumnIndex == 9)
            { //provjeravamo da li se kliknulo na kolonu sa polozenim, ako jeste radis sljedece
               var polozeni = new frmPolozeniPredmeti(student);
                polozeni.Show();
            }
            else //ako se kliknulo na bilo koju drugu kolonu ucitavas podatke o studentu
            {
                var modifikuj = new frmModifikacija(student);
                if (modifikuj.ShowDialog() == DialogResult.OK) //provjeravamo da li je dialog prosao OK, ako jeste ucitava studente
                    UcitajStudente();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //pretraga
        {
            var filter = textBox1.Text;
            var rezultat = new List<Student>(); //nova lista koju saljemo 
            foreach (var student in db.Studenti)
            {
                if (student.Ime.ToLower().Contains(filter) || student.Prezime.ToLower().Contains(filter))
                    rezultat.Add(student);
            }
            UcitajStudente(rezultat); //posaljemo listu i refreshujemo
        }

    }
}
