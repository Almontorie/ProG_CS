using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Almontorie.ProG.Model
{
    [DataContract(IsReference = true, Name = "song")]
    public class Song 
    {
        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public Artist Artist { get; private set; }

        [DataMember]
        public Time Length { get; private set; }

        [DataMember]
        public Album Album { get; private set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="name"></param>
        /// <param name="artist"></param>
        /// <param name="length"></param>
        /// <param name="album"></param>
        public Song(string name, Artist artist, Time length, Album album)
        {
            Name = name;
            Artist = artist;
            Length = length;
            Album = album;
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="name"></param>
        /// <param name="artist"></param>
        /// <param name="length"></param>
        public Song(string name, Artist artist, Time length) :this(name, artist, length, new Album())
        {
        }

        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="length"></param>
        public Song(string name, Time length) :this(name, new Artist(), length)
        {
        }

        /// <summary>
        /// Redefinition de ToString()
        /// </summary>
        /// <returns>
        /// string contenant le nom de la musique, son artiste et sa durée
        /// </returns>
        public override string ToString()
        {
            return Name+" de "+Artist+" ("+Length+")";
        }

        /// <summary>
        /// Deux musiques sont identiques si leurs noms et leurs artistes sont identiques.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// bool : 
        ///     Si égaux : true
        ///     Sinon  false
        /// </returns>
        public override bool Equals(object obj)
        {
            var song = obj as Song;
            return song != null &&
                   Name == song.Name &&
                   EqualityComparer<Artist>.Default.Equals(Artist, song.Artist);
        }

        /// <summary>
        /// HashCode calculé avec les propriétés Name et Artist
        /// </summary>
        /// <returns>
        /// int : valeur de hashCode
        /// </returns>
        public override int GetHashCode()
        {
            var hashCode = -1265090060;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Artist>.Default.GetHashCode(Artist);
            return hashCode;
        }
    }
}
