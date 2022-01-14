﻿using DLWMS.WinForms.Entiteti;
using DLWMS.WinForms.Helpers;
using DLWMS.WinForms.Izvjestaji;
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
    public partial class frmScanIspitaIB200002 : Form
    {
        private Student _student;
        KonekcijaNaBazu _baza = DLWMSdb.Baza;
        public frmScanIspitaIB200002(Student odabraniStudent)
        {
            InitializeComponent();
            _student = odabraniStudent;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void frmScanIspitaIB200002_Load(object sender, EventArgs e)
        {
            lblStudent.Text = _student.Ime + " " + _student.Prezime;
            UcitajPodatke();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frmDodajScan = new frmNoviScanIspitaIB200002(_student);
            if(frmDodajScan.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private void UcitajPodatke()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _baza.KorisniciIspitiScan.Where(s => s.Student.Id == _student.Id).ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabrani = dataGridView1.SelectedRows[0].DataBoundItem as KorisniciIspitiScan;
            if(e.ColumnIndex == 4)
            {
                if (MessageBox.Show("Jeste li sigurni da zelite obrisati zapis?", "Obavijest", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _baza.KorisniciIspitiScan.Remove(odabrani);
                    _baza.SaveChanges();
                    UcitajPodatke();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var listaZaTrenutnog = _baza.KorisniciIspitiScan.Where(s => s.Student.Id == _student.Id).ToList();
            var frmIzvj = new frmIzvjestaji(listaZaTrenutnog);
            frmIzvj.Show();
        }
    }
}
