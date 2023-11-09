using MahApps.Metro.IconPacks;
using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info
{
    public partial class InfoReproductor:ViewModelBase
    {

        private static InfoReproductor _ins = null;


        public InfoReproductor()
        {
            TitutloVentana = string.Empty;
            CancionActual = new CancionActual { Index = -1, Cancion = new Cancion() };
            Raiz = string.Empty;
            Preloader = false;
            IconoPlay = PackIconFontAwesomeKind.PlaySolid;

            Paths = new List<string>();
            Canciones = new List<Cancion>();
            CancionesFiltradas = new ObservableCollection<Cancion>();
            Partes = new ObservableCollection<Cancion>();
            Presentacion = new ObservableCollection<Cancion>();
            Albumes = new List<Cancion>();

        }



        public InfoReproductor(
            string tituloVentana, 
            CancionActual cancionActual, 
            string raiz, 
            bool preloader, 
            PackIconFontAwesomeKind iconPlay, 
            List<string> paths, 
            List<Cancion> canciones,
            ObservableCollection<Cancion> cancionesFiltradas, 
            ObservableCollection<Cancion> partes, 
            ObservableCollection<Cancion> presentacion)
        {
            TitutloVentana = tituloVentana;
            CancionActual = cancionActual;
            Raiz = raiz;
            Preloader = preloader;
            IconoPlay = iconPlay;

            Paths = paths;
            Canciones = canciones;
            CancionesFiltradas = cancionesFiltradas;
            Partes = partes;
            Presentacion = presentacion;
        }

        public static InfoReproductor DameInstancia()
        {
            if(_ins == null)
                _ins = new InfoReproductor();
            return _ins;
        }
    }
}
