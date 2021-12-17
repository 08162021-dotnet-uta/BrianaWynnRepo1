using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemoBusinessLayer
{
    public interface IMapper<T,Y>
    {
        T ModelToViewModel(Y entity);
        Y ViewModelToModel(T entity);

    }
}
