using DomainLayer.Models;
using DomainLayer.Services;

using EFDataAccess.DbAccess;

namespace EFDataAccess.Services;

public class RoleService : IRepository<AccessRole>
{
    private readonly SqlDbContext _dbContext;

    public RoleService(SqlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task DeleteAsync(AccessRole entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AccessRole>> GetAllAsync() => _dbContext.LoadDataAsync<AccessRole>($"EXECUTE dbo.sp_AccessRoleGet 0, 0");

    public Task<IEnumerable<AccessRole>> GetAsync(QueryType queryType, int param) => _dbContext.LoadDataAsync<AccessRole>($"EXECUTE dbo.sp_AccessRoleGet {(int)queryType}, {param}");

    public Task<IEnumerable<AccessRole>> GetPagingAsync(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<int> InsertAsync(AccessRole entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(AccessRole entity)
    {
        throw new NotImplementedException();
    }
}
