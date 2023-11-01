using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.Model
{
    public  class Album:IComparable<Album>
    {
        public string Artista { get; set; }
        public string Titulo { get; set; }
        public string  Ano{ get; set; }
        public string Genero { get; set;}
        public string CantidadPistas { get; set;}
        public ulong? Duracion { get; set; }
        public ulong? DuracionLong { get; set; }
        public ImageBrush Imagen {  get; set; }
        public string PathImagen {  get; set; } 

        public int CompareTo(Album other)
        {
            return Titulo.CompareTo(other.Titulo);
        }

      //  public override bool Equals(object obj)
       // {
         //   Album a = (Album) obj;
           // return Titulo.Equals(a.Titulo);
        //}

        public override int GetHashCode()
        {
            int hashCode = 1963190208;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Artista);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Titulo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Ano);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Genero);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CantidadPistas);
            hashCode = hashCode * -1521134295 + Duracion.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ImageBrush>.Default.GetHashCode(Imagen);
            return hashCode;
        }

        public override string ToString()
        {
            return $"Artista: {Artista} - Titulo: {Titulo} - Imagen: {Imagen}";
        }
    }
}
