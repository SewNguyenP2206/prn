using System;
using System.ComponentModel.DataAnnotations;

namespace BussinessObjects.Models
{
    public class InviteUsage
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid InviteId { get; set; }

        [Required]
        public Guid MemberId { get; set; }

        [Required]
        public DateTime UsedAt { get; set; }
    }
}
