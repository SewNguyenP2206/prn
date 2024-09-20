using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.Models
{
    public class RolePermission
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public bool IsGranted { get; set; }

        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
