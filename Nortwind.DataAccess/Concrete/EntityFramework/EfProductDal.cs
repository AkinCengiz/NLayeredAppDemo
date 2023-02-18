using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nortwind.DataAccess.Abstract;
using Nortwind.Entities.Concrete;

namespace Nortwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public List<Product> GetAll()
        {
            using (NortwindContext context = new NortwindContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProduct(int id)
        {
            using (NortwindContext context = new NortwindContext())
            {
                return context.Products.SingleOrDefault(p => p.ProductId == id);
            }
        }

        public void Add(Product product)
        {
            using (NortwindContext context = new NortwindContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (NortwindContext context = new NortwindContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (NortwindContext context = new NortwindContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
    }
}
