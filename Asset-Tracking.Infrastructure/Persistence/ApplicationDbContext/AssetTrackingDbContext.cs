using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext
{
    public class AssetTrackingDbContext : IdentityDbContext<ApplicationUser>
    {
        public AssetTrackingDbContext(DbContextOptions<AssetTrackingDbContext> options)
            : base(options)
        {
        }

        // =================================================================
        // DbSets
        // =================================================================
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

        public DbSet<AssetCheckInEntity> AssetCheckIns { get; set; }
        public DbSet<AssetCheckOutEntity> AssetCheckOuts { get; set; }
        public DbSet<AssetRepairEntity> AssetRepairs { get; set; }
        public DbSet<ScheduleRepairEntity> ScheduleRepairs { get; set; }
        public DbSet<RepairStatusEntity> RepairStatuses { get; set; }
        public DbSet<AssetMaintenanceEntity> AssetMaintenances { get; set; }
        public DbSet<MaintenanceStatusEntity> MaintenanceStatuses { get; set; }
        public DbSet<AssetDisposeEntity> AssetDisposals { get; set; }
        public DbSet<AssetEventHistoryEntity> AssetEventHistories { get; set; }

        public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }
        public DbSet<UserImageEntity> UserImages { get; set; }

        // =================================================================
        // Model Configuration
        // =================================================================
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply any IEntityTypeConfiguration classes
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AssetTrackingDbContext).Assembly
            );

            // ======================
            // Identity Table Mappings (Custom names)
            // ======================
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

            // ======================
            // Custom Entity Table Mappings
            // ======================
            modelBuilder.Entity<AssetEntity>().ToTable("Asset");
            modelBuilder.Entity<AssetCategoryEntity>().ToTable("AssetCategory");
            modelBuilder.Entity<AssetStatusEntity>().ToTable("AssetStatus");
            modelBuilder.Entity<AssetImageEntity>().ToTable("AssetImage");

            modelBuilder.Entity<SiteEntity>().ToTable("Site");
            modelBuilder.Entity<SiteLocationEntity>().ToTable("SiteLocation");
            modelBuilder.Entity<SiteHeadEntity>().ToTable("SiteHead");
            modelBuilder.Entity<BuildingEntity>().ToTable("Building");
            modelBuilder.Entity<FloorEntity>().ToTable("Floor");
            modelBuilder.Entity<RoomEntity>().ToTable("Room");

            modelBuilder.Entity<StaffEntity>().ToTable("Staff");
            modelBuilder.Entity<TitleEntity>().ToTable("Title");

            modelBuilder.Entity<AssetCheckInEntity>().ToTable("AssetCheckIn");
            modelBuilder.Entity<AssetCheckOutEntity>().ToTable("AssetCheckOut");
            modelBuilder.Entity<AssetRepairEntity>().ToTable("AssetRepair");
            modelBuilder.Entity<ScheduleRepairEntity>().ToTable("ScheduleRepair");
            modelBuilder.Entity<RepairStatusEntity>().ToTable("RepairStatus");
            modelBuilder.Entity<AssetMaintenanceEntity>().ToTable("AssetMaintenance");
            modelBuilder.Entity<MaintenanceStatusEntity>().ToTable("MaintenanceStatus");
            modelBuilder.Entity<AssetDisposeEntity>().ToTable("AssetDispose");
            modelBuilder.Entity<AssetEventHistoryEntity>().ToTable("AssetEventHistory");

            modelBuilder.Entity<RefreshTokenEntity>().ToTable("RefreshTokens");
            modelBuilder.Entity<UserImageEntity>().ToTable("UserImage");

            // ======================
            // Critical Configuration for RefreshTokenEntity
            // ======================
            modelBuilder.Entity<RefreshTokenEntity>(entity =>
            {
                entity.Property(rt => rt.UserId)
                      .HasMaxLength(450)      // ← Must match Identity User Id length
                      .IsRequired();

                entity.HasOne(rt => rt.User)
                      .WithMany(u => u.RefreshTokens)
                      .HasForeignKey(rt => rt.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(rt => rt.UserId);
                entity.HasIndex(rt => rt.GeneratedRefreshToken);
            });

            // UserImageEntity Configuration (if it has UserId property)
            modelBuilder.Entity<UserImageEntity>(entity =>
            {
                // Only apply if UserId property exists
                var userIdProperty = typeof(UserImageEntity).GetProperty("UserId");
                if (userIdProperty != null)
                {
                    entity.Property("UserId")
                          .HasMaxLength(450)
                          .IsRequired();

                    entity.HasOne("User")
                          .WithMany("UserImages")
                          .HasForeignKey("UserId")
                          .OnDelete(DeleteBehavior.Cascade);
                }
            });
        }
    }
}