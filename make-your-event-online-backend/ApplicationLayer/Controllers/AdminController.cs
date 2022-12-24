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
    public class AdminController : ApiController
    {
        [Route("api/Admin/add")]
        [HttpPost]
        public HttpResponseMessage Add(UserAdminDTO User)
        {
            try
            {
                User.UserType = "Admin";
                var data = AdminServices.AddAdmin(User);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [Route("api/Admin/get")]
        [HttpGet]
        [AdminLogin]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = AdminServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Admin/get/{id}")]
        [HttpGet]
        [IsLogged]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = AdminServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Admin/update")]
        [HttpPost]
        [AdminLogin]
        public HttpResponseMessage Update(UserAdminDTO User)
        {
            try
            {
                var data = AdminServices.Update(User);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Admin/delete/{id}")]
        [HttpGet]
        [AdminLogin]
        public HttpResponseMessage Delete(int ID)
        {
            try
            {
                var data = AdminServices.Delete(ID);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


    }

}
