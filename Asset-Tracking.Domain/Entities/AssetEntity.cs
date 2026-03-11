using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Tracking.Domain.Entities
{
    public class AssetEntity
    {
        [Key]
        public int AssetId { get; set; }

        [Required]
        [MaxLength(300)]
        public string AssetName { get; set; } = null!;

        [MaxLength(4000)]
        public string? AssetDescription { get; set; }

        [MaxLength(300)]
        public string? PurchaseFrom { get; set; }

        public DateTime? PurchaseDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Cost { get; set; }

        [MaxLength(300)]
        public string? Brand { get; set; }

        [MaxLength(300)]
        public string? Model { get; set; }

        [MaxLength(300)]
        public string? SerialNumber { get; set; }

        [MaxLength(300)]
        public string? AssignedTo { get; set; }

        [Required]
        public bool HasWarranty { get; set; }

        public DateTime? WarrantyDate { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [MaxLength(300)]
        public string CreatedBy { get; set; } = null!;

        public DateTime? DateUpdated { get; set; }

        [MaxLength(300)]
        public string? UpdatedBy { get; set; }

        [Required]
        [ForeignKey(nameof(AssetCategory))]
        public int AssetCategoryId { get; set; }

        public virtual AssetCategoryEntity AssetCategory { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(AssetStatus))]
        public int AssetStatusId { get; set; }

        public virtual AssetStatusEntity AssetStatus { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(AssetImage))]
        public int AssetImageId { get; set; }

        public virtual AssetImageEntity AssetImage { get; set; } = null!;

        [ForeignKey(nameof(Site))]
        public int? SiteId { get; set; }

        public virtual SiteEntity? Site { get; set; }

        [ForeignKey(nameof(Building))]
        public int? BuildingId { get; set; }

        public virtual BuildingEntity? Building { get; set; }

        [ForeignKey(nameof(Floor))]
        public int? FloorId { get; set; }

        public virtual FloorEntity? Floor { get; set; }

        [ForeignKey(nameof(Room))]
        public int? RoomId { get; set; }

        public virtual RoomEntity? Room { get; set; }

        [MaxLength(100)]
        public string? RoomLocationDescription { get; set; }

        [Required]
        [MaxLength(300)]
        public string AssetTagId { get; set; } = null!;

        [MaxLength(4000)]
        public string? AssetConditionDescription { get; set; }

        public bool? IsAssetInGoodCondition { get; set; }

        public bool? IsRepairRequired { get; set; }

    }
}
