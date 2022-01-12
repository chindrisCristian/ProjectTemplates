namespace DomainLayer.Services;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<int> InsertAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}
