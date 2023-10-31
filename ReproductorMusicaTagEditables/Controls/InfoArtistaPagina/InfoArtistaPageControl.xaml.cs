
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Controls.InfoArtistaPagina
{

    public partial class InfoArtistaPageControl : UserControl
    {
        public InfoArtistaPageControl()
        {
            InitializeComponent();
        }


        public static DependencyProperty ImagenProperty =
            DependencyProperty.Register("ImagenArtista", typeof(ImageBrush), typeof(InfoArtistaPageControl));

        public ImageBrush ImagenArtista
        {
            get => (ImageBrush)GetValue(ImagenProperty); 
            set => SetValue(ImagenProperty, value);
        }


        public static DependencyProperty NombreProperty =
            DependencyProperty.Register("NombreArtista", typeof(string), typeof(InfoArtistaPageControl));

        public string NombreArtista
        {
            get => GetValue(NombreProperty) as string;
            set => SetValue(NombreProperty, value);
        }


        public static DependencyProperty GeneroProperty =
            DependencyProperty.Register("Genero", typeof(string), typeof(InfoArtistaPageControl));

        public string Genero
        {
            get => GetValue(GeneroProperty) as string;
            set => SetValue(GeneroProperty, value);
        }

        public static DependencyProperty CantidadAlbumesProperty =
            DependencyProperty.Register("CantidadAlbumes", typeof(string), typeof(InfoArtistaPageControl));

        public string CantidadAlbumes
        {
            get => GetValue(CantidadAlbumesProperty) as string;
            set => SetValue(CantidadAlbumesProperty, value);
        }

        public static DependencyProperty HorasReproduccionProperty =
            DependencyProperty.Register("HorasReproduccion", typeof(string), typeof(InfoArtistaPageControl));

        public string HorasReproduccion
        {
            get => GetValue(HorasReproduccionProperty) as string;
            set => SetValue(HorasReproduccionProperty, value);
        }

        public static DependencyProperty PlayCommandProperty =
            DependencyProperty.Register("PlayArtista", typeof(ICommand), typeof(InfoArtistaPageControl));

        public ICommand PlayArtista
        {
            get => (ICommand) GetValue(PlayCommandProperty);
            set => SetValue(PlayCommandProperty, value);
        }
    }
}
