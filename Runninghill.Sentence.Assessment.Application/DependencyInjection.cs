using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaySpace.Calculation.Assessment.Domain.Configuration;
using Runninghill.Sentence.Assessment.Application.Services;
using Runninghill.Sentence.Assessment.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Runninghill.Sentence.Assessment.Application.Models.WordGroupDTO;
using static Runninghill.Sentence.Assessment.Application.Models.WordItemDTO;

namespace Runninghill.Sentence.Assessment.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IWordItemService, WordItemService>();
            services.AddScoped<ISentenceService, SentenceService>();
            services.AddOptions<ConfigurationOptions>();

            services.AddAutoMapper(typeof(WordItemProfile));
            services.AddAutoMapper(typeof(WordGroupProfile));
            return services;
        }
    }
}
