using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ApplicationLayer.Auth
{
    public class OrganizationLogin : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            var tokenkUser = actionContext.Request.Headers.GetValues("Username").FirstOrDefault();

            var tokenData = AuthServices.IsTokenValid(token.ToString());
            if (token == null || tokenkUser == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "No token supplied");

            }
            else if (tokenData == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Supplied Token is invalid or expired");
            }
            else if(tokenData != null)
            {
                var user = UserServices.Get(tokenData.UserId);
                if(user == null || user.UserType != "organizer")
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "You cannot access this!");
                }
                else
                {
                    var validUser = UserServices.GetByUsername(tokenkUser);
                    if(validUser == null || validUser.Id != user.Id)
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "You are not the correct user!");
                    }

                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}