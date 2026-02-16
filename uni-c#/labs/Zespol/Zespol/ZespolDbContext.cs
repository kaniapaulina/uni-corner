using OsobaZespol;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsobaZespol
{
    public  class ZespolDbContext : DbContext
    {
        public DbSet<Zespol> Zespoly { get; set; }
        public DbSet<KierownikZespolu> Kierownicy { get; set; }
        public DbSet<CzlonekZespolu> Czlonkowie { get; set; }
    }
}
