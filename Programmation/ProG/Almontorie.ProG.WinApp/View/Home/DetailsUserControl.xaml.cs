﻿using Almontorie.ProG.Model;
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
        }

        public static readonly DependencyProperty SongProperty;

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

    }
}
