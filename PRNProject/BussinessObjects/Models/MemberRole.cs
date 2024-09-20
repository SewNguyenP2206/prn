using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessObjects.Models
{
    public class MemberRole
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid MemberId { get; set; }

        [ForeignKey("MemberId")]
        public ServerMember ServerMember { get; set; }

        [Required]
        public Guid RoleId { get; set; }


        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
