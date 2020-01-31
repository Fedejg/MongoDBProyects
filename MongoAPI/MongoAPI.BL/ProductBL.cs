using MongoAPI.DAL.Contracts;
using MongoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoAPI.BL
{
    public class ProductBL
    {
        private readonly IProductDAL _productDAL;

        public ProductBL(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            var products = _productDAL.GetAll();

            return products;
        }
    }
}
