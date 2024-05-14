using MeowTasksBackend.BLL.Services;
using MeowTasksBackend.BLL.Services.Contract;
using MeowTasksBackend.DAL.DBContext;
using MeowTasksBackend.DAL.Repositories;
using MeowTasksBackend.DAL.Repositories.Contract;
using MeowTasksBackend.Utilities;
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

      services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

      services.AddAutoMapper(typeof(AutoMapperProfile));

      services.AddScoped<IAuthService, AuthService>();
    }
  }
}
