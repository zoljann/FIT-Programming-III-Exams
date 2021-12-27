using Login_Forma.Files;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Forma.DB
{
    //prije ovoga idemo desni klik na projekat i skinemo Entity Framework i System.Data.SQLite
    //u apiConfigu moramo napraviti konekcijski string
    public class KonekcijaNaBazu : DbContext //DbContext osigurava infrastrukturu potrebna za komunikaciju sa bazom
    {
        public KonekcijaNaBazu() : base("BazaPutanja")
        {

        }
        public DbSet<Kandidat> Kandidati { get; set; } //property klase koji sluze za komunikaciju sa pojedinim tabelama baze
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Spol> Spolovi { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<StudentPredmet> StudentPredmeti { get; set; }

        //ovo ispod zamjenjuje [Table("Kandidati")] u klasi Kandidat.cs

        protected override void OnModelCreating(DbModelBuilder modelBuilder) //logika komunikacije mapiranja izmedju tabela i objekata
          {
              base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Kandidat>().ToTable("Kandidati");
              modelBuilder.Entity<Student>().ToTable("Studenti");
              modelBuilder.Entity<Spol>().ToTable("Spolovi");
              modelBuilder.Entity<Predmet>().ToTable("Predmet");
              modelBuilder.Entity<StudentPredmet>().ToTable("StudentiPredmeti");
        }
    }
}
