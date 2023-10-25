
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using System.Windows;
using System.Windows.Input;

namespace ReproductorMusicaTagEditables
{ 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CargarImagenPorDefectoArtista();
        }

        private void Arrastrar_Ventana(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Cerrar_App(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Minimizar_Ventana(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CargarImagenPorDefectoArtista ()
        {
            infoArtista.ImagenArtista = ArchivoImagenBase
                                            .archivoImagenFabrica(ArchivoImagenBase.DEFAULT)
                                            .DameImagen();
        }
    }
}
