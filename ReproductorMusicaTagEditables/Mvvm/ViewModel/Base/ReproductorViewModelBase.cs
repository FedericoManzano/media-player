using ControlTiempoMultimedia.MetodosExtendidos;
using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Controls.InfoCancionTabla;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.Historial;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.Repository.Navegacion;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base
{
    public abstract class ReproductorViewModelBase : ViewModelBase
    {

        public static InfoNavegacion infoNavegacion = new InfoNavegacion();

        protected InfoReproductor irg;

        private static double _scrollVertical = 0;
        private List<Cancion> _cancionesSeleccionadas = new List<Cancion>();


        private bool _habilitados = true;
        private Visibility _capaProtectora = Visibility.Collapsed;
        public bool Habilitados
        {
            get => _habilitados;
            set
            {
                _habilitados = value; OnPropertyChanged(nameof(Habilitados));
            }
        }
        public Visibility CapaProtectora
        {
            get => _capaProtectora;
            set
            {
                _capaProtectora = value; OnPropertyChanged(nameof(CapaProtectora));
            }
        }

        public  InfoReproductor Irg
        {
            get => irg;  
        }

        public  void CargarReproductor(MediaElement me)
        {
            Irg.Reproductor = me;
        }

        public double ScrollVertical { get => _scrollVertical; set => _scrollVertical = value; }

        public ICommand CargarMusicaCommand { get; }
        public ICommand PlayCommand { get; }
        public ICommand SiguienteCommand { get; }
        public ICommand AnteriorCommand { get; }
       
        public ReproductorViewModelBase ()
        {
            irg = InfoReproductor.DameInstancia();
            ListasReproduccion.CrearListaFavoritos();

            CargarMusicaCommand = new RelayCommand(CargarMusicaAction);
            SiguienteCommand = new RelayCommand(SiguienteAction, CanSiguienteAction);
            AnteriorCommand = new RelayCommand(AnteriorAction, CanAnteriorAction);
            PlayCommand = new RelayCommand(PlayAction);
            Historial.CrearHistorial();
            CargarInfoNavegacion();
            if(irg.Canciones.Count == 0)
                Irg.CargaDesdeElRepositorioCanciones();  
        }

        private void CargarInfoNavegacion()
        {
            if (!Navegacion.Existe())
                Navegacion.Crear();
            else
            {
                infoNavegacion = Navegacion.LevantarInfo();
                if (infoNavegacion != null)
                {
                    if (infoNavegacion.CancionActual.Cancion != null)
                    {
                        Irg.CancionActual = infoNavegacion.CancionActual;
                    }

                    if (infoNavegacion.CancionesFiltradas.Count > 0)
                    {
                        Irg.CancionesFiltradas = infoNavegacion.CancionesFiltradas;
                    }
                }
                else
                {
                    infoNavegacion = new InfoNavegacion();
                    
                }

            }
        }
        public bool CanAnteriorAction(object arg)
        {
            if (EstadosControl.RANDOM)
            {
                return Irg.CancionesFiltradas.Count > 0;
            }
            if (EstadosControl.CIRCULOS)
            {
                return true;
            }
            return Irg.CancionesFiltradas.Count > 0 && Irg.CancionActual.Index > 0;
        }
        public void AnteriorAction(object obj = null)
        { 
            AccionReproductor.Fabrica(AccionReproductor.ATRAS_ACCION)?.Ejecutar(Irg);
            ScrollVertical = irg.SetScroll();
        }
        private bool CanSiguienteAction(object arg)
        {
            if(EstadosControl.RANDOM)
            {
                return Irg.CancionesFiltradas.Count > 0;
            }
            if (EstadosControl.CIRCULOS)
            {
                return true;
            }
            return Irg.CancionesFiltradas.Count > 0 && Irg.CancionActual.Index < Irg.CancionesFiltradas.Count - 1;
        }
        public void SiguienteAction(object obj = null)
        {
            AccionReproductor.Fabrica(AccionReproductor.SIGUIENTE_ACCION)?.Ejecutar(Irg);
            ScrollVertical = irg.SetScroll();
        }
        protected void PlayAction(object obj)
        {
            Cancion c = (Cancion)obj;
            if(c != null)
            {
                Irg.CancionesFiltradas = new ObservableCollection<Cancion>(irg.Canciones);
                int index = Irg.CancionesFiltradas.IndexOf(c);
                Irg.Deseleccionar();
                Irg.CancionActual.Index = index;
                Irg.CancionActual.Cancion = c;
            }
            AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION)?.Ejecutar(Irg, c);
            ScrollVertical = irg.SetScroll();
            Historial.AgregarAHistorialAlbumes(GenerarAlbum(Irg.CancionActual.Cancion));
        }
        protected Album GenerarAlbum(Cancion c)
        {
            return new Album()
            {
                Titulo = c.Album,
                Artista = c.Artista,
                PathImagen = c.Path,
                Genero = c.Genero,
                Ano = c.FechaLanzamiento,
                Imagen = null,
            };
        }
        private void CargarMusicaAction(object obj)
        {
            
            Irg.CargarMusicaSeleccion(this);
            
        }
        public void AgregarElementosAlFiltro()
        {
            Irg.AgregarElementosAlFiltro();
        }
        public void SeleccionarCancion(InfoCancionTabla infoCancionTabla)
        {
            if(infoCancionTabla != null) 
            {
                Cancion c = new Cancion()
                {
                    Numero = infoCancionTabla.NumeroInfo,
                    Titulo = infoCancionTabla.TituloInfo,
                    Artista = infoCancionTabla.ArtistaInfo,
                    Album = infoCancionTabla.AlbumInfo,
                    Duracion = infoCancionTabla.DuracionInfo,
                    Genero = infoCancionTabla.GeneroInfo,
                };


                List<Cancion> la = _cancionesSeleccionadas.Where(cs => cs.Titulo == c.Titulo && cs.Artista == c.Artista && c.Album == cs.Album).ToList();
                
                if(la.Count == 0)
                {
                    _cancionesSeleccionadas.Add(c);
                }
            }
        }
        public void DeseleccionarCancion(InfoCancionTabla infoCancionTabla)
        {
            if (infoCancionTabla != null)
            {
                Cancion c = new Cancion()
                {
                    Titulo = infoCancionTabla.TituloInfo,
                    Artista = infoCancionTabla.ArtistaInfo,
                    Album = infoCancionTabla.AlbumInfo,
                    Duracion = infoCancionTabla.DuracionInfo,
                    Genero = infoCancionTabla.GeneroInfo,
                };

                List<Cancion> ar = _cancionesSeleccionadas.Where(cl =>
                {
                   return cl.Titulo == c.Titulo && cl.Artista == c.Artista && cl.Album == c.Album;
                }).ToList();

                if(ar.Count >= 1) {

                    ar = Irg.Canciones.Where(clist => clist.Titulo == ar[0].Titulo && clist.Artista == ar[0].Artista && clist.Album == ar[0].Album).ToList();
                    _cancionesSeleccionadas = _cancionesSeleccionadas.Where(cs => cs.Titulo != ar[0].Titulo || cs.Artista != ar[0].Artista || ar[0].Album != cs.Album).ToList();
                }
            }
        }
        public int CantidadSeleccionado ()
        {
            return _cancionesSeleccionadas.Count;
        }
        public void DeseleccionarTodas ()
        {
            _cancionesSeleccionadas.Clear();    
        }
        public void CargarListadoEneditorListas ()
        {
            if(_cancionesSeleccionadas != null && _cancionesSeleccionadas.Count > 0)
            {
                MainWindow.agregarCancionesListas.AgregarListaCanciones(_cancionesSeleccionadas);
                MainWindow.agregarCancionesListas.Show();
            }
        }
        public void BuscarCancion(string inicialCancion)
        {
            Irg.BuscarCancion(inicialCancion);
        }
        protected string CalcularTiempoConjuntoCanciones(List<Cancion> canciones)
        {
            List<string> paths = canciones.Select(c => c.Path).ToList();
            return ControlTiempoMultimedia.ControlTiempo.DuracionDelConjunto(paths).DuracionLongAStringConDescripcion();
        }
    }
}
