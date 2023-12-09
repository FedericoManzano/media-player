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
        private ObservableCollection<Album> _listasAlbumes;
        public ObservableCollection<ListaRep> ListasRep
        {
            get => _listasRep;
            set
            {
                _listasRep = value;
                OnPropertyChanged(nameof(ListasRep));
            }
        }
        public ObservableCollection<Album> ListasAlbumes
        {
            get => _listasAlbumes;
            set
            {
                _listasAlbumes = value;
                OnPropertyChanged(nameof(ListasAlbumes));
            }
        }

        public HistorialViewModel() {
            Irg.TitutloVentana = "Historial";
            _listasRep = new ObservableCollection<ListaRep>();
            _listasAlbumes = new ObservableCollection<Album>();
        }

        public void CargarListasHistorial()
        {
            List<string> listaHistorial = Historial.DameHistorialListas();
            
            foreach (var ln in listaHistorial)
            {
                List<Cancion> lcan = ListasReproduccion.DameListadoCanciones(ln);

                if (lcan.Any())
                {
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
        }

        public void CargarAlbumesHistorial()
        {
            List<Album> la = Historial.DameHistorialAlbum();

            if (la.Any())
            {
                foreach (var al in la)
                {
                    al.Imagen = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(al.PathImagen) ??
                                ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
                    ListasAlbumes.Add(al);
                }
            }
        }

        public void Limpiar()
        {
            ListasRep.Clear();
            ListasAlbumes.Clear();
            System.GC.Collect();
        }
    }
}
