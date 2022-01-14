using DLWMS.WinForms.Entiteti;
using DLWMS.WinForms.Helpers;
using DLWMS.WinForms.IB200002;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DLWMS.WinForms.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private List<KorisniciIspitiScan> _lista;

        public frmIzvjestaji(List<KorisniciIspitiScan> listaZaTrenutnog)
        {
            InitializeComponent();
            _lista = listaZaTrenutnog;
        }

        private void frmIzvjestaji_Load(object sender, System.EventArgs e)
        {

            var rpc = new ReportParameterCollection();
            var rds = new ReportDataSource();
            var tbl = new dsDLWMS.tblStudentiDataTable();
            foreach (var s in _lista)
            {
                var red = tbl.NewtblStudentiRow();
                red.Predmet = s.Predmet.ToString();
                red.Napomena = s.Napomena;
                red.Varanje = s.Varanje == true ? "Varao" : "Nije varao";
                tbl.AddtblStudentiRow(red);
            }
            rds.Name = "dsDLWMS";
            rds.Value = tbl;

            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(rpc);
            this.reportViewer1.RefreshReport();
        }
    }
}
