using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos
{
    public static class ReproductorViewModel
    {
        public static Cancion CancionActual(this ReproductorViewModelBase origen)
        {
            return origen.Irg.CancionActual.Cancion;
        }


        public static int CancionSeleccionada(this ReproductorViewModelBase origen)
        {
            return origen.Irg.CancionActual.Index;
        }


        public static string ArtistaActual(this ReproductorViewModelBase origen)
        {
            Cancion c = origen.Irg.CancionActual.Cancion;

            if(c != null)
            {
                return string.IsNullOrEmpty(c.Artista) ? "Desconocido" : c.Artista;
            }
            else
            {
                return "Desconocido";
            } 
        }


        public static string AlbumActual(this ReproductorViewModelBase origen)
        {
            Cancion c = origen.Irg.CancionActual.Cancion;

            if (c != null)
            {
                return string.IsNullOrEmpty(c.Album) ? "Desconocido" : c.Album;
            }
            else
            {
                return "Desconocido";
            }
        }


        public static string TituloActual(this ReproductorViewModelBase origen)
        {
            Cancion c = origen.Irg.CancionActual.Cancion;

            if (c != null)
            {
                return string.IsNullOrEmpty(c.Titulo) ? "..." : c.Titulo;
            }
            else
            {
                return "...";
            }
        }

    }
}
