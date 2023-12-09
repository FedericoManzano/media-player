
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Controls.InfoAlbumPagina
{
    public partial class InfoAlbumPaginaControl : UserControl
    {
        public InfoAlbumPaginaControl()
        {
            InitializeComponent();
        }

        #region Imagen dependencia
        public static DependencyProperty ImagenAlbumProperty =
            DependencyProperty.Register("ImagenAlbum", typeof(ImageBrush), typeof(InfoAlbumPaginaControl));

        public ImageBrush ImagenAlbum
        {
            get => (ImageBrush)GetValue(ImagenAlbumProperty); 
            set => SetValue(ImagenAlbumProperty, value);
        }
        #endregion


        #region Nombre Property
        public static DependencyProperty NombreAlbumProperty =
            DependencyProperty.Register("NombreAlbum", typeof(string), typeof(InfoAlbumPaginaControl));

        public string NombreAlbum
        {
            get => (string)GetValue(NombreAlbumProperty);
            set => SetValue(NombreAlbumProperty, value);
        }
        #endregion


        #region Nombre Artista
        public static DependencyProperty NombreArtistaProperty =
            DependencyProperty.Register("NombreArtista", typeof(string), typeof(InfoAlbumPaginaControl));

        public string NombreArtista
        {
            get => (string)GetValue(NombreArtistaProperty);
            set => SetValue(NombreArtistaProperty, value);
        }
        #endregion

        #region Evento IrAPagina
        public static RoutedEvent IrPaginaArtistaEvent =
            EventManager.RegisterRoutedEvent("IrPaginaArtista", RoutingStrategy.Bubble, typeof(EventHandler), typeof(InfoAlbumPaginaControl));

        public event EventHandler IrPaginaArtista
        {
            add { AddHandler(IrPaginaArtistaEvent, value);}
            remove { RemoveHandler(IrPaginaArtistaEvent, value); }
        }


        public void OnIrPaginaArtista(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(IrPaginaArtistaEvent));
        }
        #endregion


        #region Cantidad property

        public static DependencyProperty CantidadCancionesProperty =
            DependencyProperty.Register("CantidadCanciones", typeof(string), typeof(InfoAlbumPaginaControl));

        public string CantidadCanciones
        {
            get => (string)GetValue(CantidadCancionesProperty);
            set => SetValue(CantidadCancionesProperty, value);
        }
        #endregion


        #region Horas Property
        public static DependencyProperty HorasProperty =
            DependencyProperty.Register("Horas", typeof(string), typeof(InfoAlbumPaginaControl));

        public string Horas
        {
            get => (string)GetValue(HorasProperty);
            set => SetValue(HorasProperty, value);
        }

        #endregion


        #region Comando Reproducir
        public static DependencyProperty ReproducirCommandProperty =
            DependencyProperty.Register("ReproducirCommand", typeof(ICommand), typeof(InfoAlbumPaginaControl));

        public ICommand ReproducirCommand
        {
            get => (ICommand)GetValue(ReproducirCommandProperty);
            set => SetValue(ReproducirCommandProperty, value);
        }

        public static DependencyProperty ReproducirParamProperty =
            DependencyProperty.Register("ReproducirParamCommand", typeof(object), typeof(InfoAlbumPaginaControl));

        public object ReproducirParamCommand
        {
            get => GetValue(ReproducirParamProperty);
            set => SetValue(ReproducirParamProperty, value);
        }

        #endregion

        #region Evento Editar
        public static RoutedEvent ModificarEvent =
            EventManager.RegisterRoutedEvent("Modificar", RoutingStrategy.Bubble, typeof(EventHandler), typeof(InfoAlbumPaginaControl));
        
        public event EventHandler Modificar
        {
            add => AddHandler(ModificarEvent, value);   
            remove => RemoveHandler(ModificarEvent, value); 
        }


        public void OnModificar(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ModificarEvent));    
        }


        #endregion
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InfoReproductor i = InfoReproductor.DameInstancia();
            List<Cancion> albums = i.Canciones.Where(c => c.Album == NombreAlbum).ToList();
            MainWindow.agregarCancionesListas.AgregarListaCanciones(albums);
            MainWindow.agregarCancionesListas.Show();
        }
    }
}
