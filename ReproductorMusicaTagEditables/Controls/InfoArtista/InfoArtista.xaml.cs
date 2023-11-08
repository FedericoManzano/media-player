
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Controls.InfoArtista
{
    public partial class InfoArtista : UserControl
    {
        public InfoArtista()
        {
            InitializeComponent();
        }


        public static DependencyProperty ImagenArtistaProperty =
            DependencyProperty.Register("ImagenArtista", typeof(ImageBrush), typeof(InfoArtista));

        public ImageBrush ImagenArtista
        {
            get => (ImageBrush)GetValue(ImagenArtistaProperty); 
            set => SetValue(ImagenArtistaProperty, value);
        }

        public static DependencyProperty NombreArtistaProperty =
            DependencyProperty.Register("NombreArtista", typeof(string), typeof(InfoArtista), new PropertyMetadata(string.Empty));

        public string NombreArtista
        {
            get => GetValue(NombreArtistaProperty) as string;
            set => SetValue(NombreArtistaProperty, value);
        }


        public static DependencyProperty NombreAlbumProperty =
            DependencyProperty.Register("NombreAlbum", typeof(string), typeof(InfoArtista), new PropertyMetadata(string.Empty));

        public string NombreAlbum
        {
            get => GetValue(NombreAlbumProperty) as string;
            set => SetValue(NombreAlbumProperty, value);
        }


        public static DependencyProperty TituloCancionProperty =
            DependencyProperty.Register("TituloCancion", typeof(string), typeof(InfoArtista), new PropertyMetadata(string.Empty));

        public string TituloCancion
        {
            get => GetValue(TituloCancionProperty) as string;
            set => SetValue(TituloCancionProperty, value);
        }

    }
}
