using MeowTasksBackend.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeowTasksBackend.IOC
{
  public static class Dependency
  {
    public static void DependenciesInjection(this IServiceCollection services, IConfiguration config)
    {
      services.AddDbContext<MeowtasksdbContext>(opt =>
      {
        opt.UseSqlServer(config.GetConnectionString("SqlString"));
      });


    }
  }
}
