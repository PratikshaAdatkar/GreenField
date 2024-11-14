using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Services;
using Specification;
using ECommerceEntities;

namespace AuthWebAPI.Controllers
{
    public class UserController : ApiController
    {
        public IEnumerable<User> Get()
        {
            AuthService svc = new AuthService();
            List<User> users = svc.GetAllUsers();
            return users;
        }

        // GET api/values/5
        public User Get(int id)
        {
            AuthService svc = new AuthService();
            User user = svc.GetUser(id);
            return user;
        }

        // POST api/values
        public void Post([FromBody] User user, string pass)
        {
            IAuthService svc = new AuthService();
            svc.Register(user, pass);
        }

        // PUT api/values/5
        /*
        public void Put(int id, [FromBody] User user)
        {
            IAuthService svc = new AuthService();
            svc.Update(user);
        }
        */
        // DELETE api/values/5
        public void Delete(int id)
        {
            IAuthService svc = new AuthService();
            svc.Delete(id);
        }
    }
}