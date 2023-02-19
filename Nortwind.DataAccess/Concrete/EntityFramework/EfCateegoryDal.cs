using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Nortwind.DataAccess.Abstract;
using Nortwind.Entities.Concrete;

namespace Nortwind.DataAccess.Concrete.EntityFramework
{
    public class EfCateegoryDal : EfEntityRepositoryBase<Category,NortwindContext>,ICategoryDal
    {
       
    }
}
