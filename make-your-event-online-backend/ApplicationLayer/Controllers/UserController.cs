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
    public class UserController : ApiController
    {
        [Route("api/category")]
        [HttpGet]
        public HttpResponseMessage GetCategory()
        {
            try
            {
                var data = CategoryServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/user/getthumbnail/{id}")]
        [HttpGet]
        public HttpResponseMessage GetThumbnail(int id)
        {
            try
            {
                var data = ServiceCatalogServices.GetByService(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/user/getCategory/{id}")]
        [HttpGet]
        public HttpResponseMessage GetCategory(int id)
        {
            try
            {
                var data = CategoryServices.GetByService(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/user/getallservices")]
        [HttpGet]
        public HttpResponseMessage GetAllServices()
        {
            try
            {
                var data = ServiceServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [Route("api/user/GetAvailableServices")]
        [HttpGet]
        public HttpResponseMessage GetAvailableServices()
        {
            try
            {
                var data = ServiceServices.GetAvailableService();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


    }
}
