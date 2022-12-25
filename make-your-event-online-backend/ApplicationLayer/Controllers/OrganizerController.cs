﻿using ApplicationLayer.Auth;
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
        public HttpResponseMessage AddService(ServiceDTO obj)
        {
            try
            {
                var data = ServiceServices.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
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

        [Route("api/organizer/totalrevenue/{id}")]
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

        [Route("api/organizer/pendingservices/{id}")]
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

        [Route("api/organizer/confirmedservices/{id}")]
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

        [Route("api/organizer/shippingservices/{id}")]
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

        [Route("api/organizer/allreviews/{id}")]
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

        [Route("api/organizer/reviewsbyservice/{id}")]
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
    }
}


