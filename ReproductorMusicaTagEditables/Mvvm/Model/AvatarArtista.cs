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

        public override bool Equals(object obj)
        {
            if(this == obj) return true;
            if(obj.GetType().Equals(this.GetType())) return true;
            AvatarArtista oth = obj as AvatarArtista;
            return oth.NombreArtista.Equals(this.NombreArtista);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
