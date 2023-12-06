using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System.Collections.Generic;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class FavoritosViewModel:ReproductorViewModelBase
    {
        private ListaRep _listaRep = new ListaRep();
        public ListaRep ListaRep { 
            get => _listaRep; 
            set { _listaRep = value; OnPropertyChanged(nameof(ListaRep)); } 
        }
        public void CrearAvatarFavoritos()
        {
            List<Cancion> l = ListasReproduccion.DameListatoFavoritos();
            
            if( l.Count >= 4 )
            {
                ListaRep = new ListaRep()
                {
                    Nombre = "FAVORITOS",
                    CantidadCanciones = l.Count.ToString() + " Canciones",
                    Imagen1 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(l[0].Path),
                    Imagen2 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(l[1].Path),
                    Imagen3 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(l[2].Path),
                    Imagen4 = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(l[3].Path),
                };


            }else
            {
                ListaRep = new ListaRep()
                {
                    Nombre = "FAVORITOS",
                    CantidadCanciones = l.Count.ToString() + " Canciones",
                };
            }
        }
    }
}
