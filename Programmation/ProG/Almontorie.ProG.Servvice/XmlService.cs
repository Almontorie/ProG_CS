using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almontorie.ProG.Model;
using System.Runtime.Serialization;
using System.IO;

namespace Almontorie.ProG.Service
{
    public class XmlService : IService
    {
        public Library LoadLibrary()
        {
            //Directory.SetCurrentDirectory(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName));
            string xmlFile = "save.xml";

            var serializer = new DataContractSerializer(typeof(Library));
            Library myLibrary;

            try
            {
                using (Stream s = File.OpenRead(xmlFile))
                {
                    myLibrary = serializer.ReadObject(s) as Library;
                }
        }
            catch (Exception)
            {
                return new Library();
            }

            return myLibrary;
        }

        public void SaveLibrary(Library myLibrary)
        {
            //Directory.SetCurrentDirectory(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName));
            string xmlFile = "save.xml";

            var serializer = new DataContractSerializer(typeof(Library));

            using (Stream s = File.Create(xmlFile))
            {
                serializer.WriteObject(s, myLibrary);
            }
        }
    }
}
