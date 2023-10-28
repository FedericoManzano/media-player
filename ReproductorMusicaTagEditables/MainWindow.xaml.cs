
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.ViewModel;
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
        private ReproductorViewModel reproductorViewModel;
        public MainWindow()
        {
            InitializeComponent();
            CargarImagenPorDefectoArtista();
            reproductorViewModel = (ReproductorViewModel)DataContext;
            reproductorViewModel.CargarReproductor(mediaReproductor);
            
            timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += new EventHandler(Time_Track);
        }

        private void Time_Track(object sender, EventArgs e)
        {
            sliderLineTime.Value = mediaReproductor.Position.TotalSeconds;
            controlTiempo.TiempoTranscurrido = mediaReproductor.Position.ToString(@"hh\:mm\:ss");
            /*if (Controles.PLAY)
            {
                tiempoTotalPista = tiempoTotalPista.Subtract(unSegundo);
                txtTiempoTotal.Text = tiempoTotalPista.ToString(@"hh\:mm\:ss");
            }
            else
            {
                txtTiempoTotal.Text = myMediaElement.Position.ToString(@"hh\:mm\:ss");
            }*/

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

        private void Inicio_Track(object sender, RoutedEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                sliderLineTime.Value = 0;
            }
            if (mediaReproductor.NaturalDuration.HasTimeSpan)
            {
                CargarInfoArtista();
                TimeSpan tiempoTotalPista = mediaReproductor.NaturalDuration.TimeSpan;
                //txtTiempoTotal.Text = tiempoTotalPista.ToString(@"hh\:mm\:ss");
                sliderLineTime.Maximum = tiempoTotalPista.TotalSeconds;
                timer.Start();
            }
        }

        private void Final_Track(object sender, RoutedEventArgs e)
        {

        }

        private void CargarInfoArtista ()
        {
            //ImageBrush bImagen = ArchivoImagenBase
            //                        .archivoImagenFabrica (ArchivoImagenBase.IMAGEN_DEL_ARCHIVO)
            //                        .DameImagen(reproductorViewModel.CancionActual.Cancion.Path);
            //if(bImagen != null)
            //{
            //    infoArtista.ImagenArtista = bImagen;
            //}
            //if(reproductorViewModel.CancionActual.Cancion != null)
            //{
            //    infoArtista.NombreArtista = reproductorViewModel.CancionActual.Cancion.Artista;
            //    infoArtista.NombreAlbum = reproductorViewModel.CancionActual.Cancion.Album;
            //    infoArtista.TituloCancion = reproductorViewModel.CancionActual.Cancion.Titulo;
            //}  
        }
    }
}
