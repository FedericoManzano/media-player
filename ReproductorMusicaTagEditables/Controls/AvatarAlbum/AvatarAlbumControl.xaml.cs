using ReproductorMusicaTagEditables.Controls.AvatarArtista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReproductorMusicaTagEditables.Controls.AvatarAlbum
{
    /// <summary>
    /// Lógica de interacción para AvatarAlbumControl.xaml
    /// </summary>
    public partial class AvatarAlbumControl : UserControl
    {
        public AvatarAlbumControl()
        {
            InitializeComponent();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            bordePrincipal.Background = Brushes.Red;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            bordePrincipal.Background = Brushes.Transparent;
        }

        public static DependencyProperty ImagenAlbumProperty =
            DependencyProperty.Register("ImagenAlbum", typeof(ImageBrush), typeof(AvatarAlbumControl));
        
        public ImageBrush ImagenAlbum
        {
            get => (ImageBrush) GetValue(ImagenAlbumProperty);
            set => SetValue(ImagenAlbumProperty, value);
        }

        public static DependencyProperty NombreAlbumProperty =
            DependencyProperty.Register("NombreAlbum", typeof(string), typeof(AvatarAlbumControl));

        public string NombreAlbum
        {
            get => (string)GetValue(NombreAlbumProperty);
            set => SetValue(NombreAlbumProperty, value);
        }

        public static DependencyProperty AnoAlbumProperty =
            DependencyProperty.Register("AnoAlbum", typeof(string), typeof(AvatarAlbumControl));

        public string AnoAlbum
        {
            get => (string)GetValue(AnoAlbumProperty);
            set => SetValue(AnoAlbumProperty, value);
        }
    }
}
