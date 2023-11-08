using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;

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
            return canciones;
        }

        public static ObservableCollection<Cancion> Deseleccionar(this ObservableCollection<Cancion> canciones)
        {
            foreach (var c in canciones)
            {
                c.EstadoColor = "White";
            }
            return canciones;
        }
    }
}
