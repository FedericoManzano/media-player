using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
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

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class InfoAlbumViewModel:ReproductorViewModelBase,IRecolector.IRecolector
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

        public async void CargarInfoAlbum(string album)
        {
            Irg.BtnNavegacion = false;
            Irg.Presentacion = new ObservableCollection<Cancion>(await CargarCancionesAlbum(album));
            AlbumSeleccionado = await CrearInfoAlbum(album);
        }    


        public async Task<List<Cancion>> CargarCancionesAlbum(string titulo)
        {

            List<Cancion> l = await Task<List<Cancion>>.Run(() => { 
                { 
                    return Irg.Canciones
                        .Where(c => c.Album == titulo)
                        .Select(c =>
                        {
                            if (Irg.CancionActual.Cancion != null && c.Equals(Irg.CancionActual.Cancion))
                                return Irg.CancionActual.Cancion.Clone();
                            return c.Clone();
                        }).ToList(); 
                } 
            });
            l.Sort(delegate (Cancion c1, Cancion c2)
            {
                try
                {
                    int numero1 = int.Parse(c1.Numero);
                    int numero2 = int.Parse(c2.Numero);
                    return numero1.CompareTo(numero2);
                }
                catch (FormatException e)
                {
                    return c1.Titulo.CompareTo(c2.Titulo);
                }

            });

            if (l.Count == 0)
            {
                MessageBox.Show($"El álbum que está intentando acceder fué eliminado en tiempo de ejecución");
            }
            return l;
        }

        private async Task<Album> CrearInfoAlbum (string album)
        {
            var uiContext = TaskScheduler.FromCurrentSynchronizationContext();
            Album a =  await Task<Album>.Factory.StartNew(() => 
            {
                
                Cancion c = Irg.Presentacion.Count > 0 ? Irg.Presentacion[0] : new Cancion();
                return new Album
                {
                    Artista = c.Artista,
                    Titulo = album,
                    Ano = c.FechaLanzamiento,
                    Genero = c.Genero,
                    Duracion = Irg.Presentacion.DuracionString(),
                    CantidadPistas = Irg.Presentacion.Count + " Canciones",
                    Imagen = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(c.Path),
                    PathImagen = c.Path
                };
            },CancellationToken.None, TaskCreationOptions.None, uiContext );
            if(a != null)
            {
                Irg.BtnNavegacion = true;
            }
            return a;
        }

        public void Limpiar()
        {
            if (AlbumSeleccionado != null)
            {
                AlbumSeleccionado = new Album()
                {
                    Titulo = AlbumSeleccionado.Titulo,
                    Artista = AlbumSeleccionado.Artista
                };
            }
            Irg.Presentacion = new ObservableCollection<Cancion>();
            System.GC.Collect();
        }
    }
}
