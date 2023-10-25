
using System.IO;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen
{
    public class NuevaImagen : ArchivoImagenBase
    {
        public override ImageBrush DameImagen(string path)
        {
            if (File.Exists(path))
            {
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(ImagenAByte(path));
                bitmapImage.EndInit();
                return new ImageBrush(bitmapImage);
            }
            return null;
        }
    }
}