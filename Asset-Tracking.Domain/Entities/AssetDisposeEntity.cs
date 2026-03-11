using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking.Domain.Entities
{
    public class AssetDisposeEntity
    {
        [Key]
        public int AssetDisposeId { get; set; }

        [Required]
        public DateTime DisposeDate { get; set; }

        [Required]
        [MaxLength(300)]
        public string DisposeTo { get; set; } = null!;

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

    }
}
