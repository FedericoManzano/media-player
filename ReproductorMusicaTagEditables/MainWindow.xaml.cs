
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

using Application = System.Windows.Application;

namespace ReproductorMusicaTagEditables
{ 
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
      
        private TimeSpan tiempoTotalPista = new TimeSpan();


        public MainWindow()
        {
            InitializeComponent();
            CargarImagenPorDefectoArtista();
           
            reproViewModel.CargarReproductor(mediaReproductor);
            
            timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(0.945)
            };
            timer.Tick += new EventHandler(Time_Track);
        }

        private void Time_Track(object sender, EventArgs e)
        {
            
            if (EstadosControl.PLAY)
            {
                sliderLineTime.Value = mediaReproductor.Position.TotalSeconds;
                controlTiempo.TiempoTranscurrido = mediaReproductor.Position.TiempoFormato();
                tiempoTotalPista = tiempoTotalPista.Subtract(TimeSpan.FromSeconds(1));
                controlTiempo.TiempoFaltante = tiempoTotalPista.TiempoFormato();
            }
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
            infoArtista.ImagenArtista = DameImagenCancion();  
        }

        private void Inicio_Track(object sender, RoutedEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                sliderLineTime.Value = 0;
            }
            if (mediaReproductor.TieneTimeSpan())
            {
                CargarInfoArtista();
                tiempoTotalPista = mediaReproductor.TiempoTotalPista();
                sliderLineTime.Maximum = mediaReproductor.TiempoTotalPista().TotalSeconds;
                controlTiempo.TiempoFaltante = mediaReproductor.TiempoTotalPista().TiempoFormato();
                timer.Start();
            }
        }

        private void Final_Track(object sender, RoutedEventArgs e)
        {
            ReiniciarCamposTiempo();
            timer.Stop();
            reproViewModel.Siguiente();
        }

        private void CargarInfoArtista ()
        {
            ImageBrush bImagen = DameImagenCancion();
            infoArtista.ImagenArtista = bImagen;
            if (reproViewModel.CancionActual() != null)
            {
                infoArtista.NombreArtista = reproViewModel.CancionActual().Artista;
                infoArtista.NombreAlbum = reproViewModel.CancionActual().Album;
                infoArtista.TituloCancion = reproViewModel.CancionActual().Titulo;
            }
        }

        private ImageBrush DameImagenCancion()
        {
            ImageBrush bImagen = ArchivoImagenBase
                                   .archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO)
                                   .DameImagen(reproViewModel.CancionActual().Path) ?? ArchivoImagenBase
                                   .archivoImagenFabrica(ArchivoImagenBase.DEFAULT)
                                   .DameImagen();
            return bImagen;
        }


        private void ReiniciarCamposTiempo ()
        {
            controlTiempo.TiempoFaltante = "00:00:00";
            controlTiempo.TiempoTranscurrido = "00:00:00";
        }
    }
}
