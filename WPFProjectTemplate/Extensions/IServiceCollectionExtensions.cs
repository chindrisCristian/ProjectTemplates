using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WPFProjectTemplate.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddViewModels(this IServiceCollection services)
    {
        typeof(App).Assembly.GetTypes()
            .Where(type => type.IsClass)
            .Where(type => type.Name.EndsWith("ViewModel"))
            .ToList()
            .ForEach(type => services.AddSingleton(type));
    }

    public static void AddDAL(this IServiceCollection services, IConfiguration configuration)
    {
        // Dapper
        //services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
        
        // EF Core
        services.AddDbContext<SqlDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        typeof(SqlDbContext).Assembly.GetTypes()
            .Where(type => type.IsClass)
            .Where(type => type.Name.EndsWith("Service"))
            .Select(type => (type, type.GetInterfaces().First()))
            .ToList()
            .ForEach(x => services.AddSingleton(x.Item2, x.Item1));
    }
}
