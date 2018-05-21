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
        {   /*
            Artist artist = new Artist("Lulu", new Date(16, 04, 1999));
            Playlist p = new Playlist("Le gros son");
            Album a = new Album("Album", artist, new Date(12, 12, 2012));
            */

            

            ConsoleView c = new ConsoleView();
            LibraryController lc = new LibraryController(c);

            lc.Menu();

            //c.DisplayObject(s);
            /*
            c.DisplayObject(artist);
            c.DisplayObject(p);
            c.DisplayObject(a);
            */

        }
    }
}
