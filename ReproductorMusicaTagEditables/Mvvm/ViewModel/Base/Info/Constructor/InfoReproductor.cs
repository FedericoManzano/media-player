using MahApps.Metro.IconPacks;
using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info
{
    public partial class InfoReproductor:ViewModelBase
    {

        private static InfoReproductor _ins = null;


        public InfoReproductor()
        {
            TitutloVentana = string.Empty;
            CancionActual = new CancionActual();
            Raiz = string.Empty;
            Preloader = false;
            IconoPlay = PackIconFontAwesomeKind.PlaySolid;

            Paths = new List<string>();
            Canciones = new List<Cancion>();
            CancionesFiltradas = new ObservableCollection<Cancion>();
            Partes = new ObservableCollection<Cancion>();
            Presentacion = new ObservableCollection<Cancion>();
        }     

        public static InfoReproductor DameInstancia()
        {
            if(_ins == null)
                _ins = new InfoReproductor();
            return _ins;
        }

        public Cancion DameCancionPorClave(Cancion c)
        {
          
            foreach(Cancion cl in Canciones)
            {
                if (cl.Titulo == c.Titulo && cl.Album == c.Album && cl.Artista == c.Artista)
                    return cl;
            }
            return c;
        }
    }
}
