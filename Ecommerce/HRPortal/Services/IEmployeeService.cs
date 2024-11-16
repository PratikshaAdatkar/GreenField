using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRPortal.Models;

namespace HRPortal.Services
{
    public interface IEmployeeService
    {
        bool Login(string username, string password);
        bool Register(Employee employee);
        bool Delete(int id);
        bool Update(Employee e);

    }
}