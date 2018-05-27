using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almontorie.ProG.Model
{
    public class Library
    {
        private List<Song> ListSong;
        public Time Length { get; private set; }

        public Library()
        {
            ListSong = new List<Song>();
            Length = new Time();
        }

        public void AddSong(Song Track)
        {
        }

        public void DeleteSong(Song Track)
        {
        }

        public void AddAlbum(Album Album)
        {
        }

        public void DeleteAlbum(Album Album)
        {
        }

        public override string ToString()
        {
            return null;
        }
    }
}
