using ReproductorMusicaTagEditables.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos
{
    public static class Seleccionador
    {
        public static ObservableCollection<Cancion> Seleccionar(this ObservableCollection<Cancion> canciones ,int index)
        {
            if (index >= 0 && index < canciones.Count)
            {
                canciones[index].EstadoColor = "Red";
            }
            return new ObservableCollection<Cancion>( canciones);
        }

        public static ObservableCollection<Cancion> Deseleccionar(this ObservableCollection<Cancion> canciones)
        {
            foreach (var c in canciones)
            {
                c.EstadoColor = "White";
            }
            return canciones;
        }


        public static int IndexRan(this List<Cancion> origen)
        {
            Random r = new Random();
            return r.Next(0,origen.Count);
        }
    }
}
