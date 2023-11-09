
using System.IO;

using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen
{
    public class ImagenDelArchivoAudio : ArchivoImagenBase
    {
        public override ImageBrush DameImagen(string path)
        {
            BitmapImage b = new BitmapImage();
            if(System.IO.File.Exists(path))
            {
                var tl = TagLib.File.Create(path);
                if (tl.Tag.Pictures != null && tl.Tag.Pictures.Length > 0)
                {
                    byte[] imgbyte = tl.Tag.Pictures[0].Data.Data;

                    b.BeginInit();
                    b.StreamSource = new MemoryStream(imgbyte);
                    b.EndInit();
                    return new System.Windows.Media.ImageBrush(b);
                }
                return null;
            }
            return null;
        }
    }
}
