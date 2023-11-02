

using ReproductorMusicaTagEditables.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Query.Dynamic;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info
{
    public partial class InfoReproductor
    {
        public async Task<List<Album>> CargarListaAlbumes(string artista)
        {
            return new SortedSet<Album>
            (
                await Task.Run(() =>
                {
                    return Canciones
                       .Where(c => c.Artista == artista && System.IO.File.Exists(c.Path))
                       .Select(c =>
                       {
                           return new Album
                           {
                               Artista = c.Artista,
                               Titulo = c.Album,
                               Ano = c.FechaLanzamiento,
                               Genero = c.Genero,
                               DuracionLong = CalcularDuracionAlbum(c.Album),
                               PathImagen = c.Path
                           };
                       }).ToList();
                })
             ).ToList();
        }

        public ulong? CalcularDuracionAlbum(string titulo)
        {
            ulong? ret = 0;
            foreach (Cancion c in Canciones)
            {
                if (c.Album == titulo)
                {
                    ret += c.DuracionLong;
                }
            }
            return ret;
        }

        public  void CargarCancionesAlbum (string titulo)
        {

            List<Cancion> l =  Canciones.Where(c => c.Album == titulo).ToList();
            l.Sort(delegate (Cancion c1, Cancion c2)
            {
                try
                {
                    int numero1 = int.Parse(c1.Numero);
                    int numero2 = int.Parse(c2.Numero);
                    return numero1.CompareTo(numero2);
                }
                catch (FormatException e)
                {
                    return c1.Titulo.CompareTo(c2.Titulo);
                }
            
            });
           
            Presentacion = new ObservableCollection<Cancion>(l);
            
        }
    }
}
