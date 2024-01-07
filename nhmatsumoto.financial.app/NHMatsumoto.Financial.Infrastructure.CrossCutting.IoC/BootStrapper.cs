using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nhmatsumoto.financial.domain.Entities;
using nhmatsumoto.financial.infrastructure.database.Context;
using nhmatsumoto.financial.infrastructure.database.Interfaces;
using nhmatsumoto.financial.infrastructure.database.Repository;
using nhmatsumoto.financial.services;
using nhmatsumoto.financial.services.Interfaces;

namespace nhmatsumoto.financial.infrastructure.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("NHMatsumotoDbContextLocalhost") ?? throw new
                Exception("Erro na conexão");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connection));

            services.AddIdentityCore<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            }).AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IWalletService, WalletService>();

        }
    }
}
