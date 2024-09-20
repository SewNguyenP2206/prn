using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessObjects.Models
{
    public class ServerMember
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User Member { get; set; }

        [Required]
        public Guid ServerId { get; set; }

        [ForeignKey("ServerId")]
        public Server Server { get; set; }

        public string Nickname { get; set; }

        [Required]
        public DateTime JoinedAt { get; set; }

        public bool Muted { get; set; }

        public bool Deafened { get; set; }

        public bool Banned { get; set; }
    }
}
