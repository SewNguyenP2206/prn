using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.Models
{
    public class Friendship
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("Addressee")]
        [Required]
        public Guid RequesterId { get; set; }

        
        public User Requester { get; set; }

        [ForeignKey("Requester")]
        [Required]
        public Guid AddresseeId { get; set; }

       
        public User Addressee { get; set; }

        [Required]
        public FriendshipStatus Status { get; set; }
    }

    public enum FriendshipStatus
    {
        Pending,
        Accepted,
        Blocked
    }
}
