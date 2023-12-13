using ReproductorMusicaTagEditables.Controls.InfoCancionTabla;
using System;
using System.Windows;
using System.Windows.Controls;


namespace ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas
{
    public partial class RegaloListaPage : Page
    {
        private readonly string _nombre;
        public RegaloListaPage(string nombre)
        {
            InitializeComponent();
            _nombre = nombre;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listasRegalo.Limpiar();
            listasRegalo.CargarPaginaListadosRegalos(_nombre);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            listasRegalo.Limpiar();
        }

        private void Ir_Atras(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                listasRegalo.Limpiar();
                this.NavigationService.GoBack();
            }
        }

        private void InfoCancionTabla_ArtistaClick(object sender, EventArgs e)
        {
            listasRegalo.Limpiar();
            InfoCancionTabla i = (InfoCancionTabla)sender;
            this.NavigationService.Navigate(new InfoArtistaPage(i.ArtistaInfo));
        }

        private void InfoCancionTabla_AlbumClick(object sender, EventArgs e)
        {
            listasRegalo.Limpiar();
            InfoCancionTabla i = (InfoCancionTabla)sender;
            this.NavigationService.Navigate(new InfoAlbumPage(i.AlbumInfo));
        }
    }
}
