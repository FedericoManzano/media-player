using ReproductorMusicaTagEditables.Controls.InfoCancionTabla;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos;
using ReproductorMusicaTagEditables.Mvvm.ViewModel;
using System;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ReproductorMusicaTagEditables.Mvvm.View.Pages
{
    public partial class TodasLasCanciones : Page
    {

        public TodasLasCanciones()
        {
            InitializeComponent();

            // scrollCanciones.ScrollToVerticalOffset(principalViewModel.ScrollVertical);
            //MessageBox.Show(panelPrincipal.Irg.CancionesFiltradas.Count + "");
        }

        private void InfoCancionTabla_PlayClick(object sender, EventArgs e)
        {
            
        }

        private void Actualiza_El_Listado_Canciones(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            //PrincipalViewModel principalViewModel = (PrincipalViewModel)DataContext;
            //principalViewModel.AgregarElementosAlFiltro();
        }

        private void Cargar_Archivos_Directorio(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }
    }
}
