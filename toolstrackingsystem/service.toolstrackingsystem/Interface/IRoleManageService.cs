﻿using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.toolstrackingsystem
{
    public interface IRoleManageService
    {
        List<Sys_User_Role> GetRoleInfoList();
    }
}
