using Almontorie.ProG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almontorie.ProG.Service
{
    public interface IService
    {
        /// <summary>
        /// Serialise une Library
        /// </summary>
        /// <param name="myLibrary"></param>
        void SaveLibrary(Library myLibrary);

        /// <summary>
        /// Déserialise une Library
        /// </summary>
        /// <returns>
        /// Library
        /// </returns>
        Library LoadLibrary();
    }
}
