using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid ServerId { get; set; }
        public int Position { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Channel> Channels { get; set; }

        [ForeignKey("ServerId")]
        public Server Server { get; set; }
    }
}
