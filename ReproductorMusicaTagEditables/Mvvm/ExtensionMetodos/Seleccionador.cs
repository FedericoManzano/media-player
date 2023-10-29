using ReproductorMusicaTagEditables.Mvvm.Model;
using System.Collections.ObjectModel;

namespace ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos
{
    public static class Seleccionador
    {

        public static void Seleccionar(this ObservableCollection<Cancion> canciones, int index)
        {
            if (index >= 0 && index < canciones.Count)
            {
                Cancion c = canciones[index];
                c.EstadoColor = "Red";
                canciones.RemoveAt(index);
                canciones.Insert(index, c);
            }
        }

        public static void Deseleccionar(this ObservableCollection<Cancion> canciones, int index)
        {
            if (index >= 0 && index < canciones.Count)
            {
                Cancion c = canciones[index];
                c.EstadoColor = "White";
                canciones.RemoveAt(index);
                canciones.Insert(index, c);
            }
        }
    }
}
