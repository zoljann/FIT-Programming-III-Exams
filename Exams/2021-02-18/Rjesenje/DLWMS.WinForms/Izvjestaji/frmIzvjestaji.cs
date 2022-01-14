using DLWMS.WinForms.Helpers;
using DLWMS.WinForms.IB200002;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DLWMS.WinForms.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private List<StudentiCovidTestovi> _listaTestova;


        public frmIzvjestaji(List<StudentiCovidTestovi> listaTestova)
        {
            InitializeComponent();
            _listaTestova = listaTestova;
        }

        private void frmIzvjestaji_Load(object sender, System.EventArgs e)
        {

            var rpc = new ReportParameterCollection();
            var rds = new ReportDataSource();

            var tbl = new dsDLWMS.tblTestoviDataTable();
            foreach (var student in _listaTestova)
            {
                var red = tbl.NewtblTestoviRow();
                red.Student = student.Student.ToString();
                red.Datum = student.Datum.ToString();
                red.Rezultat = student.Rezultat;
                red.NalazDostavljen = student.NalazDostavljen == true ? "Da" : "Ne";
                tbl.AddtblTestoviRow(red);
            }
            rds.Name = "dsDLWMS";
            rds.Value = tbl;

            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(rpc);
            this.reportViewer1.RefreshReport();
        }
    }
}
