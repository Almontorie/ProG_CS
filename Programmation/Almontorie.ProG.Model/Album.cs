using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Almontorie.ProG.Model
{
    [DataContract(IsReference = true, Name = "album")]
    public class Album 
    {
        [DataMember]
        public String Name { get; private set; }

        [DataMember]
        public Artist Artist { get; private set; }

        [DataMember]
        public Date ReleaseDate { get; private set; }

        [DataMember]
        public Time Length { get; private set; }

        [DataMember (EmitDefaultValue = false)]
        public List<Song> ListSong { get; private set; }


        public Album(string Name, Artist Artist, Date ReleaseDate)
        {
            if(Name == null || Artist == null || ReleaseDate == null)
                throw new ArgumentNullException("Le nom, l'artiste ou la date de sortie de l'album est nul");
            this.Name = Name;
            this.Artist = Artist;
            this.ReleaseDate = ReleaseDate;
            ListSong = new List<Song>();
            Length = new Time();
        } 

        public Album(string Name, Artist Artist) :this(Name,Artist,new Date())
        {
        }

        public Album(string Name, Date ReleaseDate) :this(Name, new Artist(), ReleaseDate)
        {
        }

        public Album(string Name) :this(Name,new Date())
        {
        }

        public Album() : this("Unknown")
        {
        }

        /// <summary>
        /// Ajoute la musique passée en paramètre à l'album
        /// </summary>
        /// <param name="Track"></param>
        internal void AddSong(Song Track)
        {
            ListSong.Add(Track);
            Length = Length.Addition(Track.Length);
        }

        /// <summary>
        /// Suprime la musique passée en paramètre de l'album
        /// </summary>
        /// <param name="Track"></param>
        internal void DeleteSong(Song Track)
        {
            ListSong.Remove(Track);
            Length = Length.Substraction(Track.Length);
        }
        

        public override string ToString()
        {
            return Name + " de " + Artist + " sorti le : " + ReleaseDate + " (" + Length + ")";
        }

        /// <summary>
        /// Deux albums sont identiques quand leurs noms et leurs artistes sont identiques
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var album = obj as Album;
            return album != null &&
                   Name == album.Name &&
                   EqualityComparer<Artist>.Default.Equals(Artist, album.Artist);
        }

        public override int GetHashCode()
        {
            var hashCode = 88401470;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Artist>.Default.GetHashCode(Artist);
            return hashCode;
        }
    }
}
