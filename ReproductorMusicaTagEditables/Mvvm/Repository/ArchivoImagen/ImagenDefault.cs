using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen.IArchivoimagen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen
{
    public class ImagenDefault : ArchivoImagenBase
    {
        public override ImageBrush DameImagen(string path)
        {
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(PATH_IMAGEN_DEFAULT);
            bitmapImage.EndInit();
            return new ImageBrush(bitmapImage);
        }
    }
}
