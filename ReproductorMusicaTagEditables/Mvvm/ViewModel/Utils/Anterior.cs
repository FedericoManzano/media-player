using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils
{
    public class Anterior : AccionReproductor
    {
        public override void Ejecutar(InfoReproductor Irg, Cancion c = null)
        {
            Irg.CancionesFiltradas.Deseleccionar(Irg.CancionActual.Index);
            if (EstadosControl.RANDOM)
            {
                Irg.CancionActual.Index = IndexRandom(Irg);
                Irg.CancionActual.Cancion = Irg.CancionesFiltradas[Irg.CancionActual.Index];
                Irg.CancionesFiltradas.Seleccionar(Irg.CancionActual.Index);
                ReproducirCancion(Irg);
            }
            else if (Irg.CancionesFiltradas.Count > 0 && Irg.CancionActual.Index > 0)
            {
                Irg.CancionActual.Index--;
                Irg.CancionActual.Cancion = Irg.CancionesFiltradas[Irg.CancionActual.Index];
                Irg.CancionesFiltradas.Seleccionar(Irg.CancionActual.Index);
                ReproducirCancion(Irg);
            }
        }
    }
}
