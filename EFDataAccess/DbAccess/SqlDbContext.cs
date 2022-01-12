using System.Data;

using DomainLayer.Models;

using Microsoft.EntityFrameworkCore;

namespace EFDataAccess.DbAccess
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            :base(options)
        {
        }

        public DbSet<AccessRole> AccessRoles { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<ViewTypeAccess> ViewTypes { get; set; }


        public async Task<IEnumerable<T>> LoadDataAsync<T>(FormattableString storedProcedure) where T : class => await Set<T>()
            .FromSqlInterpolated(storedProcedure)
            .ToListAsync();

        public IEnumerable<T> LoadData<T>(FormattableString storedProcedure) where T : class => Set<T>()
            .FromSqlInterpolated(storedProcedure);


        public async Task<int> WriteDataAsync<T>(FormattableString storedProcedure) where T : class => await Database
            .ExecuteSqlInterpolatedAsync(storedProcedure);

        public int WriteData<T>(FormattableString storedProcedure) where T : class => Database
            .ExecuteSqlInterpolated(storedProcedure);


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ViewTypeAccess>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}
