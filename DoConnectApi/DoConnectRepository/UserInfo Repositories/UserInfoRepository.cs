using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectEntity;
using DoConnectRepository.Data;
using DoConnectRepository.UserInfoServices;
using Microsoft.EntityFrameworkCore;

namespace DoConnectRepository.UserInfo_Repositories
{
    public class UserInfoRepository : IUserInfoRepository
    {
        DoConnectDbContext _repo;

        public UserInfoRepository(DoConnectDbContext dbContext)
        {
            _repo = dbContext;
        }
        public List<UserInfo> GetAll()
        {
            var list = _repo.userInfo.ToList();
            return list;
        }

        public UserInfo Login(string Email, string Password)
        {
            UserInfo useri = null;
            var result = _repo.userInfo.Where(u => u.Email == Email && u.Password == Password).ToList();
            foreach (var item in result)
            {
                useri = new UserInfo();
                useri.Id = item.Id;
                useri.Name = item.Name;
                useri.Email = item.Email;
                useri.Password = item.Password;
            }
            return useri;
        }

        public UserInfo Logout(UserInfo userInfo)
        {
            UserInfo logout = null;
            var result = _repo.userInfo.Where(obj => obj.Email == userInfo.Email && obj.Password == userInfo.Password).ToList();
            if (result.Count() > 0)
            {
                userInfo = result[0];
            }
            return logout;
        }

        public void Register(UserInfo userInfo)
        {
            _repo.userInfo.Add(userInfo);
            _repo.SaveChanges();
        }
    }
}
