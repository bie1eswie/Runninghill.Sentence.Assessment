using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaySpace.Calculation.Assessment.Domain.Configuration;
using Runninghill.Sentence.Assessment.Application.Configuration;
using Runninghill.Sentence.Assessment.Application.Services;
using Runninghill.Sentence.Assessment.Domain.Interface.Services;
using System.Reflection;
using static Runninghill.Sentence.Assessment.Application.Models.WordGroupDTO;
using static Runninghill.Sentence.Assessment.Application.Models.WordItemDTO;
using FluentValidation;
using Runninghill.Sentence.Assessment.Application.Validators;
using Runninghill.Sentence.Assessment.Domain.Models;

namespace Runninghill.Sentence.Assessment.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddScoped<IWordItemService, WordItemService>();
            services.AddScoped<ISentenceService, SentenceService>();
            services.AddScoped<IWordGroupService,WordGroupService>();

            services.AddScoped<IValidator<UserSentenceDTO>, UserSentenceValidator>();

            services.Configure<ConfigurationOptions>(configuration.GetSection(SectionNames.APP_CONSTANTS));
            services.AddAutoMapper(typeof(WordItemProfile));
            services.AddAutoMapper(typeof(WordGroupProfile));
            return services;
        }
    }
}
