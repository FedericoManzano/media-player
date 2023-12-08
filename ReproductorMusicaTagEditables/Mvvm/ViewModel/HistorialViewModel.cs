using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.Historial;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class HistorialViewModel:ReproductorViewModelBase, IRecolector.IRecolector
    {

        private ObservableCollection<ListaRep> _listasRep;

        public ObservableCollection<ListaRep> ListasRep
        {
            get => _listasRep;
            set
            {
                _listasRep = value;
                OnPropertyChanged(nameof(ListasRep));
            }
        }


        public HistorialViewModel() {
            Irg.TitutloVentana = "Historial";
            _listasRep = new ObservableCollection<ListaRep>();
        }

        public void CargarListasHistorial()
        {
            List<string> listaHistorial = Historial.DameHistorialListas();
            
            foreach (var ln in listaHistorial)
            {
                List<Cancion> lcan = ListasReproduccion.DameListadoCanciones(ln);
                
                ListaRep r = new ListaRep
                {
                    Nombre = ln,
                    CantidadCanciones = lcan.Count + " Canciones",
                    Imagen1 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(lcan.ElementoRandon().Path),
                    Imagen2 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(lcan.ElementoRandon().Path),
                    Imagen3 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(lcan.ElementoRandon().Path),
                    Imagen4 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(lcan.ElementoRandon().Path),
                };
                
                ListasRep.Add(r);
            }
        }

        public void Limpiar()
        {
            ListasRep.Clear();
            System.GC.Collect();
        }
    }
}
