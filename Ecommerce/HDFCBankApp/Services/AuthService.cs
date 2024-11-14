using HDFCBankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HDFCBankApp.Repositories;
using HDFCBankApp.Services;

namespace HDFCBankApp.Services
{

    public class AuthService : IAuthService
    {
        public static string logfile = "D:/bank_users.json";

        public static string credfile = "D:/bank_credentials.json";

        public bool Seeding()
        {

            bool status = false;
            List<User> Users = new List<User>();
            List<Credential> credentials = new List<Credential>();
            Users.Add(new User { FirstName = "Pratiksha", LastName = "Adatkar", Email = "adatkarpratiksha@gmail.com", ContactNo = 5667788990, Location = "Pune" });
            Users.Add(new User { FirstName = "Shruti", LastName = "Kadam", Email = "shrutikadam14@gmail.com", ContactNo = 5667788990, Location = "Sangamner" });
            
            credentials.Add(new Credential { Email = "adatkarpratiksha@gmail.com", Password = "abc" });
            credentials.Add(new Credential { Email = "shrutikadam14@gmail.com", Password = "a" });

            //IDataRepository<User> repository = new BinaryRepository<User>();
            IDataRepository<User> repository = new JsonRepository<User>();
            //IDataRepository<Credential> dataRepository = new BinaryRepository<Credential>();
            IDataRepository<Credential> dataRepository = new JsonRepository<Credential>();
            status = repository.Serialize(logfile, Users);
            status = false;
            status = dataRepository.Serialize(credfile, credentials);
            return status;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public bool Register(string firstname, string lastname, string email, long contactnumber, string location)
        {
            bool status = false;
            List<User> users = new List<User>();
            users = GetAllUsers();
            User u = new User();
            u.FirstName = firstname;
            u.LastName = lastname;
            u.Email = email;
            u.ContactNo = contactnumber;
            u.Location = location;
            users.Add(u);
            List<Credential> credentials = new List<Credential>();
            credentials = GetAllCredentials();
            Credential credential = new Credential { Email = u.Email, Password = RandomString(6) };

            credentials.Add(credential);

            //IDataRepository<User> repository = new BinaryRepository<User>();
            IDataRepository<User> repository = new JsonRepository<User>();

            status = repository.Serialize(logfile, users);

            //IDataRepository<Credential> dataRepository = new BinaryRepository<Credential>();
            IDataRepository<Credential> dataRepository = new JsonRepository<Credential>();

            status = dataRepository.Serialize(credfile, credentials);
            return status;
        }

        public string ForgotPassword(string username)
        {
            List<Credential> credentials = new List<Credential>();
            credentials = GetAllCredentials();
            foreach (Credential cred in credentials)
            {
                if (cred.Email == username)
                {
                    return cred.Password;
                }
            }
            return null;

        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            //IDataRepository<User> repository = new BinaryRepository<User>();
            IDataRepository<User> repository = new JsonRepository<User>();

            users = repository.Deserialize(logfile);
            return users;
        }
        public User GetUser(int id)
        {
            User foundUser = null;
            List<User> users = GetAllUsers();
            foreach (User u in users)
            {
                if (u.Id == id)
                {
                    foundUser = u;
                }
            }
            return foundUser;
        }

        public List<Credential> GetAllCredentials()
        {
            List<Credential> credentials = new List<Credential>();
            //IDataRepository<Credential> repository = new BinaryRepository<Credential>();
            IDataRepository<Credential> repository = new JsonRepository<Credential>();

            credentials = repository.Deserialize(credfile);
            return credentials;
        }


        public bool Login(string username, string password)
        {
            //IDataRepository<Credential> repository = new BinaryRepository<Credential>();
            IDataRepository<Credential> repository = new JsonRepository<Credential>();

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
            List<Credential> credentials = new List<Credential>();
            credentials = GetAllCredentials();
            foreach (Credential cred in credentials)
            {
                if (cred.Email == username & cred.Password == oldpassword)
                {
                    cred.Password = newpassword;

                    //IDataRepository<Credential> dataRepository = new BinaryRepository<Credential>();
                    IDataRepository<Credential> dataRepository = new JsonRepository<Credential>();

                    return dataRepository.Serialize(credfile, credentials);
                }
            }

            return false;
        }

        public bool Delete(int id)
        {
            User user = GetUser(id);
            if (user != null)
            {
                List<User> users = GetAllUsers();
                users.RemoveAll(u => u.Id == id);
                IDataRepository<User> repository = new JsonRepository<User>();
                repository.Serialize(@"D:\Users.json", users);
                return true;
            }
            return false;
        }
    }
}