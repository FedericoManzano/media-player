
using System.IO;

using System.Windows.Media;


namespace ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen
{
    public class ImagenDelArchivoAudio : ArchivoImagenBase
    {
        public override ImageBrush DameImagen(string path)
        {
            if(System.IO.File.Exists(path))
            {
                var tl = TagLib.File.Create(path);
                if (tl.Tag.Pictures != null && tl.Tag.Pictures.Length > 0)
                {
                    byte[] imgbyte = tl.Tag.Pictures[0].Data.Data;

                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = new MemoryStream(imgbyte);
                    bitmapImage.EndInit();
                    return new System.Windows.Media.ImageBrush(bitmapImage);
                }
                return null;
            }
            return null;
        }
    }
}
