using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking.Domain.Entities
{
    public class RefreshTokenEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(900)]
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }

        [MaxLength(4000)]
        public string? GeneratedRefreshToken { get; set; }

        public virtual UserEntity? User { get; set; }
    }
}
