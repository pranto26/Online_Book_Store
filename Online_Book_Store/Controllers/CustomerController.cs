using BLL.DTOs;
using BLL.Services;
using Online_Book_Store.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Online_Book_Store.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("api/customers")]
        public HttpResponseMessage Customers()
        {
            try
            {
                var data = CustomerServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Logged]
        [Route("api/customers/{id}")]
        public HttpResponseMessage Customer(int id)
        {
            try
            {
                var data = CustomerServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        
        [Logged]
        [SellerAccess]
        [HttpGet]
        [Route("api/customers/{id}/orders")]
        public HttpResponseMessage CustomerOrders(int id)
        {
            try
            {
                var data = CustomerServices.GetwithOrders(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Logged]
        [SellerAccess]
        [Route("api/customers/create")]
        public HttpResponseMessage AddCustomer(CustomerDTO obj)
        {
            try
            {
                var res = CustomerServices.Create(obj);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Inserted", Data = obj });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Not Inserted", Data = obj });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message, Data = obj });
            }
        }

        [HttpPost]
        [Logged]
        [SellerAccess]
        [Route("api/customers/update")]
        public HttpResponseMessage Update(CustomerDTO obj)
        {
            try
            {
                var res = CustomerServices.Update(obj);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Updated", Data = obj });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Not Updated", Data = obj });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message, Data = obj });
            }
        }


        [HttpPost]
        [Logged]
        [SellerAccess]
        [Route("api/customers/delete/{id}")]
        public HttpResponseMessage DeleteCustomer(int id)
        {
            try
            {
                var data = CustomerServices.DeleteCustomer(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
