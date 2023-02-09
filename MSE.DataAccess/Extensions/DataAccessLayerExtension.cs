using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSE.DataAccess.Context;
using MSE.DataAccess.Repositories.Abstract;
using MSE.DataAccess.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE.DataAccess.Extensions
{
    public static class DataAccessLayerExtension
    {
        public static IServiceCollection LoadDataAccessLayerExtension(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("cnnstr")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAlarmRepository, AlarmRepository>();
            services.AddScoped<IMaintenancePersonnelRepository, MaintenancePersonnelRepository>();
            services.AddScoped<IProductionLineRepository, ProductionLineRepository>();
            services.AddScoped<IWorkStationRepository, WorkStationRepository>();

            return services;
        }
    }
}
