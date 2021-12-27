using Login_Forma.DB;
using Login_Forma.Files;
using Login_Forma.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Forma
{
    public partial class frmPolozeniPredmeti : Form
    {
        private Student student;
        KonekcijaNaBazu db = BazaDB.Baza;
        public frmPolozeniPredmeti(Student student)
        {
            InitializeComponent();
            this.student = student;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void btnDodajPolozeni_Click(object sender, EventArgs e)
        {
            if (PredmetNePostoji())
            {
                var polozeni = new StudentPredmet()
                {
                    DatumPolaganja = dateTimePicker1.Value,
                    Ocjena = int.Parse(comboBox2.Text), //posto je ocjena int moramo parsati text u int
                    Predmet = comboBox1.SelectedItem as Predmet, //selected item dobijamo njegov ID i naziv, i pohranimo ga u predmet
                    Student = student, //da student ne bi bio null tj. da se u bazu pohrani studentov ID
                };
                db.StudentPredmeti.Add(polozeni);
                db.SaveChanges();
                UcitajPolozenePredmete();
            }
            else
                MessageBox.Show("Ne mozes dodati dva ista položena predmeta!");
        }

        private bool PredmetNePostoji()
        {
            var odabrani = comboBox1.SelectedItem as Predmet;
            return student.StudentPolozeni.Where(p => p.Predmet.ID == odabrani.ID).Count() == 0; //where vraca neku listu i poredimo odabrani sa tom listom i vraca true jer ne postoji 
        }

        private void PolozeniPredmeti_Load(object sender, EventArgs e)
        {//na load ucitajemo datagridview za polozene i ucitajemo u comboBox predmete iz inMemoryDB
            UcitajPolozenePredmete(); 
            UcitajPredmete();
            comboBox2.SelectedIndex = 0; //na ucitavanju da selected index bude prva ocjena, a ne ono prazno
        }

        private void UcitajPolozenePredmete()
        {
            dataGridView1.DataSource = null;
            var polozeni = db.StudentPredmeti.Where(s => s.Student.ID == student.ID).ToList(); //na dgv ucitava trenutnog studenta i njegove polozene
            dataGridView1.DataSource = polozeni;
        }

        private void UcitajPredmete()
        {
            comboBox1.DataSource = db.Predmeti.ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Naziv";
        }
    }
}
