using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login_Forma.Files;
namespace Login_Forma.Storage
{
    public class InMemoryDB
    {
        public static List<Student> studenti = GenerisiStudenta();
        public static List<Predmet> predmeti = GenerisiPredmet();
        public static List<Spol> spolovi = GenerisiSpolove();

        private static List<Spol> GenerisiSpolove()
        {
            return new List<Spol>()
            {
                new Spol()
                {
                    ID = 1,
                    Naziv = "Muski"
                },
                 new Spol()
                {
                    ID = 2,
                    Naziv = "Zenski"
                },
                  new Spol()
                {
                    ID = 3,
                    Naziv = "******"
                }
            };
        }

        private static List<Predmet> GenerisiPredmet()
        {
            return new List<Predmet>()
            {
                new Predmet()
                {
                    ID = 1,
                    Naziv = "PRIII",
                    GodinaStudija = 2
                }
            };
        }

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
                BrojIndeksa = "IB200055",
                DatumRodjenja = DateTime.Now,
                GodinaStudija = 3,
                },
                    new Student()
                {
                ID= 4,
                Ime = "Armin",
                Prezime = "Studenovic",
                KorisnickoIme= "armin.studenovic",
                Lozinka = "armin123",
                BrojIndeksa = "IB200021",
                DatumRodjenja = DateTime.Now,
                GodinaStudija = 4,
                },
                      new Student()
                {
                ID= 5,
                Ime = "Adem",
                Prezime = "Bostan",
                KorisnickoIme= "adem.bostan",
                Lozinka = "adem123",
                BrojIndeksa = "IB200040",
                DatumRodjenja = DateTime.Now,
                GodinaStudija = 3,
                },
                        new Student()
                {
                ID= 6,
                Ime = "Fatih",
                Prezime = "Drek",
                KorisnickoIme= "fatih.drek",
                Lozinka = "fate123",
                BrojIndeksa = "IB200089",
                DatumRodjenja = DateTime.Now,
                GodinaStudija = 1,
                },
            };
        }
    }
}
