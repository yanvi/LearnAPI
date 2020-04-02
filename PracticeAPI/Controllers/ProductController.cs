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

        [HttpPost]
        public HttpResponseMessage Post(Product product)
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
