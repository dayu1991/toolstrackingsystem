using sqlserver.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.toolstrackingsystem
{
    public class RoleManageService : IRoleManageService
    {
        private IRoleManageRepository _roleManageRepository;
        public RoleManageService(IRoleManageRepository roleManageRepository)
        {
            this._roleManageRepository = roleManageRepository;
        }
        public List<dbentity.toolstrackingsystem.Sys_User_Role> GetRoleInfoList()
        {
            return _roleManageRepository.
        }
    }
}
