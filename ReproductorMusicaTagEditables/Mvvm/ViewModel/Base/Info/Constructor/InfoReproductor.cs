using MahApps.Metro.IconPacks;
using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info
{
    public partial class InfoReproductor:ViewModelBase
    {
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
        }
    }
}
