using AspNetCoreNHibernate.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreNHibernate.Repositories.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task AddAsync(T item);
        Task RemoveAsync(long id);
        Task UpdateAsync(T item);
        Task<T> FindByIdAsync(long id);
        IEnumerable<T> FindAll();
    }
}