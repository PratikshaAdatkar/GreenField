using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    [Serializable]
    public class User
    {
        public static int i = 0;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string ContactNo { get; set; }
        public User()
        {
            i++;
            this.Id = i;
        }
    }
}