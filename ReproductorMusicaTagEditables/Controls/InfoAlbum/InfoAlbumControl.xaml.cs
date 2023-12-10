
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace ReproductorMusicaTagEditables.Controls.InfoAlbum
{
    /// <summary>
    /// Lógica de interacción para InfoAlbumControl.xaml
    /// </summary>
    public partial class InfoAlbumControl : UserControl
    {
        public InfoAlbumControl()
        {
            InitializeComponent();
            bordeCapa.Visibility = Visibility.Hidden;
            bordePrincipal.Background = Brushes.Transparent;

        }


        public static DependencyProperty ImagenProperty =
            DependencyProperty.Register("ImagenAlbum", typeof(ImageBrush), typeof(InfoAlbumControl));
        public ImageBrush ImagenAlbum
        {
            get => (ImageBrush) GetValue(ImagenProperty);
            set => SetValue(ImagenProperty, value); 
        }

        public static DependencyProperty PlayCommandProperty =
            DependencyProperty.Register("PlayCommand", typeof(ICommand), typeof(InfoAlbumControl));
        public ICommand PlayCommand
        {
            get => (ICommand)GetValue(PlayCommandProperty);
            set => SetValue(PlayCommandProperty, value);
        }

        public static DependencyProperty PlayParameterdProperty =
                    DependencyProperty.Register("PlayParameter", typeof(object), typeof(InfoAlbumControl));
        public object PlayParameter
        {
            get => (object)GetValue(PlayParameterdProperty);
            set => SetValue(PlayParameterdProperty, value);
        }


        public static DependencyProperty NombreAlbumProperty =
                    DependencyProperty.Register("NombreAlbum", typeof(string), typeof(InfoAlbumControl));
        public string NombreAlbum
        {
            get => (string)GetValue(NombreAlbumProperty);
            set => SetValue(NombreAlbumProperty, value);
        }


        public static DependencyProperty AnoAlbumProperty =
                    DependencyProperty.Register("AnoAlbum", typeof(string), typeof(InfoAlbumControl));
        public string AnoAlbum
        {
            get => (string)GetValue(AnoAlbumProperty);
            set => SetValue(AnoAlbumProperty, value);
        }

        private void borderTrigger_MouseEnter(object sender, MouseEventArgs e)
        {
            bordeCapa.Visibility = Visibility.Visible;
            bordePrincipal.Background = Brushes.DarkRed;
        }

        private void borderTrigger_MouseLeave(object sender, MouseEventArgs e)
        {
            bordeCapa.Visibility = Visibility.Hidden;
            bordePrincipal.Background = Brushes.Transparent;
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
