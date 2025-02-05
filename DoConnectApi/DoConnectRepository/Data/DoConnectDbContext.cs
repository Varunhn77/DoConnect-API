using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectEntity;
using Microsoft.EntityFrameworkCore;

namespace DoConnectRepository.Data
{
    public class DoConnectDbContext : DbContext
    {
        public DoConnectDbContext(DbContextOptions<DoConnectDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        public DbSet<UserInfo> userInfo { get; set; }

    }
}
