using ReproductorMusicaTagEditables.Controls.AvatarArtista;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
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

        public static DependencyProperty ArtistaProperty =
            DependencyProperty.Register("NombreArtista", typeof(string), typeof(AvatarAlbumControl));

        public string NombreArtista
        {
            get => (string)GetValue(ArtistaProperty);
            set => SetValue(ArtistaProperty, value);
        }


        public static DependencyProperty ComandoPlayProperty =
            DependencyProperty.Register("ComandoPlay", typeof(ICommand), typeof(AvatarAlbumControl));

        public ICommand ComandoPlay
        {
            get => (ICommand)GetValue(ComandoPlayProperty);
            set => SetValue(ComandoPlayProperty, value);    
        }

        public static DependencyProperty ParametroComandoPlayProperty =
            DependencyProperty.Register("ParametroComandoPlay", typeof(object), typeof(AvatarAlbumControl));

        public object ParametroComandoPlay
        {
            get => GetValue(ParametroComandoPlayProperty);
            set => SetValue(ParametroComandoPlayProperty, value);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            InfoReproductor i = InfoReproductor.DameInstancia();
            List<Cancion> albums = i.Canciones.Where(c => c.Album == NombreAlbum).ToList();
            MainWindow.agregarCancionesListas.AgregarListaCanciones(albums);
            MainWindow.agregarCancionesListas.Show();
        }
    }
}
