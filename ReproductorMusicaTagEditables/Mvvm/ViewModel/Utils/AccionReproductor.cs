using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System;
using System.Collections.ObjectModel;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils
{
    public abstract class AccionReproductor : IAccionReproductor
    {

        public static readonly int PLAY_ACCION = 0;
        public static readonly int SIGUIENTE_ACCION = 1;
        public static readonly int ATRAS_ACCION = 2;


        private static readonly IAccionReproductor[] ACCIONES =
        {
            new Play(),
            new Siguiente(),
            new Anterior()
        };


        public abstract void Ejecutar(InfoReproductor irg, Cancion c = null);


        public void ReproducirCancion(InfoReproductor Irg)
        {
            Irg.Reproductor.Source = new Uri(Irg.CancionActual.Cancion.Path);
            Irg.Reproductor.Play();
        }
        public int IndexRandom(ObservableCollection<Cancion> canciones)
        {
            Random r = new Random();
            return r.Next(canciones.Count);
        }


        public static IAccionReproductor Fabrica (int nroAccion)
        {
            if(nroAccion >= 0 && nroAccion < ACCIONES.Length) 
            { 
                return ACCIONES[nroAccion];
            }
            return null;
        }
    }
}
