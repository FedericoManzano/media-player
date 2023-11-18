
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;

namespace ReproductorMusicaTagEditables.Mvvm.Model
{
    public class Cancion : IComparable<Cancion>
    {
        public static readonly string COLOR_TEXTO_DEFAULT = "White";
        public string Numero { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Artista { get; set; } = string.Empty;
        public string Album { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Duracion { get; set; } = string.Empty;
        public string FechaLanzamiento { get; set; } = string.Empty;
        public string EstadoColor { get; set; } = COLOR_TEXTO_DEFAULT;
        public ulong? DuracionLong { get; set; } = 0;
        public ImageBrush Imagen { get; set; }
        public int Cantidad { get; set; } = 0;

        public Cancion()
        {
            Numero = string.Empty;
            Titulo = string.Empty;
            Artista = string.Empty;
            Album = string.Empty;
            Path = string.Empty;
            Duracion = string.Empty;
            FechaLanzamiento = string.Empty;
            EstadoColor = COLOR_TEXTO_DEFAULT;
        }

        public Cancion(Cancion c)
        {
            Numero = c.Numero;
            Titulo = c.Titulo;
            Artista = c.Artista;
            Album = c.Album;
            Path = c.Path;
            FechaLanzamiento = c.FechaLanzamiento;
            Duracion = c.Duracion;
            DuracionLong = c.DuracionLong;
            EstadoColor = c.EstadoColor;
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
                    Artista = ExtraerArtista(tag).Longitud(20),
                    Genero = ExtraerGenero(tag).Longitud(20),
                    Album = ExtraerAlbum(tag).Longitud(20),
                    DuracionLong = this.DuracionLong(path),
                    Duracion = TimeSpan.FromTicks((long) CalculoTiempo.CalculoTiempo.CalcularDuracionCancion(path).GetValueOrDefault(0UL)).ToString(@"mm\:ss"),
                    FechaLanzamiento = ExtraerFechaLanzamiento(tag),
                    EstadoColor = COLOR_TEXTO_DEFAULT,
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
            string tit = tag.Tag.Artists != null && tag.Tag.Artists.Length > 0 ? tag.Tag.Artists[0]: "Desconocido";
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
            return tit;
        }
        private string ExtraerGenero(TagLib.File tag)
        {
            string tit = tag.Tag.Genres != null && tag.Tag.Genres.Length > 0? tag.Tag.Genres[0] : "Desconocido";
            return tit;
        }
        private string ExtraerAlbum(TagLib.File tag)
        {
            string tit = tag.Tag.Album ?? "Desconocido";
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
                Album = this.Album,
                Titulo = this.Titulo,
                Numero = this.Numero,
                Genero = this.Genero,
                FechaLanzamiento = this.FechaLanzamiento,
                Duracion = this.Duracion,
                DuracionLong = this.DuracionLong,
                EstadoColor = this.EstadoColor,
                Cantidad = this.Cantidad,
            };
        }
        public override bool Equals(object obj)
        {
            if(obj.GetType() != typeof(Cancion)) return false;
            if(obj == this) return true;

            Cancion n = obj as Cancion;

            return
                this.Titulo == n.Titulo &&
                this.Artista == n.Artista &&
                this.Album == n.Album;
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
        public int CompareTo(Cancion other)
        {
            return Album.CompareTo(other.Album);
        }
    }
}
