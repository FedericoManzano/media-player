using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.Historial;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class InfoArtistaViewModel : ReproductorViewModelBase, IRecolector.IRecolector
    {
        private Artista _artista;
       
        private List<Cancion>_albumes = new List<Cancion>();

        

        public Artista Artista
        {
            get => _artista;
            set { _artista = value; OnPropertyChanged(nameof(Artista)); }
        }
        
        public ICommand PlayArtistaCommand { get; }

        public ICommand PlayAlbumCommand { get; }
        public List<Cancion> Albumes 
        {
            get => _albumes; 
            set { _albumes = value; OnPropertyChanged(nameof(Albumes)); } 
        }

        public InfoArtistaViewModel()
        {
            PlayArtistaCommand = new RelayCommand(PlayArtistaAction, CanPlayArtistaAction);
            PlayAlbumCommand = new RelayCommand(PlayAlbumAction);
        }

        private void PlayAlbumAction(object obj)
        {
            if (obj != null)
            {
                Cancion a = (Cancion)obj;
                Irg.CancionesFiltradas = new ObservableCollection<Cancion>
                    (
                        Irg.Canciones.Where(c => c.Album == a.Album).ToList()
                    );

                if (Irg.CancionesFiltradas.Any())
                {
                    Irg.Deseleccionar();

                    if (EstadosControl.RANDOM)
                    {
                        Irg.CancionActual.Index = Irg.CancionesFiltradas.IndexRan();
                        Irg.CancionActual.Cancion = Irg.CancionesFiltradas[Irg.CancionActual.Index];
                    }
                    else
                    {
                        Irg.CancionActual.Index = 0;
                        Irg.CancionActual.Cancion = Irg.CancionesFiltradas[Irg.CancionActual.Index];
                    }

                    AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION).Ejecutar(irg, Irg.CancionActual.Cancion);
                    ScrollVertical = irg.SetScroll();
                    Historial.AgregarAHistorialAlbumes(GenerarAlbum(Irg.CancionActual.Cancion));
                }
            }
        }

        private bool CanPlayArtistaAction(object arg)
        {
            return Irg.Canciones.Count > 0;
        }

        private async void PlayArtistaAction(object obj)
        {
            Irg.CancionesFiltradas = new ObservableCollection<Cancion>(await Task.Run(() =>
            {
                return Irg.Canciones.Where(c => c.Artista == Artista.Nombre).ToList();
            }));
            if (Irg.CancionesFiltradas.Any())
            {
                Irg.Deseleccionar();
                if (EstadosControl.RANDOM)
                {
                    Irg.CancionActual.Index = Irg.CancionesFiltradas.IndexRan();
                    Irg.CancionActual.Cancion = Irg.CancionesFiltradas[Irg.CancionActual.Index];
                }
                else
                {
                    Irg.CancionActual.Index = 0;
                    Irg.CancionActual.Cancion = Irg.CancionesFiltradas[0];
                }
                AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION).Ejecutar(irg, Irg.CancionActual.Cancion);
                Historial.AgregarAHistorialAlbumes(GenerarAlbum(Irg.CancionActual.Cancion));
            }
        }

        public async void CargarInfoArtista(string artista)
        {
            Irg.BtnNavegacion = false;
            Albumes =  await CargarListadoAlbumes(artista);

            if (Albumes.Count == 0)
            {
                MessageBox.Show($"El artista que está intentando acceder fue eliminado en tiempo de ejecución.");
            }

            OrdenarPorFechaAlbumes();

            Artista = await BuildArtista(artista);      
        }

        private async Task<Artista> BuildArtista(string artista)
        {
            var uiContext = TaskScheduler.FromCurrentSynchronizationContext();

            Artista a =  await Task<Artista>.Factory.StartNew(()=> {
               return new Artista()
               {
                   Nombre = artista,
                   Genero = Albumes != null && Albumes.Count > 0 ? Albumes[0].Genero : "",
                   CantidadAlbumes = Albumes.Count.ToString() + " Albumes",
                   TiempoReproduccion = TiempoTotalDeReproduccion(),
                   Imagen = DameImagenArtista()
               };
                
                
            }, CancellationToken.None, TaskCreationOptions.None, uiContext);
            if (a != null)
                Irg.BtnNavegacion = true;
            return a;
        }

        private async void OrdenarPorFechaAlbumes()
        {
            await Task.Run(() =>
            {
                Albumes.Sort(delegate (Cancion item1, Cancion item2)
                {
                    return item1.FechaLanzamiento.CompareTo(item2.FechaLanzamiento);
                });
            });
        }

        private async Task<List<Cancion>> CargarListadoAlbumes (string artista)
        {
            var uiContext = TaskScheduler.FromCurrentSynchronizationContext();
            return new SortedSet<Cancion>
            (
                await Task<List<Cancion>>.Factory.StartNew(() =>
                {
                    return Irg.Canciones
                       .Where(c => c.Artista == artista && System.IO.File.Exists(c.Path))
                       .Select(c =>
                       {
                           Cancion cc = c.Clone();
                           cc.Imagen = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(c.Path) ??
                                ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
                           return cc;


                       }).ToList();
                }, CancellationToken.None, TaskCreationOptions.None, uiContext)
             ).ToList();

            
        }

        private string TiempoTotalDeReproduccion()
        {
            ulong? tiempoTotalRepro = 0;
            foreach (Cancion album in Albumes)
            {
                tiempoTotalRepro += album.DuracionAlbum();
            }

            return tiempoTotalRepro.DuracionString(@"hh\:mm\:ss");
        }

        public ImageBrush DameImagenArtista()
        {
            foreach (Cancion a in Albumes)
            {
                if (!string.IsNullOrEmpty(a.Path))
                {
                    return ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(a.Path) ??
                        ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
                }
            }

            return null;
        }

        public void Limpiar()
        {
            lock(Irg.Presentacion)
            {
                if (Artista != null)
                {
                    Artista = new Artista()
                    {
                        Nombre = Artista.Nombre,
                    };
                }
                Albumes = new System.Collections.Generic.List<Model.Cancion>();
                System.GC.Collect();
            }
        }
    }
}
