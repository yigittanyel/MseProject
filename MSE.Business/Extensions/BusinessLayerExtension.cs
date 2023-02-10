using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MSE.Business.Utilities.AutoMapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MSE.Business.Extensions
{
    public static class BusinessLayerExtension
    {
        public static void LoadBusinessLayerExtension(this IServiceCollection serviceCollection)
        {
            var ass = Assembly.GetExecutingAssembly();
            serviceCollection.AddAutoMapper(ass);
            serviceCollection.AddMediatR(ass);
        }
    }
}
