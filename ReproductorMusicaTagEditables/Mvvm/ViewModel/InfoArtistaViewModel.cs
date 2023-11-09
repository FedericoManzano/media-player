using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Controls.InfoArtista;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaInicial;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils;
using System;
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
                Irg.Deseleccionar();
                AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION).Ejecutar(irg, Irg.CancionesFiltradas[0]);
                ScrollVertical = irg.SetScroll();
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

            Irg.Deseleccionar();

            AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION).Ejecutar(irg, Irg.CancionesFiltradas[0]);
        }

        public async void CargarInfoArtista(string artista)
        {
            Albumes =  await Irg.CargarListaAlbumes(artista);
            
            if (Albumes.Count == 0)
            {
                MessageBox.Show($"El artista que está intentando acceder fue eliminado en tiempo de ejecución.");
            }
            await Task.Run(() =>
            {
                Albumes.Sort(delegate (Cancion item1, Cancion item2)
                {
                    return item1.FechaLanzamiento.CompareTo(item2.FechaLanzamiento);
                });
            });

            Artista = new Artista
            {
                Nombre = artista,
                Genero = Albumes != null && Albumes.Count > 0 ? Albumes[0].Genero : "",
                CantidadAlbumes = Albumes.Count.ToString() + " Albumes",
                TiempoReproduccion = TiempoTotalDeReproduccion() + " Horas",
                Imagen = DameImagenArtista()
            };       
        }

        private string TiempoTotalDeReproduccion()
        {
            ulong? tiempoTotalRepro = 0;
            foreach (Cancion album in Albumes)
            {
                tiempoTotalRepro += album.DuracionLong;
            }
            return TimeSpan.FromTicks((long)tiempoTotalRepro.GetValueOrDefault(0UL)).ToString(@"hh\:mm\:ss");
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
