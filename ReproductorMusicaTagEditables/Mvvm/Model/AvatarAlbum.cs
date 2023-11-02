using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.Model
{
    public class AvatarAlbum : IComparable<AvatarAlbum>
    {

        public string NombreAlbum {  get; set; }
        public string Ano { get; set; }
        public ImageBrush Imagen { get; set; }  
        public string PathImagen { get; set; }



        public int CompareTo(AvatarAlbum other)
        {
            return NombreAlbum.CompareTo(other.NombreAlbum);
        }
    }
}
