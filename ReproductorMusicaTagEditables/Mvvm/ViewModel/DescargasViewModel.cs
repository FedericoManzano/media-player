using MediaToolkit.Model;
using MediaToolkit;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System;
using System.Threading.Tasks;
using VideoLibrary;
using System.IO;
using System.Windows;
using ReproductorMusicaTagEditables.Controls.DescargarCancion;
using ReproductorMusicaTagEditables.Mvvm.Model;
using System.Collections.Generic;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos;
using System.Windows.Forms;
using System.Net.Http;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaInicial;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class DescargasViewModel: ReproductorViewModelBase
    {

        private string _uriVideo;
        public string UriVideo { get => _uriVideo; set { _uriVideo = value; OnPropertyChanged(nameof(UriVideo)); } }

        private string _pathVideo =  Environment.CurrentDirectory + @"/Descargas/";
        public string PathVideo { get => _pathVideo; set { _pathVideo = value; OnPropertyChanged(nameof(PathVideo)); } }

        private string _extensionAudio = ".mp3";
        public string ExtensionAudio { get => _extensionAudio; set { _extensionAudio = value; OnPropertyChanged(nameof(ExtensionAudio)); } }

        public int CantidadDescargando { get; set; } = 0;


        public bool _habilitarBotones = true;



        private Visibility _mjeDescargaActivado = Visibility.Collapsed;
        public Visibility MjeDescargaActivado 
        { 
            get => _mjeDescargaActivado; 
            set { _mjeDescargaActivado = value; OnPropertyChanged(nameof(MjeDescargaActivado)) ; } 
        }

        private Visibility _notificacionCancion = Visibility.Collapsed;
        public Visibility NotificacionCancion
        {
            get => _notificacionCancion;
            set { _notificacionCancion = value; OnPropertyChanged(nameof(NotificacionCancion)); }
        }


        public bool HabilitarBotones 
        { get => _habilitarBotones; set
            {
                _habilitarBotones = value;
                OnPropertyChanged(nameof(HabilitarBotones));
            } 
        }

        

        public DescargasViewModel() 
        {
            Irg.TitutloVentana = "Descargas";
            if(!Directory.Exists(PathVideo))
            {
                Directory.CreateDirectory(PathVideo);
            }
        }

        public async void ConvertirVideo(DescargarCancionControl descarga)
        {
            UriVideo = descarga.Texto;
            
            if (string.IsNullOrEmpty(UriVideo) || !Uri.IsWellFormedUriString(UriVideo, UriKind.Absolute))
            {
                System.Windows.MessageBox.Show("Complete el campo URL con la url del video que desea convertir.");
                return;
            }
            var youtube = YouTube.Default;

            try
            {

                descarga.EsVisible = true;
                MjeDescargaActivado = Visibility.Visible;
                var vid = await youtube.GetVideoAsync(UriVideo);

                if (!Directory.Exists(PathVideo))
                {
                    System.Windows.MessageBox.Show($"La ruta {PathVideo} no existe. Por favor ingresela nuevamente.");
                    return;
                }
                CantidadDescargando++;
                HabilitarBotones = false;
                descarga.Habilitado = false;
                descarga.EsVisible = await Task<bool>.Run(() =>
                { 
                    try
                    {
                        System.IO.File.WriteAllBytes(PathVideo + vid.FullName, vid.GetBytes());

                        FileInfo fi = new FileInfo(PathVideo + vid.FullName);
                        string nombreArchivo = Path.GetFileNameWithoutExtension(fi.Name);

                        var inputFile = new MediaFile { Filename = PathVideo + vid.FullName };
                        var outputFile = new MediaFile { Filename = $"{PathVideo + nombreArchivo}{ExtensionAudio}" };

                        using (var engine = new Engine())
                        {
                            engine.GetMetadata(inputFile);
                            engine.Convert(inputFile, outputFile);
                        }

                        File.Delete(PathVideo + vid.FullName);
                    }
                    catch(HttpRequestException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(
                                "Error en el protocolo de transferencia Http." + Environment.NewLine +
                                $"El archivo {vid.FullName} no pudo descargargarse."+Environment.NewLine+
                                $"Código: {ex.Message}","Error Http", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        CantidadDescargando --;
                        return true;
                    }
                    CantidadDescargando --;
                    return false;
                });

                
                if (!descarga.EsVisible)
                {
                    descarga.Ok = Visibility.Visible;
                    descarga.IconoEstado = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.CheckSolid;
                    descarga.ColorEstado = "LightGreen";
                } else
                {
                    descarga.EsVisible = false;
                    descarga.Ok = Visibility.Visible;
                    descarga.IconoEstado = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.WindowCloseSolid;
                    descarga.ColorEstado = "Red";
                } 
            }
            catch (VideoLibrary.Exceptions.UnavailableStreamException e)
            {
                descarga.EsVisible = false;
                System.Windows.MessageBox.Show($"La URL: {UriVideo} no existe. Corrija este campo para que el proceso de descarga avance correctamente." + Environment.NewLine +
                    $"Cod: {e.Message}");
            }

            if(CantidadDescargando == 0)
            {
                HabilitarBotones = true;
                System.Windows.Forms.MessageBox.Show("La descarga ha terminado. Los botones y controles ya están disponibles.", "Descarga terminada", System.Windows.Forms.MessageBoxButtons.OK , MessageBoxIcon.Information); ;
                MjeDescargaActivado = Visibility.Collapsed;
                NotificacionCancion = Visibility.Visible;
            }
        }

        public async void MostrarNotificacion ()
        {
            CargarMusica cargarMusica = new CargarMusicaDesdeDirectorio();
            List<string> lp = await cargarMusica.IniciarCargaReproductor(PathVideo);
            if(lp != null && lp.Count > 0)
            {
                NotificacionCancion = Visibility.Visible;
            }
            else
            {
                NotificacionCancion = Visibility.Collapsed;
            }
        }

        public async Task<List<Cancion>> DameListadoCanciones ()
        {
            CargarMusica cargarMusica = new CargarMusicaDesdeDirectorio();
            List<string> lp = await cargarMusica.IniciarCargaReproductor(PathVideo);
            List<Cancion> lc = await cargarMusica.CargarListadoDeCancionesAsync(lp);
            return lc;
        }

        public async void MoverArchivosDescargados ()
        {

            CargarMusica cargarMusica = new CargarMusicaDesdeDirectorio();
            List<string> lp = await cargarMusica.IniciarCargaReproductor(PathVideo);

            if(lp != null && lp.Count > 0)
            {
                FolderBrowserDialog fd = new FolderBrowserDialog();
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string p in lp)
                    {
                        FileInfo fi = new FileInfo(p);

                        System.IO.File.Move(p, fd.SelectedPath + "\\" + fi.Name);
                    }
                    System.Windows.MessageBox.Show($"{lp.Count} fueron movidos a {fd.SelectedPath} con exito.");
                    ActualizarListadoCanciones(fd.SelectedPath);
                    NotificacionCancion = Visibility.Collapsed;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No hay canciones cargadas pendientes de revisión","Información",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
        }


        public async void ActualizarListadoCanciones(string path)
        {
            CargarMusica cargarMusica = new CargarMusicaDesdeDirectorio();
            List<string> listPath = await cargarMusica.IniciarCargaReproductor(path);
            List<Cancion> listCanciones = await cargarMusica.CargarListadoDeCancionesAsync(listPath);
            RepositorioDeCanciones.AgregarCanciones(listCanciones);
        }
    }
}
