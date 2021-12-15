using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        // public Image SlikaStudenta { get; set; } baza ne podrzava tip podatka Image pa editujemo na niz bytova
        public byte[] SlikaStudenta { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string BrojIndeksa { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int GodinaStudija { get; set; }
        public string Spol { get; set; }
        public List<PolozeniPredmeti> StudentPolozeni { get; set; }
       // [NotMapped] oznacava da ne zelimo da ucitavamo podatke koji se nalaze ispod ovoga
        public Student()
        {
            StudentPolozeni = new List<PolozeniPredmeti>(); //pravimo defaultni konstruktor da ne bi dobijali nullreference error kada ucitajemo polozene
        }
    }
}
