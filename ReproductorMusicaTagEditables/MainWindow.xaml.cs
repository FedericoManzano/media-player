
using MediaToolkit.Options;
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.Navegacion;
using ReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias;
using ReproductorMusicaTagEditables.Mvvm.View.Generador;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;

using Application = System.Windows.Application;

namespace ReproductorMusicaTagEditables
{ 
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
      
        private TimeSpan tiempoTotalPista = new TimeSpan();
        private double posicionInicialSlider = 0;
        private double posicionFinalSlider = 0;

        public static AgregarCancionesListas agregarCancionesListas;
        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            agregarCancionesListas = new AgregarCancionesListas(reproViewModel);
            CargarImagenPorDefectoArtista();
           
            reproViewModel.CargarReproductor(mediaReproductor);

            InfoReproductor infoReproductor = InfoReproductor.DameInstancia();
            infoReproductor.CancionActual = ReproductorViewModelBase.infoNavegacion.CancionActual;
            CargarInfoArtista();
            timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += new EventHandler(Time_Track);
            GuardarNavegacion();
            
        }


        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWn, int wPa, int wGm, int lParam);

        private void Time_Track(object sender, EventArgs e)
        {
            
            if (EstadosControl.PLAY && !EstadosControl.SLIDER_MOVE)
            {
                sliderLineTime.Value = mediaReproductor.Position.TotalSeconds;
                controlTiempo.TiempoTranscurrido = mediaReproductor.Position.TiempoFormato();
                tiempoTotalPista = tiempoTotalPista.Subtract(TimeSpan.FromSeconds(1));
                controlTiempo.TiempoFaltante = tiempoTotalPista.TiempoFormato();
            }
        }

        private void Arrastrar_Ventana(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(this);
            SendMessage(windowInteropHelper.Handle, 161, 2, 0);
            if (e.LeftButton == MouseButtonState.Pressed)
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
            reproViewModel.SiguienteAction();
        }

        private void CargarInfoArtista ()
        {
            ImageBrush bImagen = DameImagenCancion();
            GuardarNavegacion();
            infoArtista.ImagenArtista = bImagen;
            if (reproViewModel.CancionActual() != null)
            {
                
                infoArtista.NombreArtista = reproViewModel.CancionActual().Artista;
                infoArtista.NombreAlbum = reproViewModel.CancionActual().Album;
                infoArtista.TituloCancion = reproViewModel.CancionActual().Titulo;
            }
        }

        private void GuardarNavegacion()
        {
            InfoReproductor ir = InfoReproductor.DameInstancia();
            ReproductorViewModelBase.infoNavegacion.CancionActual = ir.CancionActual;
            ReproductorViewModelBase.infoNavegacion.CancionesFiltradas = ir.CancionesFiltradas;
            Navegacion.GuardarInfo(ReproductorViewModelBase.infoNavegacion);
        }


        private ImageBrush DameImagenCancion()
        {
            ImageBrush bImagen;
            if (reproViewModel.CancionActual() != null)
            {
                bImagen = ArchivoImagenBase
                                   .archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO)
                                   .DameImagen(reproViewModel.CancionActual().Path) ?? ArchivoImagenBase
                                   .archivoImagenFabrica(ArchivoImagenBase.DEFAULT)
                                   .DameImagen();
                return bImagen;
            } 
            
            return ArchivoImagenBase
                                   .archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
        }


        private void ReiniciarCamposTiempo ()
        {
            controlTiempo.TiempoFaltante = "00:00:00";
            controlTiempo.TiempoTranscurrido = "00:00:00";
        }

        private void Comenzar_Arrastre_Slider_TimeLineSlider(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            timer.Stop();
            
        }

        private void Finalizar_Arrastre_Slider_TimeLineSlider(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            posicionInicialSlider = mediaReproductor.Position.TotalSeconds;
            mediaReproductor.Position = TimeSpan.FromSeconds( sliderLineTime.Value);
            posicionFinalSlider = mediaReproductor.Position.TotalSeconds;
            tiempoTotalPista = tiempoTotalPista.Subtract( TimeSpan.FromSeconds( posicionFinalSlider - posicionInicialSlider));
            timer.Start();
        }

        private void sliderLineTime_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mediaReproductor.Position = mediaReproductor.Position = TimeSpan.FromSeconds(sliderLineTime.Value); ;
            posicionFinalSlider = mediaReproductor.Position.TotalSeconds;
            tiempoTotalPista = tiempoTotalPista.Subtract(TimeSpan.FromSeconds(posicionFinalSlider - posicionInicialSlider));
            timer.Start();
        }

        private void sliderLineTime_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            posicionInicialSlider = mediaReproductor.Position.TotalSeconds;
            timer.Stop();
        }

        private void Menu_DocClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.google.com");
        }
    }
}
