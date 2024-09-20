using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Username { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Avatar { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public string Banner { get; set; }

        public string Pronouns { get; set; }

        public string About { get; set; }

        [Required]
        public string Hashtag { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public bool IsVerified { get; set; }

        [Required]
        public DateTime JoinedAt { get; set; }

        public ICollection<Friendship> RequestedFriendships { get; set; } 

        public ICollection<Friendship> ReceivedFriendships { get; set; }

        public ICollection<ServerMember> ServerMembers { get; set; }
    }

    public enum Status
    {
        Online,
        Idle,
        DoNotDisturb,
        Invisible
    }
}