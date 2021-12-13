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
    public partial class FormaPolozeniPredmeti : Form
    {
        private Student student;
        public FormaPolozeniPredmeti(Student student)
        {
            InitializeComponent();
            this.student = student;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void btnDodajPolozeni_Click(object sender, EventArgs e)
        {
            if (PredmetNePostoji())
            {
                var polozeni = new PolozeniPredmeti()
                {
                    ID = student.StudentPolozeni.Count + 1,
                    DatumPolaganja = dateTimePicker1.Value,
                    Ocjena = int.Parse(comboBox2.Text), //posto je ocjena int moramo parsati text u int
                    Predmet = comboBox1.SelectedItem as Predmet, //selected item dobijamo njegov ID i naziv, i pohranimo ga u predmet
                };
                student.StudentPolozeni.Add(polozeni);
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
            dataGridView1.DataSource = student.StudentPolozeni;
        }

        private void UcitajPredmete()
        {
            comboBox1.DataSource = InMemoryDB.predmeti;
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Naziv";
        }
    }
}
