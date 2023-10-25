using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen.IArchivoimagen;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen
{
    public abstract class ArchivoImagenBase : IArchivoImagen
    {

        public static readonly string PATH_IMAGEN_DEFAULT = "pack://application:,,,/Images/albumDesconocido.png";


        public static readonly int DEFAULT = 0;
        public static readonly int NUEVA_IMAGEN = 1;
        public static readonly int IMAGEN_DEL_ARCHIVO = 2;

        protected BitmapImage bitmapImage = new BitmapImage();

        public abstract ImageBrush DameImagen(string path);

        public static IArchivoImagen archivoImagenFabrica(int opcionImagen, string path = null )
        {
            switch (opcionImagen)
            {
                case 0: return new ImagenDefault();
                case 1: return new NuevaImagen();
                case 2: return new ImagenDelArchivoAudio();
            }

            return null;
        }


        protected byte[] ImagenAByte(string path)
        {
            if (File.Exists(path))
            { 
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    byte[] ImageData = new byte[fs.Length];
                    fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));
                    return ImageData;
                }
            }
            return null;
        }
    }
}
