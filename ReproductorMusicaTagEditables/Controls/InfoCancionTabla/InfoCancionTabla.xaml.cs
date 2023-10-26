using System;
using System.Windows;
using System.Windows.Controls;


namespace ReproductorMusicaTagEditables.Controls.InfoCancionTabla
{
    public partial class InfoCancionTabla : UserControl
    {
        public InfoCancionTabla()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent PlayClickEvent =
            EventManager.RegisterRoutedEvent("PlayClick", RoutingStrategy.Bubble,typeof(EventHandler), typeof(InfoCancionTabla));
    
        public event EventHandler PlayClick
        {
            add => AddHandler(PlayClickEvent, value);
            remove => RemoveHandler(PlayClickEvent, value);
        }

        public void OnPlayClick (object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(PlayClickEvent));
        }



        public static readonly RoutedEvent AritstaClickEvent =
            EventManager.RegisterRoutedEvent("ArtistaClick", RoutingStrategy.Bubble, typeof(EventHandler), typeof(InfoCancionTabla));

        public event EventHandler ArtistaClick
        {
            add => AddHandler(AritstaClickEvent, value);
            remove => RemoveHandler(AritstaClickEvent, value);
        }

        public void OnArtistaClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(AritstaClickEvent));
        }

        public static readonly RoutedEvent AlbumClickEvent =
            EventManager.RegisterRoutedEvent("AlbumClick", RoutingStrategy.Bubble, typeof(EventHandler), typeof(InfoCancionTabla));

        public event EventHandler AlbumClick
        {
            add => AddHandler(AlbumClickEvent, value);
            remove => RemoveHandler(AlbumClickEvent, value);
        }

        public void OnAlbumClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(AlbumClickEvent));
        }


        public static readonly DependencyProperty TituloProperty =
            DependencyProperty.Register("TituloInfo", typeof(string), typeof(InfoCancionTabla), new PropertyMetadata(string.Empty) );

        public string TituloInfo
        {
            get => GetValue(TituloProperty) as string;
            set => SetValue(TituloProperty, value);
        }



        public static readonly DependencyProperty ArtistaProperty =
            DependencyProperty.Register("ArtistaInfo", typeof(string), typeof(InfoCancionTabla), new PropertyMetadata(string.Empty));

        public string ArtistaInfo
        {
            get => GetValue(ArtistaProperty) as string;
            set => SetValue(ArtistaProperty, value);
        }

        public static readonly DependencyProperty AlbumProperty =
              DependencyProperty.Register("AlbumInfo", typeof(string), typeof(InfoCancionTabla), new PropertyMetadata(string.Empty));

        public string AlbumInfo
        {
            get => GetValue(AlbumProperty) as string;
            set => SetValue(AlbumProperty, value);
        }


        public static readonly DependencyProperty AnoProperty =
              DependencyProperty.Register("AnoInfo", typeof(string), typeof(InfoCancionTabla), new PropertyMetadata(string.Empty));

        public string AnoInfo
        {
            get => GetValue(AnoProperty) as string;
            set => SetValue(AnoProperty, value);
        }


        public static readonly DependencyProperty DuracionProperty =
              DependencyProperty.Register("DuracionInfo", typeof(string), typeof(InfoCancionTabla), new PropertyMetadata(string.Empty));

        public string DuracionInfo
        {
            get => GetValue(DuracionProperty) as string;
            set => SetValue(DuracionProperty, value);
        }


        public static readonly DependencyProperty GeneroProperty =
              DependencyProperty.Register("GeneroInfo", typeof(string), typeof(InfoCancionTabla), new PropertyMetadata(string.Empty));

        public string GeneroInfo
        {
            get => GetValue(GeneroProperty) as string;
            set => SetValue(GeneroProperty, value);
        }
    }
}
