using DomainLayer.Models;
using DomainLayer.Services;

using EFDataAccess.DbAccess;

namespace EFDataAccess.Services;

public class AccessService : IRepository<ViewTypeAccess>
{
    private readonly SqlDbContext _dbContext;

    public AccessService(SqlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task DeleteAsync(ViewTypeAccess entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ViewTypeAccess>> GetAllAsync() => Task
        .FromResult(_dbContext.LoadData<ViewTypeAccess>($"EXECUTE dbo.sp_ViewAccessGet"));

    public Task<IEnumerable<ViewTypeAccess>> GetAsync(QueryType queryType, int param)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ViewTypeAccess>> GetPagingAsync(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<int> InsertAsync(ViewTypeAccess entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ViewTypeAccess entity)
    {
        throw new NotImplementedException();
    }
}
