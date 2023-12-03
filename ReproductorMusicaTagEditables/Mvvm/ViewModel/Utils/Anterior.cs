using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System.Windows;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils
{
    public class Anterior : AccionReproductor
    {
        public override void Ejecutar(InfoReproductor Irg, Cancion c = null)
        {
            Irg.Deseleccionar();
           
            if (EstadosControl.RANDOM)
            {
                Irg.CancionActual.Index = IndexRandom(Irg.CancionesFiltradas);
                Irg.CancionActual.Cancion = Irg.CancionesFiltradas[Irg.CancionActual.Index];
                if (!System.IO.File.Exists(Irg.CancionActual.Cancion.Path))
                {
                    MessageBox.Show($"El Archivo {Irg.CancionActual.Cancion.Path} fué eliminado en tiempo de ejecucion.");
                    return;
                }
                Irg.Seleccionar();
                ReproducirCancion(Irg);
            }
            else if (Irg.CancionesFiltradas.Count > 0 && Irg.CancionActual.Index > 0)
            {
                Irg.CancionActual.Index--;
                Irg.CancionActual.Cancion = Irg.CancionesFiltradas[Irg.CancionActual.Index];
                if (!System.IO.File.Exists(Irg.CancionActual.Cancion.Path))
                {
                    MessageBox.Show($"El Archivo {Irg.CancionActual.Cancion.Path} fué eliminado en tiempo de ejecucion.");
                    return;
                }
                Irg.Seleccionar();
                ReproducirCancion(Irg);
            }
            else
            {
                if (EstadosControl.CIRCULOS)
                {
                    Irg.CancionActual.Index = Irg.CancionesFiltradas.Count - 1;
                    Irg.CancionActual.Cancion = Irg.CancionesFiltradas[Irg.CancionActual.Index];
                    if (!System.IO.File.Exists(Irg.CancionActual.Cancion.Path))
                    {
                        MessageBox.Show($"El Archivo {Irg.CancionActual.Cancion.Path} fué eliminado en tiempo de ejecucion.");
                        return;
                    }
                    Irg.Seleccionar();
                    ReproducirCancion(Irg);
                }
            }
            
            ListasReproduccion.AgregarCancionAFavoritos(Irg.CancionActual.Cancion);
        }
    }
}
