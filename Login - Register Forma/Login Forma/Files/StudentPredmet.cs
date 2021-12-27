using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Forma.Files
{
    public class StudentPredmet
    {
        public int ID { get; set; }
        public virtual Predmet Predmet { get; set; }
        public virtual Student Student { get; set; }
        public int Ocjena { get; set; }
        public DateTime DatumPolaganja { get; set; }
    }
}
