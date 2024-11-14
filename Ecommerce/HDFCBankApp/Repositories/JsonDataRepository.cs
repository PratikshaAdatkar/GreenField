
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.Serialization;


namespace HDFCBankApp.Repositories
{

    public class JsonRepository<T> : IDataRepository<T>
    {
        public bool Serialize(string filename, List<T> items)
        {
            bool status = false;
            FileStream stream = File.Create(filename);
            JsonSerializer.Serialize(stream, items);
            stream.Close();
            status = true;
            return status;
        }
        public List<T> Deserialize(string filename)
        {
            List<T> items = new List<T>();
            FileStream stream = new FileStream(filename, FileMode.Open);
            if (stream != null)
            {
                items = JsonSerializer.Deserialize<List<T>>(stream);
            }
            stream.Close();
            return items;
        }
    }

}