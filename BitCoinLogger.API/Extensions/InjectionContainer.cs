using BitcoinLogger.Api.Data;
using BitcoinLogger.Api.Data.Models;
using BitcoinLogger.Api.Services;
using BitCoinLogger.Api.Data;
using BitCoinLogger.Api.Data.Models;
using BitCoinLogger.API.Data;
using BitCoinLogger.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace BitCoinLogger.Api.Extensions
{
    public static class InjectionContainer
    {
        public static void InjectEntities(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));

            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddScoped<ISourceRepository, SourceRepository>();
            services.AddScoped<IPriceItemRepository, PriceItemRepository>();
            services.AddScoped<IHistoryRepository, HistoryRepository>();

            services.AddScoped<IPriceService, PriceService>();
            services.AddScoped<HttpClient>();
        }

    }
}

