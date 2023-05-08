using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Recomendation.Domain.Configurations;
using Recomendation.Domain.Interfaces;
using Recomendation.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.Domain.Extentions
{
    public static class DatabaseExtentions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient>(provider =>
            {
                var settings = provider.GetRequiredService<IOptions<RecommendationDatabaseSettings>>().Value;

                return new MongoClient(settings.ConnectionString);
            });

            services.AddSingleton<IPostWatchingEventRepository, PostWatchingEventRepository>();

            return services;
        }
    }
}
