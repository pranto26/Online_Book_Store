using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Online_Book_Store.Controllers
{
    public class BookController : ApiController
    {
        [HttpGet]
        [Route("api/books")]
        public HttpResponseMessage Books()
        {
            try
            {
                var data = BookServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/books/{id}")]
        public HttpResponseMessage Book(int id)
        {
            try
            {
                var data = BookServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/books/{id}/orders")]
        public HttpResponseMessage BookOrders(int id)
        {
            try
            {
                var data = BookServices.GetwithOrders(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/books/create")]
        public HttpResponseMessage AddBook(BookDTO obj)
        {
            try
            {
                var res = BookServices.Create(obj);
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
        [Route("api/books/update")]
        public HttpResponseMessage Update(BookDTO obj)
        {
            try
            {
                var res = BookServices.Update(obj);
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
        [Route("api/books/delete/{id}")]
        public HttpResponseMessage DeleteBook(int id)
        {
            try
            {
                var data = BookServices.DeleteBook(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
