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

namespace Almontorie.ProG.WinApp.View
{
    /// <summary>
    /// Logique d'interaction pour HomeView.xaml
    /// </summary>
    public partial class HomeView : Window
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

            MySong = MyLibrary.ListSong[0];


        }
    }
}
