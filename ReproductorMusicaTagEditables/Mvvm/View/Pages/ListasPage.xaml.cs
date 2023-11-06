using ReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias;
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
        CrearListaReproduccion crearListaReproduccion = new CrearListaReproduccion();
        public ListasPage()
        {
            InitializeComponent();
            listasReproduccion.CargarListasReproduccion();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            crearListaReproduccion.ShowDialog();
        }
    }
}
