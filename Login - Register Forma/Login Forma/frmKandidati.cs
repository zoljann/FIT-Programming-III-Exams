using Login_Forma.DB;
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
    public partial class frmKandidati : Form
    {
        public frmKandidati()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void frmKandidati_Load(object sender, EventArgs e)
        {
            UcitajKandidate();
        }

        private void UcitajKandidate()
        {
            try
            {
                KonekcijaNaBazu db = new KonekcijaNaBazu();
                dataGridView1.DataSource = db.Kandidati.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}" +$"{ex.InnerException?.Message}");
                //dodajemo i innerexception, dodajemo ? da provjerimo da li je null da ne bi doslo do errora

            }
        }
    }
}
