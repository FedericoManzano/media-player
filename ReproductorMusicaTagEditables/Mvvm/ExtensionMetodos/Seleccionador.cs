using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos
{
    public static class Seleccionador
    {
        public static void Seleccionar(this ObservableCollection<Cancion> canciones, ObservableCollection<Cancion> general ,int index)
        {
            if (index >= 0 && index < canciones.Count)
            {
                Cancion c = canciones[index];
                c.EstadoColor = "Red";
                canciones.RemoveAt(index);
                canciones.Insert(index, c);

                for (int i = 0; i < general.Count; i++)
                {
                    if (general[i].Equals(c))
                    {
                        general.RemoveAt(i);
                        general.Insert(i, c);
                    }
                }
            }
        }

        public static void Deseleccionar(this ObservableCollection<Cancion> canciones, ObservableCollection<Cancion> general, int index)
        {
            if (index >= 0 && index < canciones.Count)
            {
                Cancion c = canciones[index];
                c.EstadoColor = "White";
                canciones.RemoveAt(index);
                canciones.Insert(index, c);

                for(int i = 0; i< general.Count; i ++)
                {
                    if (general[i].Equals(c))
                    {
                        general.RemoveAt(i);
                        general.Insert(i, c);
                    }
                }
            }
        }
    }
}
