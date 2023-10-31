using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.Model
{
    public  struct Album
    {
        public string Artista { get; set; }
        public string Titulo { get; set; }
        public string  Ano{ get; set; }
        public string Genero { get; set;}
        public string CantidadPistas { get; set;}
        public string Duracion { get; set; }
    }
}
