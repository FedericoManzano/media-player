using Microsoft.WindowsAPICodePack.Shell;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System.Collections.Generic;
using System.IO;

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

        public static ulong? CalcularDuracionAlbum (List<Cancion> album)
        {
           
            ulong? du = 0;
            foreach (Cancion e in album)
            {
                du += CalcularDuracionCancion(e.Path);
            }
            return du;
        }
    }
}
 