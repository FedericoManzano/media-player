using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class InfoAlbumViewModel:ReproductorViewModelBase
    {

        private Album _album;

        public Album AlbumSeleccionado 
        { 
            get => _album; 
            set 
            { 
                _album = value;
                OnPropertyChanged(nameof(AlbumSeleccionado));
            } 
        }

        public ICommand PlayAlbumCommand { get; }


        public InfoAlbumViewModel ()
        {
            PlayAlbumCommand = new RelayCommand(PlayAlbumAction);
        }

        public void PlayAlbumAction(object obj = null)
        {
            if(obj != null)
            {
                Cancion c = (Cancion)obj;
                int index = Irg.Presentacion.IndexOf(c);
                Irg.Deseleccionar();
                Irg.CancionActual.Index = index;
                Irg.CancionActual.Cancion = c;
                Irg.CancionesFiltradas = Irg.Presentacion;
                AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION).Ejecutar(irg, Irg.CancionActual.Cancion);
            }
            else
            {
                Irg.Deseleccionar();
                Irg.CancionesFiltradas = Irg.Presentacion;
                Irg.CancionActual.Index = 0;
                Irg.CancionActual.Cancion = Irg.CancionesFiltradas[0];
                AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION).Ejecutar(irg, Irg.CancionesFiltradas[0]);
            }
        }

        public void CargarInfoAlbum(string album)
        {
            Irg.CargarCancionesAlbum(album);
            ulong? duracion = Irg.CalcularDuracionAlbum(album);

            if (Irg.Presentacion.Count > 0) 
            {
                AlbumSeleccionado = new Album
                {
                    Artista = Irg.Presentacion[0].Artista,
                    Titulo = album,
                    Ano = Irg.Presentacion[0].FechaLanzamiento,
                    Genero = Irg.Presentacion[0].Genero,
                    DuracionLong = duracion,
                    Duracion = TimeSpan.FromTicks((long)duracion.GetValueOrDefault(0UL)).ToString(@"hh\:mm\:ss") + " Horas",
                    CantidadPistas = Irg.Presentacion.Count + " Canciones",
                    Imagen = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(Irg.Presentacion[0].Path),
                    PathImagen = Irg.Presentacion[0].Path
                };
            }
        }
    }
}
