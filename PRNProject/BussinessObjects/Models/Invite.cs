using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.Models
{
    public class Invite
    {
        public Guid Id { get; set; } 
        public string Code { get; set; } 
        public Guid ServerId { get; set; }
        public Guid CreatorId { get; set; } 
        public DateTime ExpiryDate { get; set; } 
        public int MaxUses { get; set; } 
        public int Uses { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
        public Server Server { get; set; }
        public ServerMember ServerMember { get; set; }
    }
}
