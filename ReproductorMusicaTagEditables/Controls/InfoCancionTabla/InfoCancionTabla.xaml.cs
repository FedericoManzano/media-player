using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReproductorMusicaTagEditables.Controls.InfoCancionTabla
{
    public partial class InfoCancionTabla : UserControl
    {

        private bool _seleccionado = false;

        public InfoCancionTabla()
        {
            InitializeComponent();
            menuContexto.DataContext = this;
        }

        public bool Seleccionado { get => _seleccionado; set => _seleccionado = value; }

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

        public static readonly DependencyProperty NumeroProperty =
           DependencyProperty.Register("NumeroInfo", typeof(string), typeof(InfoCancionTabla), new PropertyMetadata(string.Empty));

        public string NumeroInfo
        {
            get => GetValue(NumeroProperty) as string;
            set => SetValue(NumeroProperty, value);
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

        public static readonly DependencyProperty ColorTextoProperty =
              DependencyProperty.Register("ColorTexto", typeof(string), typeof(InfoCancionTabla), new PropertyMetadata(string.Empty));

        public string ColorTexto
        {
            get => GetValue(ColorTextoProperty) as string;
            set => SetValue(ColorTextoProperty, value);
        }

        public static readonly DependencyProperty ParametroComandoProperty =
            DependencyProperty.Register("ParametroComando", typeof(object), typeof(InfoCancionTabla));
        public object ParametroComando
        {
            get => GetValue(ParametroComandoProperty);
            set => SetValue(ParametroComandoProperty, value);
        }

        public static readonly DependencyProperty ComandoProperty =
            DependencyProperty.Register("Comando", typeof(ICommand), typeof(InfoCancionTabla));
        public ICommand Comando
        {
            get => (ICommand)GetValue(ComandoProperty);
            set => SetValue(ComandoProperty, value);
        }

        public static readonly RoutedEvent AgregarClickEvent =
            EventManager.RegisterRoutedEvent("AgregarClick", RoutingStrategy.Bubble, typeof(EventHandler), typeof(InfoCancionTabla));

        public event EventHandler AgregarClick
        {
            add => AddHandler(AgregarClickEvent, value);
            remove => RemoveHandler(AgregarClickEvent, value);
        }

        public void OnAgregarClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(AgregarClickEvent));
        }




        public static readonly RoutedEvent BorrarCancionEvent =
            EventManager.RegisterRoutedEvent("BorrarClick", RoutingStrategy.Bubble, typeof(EventHandler), typeof(InfoCancionTabla));

        public event EventHandler BorrarClick
        {
            add => AddHandler(BorrarCancionEvent, value);
            remove => RemoveHandler(BorrarCancionEvent, value);
        }

        public void OnBorrarClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BorrarCancionEvent));
        }



        public static DependencyProperty EncendidoProperty =
            DependencyProperty.Register("Habilitado", typeof(bool), typeof(InfoCancionTabla), new PropertyMetadata(false));


        public bool Habilitado
        {
            get => (bool)GetValue(EncendidoProperty);
            set=> SetValue(EncendidoProperty, value);
        }
        
        

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           if( MainWindow.agregarCancionesListas.AgregarCancion(new Mvvm.Model.Cancion()
            {
                Numero = NumeroInfo,
                Titulo = TituloInfo,
                Album = AlbumInfo,
                Artista = ArtistaInfo,
                FechaLanzamiento = AnoInfo,
                Duracion = DuracionInfo,
                Genero = GeneroInfo
            }))
                MainWindow.agregarCancionesListas.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Toca");
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            Seleccionado = !Seleccionado;
            if(!Seleccionado)
            {
                iconCheck.Kind = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.SquareRegular;
            }
            else
            {
                iconCheck.Kind = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.CheckSquareSolid;
            }
        }

        public void Deseleccionar()
        {
            Seleccionado = false;
        }

        public bool EstaSeleccionado()
        {
            return Seleccionado;
        }
    }
}
