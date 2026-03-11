using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking.Domain.Entities
{
    public class AssetCheckOutEntity
    {
        [Key]
        public int AssetCheckOutId { get; set; }

        [Required]
        public DateTime AssetCheckOutDate { get; set; }

        public DateTime? DueDate { get; set; }

        [MaxLength(4000)]
        public string? Notes { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [MaxLength(300)]
        public string CreatedBy { get; set; } = null!;

        public DateTime? DateUpdated { get; set; }

        [MaxLength(300)]
        public string? UpdatedBy { get; set; }

        [Required]
        [ForeignKey(nameof(Asset))]
        public int AssetId { get; set; }

        public virtual AssetEntity Asset { get; set; } = null!;

        [MaxLength(100)]
        [ForeignKey(nameof(Staff))]
        public string? StaffId { get; set; }

        public virtual StaffEntity? Staff { get; set; }

        [MaxLength(300)]
        public string? AssignedTo { get; set; }

        [ForeignKey(nameof(Site))]
        public int? SiteId { get; set; }

        public virtual SiteEntity? Site { get; set; }

        [Required]
        [ForeignKey(nameof(Building))]
        public int BuildingId { get; set; }

        public virtual BuildingEntity Building { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Floor))]
        public int FloorId { get; set; }

        public virtual FloorEntity Floor { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }

        public virtual RoomEntity Room { get; set; } = null!;

        [MaxLength(300)]
        public string? RoomLocationDescription { get; set; }

        public bool IsConfirmedEmailSent { get; set; }

        public DateTime? EmailSentDate { get; set; }

        public bool HasReceivedConfirmed { get; set; }

        public DateTime? HasReceivedConfirmedDate { get; set; }

        public bool IsSMSSent { get; set; }

        public DateTime? SMSSentDate { get; set; }


    }
}
