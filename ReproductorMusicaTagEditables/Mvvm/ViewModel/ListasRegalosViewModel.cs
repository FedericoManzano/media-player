using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class ListasRegalosViewModel: ReproductorViewModelBase, IRecolector.IRecolector
    {
        private ObservableCollection<Cancion> _cancions = new ObservableCollection<Cancion>();

        public ObservableCollection<Cancion> Cancions 
        { 
            get => _cancions;
            set { _cancions = value; OnPropertyChanged(nameof(Cancions)); } 
        }

        

        private ListaRep _listaRep = new ListaRep();
        public ListaRep ListaRep 
        { 
            get => _listaRep;
            set { _listaRep = value; OnPropertyChanged(nameof(ListaRep)); }
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
                Imagen1 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(Irg.Presentacion[0].Path) ??
                            ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen(),
                Imagen2 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(Irg.Presentacion[1].Path) ??
                            ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen(),
                Imagen3 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(Irg.Presentacion[2].Path) ??
                            ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen(),
                Imagen4 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(Irg.Presentacion[3].Path) ??
                            ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen(),
                CantidadCanciones = Irg.Presentacion.Count + " Canciones"
            };
        }



        public void Limpiar()
        {
            _listaRep = new ListaRep();
            Cancions.Clear();
            System.GC.Collect();
        }
    }
}
