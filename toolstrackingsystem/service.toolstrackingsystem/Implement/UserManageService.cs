using dbentity.toolstrackingsystem;
using sqlserver.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.toolstrackingsystem
{
    public class UserManageService : IUserManageService
    {
        private readonly IUserManageRepository _userManageRepository;
        public UserManageService(IUserManageRepository userManageRepository)
	    {
            this._userManageRepository = userManageRepository;
	    }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public Sys_User_Info GetUserInfo(string UserCode, string Pwd)
        {
            return _userManageRepository.GetUserInfo(UserCode, Pwd);
        }
        /// <summary>
        /// 通过用户名获取用户信息
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public Sys_User_Info GetUserInfo(string UserCode)
        {
            return _userManageRepository.GetUserInfo(UserCode);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int InsertUserInfo(string UserCode,string UserName, string Password, out Sys_User_Info userinfo)
        {
            return _userManageRepository.InsertUserInfo(UserCode,UserName, Password, out userinfo);
        }
        /// <summary>
        /// 获取所有满足条件的用户列表
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="DateTimeFrom"></param>
        /// <param name="DateTimeTo"></param>
        /// <returns></returns>
        public List<Sys_User_Info> GetUserInfoList(string UserCode, string DateTimeFrom, string DateTimeTo)
        {
            return _userManageRepository.GetUserInfoList(UserCode, DateTimeFrom, DateTimeTo);
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(Sys_User_Info userInfo)
        {
            return _userManageRepository.UpdateUserInfo(userInfo);
        }
        /// <summary>
        /// 删除某个用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool DeleteUser(Sys_User_Info userInfo)
        {
            return _userManageRepository.DeleteUser(userInfo);
        }
    }
}
