using System.Threading.Tasks;

namespace ST.Domain.Data
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        Task CreateAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>( T entity) where T : class;
        Task DeleteAsync<T>(int id) where T : class;
    }
}
