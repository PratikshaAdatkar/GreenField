using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Specification;

using POCO;
using System.Runtime.Serialization;

namespace BinaryDataRepositoryLib

{

    public class DataRepository : IDataRepository

    {

        public bool Serialize(string filename, List<User> users)

        {

            bool status = false;
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filename, FileMode.OpenOrCreate);
            formatter.Serialize(stream, users);
            stream.Close();

            return status;

        }

        public List<User> Deserialize(string filename)

        {

            List<User> users = new List<User>();
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filename, FileMode.Open);
            if (stream != null)
            {
                users = (List<User>)formatter.Deserialize(stream);
            }
            stream.Close();
            return users;

        }

    }

}

