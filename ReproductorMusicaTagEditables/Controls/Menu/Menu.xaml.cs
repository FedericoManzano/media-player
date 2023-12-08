
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReproductorMusicaTagEditables.Controls.Menu
{
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CommandInicioProperty =
            DependencyProperty.Register("CommandInicio", typeof(ICommand), typeof(Menu));

        public ICommand CommandInicio
        {
            get => (ICommand)GetValue(CommandInicioProperty); 
            set => SetValue(CommandInicioProperty, value);
        }


        public static readonly DependencyProperty CommandArtistasProperty =
            DependencyProperty.Register("CommandArtistas", typeof(ICommand), typeof(Menu));

        public ICommand CommandArtistas
        {
            get => (ICommand)GetValue(CommandArtistasProperty);
            set => SetValue(CommandArtistasProperty, value);
        }

        public static readonly DependencyProperty CommandAlbumesProperty =
            DependencyProperty.Register("CommandAlbumes", typeof(ICommand), typeof(Menu));

        public ICommand CommandAlbumes
        {
            get => (ICommand)GetValue(CommandAlbumesProperty);
            set => SetValue(CommandAlbumesProperty, value);
        }


        public static readonly DependencyProperty CommandGenerosProperty =
            DependencyProperty.Register("CommandGeneros", typeof(ICommand), typeof(Menu));

        public ICommand CommandGeneros
        {
            get => (ICommand)GetValue(CommandGenerosProperty);
            set => SetValue(CommandGenerosProperty, value);
        }

        public static readonly DependencyProperty CommandListasProperty =
            DependencyProperty.Register("CommandListas", typeof(ICommand), typeof(Menu));

        public ICommand CommandListas
        {
            get => (ICommand)GetValue(CommandListasProperty);
            set => SetValue(CommandListasProperty, value);
        }

        public static readonly DependencyProperty CommandFavoritosProperty =
            DependencyProperty.Register("CommandFavoritos", typeof(ICommand), typeof(Menu));

        public ICommand CommandFavoritos
        {
            get => (ICommand)GetValue(CommandFavoritosProperty);
            set => SetValue(CommandFavoritosProperty, value);
        }


        public static readonly DependencyProperty CommandDescargasProperty =
            DependencyProperty.Register("CommandDescargas", typeof(ICommand), typeof(Menu));

        public ICommand CommandDescargas
        {
            get => (ICommand)GetValue(CommandDescargasProperty);
            set => SetValue(CommandDescargasProperty, value);
        }


        public static readonly DependencyProperty CommandHistorialProperty =
            DependencyProperty.Register("CommandHistorial", typeof(ICommand), typeof(Menu));

        public ICommand CommandHistorial
        {
            get => (ICommand)GetValue(CommandHistorialProperty);
            set => SetValue(CommandHistorialProperty, value);
        }

        public static RoutedEvent DocClickEvent =
            EventManager.RegisterRoutedEvent("DocClick", RoutingStrategy.Bubble, typeof(EventHandler), typeof(Menu));

        public event EventHandler DocClick
        {
            add => AddHandler(DocClickEvent, value);
            remove => RemoveHandler(DocClickEvent, value);
        }

        public void OnClickDoc(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(DocClickEvent));
        }
    }
}
