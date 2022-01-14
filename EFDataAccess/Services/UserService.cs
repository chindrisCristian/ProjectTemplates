using DomainLayer.Models;
using DomainLayer.Services;

using EFDataAccess.DbAccess;

namespace EFDataAccess.Services;

public class UserService : IRepository<AppUser>
{
    private readonly SqlDbContext _dbContext;

    public UserService(SqlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task DeleteAsync(AppUser entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AppUser>> GetAllAsync() => _dbContext.LoadDataAsync<AppUser>($"EXECUTE dbo.sp_AppUsersGet");

    public Task<IEnumerable<AppUser>> GetAsync(QueryType queryType, int param)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AppUser>> GetPagingAsync(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<int> InsertAsync(AppUser entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(AppUser entity)
    {
        throw new NotImplementedException();
    }
}
