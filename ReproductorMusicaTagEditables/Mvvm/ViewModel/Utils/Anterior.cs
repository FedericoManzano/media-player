using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils
{
    public class Anterior : AccionReproductor
    {
        public override void Ejecutar(InfoReproductor Irg, Cancion c = null)
        {
            Irg.Deseleccionar();
           
            if (EstadosControl.RANDOM)
            {
                Irg.CancionActual.Cancion = Irg.CancionesFiltradas[Irg.CancionActual.Index];
                Irg.Seleccionar();
                ReproducirCancion(Irg);
            }
            else if (Irg.CancionesFiltradas.Count > 0 && Irg.CancionActual.Index > 0)
            {
                Irg.CancionActual.Index--;
                Irg.CancionActual.Cancion = Irg.CancionesFiltradas[Irg.CancionActual.Index];
                Irg.Seleccionar();
                ReproducirCancion(Irg);
            }
        }
    }
}
