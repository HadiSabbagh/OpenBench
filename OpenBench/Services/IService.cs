using OpenBench.Models;
using OpenBench.Models.Dtos;

namespace OpenBench.Services
{
    public interface IService<T> where T : class, IDto
    {
        Task<List<T>> GetAllRows();

        Task<T> GetRowById(int? id);

        Task<T> AddRow(T entity);

        Task<T> UpdateRow(T entity);

        Task DeleteRow(int id);

        Task<T> FindRowByCompositeIds(object[] keyValues);
    }
}
