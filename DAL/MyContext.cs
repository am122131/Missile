using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    class MyContext:DbContext
    {
        public MyContext() : base("RaptorDB") {
        //    var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        //    if (type == null)
        //        throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");
        }
        public DbSet<Falling> Fallings { get; set; }
        public DbSet<RightFall> RightFallings { get; set; }
        public DbSet<Report> Reports { get; set; }

       
    }
}
