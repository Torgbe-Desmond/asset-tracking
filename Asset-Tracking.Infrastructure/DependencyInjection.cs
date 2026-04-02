using Asset_Tracking.Domain;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Identity;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Asset_Tracking.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Asset_Tracking.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDi(this IServiceCollection services, IConfiguration configuration)
        {
            // Register application services here
            services.AddDomainDi();

            var connectionString = configuration.GetConnectionString("DefaultConnection")
               ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            //services.AddDbContext<AssetTrackingDbContext>(options =>
            //    options.UseSqlServer(connectionString));
            services.AddDbContext<AssetTrackingDbContext>(options =>
            {
                options.UseSqlServer(connectionString)
                       .EnableSensitiveDataLogging()       
                       .LogTo(Console.WriteLine, LogLevel.Information);  
            });

            // --- ADD THIS SECTION ---
            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AssetTrackingDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

            services.AddScoped<IAssetCategoryRepository , AssetCategoryRepository>();
            services.AddScoped<IAssetCheckInRepository, AssetCheckInRepository>();
            services.AddScoped<IAssetCheckOutRepository, AssetCheckOutRepository>();
            services.AddScoped<IAssetDisposeRepository, AssetDisposeRepository>();
            services.AddScoped<IAssetEventHistoryRepository, AssetEventHistoryRepository>();
            services.AddScoped<IAssetImageRepository, AssetImageRepository>();
            services.AddScoped<IAssetMaintenanceRepository, AssetMaintenanceRepository>();
            services.AddScoped<IAssetRepairRepository, AssetRepairRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IFloorRepository, FloorRepository>();
            services.AddScoped<IAssetStatusRepository, AssetStatusRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IRepairStatusRepository, RepairStatusRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IScheduleRepairRepository, ScheduleRepaireRepository>();
            services.AddScoped<ISiteHeadRepository, SiteHeadRepository>();
            services.AddScoped<ISiteRepository,  SiteRepository>();
            services.AddScoped<ISiteLocationRepository, SiteLocationRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<IUserImageRepository, UserImageRepository>();
            services.AddScoped<IMaintenanceStatusRepository, MaintenanceStatusRepository>();

            // Jwt Service
            services.AddScoped<IJwtService, JwtService>();



            return services;
        }
    }
}
