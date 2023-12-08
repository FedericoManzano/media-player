
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace ReproductorMusicaTagEditables.Controls.Historial
{
    public partial class AlbumHistorialControl : UserControl
    {
        public AlbumHistorialControl()
        {
            InitializeComponent();
        }

        #region Imagen1
        public static DependencyProperty ImagenUnoProperty = 
            DependencyProperty.Register("ImagenUno", typeof(ImageBrush), typeof(AlbumHistorialControl));
        
        public ImageBrush ImagenUno
        {
            get => (ImageBrush)GetValue(ImagenUnoProperty); 
            set => SetValue(ImagenUnoProperty, value);
        }
        #endregion


        public static DependencyProperty NombreProperty = 
            DependencyProperty.Register("Nombre", typeof(string), typeof(AlbumHistorialControl), new PropertyMetadata(string.Empty));   
    
        public string Nombre
        {
            get => (string)GetValue(NombreProperty);
            set => SetValue(NombreProperty, value); 
        }



        public static DependencyProperty ArtistaProperty =
            DependencyProperty.Register("Artista", typeof(string), typeof(AlbumHistorialControl), new PropertyMetadata(string.Empty));

        public string Artista
        {
            get => (string)GetValue(ArtistaProperty);
            set => SetValue(ArtistaProperty, value);
        }
    }
}
