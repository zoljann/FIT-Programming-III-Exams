using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Forma.Storage
{
    public class InMemoryDB
    {
        public static List<Student> studenti = GenerisiStudenta();

        private static List<Student> GenerisiStudenta()
        {
            return new List<Student>()
            {
                new Student()
                {
                ID= 1,
                Ime = "Nedim",
                Prezime = "Zolj",
                KorisnickoIme= "nedim.zolj",
                Lozinka = "nedim123",
                BrojIndeksa = "IB200002",
                DatumRodjenja = DateTime.Now,
                GodinaStudija = 2,
                },
                 new Student()
                {
                ID= 2,
                Ime = "Inas",
                Prezime = "Bajrektarevic",
                KorisnickoIme= "inas.bajrektarevic",
                Lozinka = "inas123",
                BrojIndeksa = "IB200007",
                DatumRodjenja = DateTime.Now,
                GodinaStudija = 2,
                },
                  new Student()
                {
                ID= 3,
                Ime = "Ali",
                Prezime = "Kajan",
                KorisnickoIme= "ali.kajan",
                Lozinka = "ali123",
                BrojIndeksa = "IB2000055",
                DatumRodjenja = DateTime.Now,
                GodinaStudija = 3,
                }
            };
        }
    }
}
