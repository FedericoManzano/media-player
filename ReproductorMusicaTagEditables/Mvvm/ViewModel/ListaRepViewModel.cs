using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Controls.ListaAvatar;
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class ListaRepViewModel:ReproductorViewModelBase , IRecolector.IRecolector
    {
        private ListaRep _listaRep = new ListaRep();
        public ListaRep ListaRep { get => _listaRep; set { _listaRep = value; OnPropertyChanged(nameof(ListaRep)); } }

        private string _fechaCreacion = "";
        public string FechaCreacion 
        { 
            get => _fechaCreacion; 
            set { _fechaCreacion = value; OnPropertyChanged(nameof(FechaCreacion)); } 
        }

        

        public void CargarInfoLista(ListaAvatarControl listaAvatarControl)
        {
            
            
            ListaRep = new ListaRep()
            {
                Nombre = listaAvatarControl.Nombre,
                CantidadCanciones = listaAvatarControl.Cantidad,
                Duracion = ListasReproduccion.CalcularDuracionLista(listaAvatarControl.Nombre),
                Imagen1 = listaAvatarControl.ImagenUno,
                Imagen2 = listaAvatarControl.ImagenDos,
                Imagen3 = listaAvatarControl.ImagenTres, 
                Imagen4 = listaAvatarControl.ImagenCuatro,
            };

            


            FechaCreacion = ListasReproduccion.FechaCreacion(ListaRep.Nombre);
            
            Irg.Presentacion = new ObservableCollection<Cancion>( ListasReproduccion.DameListadoCanciones(ListaRep.Nombre));

            Irg.Presentacion = new ObservableCollection<Cancion>(

                   Irg.Presentacion.Select(c =>
                   {
                       if (c.Titulo == Irg.CancionActual.Cancion.Titulo
                       && c.Artista == Irg.CancionActual.Cancion.Artista
                       && c.Album == Irg.CancionActual.Cancion.Album)
                       {
                           return Irg.CancionActual.Cancion.Clone();
                       }
                       return c;
                   }).ToList()

            );
            Irg.CancionesFiltradas = Irg.Presentacion;
        }

        public ICommand PlayCommandLista { get; }
        

        public ListaRepViewModel ()
        {
            PlayCommandLista = new RelayCommand(PlayActionLista, CanPlayAction);
        }

        private bool CanPlayAction(object arg)
        {
            return true;
        }

        private void PlayActionLista(object obj)
        {
            if(obj == null)
            {
                Irg.Deseleccionar();

                Irg.CancionesFiltradas = Irg.Presentacion;
                Irg.CancionActual.Index = 0;
                Irg.CancionActual.Cancion = Irg.CancionesFiltradas[0];
                
                AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION).Ejecutar(irg, Irg.CancionesFiltradas[0]);
            } else
            {
                Cancion c = (Cancion)obj;
                int index = Irg.Presentacion.IndexOf(c);
                Irg.Deseleccionar();
                
                Irg.CancionActual.Index = index;
                Irg.CancionActual.Cancion = c;
                Irg.CancionesFiltradas = Irg.Presentacion;

                AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION).Ejecutar(irg, Irg.CancionActual.Cancion);
            }
        }

        public void Limpiar()
        {
   
           ListaRep = new ListaRep();
           System.GC.Collect();
            
        }
    }
}
