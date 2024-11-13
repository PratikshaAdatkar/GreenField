using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCO;

namespace Specification
{
    public interface IAuthService
    {
        bool Login(string username, string password);
        bool Register(User u, string pass);
        string ForgotPassword(string username);
        bool ResetPassword(string username, string oldpassword, string newpassword);
        User GetUser(int id);
        List<User> GetAllUsers();
        List<Credential> GetAllCredentials();
        bool Delete(int id);
    }
}