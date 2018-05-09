using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almontorie.ProG.Model
{
    public class Playlist 
    {
        public string Name { get; private set; }
        public Time Length { get; private set; }
        public List<Song> ListSong { get; private set; }

        public Playlist(string name)
        {
            if (name == null)
                throw new ArgumentNullException("Le nom de la playlist est nul");
            Name = name;
            Length = new Time();
            ListSong = new List<Song>();
        }

        public void AddSong(Song Track)
        {
            ListSong.Add(Track);
            Length = Length.Addition(Track.Length);
        }

        public void DeleteSong(Song Track)
        {
            ListSong.Remove(Track);
            Length = Length.Substraction(Track.Length);
        }

        public override string ToString()
        {
            return Name+" ("+Length+")";
        }

        public override bool Equals(object obj)
        {
            var playlist = obj as Playlist;
            return playlist != null &&
                   Name == playlist.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
