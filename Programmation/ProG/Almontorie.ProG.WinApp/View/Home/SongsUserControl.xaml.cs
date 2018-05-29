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
using Almontorie.ProG.Model;
namespace Almontorie.ProG.WinApp.View.Home
{
    /// <summary>
    /// Logique d'interaction pour SongsUserControl.xaml
    /// </summary>
    public partial class SongsUserControl : UserControl
    {
        public SongsUserControl()
        {
            InitializeComponent();
        }
        static SongsUserControl()
        {
            LibraryProperty = DependencyProperty.Register("Library", typeof(Library), typeof(SongsUserControl));
        }

        public static readonly DependencyProperty LibraryProperty;

        public Library Library
        {
            get
            {
                return GetValue(SongsUserControl.LibraryProperty) as Library;
            }
            set
            {
                SetValue(SongsUserControl.LibraryProperty, value);
            }
        }
    }

}
