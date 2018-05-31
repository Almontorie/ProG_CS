using System;
using Almontorie.ProG.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almontorie.ProG.View
{
    public interface IView
    {
        void DisplayObject(object o);

        void DisplayArtist(Artist a);

        void DisplaySongOfPlaylist(Playlist p);

        void DisplaySongOfAlbum(Album a);

        void DisplaySongOfArtist(Artist a);

        Song AskForSong();

        Time AskForTime();
        Artist AskForArtist();

        Date AskForDate();

        Album AskForAlbum(Artist arti);

        Playlist AskForPlaylist();

        int AskForNumber();

        void DisplayText(string text);

        void DisplayListOfArtist(Library l);

        void DisplayListOfSong(Library l);

        void DisplayListOfPlaylist(Library l);

        void DisplayListOfAlbum(Library l);
        
    }
}
