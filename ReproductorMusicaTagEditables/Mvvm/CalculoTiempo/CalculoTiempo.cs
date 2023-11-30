using Microsoft.WindowsAPICodePack.Shell;
using ReproductorMusicaTagEditables.Mvvm.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReproductorMusicaTagEditables.Mvvm.CalculoTiempo
{
    public class CalculoTiempo
    {
        public static ulong? CalcularDuracionCancion(string path)
        {
            if(!System.IO.File.Exists(path))
            {
                return 0;
            }
            FileInfo fi = new FileInfo(path);
            ShellObject shellObj = ShellObject.FromParsingName(fi.FullName);
            ulong? du = shellObj.Properties.System.Media.Duration.Value;
            return du;
        }
        public static ulong? CalcularDuracionAlbum (List<Cancion> canciones, string tituloAlbum)
        {
            ulong?[] timepoAlbum = canciones.Where(c => tituloAlbum == c.Album)
                                           .Select(c => CalcularDuracionCancion(c.Path)).ToArray();

            ulong? tiempoTotal = 0;
            foreach (ulong? t in timepoAlbum)
            {
                tiempoTotal += t.Value;
            }                              
                                          
            return tiempoTotal;
        }
    }
}
 