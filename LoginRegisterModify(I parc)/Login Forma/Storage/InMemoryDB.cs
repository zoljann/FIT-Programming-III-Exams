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
                }
            };
        }
    }
}
