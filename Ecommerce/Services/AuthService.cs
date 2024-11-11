using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using BinaryDataRepositoryLib;
using POCO;
using Specification;

namespace Services
{

    public class AuthService : IAuthService
    {
        public static string logfile = "logfile.dat";

        public static string credfile = "credentials.dat";

        public bool Seeding()
        {

            bool status = false;
            List<User> Users = new List<User>();
            List<Credential> credentials = new List<Credential>();
            Users.Add(new User { Id = 1, FirstName = "Pratiksha", LastName = "Adatkar", Email = "adatkarpratiksha14@gmail.com", ContactNo = "7410542126" });
            Users.Add(new User { Id = 1, FirstName = "Shruti", LastName = "Kadam", Email = "shrutikadam132@gmail.com", ContactNo = "9075652126" });
   
            credentials.Add(new Credential { Email = "adatakarpratiksha14@gmail.com", Password = "abc" });
            credentials.Add(new Credential { Email = "shrutikadam132@gmail.com", Password = "xyz" });
           

            IDataRepository<User> repository = new BinaryRepository<User>();
            IDataRepository<Credential> dataRepository = new BinaryRepository<Credential>();
            status = repository.Serialize(logfile, Users);
            status = dataRepository.Serialize(credfile, credentials);
            return status;
        }
        public bool Register(User u, string pass)
        {
            bool status = false;
            List<User> users = new List<User>();
            users = GetAllUsers();
            users.Add(u);
            List<Credential> credentials = new List<Credential>();
            credentials = GetAllCredentials();
            Credential credential = new Credential { Email = u.Email, Password = pass };
            credentials.Add(credential);

            IDataRepository<User> repository = new BinaryRepository<User>();
            status = repository.Serialize(logfile, users);

            IDataRepository<Credential> dataRepository = new BinaryRepository<Credential>();
            status = dataRepository.Serialize(credfile, credentials);
            return status;
        }

        public bool ForgotPassword(string username)
        {
            throw new NotImplementedException();
        }
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            IDataRepository<User> repository = new BinaryRepository<User>();
            users = repository.Deserialize(logfile);
            return users;
        }
        public List<Credential> GetAllCredentials()
        {
            List<Credential> credentials = new List<Credential>();
            IDataRepository<Credential> repository = new BinaryRepository<Credential>();
            credentials = repository.Deserialize(credfile);
            return credentials;
        }
        /*
        public List<User> GetAllCredentials()
        {
            List<Credential> credentials = new List<Credential>();
            IDataRepository<User> repository = new MemberRepository();
            credentials = repository.Deserialize<Credential>(logfile);
            return credentials;
        }
        */


        public bool Login(string username, string password)
        {
            IDataRepository<Credential> repository = new BinaryRepository<Credential>();
            List<Credential> credentials = repository.Deserialize(credfile);
            foreach (Credential cred in credentials)
            {
                if (cred.Email == username && cred.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ResetPassword(string username, string oldpassword, string newpassword)
        {
            throw new NotImplementedException();
        }
    }
}