

using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Query.Dynamic;
using System.Windows;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info
{
    public partial class InfoReproductor
    {
       
        public async Task<List<Cancion>> CargarListaAlbumes(string artista)
        {
            var uiContext = TaskScheduler.FromCurrentSynchronizationContext();
            return new SortedSet<Cancion>
            (
                await Task<List<Cancion>>.Factory.StartNew(() =>
                {
                    return Canciones
                       .Where(c => c.Artista == artista && System.IO.File.Exists(c.Path))
                       .Select(c =>
                       {
                           Cancion cc= c.Clone();
                           cc.Imagen = ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.IMAGEN_DEL_ARCHIVO).DameImagen(c.Path) ??
                                ArchivoImagenBase.archivoImagenFabrica(ArchivoImagenBase.DEFAULT).DameImagen();
                           return cc;


                       }).ToList();
                }, CancellationToken.None, TaskCreationOptions.None, uiContext)
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

        public async  Task<List<Cancion>> CargarCancionesAlbum (string titulo)
        {
            List<Cancion> l = await Task<List<Cancion>>.Run(()=> Canciones.Where(c => c.Album == titulo).Select(c=> c.Clone()).ToList());
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
           
            if(l.Count == 0 )
            {
                MessageBox.Show($"El álbum que está intentando acceder fué eliminado en tiempo de ejecución");
            }
            return l;
        }
    }
}
