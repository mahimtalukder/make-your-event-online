using ApplicationLayer.Auth;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
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
        public HttpResponseMessage AddService(ServiceDTO info)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = ServiceServices.Add(info);
                    var db_path = "https://localhost:44335/Images/default.jpg";
                    var catalog = new ServiceCatalogDTO()
                    {
                        ServiceId = data.Id,
                        Source = db_path,
                        IsThumbnail = true,

                    };
                    var image = ServiceCatalogServices.Add(catalog);
                    data.ThumbnailId = image.Id;

                    return Request.CreateResponse(HttpStatusCode.OK, data);
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
                var data = ServiceServices.GetAllByUser(Id);
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

        [Route("api/organizer/serviceordercount/{id}")]
        [HttpGet]
        [OrganizationLogin]
        public HttpResponseMessage ServiceOrderCount(int Id)
        {
            try
            {
                var data = OrganizerServices.TotalServiceOrders(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/organizer/serviceallorders/{id}")]
        [HttpGet]
        [OrganizationLogin]
        public HttpResponseMessage ServiceAllOrders(int Id)
        {
            try
            {
                var data = OrganizerServices.AllServiceOrders(Id);
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
        public HttpResponseMessage TotalRevenue(int Id)
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

        [Route("api/organizer/getpendingservices/{id}")]
        [HttpGet]
        [OrganizationLogin]
        public HttpResponseMessage PendingServices(int Id)
        {
            try
            {
                var data = OrganizerServices.GetPending(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/organizer/getconfirmedservices/{id}")]
        [HttpGet]
        [OrganizationLogin]
        public HttpResponseMessage ConfirmedServices(int Id)
        {
            try
            {
                var data = OrganizerServices.GetConfirmed(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/organizer/getshippingservices/{id}")]
        [HttpGet]
        [OrganizationLogin]
        public HttpResponseMessage ShippingServices(int Id)
        {
            try
            {
                var data = OrganizerServices.GetShipping(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [Route("api/organizer/getallreviews/{id}")]
        [HttpGet]
        [OrganizationLogin]
        public HttpResponseMessage AllReviews(int Id)
        {
            try
            {
                var data = ReviewServices.OrganizeReview(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [Route("api/organizer/getreviewsbyservice/{id}")]
        [HttpGet]
        [OrganizationLogin]
        public HttpResponseMessage ReviewsByService(int Id)
        {
            try
            {
                var data = ReviewServices.ServiceReviews(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/organizer/getreport/{id}")]
        [HttpGet]
        [OrganizationLogin]
        public HttpResponseMessage GetReport(int Id)
        {
            try
            {
                var data = 1;
                //var data = OrganizerServices.GenerateReport(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}


