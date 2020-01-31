using MongoAPI.DAL.Contracts;
using MongoAPI.DAL.Tools;
using MongoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoAPI.DAL
{
    public class ProductDAL: IProductDAL
    {
        private readonly string collection = "producto";

        public List<ProductModel> GetAll()
        {
            var products = DataAccess.ConnectAndQuery(collection);

            var prod = new List<ProductModel>();

            return prod;
        }
    }
}
