using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Almontorie.ProG.Model
{

    [DataContract(IsReference = true, Name = "playlist")]
    public class Playlist 
    {
        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public Time Length { get; private set; }

        [DataMember (EmitDefaultValue = false)]
        public List<Song> ListSong { get; private set; }

        /// <summary>
        /// Consructeur
        /// </summary>
        /// <param name="name"></param>
        public Playlist(string name)
        {
            if (name == null)
                throw new ArgumentNullException("Le nom de la playlist est nul");
            Name = name;
            Length = new Time();
            ListSong = new List<Song>();
        }

        /// <summary>
        /// Ajoute une musique passée en paramètre à la playlist.
        /// </summary>
        /// <param name="Track"></param>
        public void AddSong(Song Track)
        {
            ListSong.Add(Track);
            Length = Length.Addition(Track.Length);
        }

        /// <summary>
        /// Supprime une musique passée en paramètre de la playlist.
        /// </summary>
        /// <param name="Track"></param>
        public void DeleteSong(Song Track)
        {
            ListSong.Remove(Track);
            Length = Length.Substraction(Track.Length);
        }

        /// <summary>
        /// Redéfinition de ToString()
        /// </summary>
        /// <returns>
        /// string contenant le nom de la playlist et sa durée
        /// </returns>
        public override string ToString()
        {
            return Name+" ("+Length+")";
        }

        /// <summary>
        /// Deux playlists sont identiques si leurs noms sont identiques.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// bool :
        ///     Si égales : true
        ///     Sinon : false
        /// </returns>
        public override bool Equals(object obj)
        {
            var playlist = obj as Playlist;
            return playlist != null &&
                   Name == playlist.Name;
        }

        /// <summary>
        /// HashCode calculé avec la propiété Name
        /// </summary>
        /// <returns>
        /// int : valeur de hashCode 
        /// </returns>
        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
