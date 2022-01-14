namespace DomainLayer.Services;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<IEnumerable<T>> GetPagingAsync(int page, int pageSize);

    Task<IEnumerable<T>> GetAsync(QueryType queryType, int param);

    Task<int> InsertAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}
