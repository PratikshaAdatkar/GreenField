using Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Repositories
{
    public interface IAuthRepository
    {
        bool Register(User user);
        bool Login(string username, string password);
        List<User> GetAllUsers();
        User GetById(int id);
    }
}