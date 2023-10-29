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

    }
}
