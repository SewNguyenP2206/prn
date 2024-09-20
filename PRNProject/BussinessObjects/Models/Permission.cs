﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.Models
{
    public class Permission
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsServer { get; set; }
        public ICollection<ChannelRolePermission> ChannelRolePermissions { get; set; }

    }
}
