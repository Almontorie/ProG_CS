using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
    
    

namespace Almontorie.ProG.Model
{

    [DataContract (IsReference = true, Name = "artist")]
    public class Artist 
    {

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public Date Birthday { get; private set; }

        [DataMember (EmitDefaultValue = false)]
        public List<Song> ListSong { get; private set; }
        
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Birthday"></param>
        public Artist(string Name, Date Birthday)
        {
            if (Name == null || Birthday == null)
                throw new ArgumentNullException("Le nom ou la date de naissance de l'artiste est nul");
            this.Name = Name;
            this.Birthday = Birthday;
            ListSong = new List<Song>();
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="Name"></param>
        public Artist(string Name) :this(Name, new Date())
        {
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public Artist() : this("Unknown")
        {
        }

        /// <summary>
        /// Ajoute la musique passée en paramètre à la liste de musique appartenant à l'artiste
        /// </summary>
        /// <param name="Track"></param>
        public void AddSong(Song Track)
        {
            ListSong.Add(Track);
        }

        /// <summary>
        /// Supprime la musique passée en paramètre de la liste de musique appartenant à l'artiste
        /// </summary>
        /// <param name="Track"></param>
        public void DeleteSong(Song Track)
        {
            ListSong.Remove(Track);
        }

        /// <summary>
        /// Redéfinition de ToString()
        /// </summary>
        /// <returns>
        /// string contenant le nom de l'artiste
        /// </returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Deux artistes sont identiques quand leurs noms et leurs dates de naissance sont identiques
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// bool :
        ///     Si égaux : true
        ///     Sinon : false
        /// </returns>
        public override bool Equals(object obj)
        {
            var artist = obj as Artist;
            return artist != null &&
                   Name == artist.Name &&
                   EqualityComparer<Date>.Default.Equals(Birthday, artist.Birthday);
        }

        /// <summary>
        /// HashCode calculé avec les propriétes Name et Birthday
        /// </summary>
        /// <returns>
        /// int : valeur de hashCode
        /// </returns>
        public override int GetHashCode()
        {
            var hashCode = -512614078;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Date>.Default.GetHashCode(Birthday);
            return hashCode;
        }
    }
}
