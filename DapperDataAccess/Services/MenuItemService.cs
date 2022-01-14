using DapperDataAccess.DbAccess;

using DomainLayer.Models;
using DomainLayer.Services;

namespace DapperDataAccess.Services;

public class MenuItemService : IRepository<MenuItem>
{
    private readonly ISqlDataAccess _db;

    public MenuItemService(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task DeleteAsync(MenuItem entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MenuItem>> GetAllAsync()
    {
        return _db.LoadData<MenuItem, object>("dbo.sp_MenuItemsGet", null);
    }

    public Task<IEnumerable<MenuItem>> GetAsync(QueryType queryType, int param)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MenuItem>> GetPagingAsync(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<int> InsertAsync(MenuItem entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(MenuItem entity)
    {
        throw new NotImplementedException();
    }
}
