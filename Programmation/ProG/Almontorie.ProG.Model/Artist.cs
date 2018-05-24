using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
    
    

namespace Almontorie.ProG.Model
{

    [DataContract (Name = "artist")]
    public class Artist 
    {

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public Date Birthday { get; private set; }

        [DataMember (EmitDefaultValue = false)]
        public List<Song> ListSong { get; private set; }
        
        public Artist(string Name, Date Birthday)
        {
            if (Name == null || Birthday == null)
                throw new ArgumentNullException("Le nom ou la date de naissance de l'artiste est nul");
            this.Name = Name;
            this.Birthday = Birthday;
            ListSong = new List<Song>();
        }

        public Artist(string Name) :this(Name, new Date())
        {
        }

        public Artist() : this("Unknown")
        {
        }


        public void AddSong(Song Track)
        {
            ListSong.Add(Track);
        }

        public void DeleteSong(Song Track)
        {
            ListSong.Remove(Track);
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            var artist = obj as Artist;
            return artist != null &&
                   Name == artist.Name &&
                   EqualityComparer<Date>.Default.Equals(Birthday, artist.Birthday);
        }

        public override int GetHashCode()
        {
            var hashCode = -512614078;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Date>.Default.GetHashCode(Birthday);
            return hashCode;
        }
    }
}
