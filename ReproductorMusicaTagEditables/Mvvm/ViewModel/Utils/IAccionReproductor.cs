using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils
{
    public interface IAccionReproductor
    {
        void Ejecutar(InfoReproductor Irg, Cancion c = null);
        int IndexRandom(InfoReproductor Irg);
        void ReproducirCancion(InfoReproductor Irg);


    }
}
