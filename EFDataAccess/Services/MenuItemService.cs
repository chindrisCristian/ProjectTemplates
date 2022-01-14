using DomainLayer.Models;
using DomainLayer.Services;

using EFDataAccess.DbAccess;

namespace EFDataAccess.Services;

public class MenuItemService : IRepository<MenuItem>
{
    private readonly SqlDbContext _dbContext;

    public MenuItemService(SqlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<MenuItem>> GetAllAsync() => _dbContext.LoadDataAsync<MenuItem>($"EXECUTE dbo.sp_MenuItemsGet");

    public Task<int> InsertAsync(MenuItem entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(MenuItem entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(MenuItem entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MenuItem>> GetPagingAsync(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MenuItem>> GetAsync(QueryType queryType, int param)
    {
        throw new NotImplementedException();
    }
}
