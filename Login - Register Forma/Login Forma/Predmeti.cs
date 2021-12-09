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
    public partial class Predmeti : Form
    {
        public Predmeti()
        {
            InitializeComponent();
        }

        private void btnDodaj(object sender, EventArgs e)
        {
            //ovdje sa onim contains tako nesto
           var moze = true;
            foreach (var predmeti in InMemoryDB.predmeti)
            {
                if (predmeti.Naziv == textBox1.Text)
                {
                    moze = false;
                    MessageBox.Show("Predmet vec postoji!");
                }
            }
            if (moze)
            {
                var noviPredmet = new Predmet()
                {
                    ID = InMemoryDB.predmeti.Count + 1,
                    Naziv = textBox1.Text,
                    GodinaStudija = comboBox1.SelectedIndex + 1
                };
                InMemoryDB.predmeti.Add(noviPredmet);
                MessageBox.Show("Predmet dodan");
               foreach (var studenta in InMemoryDB.studenti)
               {
                    studenta.StudentPredmeti.Clear(); //ocisti da se predmeti ne bi duplirali
                    foreach (var predmeta in InMemoryDB.predmeti)
                   {
                       if (studenta.GodinaStudija == predmeta.GodinaStudija)
                       {
                           studenta.StudentPredmeti.Add(predmeta);
                       }
                   }
               }
           }
            Close();
          
        }

       
    }
}
