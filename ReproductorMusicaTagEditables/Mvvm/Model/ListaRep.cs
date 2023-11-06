using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.Model
{
    public class ListaRep
    {

        public string Nombre { get; set; }
        public string CantidadCanciones { get; set;}
        public string Duracion { get; set; }

        public ImageBrush Imagen1 { get; set; }
        public ImageBrush Imagen2 { get; set; }
        public ImageBrush Imagen3 { get; set; }
        public ImageBrush Imagen4 { get; set; } 

    }
}
