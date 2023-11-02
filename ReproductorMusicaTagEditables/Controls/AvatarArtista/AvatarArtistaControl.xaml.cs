
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Controls.AvatarArtista
{
   
    public partial class AvatarArtistaControl : UserControl
    {
        public AvatarArtistaControl()
        {
            InitializeComponent();
        }

        public static DependencyProperty ImagenArtistaProperty =
            DependencyProperty.Register("ImagenArtista", typeof(ImageBrush), typeof(AvatarArtistaControl));
        public ImageBrush ImagenArtista
        {
            get => GetValue(ImagenArtistaProperty) as ImageBrush;
            set => SetValue(ImagenArtistaProperty, value);
        }


        public static DependencyProperty NombreArtistaProperty =
            DependencyProperty.Register("NombreArtista", typeof(string), typeof(AvatarArtistaControl));
        public string NombreArtista
        {
            get => GetValue(NombreArtistaProperty) as string;
            set => SetValue(NombreArtistaProperty, value);
        }


    }
}
