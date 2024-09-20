using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.Models
{
    public class ChannelRolePermission
    {
        public Guid Id { get; set; }
        public Guid ChannelId { get; set; }
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public bool IsGranted { get; set; }
        public Role Role { get; set; }
        public Permission Permission { get; set; }  
        public Channel Channel { get; set; }
    }
}
