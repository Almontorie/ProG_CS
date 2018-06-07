using Almontorie.ProG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Almontorie.ProG.WinApp.View.Home
{
    /// <summary>
    /// Logique d'interaction pour AddSongWindow.xaml
    /// </summary>
    public partial class AddSongWindow : Window
    {

        #region Properties

        public string SongName { get;  set; }


        public string NameArtist { get;  set; }
        public int DayArtist { get;  set; }
        public int MonthArtist { get;  set; }
        public int YearArtist { get;  set; }


        public string NameAlbum { get;  set; }
        public int DayAlbum { get;  set; }
        public int MonthAlbum { get;  set; }
        public int YearAlbum { get;  set; }


        public int Sec { get;  set; }
        public int Min { get;  set; }
        public int Hour { get;  set; }

        public Song SaveSong { get; private set; }

        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        public AddSongWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="song"></param>
        public AddSongWindow(Song song)
        {
            InitializeComponent();
            DataContext = this;

            SongName = song.Name;

            NameArtist = song.Artist.Name;
            DayArtist = song.Artist.Birthday.Day;
            MonthArtist = song.Artist.Birthday.Month;
            YearArtist = song.Artist.Birthday.Year;

            NameAlbum = song.Album.Name;
            DayAlbum = song.Album.ReleaseDate.Day;
            MonthAlbum = song.Album.ReleaseDate.Month;
            YearAlbum = song.Album.ReleaseDate.Year;

            Sec = song.Length.Second;
            Min = song.Length.Min;
            Hour = song.Length.Hour;
        }

        /// <summary>
        /// Si le champ "Nom :" est renseignée :
        ///     Instancie un Song et ferme la fenêtre 
        /// Sinon ne fait rien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)

        {
           Artist arti; 

            if(SongName == null || SongName == "")
            {
                return;
            }

            Time length = new Time(Hour, Min, Sec);
            if (NameArtist != null)
            {   
                if (DayArtist != 0 && MonthArtist != 0 && YearArtist != 0)
                {
                    arti = new Artist(NameArtist, new Date(DayArtist, MonthArtist, YearArtist));
                }
                else
                {
                    arti = new Artist(NameArtist, new Date());
                }
                if (NameAlbum != null)
                {
                    if (DayAlbum != 0 && MonthAlbum != 0 && YearAlbum != 0)
                    {
                        Album alb = new Album(NameAlbum, arti, new Date(DayAlbum, MonthAlbum, YearAlbum));
                        SaveSong = new Song(SongName, arti, length, alb);
                    }
                    else
                    {
                        Album alb2 = new Album(NameAlbum, arti);
                        SaveSong = new Song(SongName, arti, length, alb2);
                    }
                }
                else
                {
                    SaveSong = new Song(SongName, arti, length);
                }
            }
            else
            {
                SaveSong = new Song(SongName, length);
            }

            Close();

        }
    }
}