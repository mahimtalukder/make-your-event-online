using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginDTO login)
        {
            try
            {
                if (login == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username password not supplied");
                }
                if (ModelState.IsValid)
                {
                    var token = AuthServices.Authenticate(login.Username, login.Password);
                    if (token != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, token);
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Username password invalid");
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/logout")]
        [HttpGet]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            try
            {
                var isLoggedOut = AuthServices.ExpToken(token);
                if (isLoggedOut)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, isLoggedOut);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, isLoggedOut);
                }
         

            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
