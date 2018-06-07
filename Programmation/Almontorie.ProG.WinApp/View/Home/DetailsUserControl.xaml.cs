using Almontorie.ProG.Model;
using Almontorie.ProG.Service;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Almontorie.ProG.WinApp.View.Home
{
    /// <summary>
    /// Logique d'interaction pour DetailsUserControl.xaml
    /// </summary>
    public partial class DetailsUserControl : UserControl
    {
        public DetailsUserControl()
        {
            InitializeComponent();
        }

        static DetailsUserControl()
        {
            SongProperty = DependencyProperty.Register("Song", typeof(Song), typeof(DetailsUserControl));
            LibraryProperty = DependencyProperty.Register("Library", typeof(Library), typeof(DetailsUserControl));
        }

        public static readonly DependencyProperty SongProperty;
        public static readonly DependencyProperty LibraryProperty;

        public Library Library
        {
            get
            {
                return GetValue(DetailsUserControl.LibraryProperty) as Library;
            }
            set
            {
                SetValue(DetailsUserControl.LibraryProperty, value);
            }
        }

        public Song Song
        {
            get
            {
                return GetValue(DetailsUserControl.SongProperty) as Song;
            }
            set
            {
                SetValue(DetailsUserControl.SongProperty, value);
            }
        }

        public AddSongWindow AddSongWindow { get; set; }

        /// <summary>
        /// Si une musique est sélectionée, la supprime de la library
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if(Song != null)
                Library.DeleteSong(Song);
        }

        /// <summary>
        /// Instancie est ouvre une AddSongWindow
        /// Supprime la musique sélécttionnée et la remplace par celle qui est modifiée si le champ "Nom :" de AddSongWindow est renseigné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mButtonModify_Click(object sender, RoutedEventArgs e)
        {
            if (Song == null)
                return;

            AddSongWindow = new AddSongWindow(Song);
            AddSongWindow.ShowDialog();

            if (AddSongWindow.SaveSong != null)
            {
                Library.DeleteSong(Song);
                Library.AddSong(AddSongWindow.SaveSong);
            }
        }
    }
}
