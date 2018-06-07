using System;
using Almontorie.ProG.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almontorie.ProG.Controller;

namespace Almontorie.ProG.ConsoleApp   
{
    class Program
    {
        static void Main(string[] args)
        {   
            ConsoleView c = new ConsoleView();
            LibraryController lc = new LibraryController(c);

            lc.Menu();
        }
    }
}
