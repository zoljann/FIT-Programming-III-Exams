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
    }
}
