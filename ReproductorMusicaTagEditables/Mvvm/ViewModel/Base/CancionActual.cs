using ReproductorMusicaTagEditables.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base
{
    public class CancionActual
    {
        public int Index { get; set; } = -1;
        public Cancion Cancion { get; set; } = new Cancion()
        {
            Artista = "Descanocido",
            Album = "Desconocido",
            Titulo = "...",
            Path = "",

        };
    }
}
