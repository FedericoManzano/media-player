using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen.IArchivoimagen
{
    public interface IArchivoImagen
    {
        ImageBrush DameImagen(string path = null);
    }
}
