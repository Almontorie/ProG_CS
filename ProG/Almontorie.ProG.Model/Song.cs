using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almontorie.ProG.Model
{
    public class Song 
    {
        public string Name { get; private set; }
        public Artist Artist { get; private set; }
        public Time Length { get; private set; }
        public Album Album { get; private set; }

        public Song(string name, Artist artist, Time length, Album album)
        {
            Name = name;
            Artist = artist;
            Length = length;
            Album = album;
        }

        public Song(string name, Artist artist, Time length) :this(name, artist, length, new Album())
        {
        }

        public Song(string name, Time length) :this(name, new Artist(), length)
        {
        }

        public override string ToString()
        {
            return Name+" de "+Artist+" ("+Length+")";
        }

        public override bool Equals(object obj)
        {
            var song = obj as Song;
            return song != null &&
                   Name == song.Name &&
                   EqualityComparer<Artist>.Default.Equals(Artist, song.Artist);
        }

        public override int GetHashCode()
        {
            var hashCode = -1265090060;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Artist>.Default.GetHashCode(Artist);
            return hashCode;
        }
    }
}
