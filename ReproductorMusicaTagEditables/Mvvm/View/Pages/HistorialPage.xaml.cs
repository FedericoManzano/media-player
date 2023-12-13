
using ReproductorMusicaTagEditables.Controls.Historial;
using ReproductorMusicaTagEditables.Controls.ListaAvatar;
using ReproductorMusicaTagEditables.Mvvm.Repository.Historial;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas;
using System.Windows;
using System.Windows.Controls;


namespace ReproductorMusicaTagEditables.Mvvm.View.Pages
{
    public partial class HistorialPage : Page
    {
        public HistorialPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CargarPagina();
        }


        private void CargarPagina()
        {
            historialViewModel.Limpiar();
            historialViewModel.CargarAlbumesHistorial();
            historialViewModel.CargarListasHistorial();

            if (historialViewModel.ListasAlbumes.Count == 0)
            {
                albumesVacio.Visibility = Visibility.Visible;
                itemsAlbumes.Visibility = Visibility.Collapsed;
            }
            else
            {
                albumesVacio.Visibility = Visibility.Collapsed;
                itemsAlbumes.Visibility = Visibility.Visible;
            }

            if (historialViewModel.ListasRep.Count == 0)
            {
                listasVacio.Visibility = Visibility.Visible;
                listasRepro.Visibility = Visibility.Collapsed;
            }
            else
            {
                listasVacio.Visibility = Visibility.Collapsed;
                listasRepro.Visibility = Visibility.Visible;
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            historialViewModel.Limpiar();
        }

        private void ListasHistorialControl_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListasHistorialControl i = (ListasHistorialControl)sender;
            historialViewModel.Limpiar();

            if(i.Nombre.EsUnRegalo())
            {
                this.NavigationService.Navigate(new RegaloListaPage(i.Nombre.DameFormatoVisibleFecha()));
            }
            else
            {
                ListaAvatarControl li = new ListaAvatarControl()
                {
                    Nombre = i.Nombre,
                    ImagenUno = i.ImagenUno,
                    ImagenDos = i.ImagenDos,
                    ImagenTres = i.ImagenTres,
                    ImagenCuatro = i.ImagenCuatro,
                    Cantidad = i.Cantidad,
                };
                this.NavigationService.Navigate(new InfoListasPage(li));
            }

            
        }

        private void AlbumHistorialControl_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AlbumHistorialControl i = (AlbumHistorialControl)sender;
            historialViewModel.Limpiar();
            this.NavigationService.Navigate(new InfoAlbumPage(i.Nombre));
        }

        private void Eliminar_Historial(object sender, RoutedEventArgs e)
        {
            Historial.BorrarHistorial();
            CargarPagina();
        }

        private void Pagina_Anterior(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                historialViewModel.Limpiar();
                this.NavigationService.GoBack();
            }
        }
    }
}
