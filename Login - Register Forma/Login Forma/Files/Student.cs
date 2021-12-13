﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login_Forma.Files;
namespace Login_Forma
{
    public class Student
    {
        public int ID { get; set; }
        public Image SlikaStudenta { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string BrojIndeksa { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int GodinaStudija { get; set; }
        public List<PolozeniPredmeti> StudentPolozeni { get; set; }
        public Spol StudentSpol { get; set; }
        public Student()
        {
            StudentPolozeni = new List<PolozeniPredmeti>(); //pravimo defaultni konstruktor da ne bi dobijali nullreference error kada ucitajemo polozene
        }
    }
}
