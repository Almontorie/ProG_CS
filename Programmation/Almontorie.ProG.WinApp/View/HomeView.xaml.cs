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
using Almontorie.ProG.Service;
using System.ComponentModel;
using Almontorie.ProG.WinApp.View.Home;
using System.Data.SqlClient;

namespace Almontorie.ProG.WinApp.View
{
    /// <summary>
    /// Logique d'interaction pour HomeView.xaml
    /// </summary>
    public partial class HomeView : Window, INotifyPropertyChanged
    {
        private readonly IService _serv;

        public Library MyLibrary { get; set; }

        public Song MySong { get; set; }


        public HomeView()
        {
            InitializeComponent();
            DataContext = this;

            _serv = new XmlService();

            MyLibrary = _serv.LoadLibrary();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Song selectedItem;
        public Song SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; OnPropertyChanged(nameof(SelectedItem)); }
        }

        public AddSongWindow AddSongWindow { get; set; }

        /// <summary>
        /// Instancie et ouvre une AddSongWindow
        /// Un fois AddSongWindow fermée ajoute une musique à la librairie si son nom a été renseigné dans AddSongWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddSongWindow = new AddSongWindow();
            AddSongWindow.ShowDialog();

            if(AddSongWindow.Name != null)
                MyLibrary.AddSong(AddSongWindow.SaveSong);
        }

        /// <summary>
        /// Instancie un XmlService et sérialise le contenu de la librairie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            IService serv = new XmlService();
            serv.SaveLibrary(MyLibrary);
        }
    }
}
