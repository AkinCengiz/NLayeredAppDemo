using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Nortwind.Entities.Concrete;

namespace Nortwind.DataAccess.Concrete.EntityFramework
{
    public class NortwindContext:DbContext
    {
        public  DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
