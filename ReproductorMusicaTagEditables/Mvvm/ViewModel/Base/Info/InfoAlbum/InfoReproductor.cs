

using ReproductorMusicaTagEditables.Mvvm.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

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
                       .Where(c => c.Artista == artista)
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
            CancionesFiltradas = new ObservableCollection<Cancion>
            (
                
                Canciones.Where(c => c.Album == titulo).ToList()
               

            );     
            
        }
    }
}
