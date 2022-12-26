using ApplicationLayer.Auth;
using BLL.DTOs;
using BLL.Email;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net.Http.Headers;
using System.Web.Hosting;

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

        //dashbord
        //customar list

        [Route("api/Admin/AllCustomer")]
        [HttpGet]
        public HttpResponseMessage AllCustomer()
        {
            try
            {
                var data = CustomerServices.Getlast();

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Admin/AllOrganizar")]
        [HttpGet]
        public HttpResponseMessage AllOrganizar()
        {
            try
            {
                var data = OrganizerServices.Get();
                var data2 = data.LastOrDefault();
                var data3 = data2.Id;
                return Request.CreateResponse(HttpStatusCode.OK, data3);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Admin/AllAccount")]
        [HttpGet]
        public HttpResponseMessage AllAccount()
        {
            try
            {
                var data = UserServices.Get();
                var data2 = data.LastOrDefault();
                var data3 = data2.Id;
                return Request.CreateResponse(HttpStatusCode.OK, data3);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        //resetpassword
        [Route("api/Admin/userResetPassword/{id}")]
        [HttpGet]
        [AdminLogin]
        public HttpResponseMessage ResetPassword(int Id)
        {
            try
            {
                Random rand = new Random();

                // Choosing the size of string
                // Using Next() string
                int stringlen = rand.Next(4, 10);
                int randValue;
                string str = "";
                char letter;
                for (int i = 0; i < stringlen; i++)
                {

                    // Generating a random number.
                    randValue = rand.Next(0, 26);

                    // Generating random character by converting
                    // the random number into character.
                    letter = Convert.ToChar(randValue + 65);

                    // Appending the letter to string.
                    str = str + letter;
                }

                var user = UserServices.Get(Id);
                var user2 = UserCustomerServices.Get(Id);

               user.Password = str;
               var data = UserServices.Update(user);

                var mail = new MailDataDTO()
                {
                    Email = user2.Email,
                    Name = user2.Name,
                    Subject = "Reset Password",
                    Body = @"Your new password is: " + str,
                };

                SendMail.Mail(mail);


                return Request.CreateResponse(HttpStatusCode.OK,"Mail sended");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Admin/report")]
        [HttpGet]
        public HttpResponseMessage PrintOrders()
        {


            


            try
            {


                return null;

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [Route("api/Admin/getOrganization")]
        [HttpGet]
        [AdminLogin]
        public HttpResponseMessage Getorga()
        {
            try
            {
                var data = OrganizerServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Admin/getuser")]
        [HttpGet]
        [AdminLogin]
        public HttpResponseMessage Getuser()
        {
            try
            {
                var data = UserServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }

}
