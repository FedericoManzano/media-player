using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System.Collections.ObjectModel;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils
{
    public interface IAccionReproductor
    {
        void Ejecutar(InfoReproductor irg,Cancion c = null);
        int IndexRandom(ObservableCollection<Cancion> canciones);
        void ReproducirCancion(InfoReproductor irg);
    }
}
