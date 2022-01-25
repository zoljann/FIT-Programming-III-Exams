using DLWMS.WinForms.DB;
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

namespace DLWMS.WinForms.Reports
{
    public partial class frmIzvjestaj : Form
    {
        public frmIzvjestaj()
        {
            InitializeComponent();
        }

        private void frmIzvjestaj_Load(object sender, EventArgs e)
        {
            var rds = new ReportDataSource();
            var rpc = new ReportParameterCollection();
            var tbl = new dsDLWMS.tblStudentiDataTable();
            foreach (var s in DLWMSdb.Baza.Studenti)
            {
                var red = tbl.NewtblStudentiRow();
                red.Ime = s.Ime;
                red.Prezime = s.Prezime;
                red.Indeks = s.Indeks;
                tbl.AddtblStudentiRow(red);
            }
            rds.Name = "dsDLWMS";
            rds.Value = tbl;

            this.reportViewer1.LocalReport.SetParameters(rpc);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
