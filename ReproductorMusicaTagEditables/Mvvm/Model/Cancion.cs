
using System;
using System.Collections.Generic;
using System.IO;

namespace ReproductorMusicaTagEditables.Mvvm.Model
{
    public class Cancion
    {
        public string Numero { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Artista { get; set; } = string.Empty;
        public string Album { get; set; } = string.Empty;
        public string Genero { get; set;} = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Duracion { get; set; } = string.Empty;
        public string FechaLanzamiento { get; set;} = string.Empty;



        public Cancion()
        {
            Numero = string.Empty;
            Titulo = string.Empty;
            Artista = string.Empty;
            Album = string.Empty;
            Path = string.Empty;
            Duracion = string.Empty;
            FechaLanzamiento = string.Empty;
        }


        public Cancion CrearCancion(string path)
        {
            if(System.IO.File.Exists(path))
            {
                var tag = TagLib.File.Create(path);
                return new Cancion
                {
                    Path = path,
                    Numero = ExtraerNumero(tag),
                    Titulo = ExtraerTitulo(tag, path),
                    Artista = ExtraerArtista(tag),
                    Genero = ExtraerGenero(tag),
                    Album = ExtraerAlbum(tag),
                    Duracion = ExtraerDuracion(tag),
                    FechaLanzamiento = ExtraerFechaLanzamiento(tag),
                };
            }
            return null;
        }

        private string ExtraerNumero(TagLib.File tag)
        {
            string num = tag.Tag.Track > 0 ? tag.Tag.Track.ToString() : string.Empty;
            return num;
        }
        private string ExtraerTitulo(TagLib.File tag, string path)
        {

            string tit = tag.Tag.Title ?? string.Empty;
            if(tit == string.Empty)
            {
                FileInfo fi = new FileInfo(path);
                return System.IO.Path.GetFileNameWithoutExtension(fi.Name);
            }
            return tit;
        }
        private string ExtraerArtista(TagLib.File tag)
        {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
            string tit = tag.Tag.Artists != null && tag.Tag.Artists.Length > 0 ? tag.Tag.Artists[0]: string.Empty;
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
            return tit;
        }
        private string ExtraerGenero(TagLib.File tag)
        {
            string tit = tag.Tag.Genres != null ? tag.Tag.Genres[0] : string.Empty;
            return tit;
        }
        private string ExtraerAlbum(TagLib.File tag)
        {
            string tit = tag.Tag.Album ?? string.Empty;
            return tit;
        }
        private string ExtraerDuracion(TagLib.File tag)
        {
            string tit = tag.Tag.Length ?? string.Empty;
            return tit;
        }
        private string ExtraerFechaLanzamiento (TagLib.File tag)
        {
            return tag.Tag.Year.ToString();
        }
        public Cancion Clone()
        {
            return new Cancion
            {
                Path = this.Path,
                Artista = this.Artista,
                Titulo = this.Titulo,
                Numero = this.Numero,
                Genero = this.Genero,
                FechaLanzamiento = this.FechaLanzamiento,
                Duracion = this.Duracion,
            };
        }
        public override bool Equals(object obj)
        {
            if(obj.GetType() != typeof(Cancion)) return false;
            if(obj == this) return true;
            return this.Path == ((Cancion) obj).Path;
        }
        public override int GetHashCode()
        {
            int hashCode = 236998955;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Numero);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Titulo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Artista);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Album);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Genero);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Path);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FechaLanzamiento);
            return hashCode;
        }
        public override string ToString()
        {
            return string.Format($"Número: {Numero}" + Environment.NewLine + $"Título: {Titulo}" + Environment.NewLine + $"Artista: {Artista}" + Environment.NewLine + $"Album: {Album}" + Environment.NewLine + $"Género: {Genero}" + Environment.NewLine + $"Fecha de Lanzamiento: {FechaLanzamiento}" + Environment.NewLine + $"Duración {Duracion}" + Environment.NewLine);
        }
    }
}
