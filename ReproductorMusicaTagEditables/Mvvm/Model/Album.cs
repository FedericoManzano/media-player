using System;
using System.Collections.Generic;
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
        public string Duracion { get; set; }
        public ulong? DuracionLong { get; set; }
        public ImageBrush Imagen {  get; set; }
        public string PathImagen {  get; set; } 


        public override bool Equals(object otro)
        {
            if (otro == null)
                return false;
            if (otro.GetType() != typeof(Album)) return false;
            if (otro == this) return true;

            Album n = otro as Album;

            return this.Titulo == n.Titulo;
        }

        public int CompareTo(Album other)
        {
            return Titulo.CompareTo(other.Titulo);
        }
        public override int GetHashCode()
        {
            int hashCode = 1963190208;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Artista);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Titulo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Ano);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Genero);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CantidadPistas);
       
            hashCode = hashCode * -1521134295 + EqualityComparer<ImageBrush>.Default.GetHashCode(Imagen);
            return hashCode;
        }
        public override string ToString()
        {
            return $"Artista: {Artista} - Titulo: {Titulo} - Imagen: {Imagen}";
        }
    }
}
