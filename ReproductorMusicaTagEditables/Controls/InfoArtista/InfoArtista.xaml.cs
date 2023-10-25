
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
    }
}
