using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessObjects.Models
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        public string Color { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public bool Mentionable { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public Guid ServerId { get; set; }

        [ForeignKey("ServerId")]
        public Server Server { get; set; }

        public ICollection<MemberRole> MemberRoles { get; set; } 
    }
}
