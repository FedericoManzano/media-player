
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System.Collections.ObjectModel;


namespace ReproductorMusicaTagEditables.Mvvm.Repository.Navegacion
{
    public class InfoNavegacion
    {
        public CancionActual CancionActual { get; set; } = new CancionActual();
        public int PaginaActual { get; set; } = 0;
        public ObservableCollection<Cancion> CancionesFiltradas { get; set; } = new ObservableCollection<Cancion>();

    }
}
