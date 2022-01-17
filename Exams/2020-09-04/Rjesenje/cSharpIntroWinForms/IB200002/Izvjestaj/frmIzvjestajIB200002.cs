using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms.IB200002.Izvjestaj
{
    public partial class frmIzvjestajIB200002 : Form
    {
        private List<KorisniciPoruke> _listaOdabranog;

        public frmIzvjestajIB200002(List<KorisniciPoruke> listaOdabranog)
        {
            InitializeComponent();
            _listaOdabranog = listaOdabranog;
        }

        private void frmIzvjestajIB200002_Load(object sender, EventArgs e)
        {
            var rpc = new ReportParameterCollection();
            var rds = new ReportDataSource();
            var tbl = new dsPoruke.tblPorukeDataTable();
            foreach (var student in _listaOdabranog)
            {
                var red = tbl.NewtblPorukeRow();
                red.Datum = student.Datum.ToString();
                red.Sadrzaj = student.Poruka;
                red.Korisnik = student.Korisnik.ToString();
                tbl.AddtblPorukeRow(red);
            }
            rds.Name = "dsPoruke";
            rds.Value = tbl;

            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(rpc);
            this.reportViewer1.RefreshReport();
        }
    }
}
