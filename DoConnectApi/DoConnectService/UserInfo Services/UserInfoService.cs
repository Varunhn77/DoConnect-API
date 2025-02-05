using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectEntity;
using DoConnectRepository.UserInfoServices;

namespace DoConnectService.UserInfo_Services
{
    public class UserInfoService : IUserInfoService
    {
        IUserInfoRepository _remo;

        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            _remo = userInfoRepository;
        }
               
        public UserInfo Login(string Email, string Password)
        {
            var use = _remo.Login(Email, Password);

            return use;
        }

        public UserInfo Logout(UserInfo userInfo)
        {
            return _remo.Logout(userInfo);
        }

        public void Register(UserInfo userInfo)
        {
           _remo.Register(userInfo);
        }

        List<UserInfo> IUserInfoService.GetUserInfo()
        {
            return _remo.GetAll();
        }
    }
}
