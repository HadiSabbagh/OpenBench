using OpenBench.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenBench.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {

        Task<List<T>> GetAllRows();

        Task<T> GetRowById(int id);

        Task<T> AddRow(T entity);

        Task<T> UpdateRow(T entity);

        Task DeleteRow(int id);

        Task<T> FindRowByCompositeIds(object[] keyValues);


    }
}
