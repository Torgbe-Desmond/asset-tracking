using Microsoft.EntityFrameworkCore;
using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext
{
    public class AssetTrackingDbContext : DbContext
    {
        public AssetTrackingDbContext(DbContextOptions<AssetTrackingDbContext> options)
            : base(options)
        {
        }

        // -------------------------
        // Identity / Authentication
        // -------------------------
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<RoleClaimsEntity> RoleClaims { get; set; }
        public DbSet<UserClaimsEntity> UserClaims { get; set; }
        public DbSet<UserRolesEntity> UserRoles { get; set; }
        public DbSet<UserLoginEntity> UserLogins { get; set; }
        public DbSet<UserTokenEntity> UserTokens { get; set; }
        public DbSet<UserImageEntity> UserImages { get; set; }

        // -------------------------
        // Core Asset & Location Entities
        // -------------------------
        public DbSet<AssetEntity> Assets { get; set; }
        public DbSet<AssetCategoryEntity> AssetCategories { get; set; }
        public DbSet<AssetStatusEntity> AssetStatuses { get; set; }
        public DbSet<AssetImageEntity> AssetImages { get; set; }
        public DbSet<SiteEntity> Sites { get; set; }
        public DbSet<SiteLocationEntity> SiteLocations { get; set; }
        public DbSet<SiteHeadEntity> SiteHeads { get; set; }
        public DbSet<BuildingEntity> Buildings { get; set; }
        public DbSet<FloorEntity> Floors { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<StaffEntity> Staff { get; set; }
        public DbSet<TitleEntity> Titles { get; set; }

        // -------------------------
        // Asset Lifecycle / Transactions
        // -------------------------
        public DbSet<AssetCheckInEntity> AssetCheckIns { get; set; }
        public DbSet<AssetCheckOutEntity> AssetCheckOuts { get; set; }
        public DbSet<AssetRepairEntity> AssetRepairs { get; set; }
        public DbSet<ScheduleRepairEntity> ScheduleRepairs { get; set; }
        public DbSet<RepairStatusEntity> RepairStatuses { get; set; }
        public DbSet<AssetMaintenanceEntity> AssetMaintenances { get; set; }
        public DbSet<MaintenanceStatusEntity> MaintenanceStatuses { get; set; }
        public DbSet<AssetDisposeEntity> AssetDisposals { get; set; }
        public DbSet<AssetEventHistoryEntity> AssetEventHistories { get; set; }

        // -------------------------
        // Model Configuration
        // -------------------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all IEntityTypeConfiguration classes from assembly
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AssetTrackingDbContext).Assembly
            );

            // -------------------------
            // Table Mappings
            // -------------------------
            modelBuilder.Entity<UserEntity>().ToTable("Users");
            modelBuilder.Entity<AssetCategoryEntity>().ToTable("AssetCategory");
            modelBuilder.Entity<AssetCheckInEntity>().ToTable("AssetCheckIn");
            modelBuilder.Entity<AssetCheckOutEntity>().ToTable("AssetCheckOut");
            modelBuilder.Entity<AssetDisposeEntity>().ToTable("AssetDispose");
            modelBuilder.Entity<AssetEntity>().ToTable("Asset");
            modelBuilder.Entity<AssetEventHistoryEntity>().ToTable("AssetEventHistory");
            modelBuilder.Entity<AssetImageEntity>().ToTable("AssetImage");
            modelBuilder.Entity<AssetMaintenanceEntity>().ToTable("AssetMaintenance");
            modelBuilder.Entity<AssetRepairEntity>().ToTable("AssetRepair");
            modelBuilder.Entity<AssetStatusEntity>().ToTable("AssetStatus");
            modelBuilder.Entity<BuildingEntity>().ToTable("Building");
            modelBuilder.Entity<FloorEntity>().ToTable("Floor");
            modelBuilder.Entity<MaintenanceStatusEntity>().ToTable("MaintenanceStatus");
            modelBuilder.Entity<RefreshTokenEntity>().ToTable("RefreshTokens");
            modelBuilder.Entity<RepairStatusEntity>().ToTable("RepairStatus");
            modelBuilder.Entity<RoleClaimsEntity>().ToTable("RoleClaims");
            modelBuilder.Entity<RoleEntity>().ToTable("Role");
            modelBuilder.Entity<RoomEntity>().ToTable("Room");
            modelBuilder.Entity<ScheduleRepairEntity>().ToTable("ScheduleRepair");
            modelBuilder.Entity<SiteEntity>().ToTable("Site");
            modelBuilder.Entity<SiteHeadEntity>().ToTable("SiteHead");
            modelBuilder.Entity<SiteLocationEntity>().ToTable("SiteLocation");
            modelBuilder.Entity<StaffEntity>().ToTable("Staff");
            modelBuilder.Entity<TitleEntity>().ToTable("Title");
            modelBuilder.Entity<UserClaimsEntity>().ToTable("UserClaims");
            modelBuilder.Entity<UserImageEntity>().ToTable("UserImages");

            // -------------------------
            // UserTokenEntity: Composite Key
            // -------------------------
            modelBuilder.Entity<UserTokenEntity>(entity =>
            {
                entity.ToTable("UserTokens");
                entity.HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });
            });

            // -------------------------
            // UserRolesEntity: Composite Key
            // -------------------------
            modelBuilder.Entity<UserRolesEntity>(entity =>
            {
                entity.ToTable("userRoles");
                entity.HasKey(e => new { e.RoleId, e.UserId });

                // Uncomment for relationships if needed
                // entity.HasOne(e => e.User)
                //       .WithMany(u => u.UserRoles)
                //       .HasForeignKey(e => e.UserId)
                //       .OnDelete(DeleteBehavior.Cascade);
                // entity.HasOne(e => e.Role)
                //       .WithMany(r => r.UserRoles)
                //       .HasForeignKey(e => e.RoleId)
                //       .OnDelete(DeleteBehavior.Cascade);
            });

            // -------------------------
            // UserLoginEntity: Composite Key
            // -------------------------
            modelBuilder.Entity<UserLoginEntity>(entity =>
            {
                entity.ToTable("UserLogins");
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

                // Uncomment for relationship if needed
                // entity.HasOne(e => e.User)
                //       .WithMany(u => u.UserLogin)
                //       .HasForeignKey(e => e.UserId)
                //       .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
