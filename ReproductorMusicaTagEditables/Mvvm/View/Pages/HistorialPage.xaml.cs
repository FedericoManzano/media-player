
using ReproductorMusicaTagEditables.Controls.Historial;
using ReproductorMusicaTagEditables.Controls.ListaAvatar;
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
            historialViewModel.Limpiar();
            historialViewModel.CargarListasHistorial();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            historialViewModel.Limpiar();
        }

        private void ListasHistorialControl_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListasHistorialControl i = (ListasHistorialControl)sender;
            historialViewModel.Limpiar();
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
}
