
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

        #region Imagen2
        public static DependencyProperty ImagenDosProperty =
            DependencyProperty.Register("ImagenDos", typeof(ImageBrush), typeof(AlbumHistorialControl));

        public ImageBrush ImagenDos
        {
            get => (ImageBrush)GetValue(ImagenDosProperty);
            set => SetValue(ImagenDosProperty, value);
        }
        #endregion

        #region Imagen3
        public static DependencyProperty ImagenTresProperty =
            DependencyProperty.Register("ImagenTres", typeof(ImageBrush), typeof(AlbumHistorialControl));

        public ImageBrush ImagenTres
        {
            get => (ImageBrush)GetValue(ImagenTresProperty);
            set => SetValue(ImagenTresProperty, value);
        }
        #endregion

        #region Imagen4
        public static DependencyProperty ImagenCuatroProperty =
            DependencyProperty.Register("ImagenCuatro", typeof(ImageBrush), typeof(AlbumHistorialControl));

        public ImageBrush ImagenCuatro
        {
            get => (ImageBrush)GetValue(ImagenCuatroProperty);
            set => SetValue(ImagenCuatroProperty, value);
        }
        #endregion



        public static DependencyProperty NombreProperty = 
            DependencyProperty.Register("Nombre", typeof(string), typeof(AlbumHistorialControl), new PropertyMetadata(string.Empty));   
    
        public string Nombre
        {
            get => (string)GetValue(NombreProperty);
            set => SetValue(NombreProperty, value); 
        }



        public static DependencyProperty CantidadProperty =
            DependencyProperty.Register("Cantidad", typeof(string), typeof(AlbumHistorialControl), new PropertyMetadata(string.Empty));

        public string Cantidad
        {
            get => (string)GetValue(CantidadProperty);
            set => SetValue(CantidadProperty, value);
        }

    }
}
