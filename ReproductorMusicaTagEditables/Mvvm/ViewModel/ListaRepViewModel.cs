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
    public class ListaRepViewModel:ReproductorViewModelBase
    {
        private ListaRep _listaRep = new ListaRep();

        public ListaRep ListaRep { get => _listaRep; set { _listaRep = value; OnPropertyChanged(nameof(ListaRep)); } }


        private ObservableCollection<Cancion> _presentacionLista = new ObservableCollection<Cancion>();

        public ObservableCollection<Cancion> PresentacionLista 
        { 
            get => _presentacionLista;
            set { _presentacionLista = value; OnPropertyChanged(nameof(PresentacionLista)); } 
        }
        public string FechaCreacion 
        { 
            get => _fechaCreacion; 
            set { _fechaCreacion = value; OnPropertyChanged(nameof(FechaCreacion)); } 
        }

        private string _fechaCreacion = "";

        public void CargarInfoLista(ListaAvatarControl listaAvatarControl)
        {
            ListaRep.Nombre = listaAvatarControl.Nombre;
            ListaRep.CantidadCanciones = listaAvatarControl.Cantidad;
            ListaRep.Duracion = 
                TimeSpan.FromTicks((long) ListasReproduccion.CalcularDuracionLista(ListaRep.Nombre).GetValueOrDefault(0UL)).ToString(@"hh\:mm\:ss");
            ListaRep.Imagen1 = listaAvatarControl.ImagenUno;
            ListaRep.Imagen2 = listaAvatarControl.ImagenDos;
            ListaRep.Imagen3 = listaAvatarControl.ImagenTres;
            ListaRep.Imagen4 = listaAvatarControl.ImagenCuatro;
            ListaRep = new ListaRep()
            {
                Nombre = ListaRep.Nombre,
                CantidadCanciones = ListaRep.CantidadCanciones,
                Duracion = ListaRep.Duracion,
                Imagen1 = ListaRep.Imagen1,
                Imagen2 = ListaRep.Imagen2,
                Imagen3 = ListaRep.Imagen3, 
                Imagen4 = ListaRep.Imagen4,
            };
            FechaCreacion = ListasReproduccion.FechaCreacion(ListaRep.Nombre);
            
            PresentacionLista = new ObservableCollection<Cancion>( ListasReproduccion.DameListadoCanciones(ListaRep.Nombre));

            PresentacionLista = new ObservableCollection<Cancion>(

                   PresentacionLista.Select(c =>
                   {
                       if (c.Titulo == Irg.CancionActual.Cancion.Titulo
                       && c.Artista == Irg.CancionActual.Cancion.Artista
                       && c.Album == Irg.CancionActual.Cancion.Album)
                       {
                           return Irg.CancionActual.Cancion;
                       }
                       return c;
                   }).ToList()

            );
            Irg.CancionesFiltradas = PresentacionLista;
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
                PresentacionLista = PresentacionLista.Deseleccionar();
                Irg.CancionesFiltradas = PresentacionLista;
                Irg.CancionActual.Index = 0;
                Irg.CancionActual.Cancion = Irg.CancionesFiltradas[0];
                PresentacionLista = PresentacionLista.Seleccionar(Irg.CancionActual.Index);
                AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION).Ejecutar(irg, Irg.CancionesFiltradas[0]);
            } else
            {
                Cancion c = (Cancion)obj;
                int index = PresentacionLista.IndexOf(c);
                Irg.Deseleccionar();
                PresentacionLista = PresentacionLista.Deseleccionar();
                Irg.CancionActual.Index = index;
                Irg.CancionActual.Cancion = c;
                PresentacionLista = PresentacionLista.Seleccionar(Irg.CancionActual.Index);
                Irg.CancionesFiltradas = PresentacionLista;

                AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION).Ejecutar(irg, Irg.CancionActual.Cancion);
            }
        }
    }
}
