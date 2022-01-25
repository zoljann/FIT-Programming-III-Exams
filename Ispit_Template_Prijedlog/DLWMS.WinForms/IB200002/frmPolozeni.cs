using DLWMS.WinForms.DB;
using DLWMS.WinForms.P5;
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
    public partial class frmPolozeni : Form
    {
        KonekcijaNaBazu _baza = DLWMSdb.Baza;
        private Student _student;
       
        public frmPolozeni(Student odabrani)
        {
            InitializeComponent();
            _student = odabrani;
            dgvPolozeniPredmeti.AutoGenerateColumns = false;
        }

        private void btnDodajPolozeni_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                if (Isti())
                {
                    var noviPolozeni = new StudentiPredmeti()
                    {
                        Student = _student,
                        Predmet = cmbPredmeti.SelectedItem as Predmeti,
                        DatumPolaganja = dtpDatumPolaganja.Value,
                        Ocjena = int.Parse(cmbOcjene.Text)
                    };
                    _baza.StudentiPredmeti.Add(noviPolozeni);
                    _baza.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Ne mozes dodati iste predmete!");
                }
                UcitajPodatke();
            }
        }

        private bool Isti()
        {
            var predmet = cmbPredmeti.SelectedItem as Predmeti;
            foreach (var p in _baza.StudentiPredmeti.Where(s=>s.Student.Id == _student.Id))
            {
                if(p.Predmet == predmet)
                {
                    return false;
                }
            }
            return true;
        }

        private bool Validiraj()
        {
            return Validator.ValidirajKontrolu(cmbPredmeti, errorProvider1, Poruke.ObaveznaVrijednost) &&
                Validator.ValidirajKontrolu(cmbOcjene, errorProvider1, Poruke.ObaveznaVrijednost);
        }

        private void UcitajPodatke()
        {
            dgvPolozeniPredmeti.DataSource = null;
            dgvPolozeniPredmeti.DataSource = _baza.StudentiPredmeti.Where(s => s.Student.Id == _student.Id).ToList();
        }

        private void frmPolozeni_Load(object sender, EventArgs e)
        {
            cmbPredmeti.DataSource = _baza.Predmeti.ToList();
            UcitajPodatke();
        }

        private void dgvPolozeniPredmeti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabraniP = dgvPolozeniPredmeti.SelectedRows[0].DataBoundItem as StudentiPredmeti;
            if(e.ColumnIndex == 3)
            {
                if (MessageBox.Show("Jeste li sigurni?", "Obavijest", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _baza.StudentiPredmeti.Remove(odabraniP);
                    _baza.SaveChanges();
                    UcitajPodatke();
                }
            }
        }
    }
}
