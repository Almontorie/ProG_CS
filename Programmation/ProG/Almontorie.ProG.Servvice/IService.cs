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
        void SaveLibrary(Library myLibrary);

        Library LoadLibrary();
    }
}
