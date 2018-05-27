using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Almontorie.ProG.Model
{
    [DataContract (Name = "library")]
    public class Library
    {
        [DataMember(EmitDefaultValue = false)]
        public ObservableCollection<Song> ListSong { get; private set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Artist> ListArtist  { get; private set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Album> ListAlbum { get; private set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Playlist> ListPlaylist { get; private set; }

        [DataMember(EmitDefaultValue = false)]
        public Time Length { get; private set; }

        public Library()
        {
            ListSong = new ObservableCollection<Song>();
            ListArtist = new List<Artist>();
            ListAlbum = new List<Album>();
            ListPlaylist = new List<Playlist>();
            Length = new Time();
        }

        public void AddSong(Song Track)
        {
            if (ListSong.Contains(Track))
            {
                Console.WriteLine("Cette musique est déjà présente dans la librarie");
                return;
            }
            ListSong.Add(Track);
            Length = Length.Addition(Track.Length);

            if (!ListArtist.Contains(Track.Artist))
                AddArtist(Track.Artist);
            ListArtist[ListArtist.IndexOf(Track.Artist)].AddSong(Track);

            if (Track.Album.Name != "Unknown")
            {
                if (!ListAlbum.Contains(Track.Album))
                    AddAlbum(Track.Album);
                ListAlbum[ListAlbum.IndexOf(Track.Album)].AddSong(Track);
            }
        }

        public void DeleteSong(Song Track)
        {
            ListSong.Remove(Track);
            Length = Length.Substraction(Track.Length);

            if (Track.Album.Name != "Unknown")
            {
                int i;
                i = ListAlbum.IndexOf(Track.Album);
                ListAlbum[i].DeleteSong(Track);

                if (ListAlbum[i].ListSong.Count() == 0)
                    DeleteAlbum(ListAlbum[i]);
            }

            foreach (var playlist in ListPlaylist)
            {
                if (playlist.ListSong.Contains(Track))
                    playlist.DeleteSong(Track);
            }

            int it;
            it = ListArtist.IndexOf(Track.Artist);
            ListArtist[it].DeleteSong(Track);
            if (ListArtist[it].ListSong.Count == 0)
                DeleteArtist(Track.Artist);

        }

        private void AddAlbum(Album Album)
        {
            ListAlbum.Add(Album);
        }

        public void DeleteAlbum(Album Album)
        {
            Album.ListSong.Clear();
            ListAlbum.Remove(Album);
        }

        private void AddArtist(Artist Artist)
        {
            ListArtist.Add(Artist);
        }

        private void DeleteArtist(Artist Artist)
        {
            ListArtist.Remove(Artist);
        }

        public void AddPlaylist(Playlist TrackList)
        {
            if (ListPlaylist.Contains(TrackList))
            {
                Console.WriteLine("Cette playlist existe déjà");
                return;
            }
            ListPlaylist.Add(TrackList);
        }

        public void DeletePlaylist(Playlist TrackList)
        {
            TrackList.ListSong.Clear();
            ListPlaylist.Remove(TrackList);
        }

        

    }
}
