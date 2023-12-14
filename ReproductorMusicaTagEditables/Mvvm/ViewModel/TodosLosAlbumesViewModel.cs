using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.Historial;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class TodosLosAlbumesViewModel:ReproductorViewModelBase
    {

        public static Dictionary<string, Dictionary<string, Cancion>> diccionarioalbumes = 
                    new Dictionary<string, Dictionary<string, Cancion>>();


        public static Dictionary<string, bool> paginacion =
                    new Dictionary<string, bool>();

        public static ObservableCollection<Cancion> _avatarAlbums = 
                    new ObservableCollection<Cancion>();


        public ObservableCollection<Cancion> AvatarAlbums 
        { 
            get => _avatarAlbums; 
            set
            {
                _avatarAlbums = value;
                OnPropertyChanged(nameof(AvatarAlbums));
            } 
        }

        public Dictionary<string, bool> Paginacion 
        { 
            get => paginacion;
            set 
            { 
                paginacion = value;
                OnPropertyChanged(nameof(Paginacion)); 
            } 
        }


        public ICommand PlayCommandAlbum { get; }



        public TodosLosAlbumesViewModel()
        {
            PlayCommandAlbum = new RelayCommand(PlayAlbumAction);
        }

        private void PlayAlbumAction(object obj)
        {
            Cancion c = (Cancion)obj;
            if(c == null) { return; }
            c.Imagen = null;
            List<Cancion> l = Irg.Canciones.Where(cl=>cl.Album == c.Album && c.Artista == cl.Artista).ToList();
            
            if(l.Any())
            {
                OrdenarListadoCanciones(l);
                Irg.CancionesFiltradas = new ObservableCollection<Cancion>(l);

                Irg.Deseleccionar();

                if (EstadosControl.RANDOM)
                {
                    Irg.CancionActual.Index = irg.CancionesFiltradas.IndexRan();
                    Irg.CancionActual.Cancion = Irg.CancionesFiltradas[Irg.CancionActual.Index];
                }
                else
                {
                    Irg.CancionActual.Index = 0;
                    Irg.CancionActual.Cancion = Irg.CancionesFiltradas[0];
                }

                AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION).Ejecutar(Irg, irg.CancionActual.Cancion);
                Historial.AgregarAHistorialAlbumes(GenerarAlbum(Irg.CancionesFiltradas[0]));
            }
            
        }


        private void OrdenarListadoCanciones(List<Cancion> l)
        {
            
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
        }

        public  void CargarAvatarAlbumes()
        {
            Irg.IsMensajeVisible = Visibility.Visible;
            for (int i = 0; i < Irg.Canciones.Count; i ++)
            {
                if (diccionarioalbumes.ContainsKey(Irg.Canciones[i].Album.PrimeraLetraMayuscula()))
                {
                    diccionarioalbumes[Irg.Canciones[i].Album.PrimeraLetraMayuscula()][Irg.Canciones[i].Album] = Irg.Canciones[i];
                }
                else
                {
                    diccionarioalbumes[Irg.Canciones[i].Album.PrimeraLetraMayuscula()] = new Dictionary<string, Cancion>
                    {
                        [Irg.Canciones[i].Album] = Irg.Canciones[i]
                    };
                }
                Paginacion[Irg.Canciones[i].Album.PrimeraLetraMayuscula()] = false;
            }
            if (diccionarioalbumes.Count > 0)
            {
                Paginacion = Paginacion.OrdenarPorClave();
                Paginacion = Paginacion.MarcarClave(Paginacion.Keys.First());
                AvatarAlbums = diccionarioalbumes.CargarImagenes(Paginacion.Keys.First());
                Irg.IsMensajeVisible = Visibility.Collapsed;
            }
        }

        public void BuscarPorAlbum(string inicialAlbum)
        {
            Paginacion = Paginacion.DesmarcarTodos();
            Paginacion = Paginacion.MarcarClave(inicialAlbum);
            AvatarAlbums = diccionarioalbumes.CargarImagenes(inicialAlbum);
        }
    }
}
