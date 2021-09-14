using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemoDataAcess.EntityModels;

namespace WebAPIDemoBusinessLayer.Abstract_Classes
{
    abstract class Repository
    {
        CoreDbContext _dbContext = new CoreDbContext();
        Repository()
        {

        }


        //get all of a table type
        //public virtual List<T> GetTable()
        //{
        //    List<T> returned = _dbContext.Generic.FromSqlInterpolated("Select * from {0}", genericType).ToList();
        //}
    }
}
