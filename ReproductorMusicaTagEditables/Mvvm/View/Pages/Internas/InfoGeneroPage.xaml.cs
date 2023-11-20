using ReproductorMusicaTagEditables.Controls.InfoCancionTabla;
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
using TagLib;

namespace ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas
{
    /// <summary>
    /// Lógica de interacción para InfoGeneroPage.xaml
    /// </summary>
    public partial class InfoGeneroPage : Page
    {
        private string _genero;
        public InfoGeneroPage(string genero)
        {
            InitializeComponent();
            this._genero = genero;
            infoGenero.CargarInfoGenero(genero);
        }

        private void scrollCanciones_IsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            infoGenero.ActualizarFiltro();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                infoGenero.Limpiar();
                this.NavigationService.GoBack();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            infoGenero.Limpiar();
            infoGenero.CargarInfoGenero(_genero);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            infoGenero.Limpiar();
        }

        private void agregarControl_AgregarClick(object sender, EventArgs e)
        {
            infoGenero.CargarListadoEneditorListas();
        }

        private void agregarControl_DesmarcarClick(object sender, EventArgs e)
        {
            infoGenero.Limpiar();
            infoGenero.DeseleccionarTodas();
            infoGenero.CargarInfoGenero(_genero);
            agregarControl.Visibilidad = System.Windows.Visibility.Hidden;
        }

        private void InfoCancionTabla_MouseLeave(object sender, MouseEventArgs e)
        {
            InfoCancionTabla i = (InfoCancionTabla)sender;
            if (i.EstaSeleccionado())
            {
                infoGenero.SeleccionarCancion(i);
                agregarControl.Visibilidad = System.Windows.Visibility.Visible;
            }
            else
            {
                infoGenero.DeseleccionarCancion(i);
                if (infoGenero.CantidadSeleccionado() == 0 && agregarControl.Visibilidad == System.Windows.Visibility.Visible)
                {
                    agregarControl.Visibilidad = System.Windows.Visibility.Hidden;
                }
            }
        }
    }
}
