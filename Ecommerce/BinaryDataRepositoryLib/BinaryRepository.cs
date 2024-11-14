using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Specification;
using ECommerceEntities;
using System.Runtime.Serialization;

namespace BinaryDataRepositoryLib
{
    public class BinaryRepository<T> : IDataRepository<T>
    {
        public bool Serialize(string filename, List<T> items)
        {
            bool status = false;
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filename, FileMode.OpenOrCreate);
            formatter.Serialize(stream, items);
            stream.Close();
            status = true;
            return status;
        }
        public List<T> Deserialize(string filename)
        {
            List<T> products = new List<T>();
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filename, FileMode.Open);
            if (stream != null)
            {
                products = (List<T>)formatter.Deserialize(stream);
            }
            stream.Close();
            return products;
        }
    }
}