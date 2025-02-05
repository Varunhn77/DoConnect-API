using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectEntity;
using DoConnectRepository.Data;
using Microsoft.EntityFrameworkCore;

namespace DoConnectRepository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        DoConnectDbContext _connect;
        public ProductRepository(DoConnectDbContext dbContext)
        {
            _connect = dbContext;

        }
        public void AddProduct(Product product)
        {
            _connect.Products.Add(product);
            _connect.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product product = _connect.Products.Find(id);
            //delete from products where id=1
            _connect.Products.Remove(product);
            _connect.SaveChanges();
        }

        public  void UpdateProduct(Product product)
        {
            _connect.Products.Update(product);
            _connect.SaveChanges();
        }

        public Product GetProductById(int id)
        {
           Product obj= _connect.Products.Find(id);
            return obj;
        }

        public List<Product> GetAll()
        {
            var list = _connect.Products.ToList();
            return list;
        }

        
    }
}
