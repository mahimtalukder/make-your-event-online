using ApplicationLayer.Auth;
using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApplicationLayer.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CustomerController : ApiController
    {
        [Route("api/customer/add")]
        [HttpPost]
        public HttpResponseMessage Add(UserCustomerDTO User)
        {
            try
            {
                User.UserType = "Customer";
                var data = UserCustomerServices.Add(User);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [Route("api/customer/get")]
        [HttpGet]
        [CustomerLogin]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = UserCustomerServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/customer/get/{id}")]
        [HttpGet]
        [IsLogged]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = UserCustomerServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/customer/update")]
        [HttpPost]
        [CustomerLogin]
        public HttpResponseMessage Update(UserCustomerDTO User)
        {
            try
            {
                var data = UserCustomerServices.Update(User);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/customer/delete/{id}")]
        [HttpGet]
        [CustomerLogin]
        public HttpResponseMessage Delete(int ID)
        {
            try
            {
                var data = UserCustomerServices.Delete(ID);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}