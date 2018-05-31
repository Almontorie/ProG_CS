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

        /// <summary>
        /// Constructeur
        /// </summary>
        public Library()
        {
            ListSong = new ObservableCollection<Song>();
            ListArtist = new List<Artist>();
            ListAlbum = new List<Album>();
            ListPlaylist = new List<Playlist>();
            Length = new Time();
        }

        /// <summary>
        /// Ajoute la musique passée en paramètre à la librarie sauf si elle est déjà présente.
        /// Appelle "AddArtist" si l'artiste n'est pas déjà présent dans la librairie.
        /// Appelle "AddSong" de l'artiste saisie.
        /// Si un album a été saisie,
        ///     appelle "AddAlbum" si l'album n'est pas déjà présent dans la librairie.
        ///     appelle "AddSong" de l'album saisie.
        /// </summary>
        /// <param name="Track"></param>
        public void AddSong(Song Track)
        {
            if (Track == null)
                return;

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

        /// <summary>
        /// Supprime la musique passée en paramètre de la toute la librarie sauf si elle n'est pas présente dedans.
        /// </summary>
        /// <param name="Track"></param>
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

        /// <summary>
        /// Ajoute un album passée en paramètre à la liste des albums.
        /// </summary>
        /// <param name="Album"></param>
        private void AddAlbum(Album Album)
        {
            ListAlbum.Add(Album);
        }

        /// <summary>
        /// Supprime un album passée en paramètre de la liste des albums.
        /// </summary>
        /// <param name="Album"></param>
        public void DeleteAlbum(Album Album)
        {
            Album.ListSong.Clear();
            ListAlbum.Remove(Album);
        }

        /// <summary>
        /// Ajoute un artiste passée en paramètre à la liste des artistes.
        /// </summary>
        /// <param name="Artist"></param>
        private void AddArtist(Artist Artist)
        {
            ListArtist.Add(Artist);
        }

        /// <summary>
        /// Supprime un artiste passée en paramètre de la liste des artistes.
        /// </summary>
        /// <param name="Artist"></param>
        private void DeleteArtist(Artist Artist)
        {
            ListArtist.Remove(Artist);
        }

        /// <summary>
        /// Ajoute une playlist passée en paramètre à la liste des playlists.
        /// </summary>
        /// <param name="TrackList"></param>
        public void AddPlaylist(Playlist TrackList)
        {
            if (ListPlaylist.Contains(TrackList))
            {
                Console.WriteLine("Cette playlist existe déjà");
                return;
            }
            ListPlaylist.Add(TrackList);
        }

        /// <summary>
        /// Supprime une playlist passée en paramètre de la liste des playlists.
        /// </summary>
        /// <param name="TrackList"></param>
        public void DeletePlaylist(Playlist TrackList)
        {
            TrackList.ListSong.Clear();
            ListPlaylist.Remove(TrackList);
        }

        

    }
}
