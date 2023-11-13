using ReproductorMusicaTagEditables.Controls.ListaAvatar;
using ReproductorMusicaTagEditables.Controls.Paginador;
using ReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias;
using ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ReproductorMusicaTagEditables.Mvvm.View.Pages
{
    public partial class ListasPage : Page
    {
        CrearListaReproduccion crearListaReproduccion;
        public ListasPage()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            crearListaReproduccion.ShowDialog();
        }

        private void BotonPaginador_DarClick(object sender, EventArgs e)
        {
            BotonPaginador i = (BotonPaginador)sender;
            listasReproduccion.ActualizarListas(i.Inicial);
        }

        private void ListaAvatarControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            listasReproduccion.Limpiar();
            ListaAvatarControl i = (ListaAvatarControl)sender;
            this.NavigationService.Navigate(new InfoListasPage(i));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listasReproduccion.Limpiar();
            crearListaReproduccion = new CrearListaReproduccion(listasReproduccion);
            listasReproduccion.CargarListasReproduccion();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            listasReproduccion.Limpiar();
        }
    }
}
