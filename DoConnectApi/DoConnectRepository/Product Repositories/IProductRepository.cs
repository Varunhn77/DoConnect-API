using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectEntity;

namespace DoConnectRepository.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int product);

        Product GetProductById(int id);

        List<Product> GetAll();
    }
}
