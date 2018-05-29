using Almontorie.ProG.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almontorie.ProG.Model;

namespace Almontorie.ProG.ConsoleApp
{
    public class ConsoleView : IView
    {
        /*
        public void DisplayAlbum(Album a)
        {
            Console.WriteLine(a);
        }

        public void DisplayArtist(Artist a)
        {
            Console.WriteLine(a);
        }
        
        public void DisplayPlaylist(Playlist p)
        {
            Console.WriteLine(p);
        }

        public void DisplaySong(Song s)
        {
            Console.WriteLine(s);
        }

        */


        public void DisplaySongOfAlbum(Album a)
        {
            DisplayObject(a);
            foreach (var s in a.ListSong)
            {
                Console.WriteLine("\t" + s);
            }
        }

        public void DisplaySongOfArtist(Artist a)
        {
            DisplayObject(a);
            foreach (var s in a.ListSong)
            {
                Console.WriteLine("\t" + s);
            }
        }

        public void DisplaySongOfPlaylist(Playlist p)
        {
            int i = 1;
            DisplayObject(p);
            foreach (var s in p.ListSong)
            {
                Console.WriteLine("\t"+i+" : " + s);
                i++;
            }
        }

        public void DisplayObject(object o)
        {
            Console.WriteLine(o);
        }

        public void DisplayArtist(Artist a)
        {
            Console.WriteLine(a + " né(e) le : " + a.Birthday);
        }

        public Song AskForSong()
        {
            Console.WriteLine("Nom de la musique : ");
            string name = Console.ReadLine();


            Time t = AskForTime();


            Console.WriteLine("Voulez-vous saisir un nom d'artiste ? (o/n)");
            var testArtist = Console.ReadLine();

            if(testArtist == "o")
            {
                Artist arti = AskForArtist();

                Console.WriteLine("Voulez-vous saisir un nom d'album ? (o/n)");
                var testAlbum = Console.ReadLine();

                if (testAlbum == "o")
                {
                    Album album = AskForAlbum(arti);
                    return new Song(name, arti, t, album);            
                }

                return new Song(name, arti, t);
            }

            return new Song(name, t);
        }

        public Time AskForTime()
        {
            bool exit = true;
            int hour, min, sec;

            do
            {
                exit = true;
                Console.WriteLine("Durée : ");
                Console.WriteLine("Heures : ");
                hour = AskForNumber();

                Console.WriteLine("Minutes : ");
                min = AskForNumber();

                Console.WriteLine("Secondes : ");
                sec = AskForNumber();

                try
                {
                    Time t = new Time(hour, min, sec);
                }
                catch(ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e);
                    exit = false;
                }


            } while (!exit);

            return new Time(hour, min, sec);
        }

        public Artist AskForArtist()
        {
            Console.WriteLine("Nom de l'artiste : ");
            string nameArti = Console.ReadLine();

            Console.WriteLine("Voulez-vous saisir une date de naissance ? (o/n) ");
            string test = Console.ReadLine();

            if (test == "o")
            {
                Date d = AskForDate();
                return new Artist(nameArti, d);
            }

            return new Artist(nameArti);
        }

        public Date AskForDate()
        {
            bool exit = true;
            int day, month, year;

            do
            {
                exit = true;
                Console.WriteLine("Date : ");
                Console.WriteLine("Jour : ");
                day = AskForNumber();

                Console.WriteLine("Mois : ");
                month = AskForNumber();

                Console.WriteLine("Année : ");
                year = AskForNumber();

                try
                {
                    Date d = new Date(day, month, year);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e);
                    exit = false;
                }


            } while (!exit);

            return new Date(day, month, year);

            
        }

        public Album AskForAlbum(Artist arti)
        {
            Console.WriteLine("Nom de l'album : ");
            var nameAlbum = Console.ReadLine();

            Console.WriteLine("Voulez-vous saisir une date de sortie ? (o/n) ");
            var test = Console.ReadLine();

            if(test == "o")
            {
                Date d = AskForDate();
                return new Album(nameAlbum, arti, d);
            }

            return new Album(nameAlbum, arti);
        }

        public Playlist AskForPlaylist()
        {
            Console.WriteLine("Nom de la Playlist :");
            string name = Console.ReadLine();

            return new Playlist(name);
        }

        public int AskForNumber()
        {
            int number;
            bool valid = false;

            do
            {
            var input = Console.ReadLine();
                if (!int.TryParse(input, out number))
                {
                    Console.WriteLine(input + " est incorrect");
                    Console.WriteLine("Retapez le nombre");
                }
                else
                    valid = true;
            } while (!valid);

            return number;
        }

        public void DisplayText(string text)
        {
            Console.WriteLine(text);
        }

        public void DisplayListOfArtist(Library l)
        {
            int i = 1;
            foreach (var artist in l.ListArtist)
            {
                Console.WriteLine(i+" : "+artist);
                i++;
            }
        }

        public void DisplayListOfSong(Library l)
        {
            int i = 1;
            foreach (var song in l.ListSong)
            {
                Console.WriteLine(i+" : "+song);
                i++;
            }
        }

        public void DisplayListOfPlaylist(Library l)
        {
            int i = 1;
            foreach (var playlist in l.ListPlaylist)
            {
                Console.WriteLine(i+" : "+playlist);
                i++;
            }
        }

        public void DisplayListOfAlbum(Library l)
        {
            int i = 1;
            foreach (var album in l.ListAlbum)
            {
                Console.WriteLine(i+" : "+album);
                i++;
            }
        }
    }
}
