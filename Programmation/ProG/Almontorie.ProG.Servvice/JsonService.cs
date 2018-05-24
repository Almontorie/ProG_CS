using Almontorie.ProG.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almontorie.ProG.Model;
using System.IO;
using Newtonsoft.Json;

namespace Almontorie.ProG.Service
{
    public class JsonService : IService
    {
        public Library LoadLibrary()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "save.json");
            Uri u = new Uri(path);
            string content;
            try
            {
                content = File.ReadAllText(path);
                
            }
            catch (FileNotFoundException)
            {
                return new Library();
            }

            Library l = JsonConvert.DeserializeObject<Library>(content);

            return l;
        }

        public void SaveLibrary(Library myLibrary)
        {
            using (StreamWriter sw = File.CreateText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "save.json")))
            {
                JsonConvert.SerializeObject(myLibrary);
            }
                
        }
    }

}

