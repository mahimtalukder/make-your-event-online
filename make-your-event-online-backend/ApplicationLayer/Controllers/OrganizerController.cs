using ApplicationLayer.Auth;
using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApplicationLayer.Controllers
{
    [EnableCors("*", "*", "*")]
    public class OrganizerController : ApiController
    {
        [Route("api/organizer/add")]
        [HttpPost]
        public HttpResponseMessage Add(UserOrganizerDTO user)
        {
            try
            {
                user.UserType = "organizer";
                var data = OrganizerServices.Add(user);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [Route("api/organizer/get")]
        [HttpGet]
        [OrganizationLogin]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = OrganizerServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/organizer/get/{id}")]
        [HttpGet]
        [IsLogged]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = OrganizerServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/organizer/update")]
        [HttpPost]
        [OrganizationLogin]
        public HttpResponseMessage Update(UserOrganizerDTO organizerDTO)
        {
            try
            {
                var data = OrganizerServices.Update(organizerDTO);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/organizer/delete/{id}")]
        [HttpGet]
        [OrganizationLogin]
        public HttpResponseMessage Delete(int ID)
        {
            try
            {
                var data = OrganizerServices.Delete(ID);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/organizer/addservice")]
        [HttpPost]
        [OrganizationLogin]
        public HttpResponseMessage AddService(ServiceDTO obj, HttpPostedFileBase Image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Image != null)
                    {
                        var data = ServiceServices.Add(obj);




                        var path = System.Web.Hosting.HostingEnvironment.MapPath("~/Images/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        Image.SaveAs(path + Path.GetFileName(Image.FileName));
                        var db_path = "https://localhost:44335/Images/" + Image.FileName;

                        var catalog = new ServiceCatalogDTO()
                        {
                            ServiceId = data.Id,
                            Source = db_path,
                            IsThumbnail= true,
                            
                        };

                        return Request.CreateResponse(HttpStatusCode.OK, data);

                    }
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/organizer/getallservice/{id}")]
        [HttpGet]
        [OrganizationLogin]
        public HttpResponseMessage GetAllServices(int Id)
        {
            try
            {
                var data = OrganizerServices.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/organizer/updateservice")]
        [HttpPost]
        [OrganizationLogin]
        public HttpResponseMessage UpdateService(ServiceDTO obj)
        {
            try
            {

                var data = ServiceServices.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/organizer/deleteservice/{id}")]
        [HttpGet]
        [OrganizationLogin]
        public HttpResponseMessage DeleteService(int Id)
        {
            try
            {
                var data = ServiceServices.Delete(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/organizer/gettotalrevenue/{id}")]
        [HttpGet]
        [OrganizationLogin]
        public HttpResponseMessage GetTotalRevenue(int Id)
        {
            try
            {
                var data = OrganizerServices.GetTotalRevenue(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/organizer/gettotalpending/{id}")]
        [HttpGet]
        [OrganizationLogin]
        public HttpResponseMessage GetTotalPending(int Id)
        {
            try
            {
                var data = OrganizerServices.GetTotalPending(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
