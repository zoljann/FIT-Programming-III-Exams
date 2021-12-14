﻿using Login_Forma.Storage;
using System;
using System.Windows.Forms;
using Login_Forma.Files;
namespace Login_Forma
{
    public partial class Aplikacija : Form
    {
        public Aplikacija()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //handlujemo prijavu, provjeravamo postoji li u bazi
        {
            var korisnickoIme = imeBox.Text;
            var lozinka = lozinkaBox.Text;
            if (!string.IsNullOrEmpty(korisnickoIme) || string.IsNullOrEmpty(lozinka))
            {
                foreach (var studenta in InMemoryDB.studenti)
                {
                    if (korisnickoIme == studenta.KorisnickoIme && lozinka == studenta.Lozinka)
                        MessageBox.Show($"{Poruke.Dobrodosli} {korisnickoIme}!");
                }
            }
        }
        private void label3_Click(object sender, EventArgs e) //klik na label da vodi na registracijsku formu
        {
            var registracija = new Registracija();
            registracija.Show();
        }

        private void label4_Click(object sender, EventArgs e) //klik na label da vodi na "bazu podataka"
        {
            var bazaPodataka = new BazaPodataka();
            bazaPodataka.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            var formaStudenti = new frmKandidati();
            formaStudenti.Show();
        }
    }
}
