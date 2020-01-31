using MongoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoAPI.DAL.Contracts
{
    public interface IProductDAL
    {
        List<ProductModel> GetAll();
    }
}
