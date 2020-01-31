using MongoAPI.API.Helpers;
using MongoAPI.BL;
using MongoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MongoAPI.API.Controllers
{
    public class ProductController : ApiController
    {
        private readonly ProductBL _productBL;

        public ProductController(ProductBL productBL)
        {
            _productBL = productBL;
        }

        [HttpGet]
        // GET: api/Product
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage oResponse = null;

            try
            {
                var ProductList = _productBL.GetAll();

                if (ProductList != null)
                {
                    oResponse = CommunicationHelper.GetHttpResponseMessage(Request, ProductList);
                }
            }
            catch (Exception ex)
            {
                oResponse = CommunicationHelper.GetException(ex, this.Request);
            }

            return oResponse;
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
