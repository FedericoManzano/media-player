using System;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.Model
{
    public class AvatarArtista:IComparable<AvatarArtista>
    {
        public string NombreArtista { get; set; }
        public ImageBrush ImagenArtista {  get; set; }
        public string PathImagen { get; set; }

        public int CompareTo(AvatarArtista other)
        {
            return this.NombreArtista.CompareTo(other.NombreArtista);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
