
using ReproductorMusicaTagEditables.Controls.InfoCancionTabla;
using ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ReproductorMusicaTagEditables.Mvvm.View.Pages
{
    public partial class TodasLasCanciones : Page
    {
        
        public TodasLasCanciones()
        {
            InitializeComponent();
           
            panelPrincipal.AgregarElementosAlFiltro();
            scrollCanciones.ScrollToVerticalOffset(panelPrincipal.ScrollVertical);
        }

        private void InfoCancionTabla_PlayClick(object sender, EventArgs e)
        {
            panelPrincipal.ScrollVertical = scrollCanciones.VerticalOffset;
        }

        private void Actualiza_El_Listado_Canciones(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            panelPrincipal.ScrollVertical = scrollCanciones.VerticalOffset;
            panelPrincipal.AgregarElementosAlFiltro();
        }

        private void Cargar_Archivos_Directorio(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void InfoCancionTabla_ArtistaClick(object sender, EventArgs e)
        {
            InfoCancionTabla i = (InfoCancionTabla)sender;
            this.NavigationService.Navigate(new InfoArtistaPage(i.ArtistaInfo));
        }

        private void InfoCancionTabla_AlbumClick(object sender, EventArgs e)
        {
            InfoCancionTabla i = (InfoCancionTabla)sender;
            this.NavigationService.Navigate(new InfoAlbumPage(i.AlbumInfo));  
        }

        private void InfoCancionTabla_AgregarClick(object sender, EventArgs e)
        {
            MessageBox.Show(((InfoCancionTabla)sender).TituloInfo + "");
        }

        
    }
}
