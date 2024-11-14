using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ECommerceEntities;
using Specification;
using Services;

namespace AuthWebAPI.Controllers
{
    public class AuthController : ApiController
    {
        public IHttpActionResult Post([FromBody] Credential crednetial)
        {
            IAuthService svc = new AuthService();
            if (svc.Login(crednetial.Email, crednetial.Password))
            {
                return Ok("login successful");
            }
            else
            {
                return Unauthorized();

            }

        }
    }
}