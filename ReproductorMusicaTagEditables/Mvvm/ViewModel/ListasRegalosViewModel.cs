using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.Historial;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class ListasRegalosViewModel: ReproductorViewModelBase, IRecolector.IRecolector
    {
        private ObservableCollection<Cancion> _cancions;
        public ObservableCollection<Cancion> Cancions 
        { 
            get => _cancions;
            set { _cancions = value; OnPropertyChanged(nameof(Cancions)); } 
        }

        

        private ListaRep _listaRep;
        public ListaRep ListaRep 
        { 
            get => _listaRep;
            set { _listaRep = value; OnPropertyChanged(nameof(ListaRep)); }
        }


        private string _fechaCreacion;
        public string FechaCreacion { get => _fechaCreacion; set { _fechaCreacion = value; OnPropertyChanged(nameof(FechaCreacion)); } }


        public ICommand PlayRegalo { get; }

        public ListasRegalosViewModel()
        {
            _cancions = new ObservableCollection<Cancion>();
            _listaRep = new ListaRep();
            _fechaCreacion = "";
            PlayRegalo = new RelayCommand(PlayRegaloAction);
        }

        private void PlayRegaloAction(object obj)
        {
            Irg.Deseleccionar();
            Irg.CancionesFiltradas = Irg.Presentacion;
            if (obj == null)
            {
                if (EstadosControl.RANDOM)
                {
                    Irg.CancionActual.Index = Irg.CancionesFiltradas.IndexRan();
                    Irg.CancionActual.Cancion = Irg.CancionesFiltradas[Irg.CancionActual.Index];
                } else
                {
                    Irg.CancionActual.Index = 0;
                    Irg.CancionActual.Cancion = Irg.CancionesFiltradas[0];
                }
            }
            else
            {
                Cancion c = (Cancion)obj;
                int index = Irg.CancionesFiltradas.IndexOf(c);

                Irg.CancionActual.Index = index;
                Irg.CancionActual.Cancion = c;
            }
            AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION)
                        .Ejecutar(irg, Irg.CancionActual.Cancion);
            GuardarHistorial(ListaRep.Nombre, Irg.CancionActual.Cancion);
        }

        private void GuardarHistorial(string nombreLista, Cancion cancionActual)
        {
            Historial.AgregarAHistorialListas(nombreLista.DameConFormatoFecha());
            Historial.AgregarAHistorialAlbumes(GenerarAlbum(cancionActual));
        }

        public void CargarPaginaListadosRegalos(string nombreRegalo)
        {
            Irg.Presentacion = new ObservableCollection<Cancion>( ListasReproduccion.DameListadoRegalo(nombreRegalo));
            Irg.Presentacion = new ObservableCollection<Cancion>(Irg.Presentacion.Select(c =>
            {
                if (c.Equals(Irg.CancionActual.Cancion))
                    return Irg.CancionActual.Cancion;
                c.EstadoColor = "White";
                return c;
            }).ToList());

            ListaRep = new ListaRep()
            {
                Nombre = nombreRegalo,
                Duracion = Irg.Presentacion.DuracionString(),
                Imagen1 = DameImagen(0,Irg.Presentacion.ToList()),
                Imagen2 = DameImagen(1, Irg.Presentacion.ToList()),
                Imagen3 = DameImagen(2, Irg.Presentacion.ToList()),
                Imagen4 = DameImagen(3, Irg.Presentacion.ToList()),
                CantidadCanciones = Irg.Presentacion.Count + " Canciones"
            };

            FechaCreacion = ListasReproduccion.FechaCreacionDelRegalo(nombreRegalo);
        }

        private ImageBrush DameImagen(int index, List<Cancion> listado)
        {
            if (listado == null)
                return ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
            if (index >= listado.Count || index < 0)
                return ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
            return ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(listado[index].Path);
        }

        public void Limpiar()
        {
            _listaRep = new ListaRep();
            Cancions.Clear();
            System.GC.Collect();
        }
    }
}
