using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectEntity;

namespace DoConnectRepository.UserInfoServices
{
    public interface IUserInfoRepository
    {
        void Register(UserInfo userInfo);

        UserInfo Login(string Email, string Password);

        UserInfo Logout(UserInfo userInfo);

        List<UserInfo> GetAll();
    }
}
