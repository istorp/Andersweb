using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Andersweb.DataAccess.Repository.IRepository
{
    public interface IRepository<T>  where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        void Remove(IEnumerable<T> entities);
        IEnumerable<T> GetAll();

        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null);
    }
}
