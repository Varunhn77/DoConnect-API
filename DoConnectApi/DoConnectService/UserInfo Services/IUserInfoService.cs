using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectEntity;

namespace DoConnectService.UserInfo_Services
{
    public interface IUserInfoService
    {
        void Register(UserInfo userInfo);

        List<UserInfo> GetUserInfo();

        UserInfo Login(string Email , string Password);

        UserInfo Logout(UserInfo userInfo);
    }
}
