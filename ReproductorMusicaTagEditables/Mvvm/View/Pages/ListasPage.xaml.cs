using ReproductorMusicaTagEditables.Controls.Paginador;
using ReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias;
using ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReproductorMusicaTagEditables.Mvvm.View.Pages
{
    /// <summary>
    /// Lógica de interacción para ListasPage.xaml
    /// </summary>
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
            this.NavigationService.Navigate(new InfoListasPage());
        }
    }
}
