using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class InfoArtistaViewModel : ReproductorViewModelBase
    {

        private Artista _artista;
        public static List<Album> _albumes = new List<Album>();

        public Artista Artista
        {
            get => _artista;
            set { _artista = value; OnPropertyChanged(nameof(Artista)); }
        }
        public List<Album> Albumes
        {
            get => _albumes;
            set { _albumes = value; OnPropertyChanged(nameof(Albumes)); }
        }


        public ICommand PlayArtistaCommand { get; }

        public ICommand PlayAlbumCommand { get; }
        public InfoArtistaViewModel()
        {
            PlayArtistaCommand = new RelayCommand(PlayArtistaAction, CanPlayArtistaAction);
            PlayAlbumCommand = new RelayCommand(PlayAlbumAction);
        }

        private void PlayAlbumAction(object obj)
        {
            if (obj != null)
            {
                Album a = (Album)obj;
                Irg.CancionesFiltradas = new ObservableCollection<Cancion>
                    (
                        Irg.Canciones.Where(c => c.Album == a.Titulo).ToList()
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
            Albumes = await Irg.CargarListaAlbumes(artista);

            if(Albumes.Count == 0)
            {
                MessageBox.Show($"El artista que está intentando acceder fue eliminado en tiempo de ejecución.");
            }
            await Task.Run(() =>
            {
                Albumes.Sort(delegate (Album item1, Album item2)
                {
                    return item1.Ano.CompareTo(item2.Ano);
                });
            });

            Artista = new Artista
            {
                Nombre = artista,
                Genero = Albumes != null && Albumes.Count>0 ? Albumes[0].Genero : "",
                CantidadAlbumes = Albumes.Count.ToString() + " Albumes",
                TiempoReproduccion = TiempoTotalDeReproduccion() + " Horas",
                Imagen = DameImagenArtista()
            };

            Albumes = Albumes.Select(a =>
            {
                a.Imagen = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(a.PathImagen) ??
                            ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
                return a;
            }).ToList();

        }

        private string TiempoTotalDeReproduccion()
        {
            ulong? tiempoTotalRepro = 0;
            foreach (Album album in Albumes)
            {
                tiempoTotalRepro += album.DuracionLong;
            }
            return TimeSpan.FromTicks((long)tiempoTotalRepro.GetValueOrDefault(0UL)).ToString(@"hh\:mm\:ss");
        }

        public ImageBrush DameImagenArtista()
        {
            foreach (Album a in Albumes)
            {
                if (!string.IsNullOrEmpty(a.PathImagen))
                {
                    return ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(a.PathImagen) ??
                        ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
                }
            }

            return null;
        }
    }
}
