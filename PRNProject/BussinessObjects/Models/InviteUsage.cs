using System;
using System.ComponentModel.DataAnnotations;

namespace BussinessObjects.Models
{
    public class InviteUsage
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid InviteId { get; set; }

        public Guid MemberId { get; set; }

        public DateTime UsedAt { get; set; }
        public ServerMember ServerMember { get; set; }
        public Invite Invite { get; set; }
    }
}
