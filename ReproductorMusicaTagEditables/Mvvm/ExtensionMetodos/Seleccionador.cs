using ReproductorMusicaTagEditables.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos
{
    public static class Seleccionador
    {

        public static void Seleccionar(this ObservableCollection<Cancion> canciones, int index)
        {
            if (index >= 0)
            {
                Cancion c = canciones[index];
                c.EstadoColor = "Red";
                canciones.RemoveAt(index);
                canciones.Insert(index, c);
            }
        }

        public static void Deseleccionar(this ObservableCollection<Cancion> canciones, int index)
        {
            if (index >= 0)
            {
                Cancion c = canciones[index];
                c.EstadoColor = "White";
                canciones.RemoveAt(index);
                canciones.Insert(index, c);
            }
        }
    }
}
