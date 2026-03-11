using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset_Tracking.Domain;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Asset_Tracking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddDbContext<AssetTrackingDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });


            services.AddScoped<IAssetCategoryRepository , AssetCategoryRepository>();
            services.AddScoped<IAssetCheckInRepository, AssetCheckInRepository>();
            services.AddScoped<IAssetCheckOutRepository, AssetCheckOutRepository>();
            services.AddScoped<IAssetDisposeRepository, AssetDisposeRepository>();
            services.AddScoped<IAssetEventHistoryRepository, AssetEventHistoryRepository>();
            services.AddScoped<IAssetImageRepository, AssetImageRepository>();
            services.AddScoped<IAssetMaintenanceRepository, AssetMaintenanceRepository>();
            services.AddScoped<IAssetRepairRepository, AssetRepairRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IAssetRepairRepository, AssetRepairRepository>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IFloorRepository, FloorRepository>();
            services.AddScoped<IAssetStatusRepository, AssetStatusRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IRoleClaimsRepository, RoleClaimsRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRepairStatusRepository, RepairStatusRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IScheduleRepairRepository, ScheduleRepaireRepository>();
            services.AddScoped<ISiteHeadRepository, SiteHeadRepository>();
            services.AddScoped<ISiteRepository,  SiteRepository>();
            services.AddScoped<ISiteLocationRepository, SiteLocationRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<IUserClaimRepository, UserClaimRepository>();
            services.AddScoped<IUserImageRepository, UserImageRepository>();
            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRolesRepository, UserRolesRepository>();
            services.AddScoped<IUserTokenRepository, UserTokenRepository>();
            services.AddScoped<IMaintenanceStatusRepository, MaintenanceStatusRepository>();

            return services;
        }
    }
}
