using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PracticeAPI.Models;

namespace PracticeAPI.Controllers
{
    public class ProductController : ApiController
    {

        public HttpResponseMessage Get()
        {
            try
            {
                var c = new Product { Id = 1, Name = "LUX", DOM = new DateTime(2019, 01, 01), DOE = new DateTime(2021, 01, 01), Active = false };
                var obj = Newtonsoft.Json.JsonConvert.SerializeObject(c);
                return Request.CreateResponse(HttpStatusCode.OK, obj);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Product product)
        {
            try
            {

                ProductDB obj = new ProductDB();
                int x = obj.Save(product);

                var message = Request.CreateResponse(HttpStatusCode.Created, product);
                message.Headers.Location = new Uri(Request.RequestUri +
                    product.Id.ToString());



                return message;

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
