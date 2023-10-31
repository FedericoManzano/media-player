using ReproductorMusicaTagEditables.Mvvm.View.Pages;
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

namespace ReproductorMusicaTagEditables.Mvvm.View
{
    /// <summary>
    /// Lógica de interacción para PrincipalView.xaml
    /// </summary>
    public partial class PrincipalView : UserControl
    {
        private TodasLasCanciones todasLasCanciones;

        public PrincipalView()
        {
            InitializeComponent();
            todasLasCanciones = new TodasLasCanciones(paginacion);
            paginacion.NavigationService.Navigate(todasLasCanciones);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            paginacion.NavigationService.Navigate(new TodasLasCanciones(paginacion));
        }
    }
}
