using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.toolstrackingsystem
{
    public interface IUserManageService
    {
        Sys_User_Info GetUserInfo(string UserCode, string Pwd);
        Sys_User_Info GetUserInfo(string UserCode);
        int InsertUserInfo(string UserCode, string UserName, string Password, out Sys_User_Info userInfo);
        List<Sys_User_Info> GetUserInfoList(string UserCode, string DateTimeFrom, string DateTimeTo);
        bool UpdateUserInfo(Sys_User_Info userInfo);
        bool DeleteUser(Sys_User_Info userInfo);
    }
}
