using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestContactMVVM
{
    public interface IRepository<TEntity, TKey>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TKey ID);
        TEntity Insert(TEntity Entity);
        bool Update(TKey ID, TEntity Entity);
        bool Delete(TKey ID);
    }
}
