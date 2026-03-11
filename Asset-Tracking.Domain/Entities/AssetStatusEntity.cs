using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking.Domain.Entities
{
    public class AssetStatusEntity
    {
        [Key]
        public int AssetStatusId { get; set; }

        [Required]
        [MaxLength(300)]
        public string AssetStatusName { get; set; } = null!;

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [MaxLength(300)]
        public string CreatedBy { get; set; } = null!;

        public DateTime? DateUpdated { get; set; }

        [MaxLength(300)]
        public string? UpdatedBy { get; set; }
    }
}
