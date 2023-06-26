using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Recomendation.EventListener.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.EventListener.Extentions
{
    public static class AutoMapperExtentions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            return services.AddSingleton(options => new MapperConfiguration(options =>
            {
                options.AddProfile(new PostMappingProfile());
            }).CreateMapper());
        }
    }
}
