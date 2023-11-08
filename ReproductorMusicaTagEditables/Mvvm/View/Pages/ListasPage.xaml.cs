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
            crearListaReproduccion = new CrearListaReproduccion(listasReproduccion);
            listasReproduccion.CargarListasReproduccion();
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
            ListaAvatarControl i = (ListaAvatarControl)sender;
            this.NavigationService.Navigate(new InfoListasPage(i));
        }
    }
}
