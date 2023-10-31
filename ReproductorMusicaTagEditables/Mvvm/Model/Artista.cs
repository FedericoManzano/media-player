using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.Model
{
    public struct Artista
    {
        public string Nombre { get; set;}
        public string Genero { get; set; }
        public string CantidadAlbumes { get; set; }
        public string TiempoReproduccion {  get; set; }
    }
}
