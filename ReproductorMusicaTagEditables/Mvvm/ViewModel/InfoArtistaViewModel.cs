using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.Model;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using System.Threading.Tasks;
using System.Windows.Media;
using Reproductor_Musica.Core;
using System.Collections.ObjectModel;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils;
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class InfoArtistaViewModel : ReproductorViewModelBase
    {

        private Artista _artista;
        private List<Album> _albumes;

        public Artista Artista {
            get => _artista;
            set { _artista = value; OnPropertyChanged(nameof(Artista)); }
        }
        public List<Album> Albumes
        {
            get => _albumes;
            set { _albumes = value; OnPropertyChanged(nameof(Album)); }
        }


        public ICommand PlayArtistaCommand { get; }


        public InfoArtistaViewModel()
        {
            PlayArtistaCommand = new RelayCommand(PlayArtistaAction, CanPlayArtistaAction);
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

            Irg.Partes.Deseleccionar(Irg.CancionesFiltradas, Irg.CancionActual.Index);

            PlayAction(Irg.CancionesFiltradas[0]);
        }

        public async void CargarInfoArtista(string artista)
        {
            Albumes = new SortedSet<Album>
            (
                await Task.Run(() =>
                {
                    return irg.Canciones
                       .Where(c => c.Artista == artista)
                       .Select(c =>
                       {
                           return new Album
                           {
                               Artista = c.Artista,
                               Titulo = c.Album,
                               Ano = c.FechaLanzamiento,
                               Genero = c.Genero,
                               DuracionLong = CalcularDuracionAlbum(c.Album),
                               PathImagen = c.Path
                           };
                       }).ToList();
                })
             ).ToList();


            await Task.Run(() => {
                Albumes.Sort(delegate (Album item1, Album item2)
                {
                    return item1.Ano.CompareTo(item2.Ano);
                });
            });

            Artista = new Artista
            {
                Nombre = artista,
                Genero = Albumes[0].Genero,
                CantidadAlbumes = Albumes.Count.ToString() + " Albumes",
                TiempoReproduccion = TiempoTotalDeReproduccion() + " Horas",
                Imagen = DameImagenArtista()
            };

            Albumes = Albumes.Select(a =>
            {
                a.Imagen = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(a.PathImagen);
                return a;
            }).ToList();

        }


        private ulong? CalcularDuracionAlbum(string titulo)
        {
            ulong? ret = 0;
            foreach (Cancion c in Irg.Canciones)
            {
                if (c.Album == titulo)
                {
                    ret += c.DuracionLong;
                }
            }

            return ret;
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
        
        public ImageBrush DameImagenArtista ()
        {
            foreach (Album a in Albumes)
            {
                if(!string.IsNullOrEmpty(a.PathImagen))
                {
                    return ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(a.PathImagen);
                }
            }

            return null;
        }
    }
}
