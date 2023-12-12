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

namespace ReproductorMusicaTagEditables.Controls.Regalos
{
    public partial class RegalosControl : UserControl
    {


        public static DependencyProperty ImagenUnoProperty =
            DependencyProperty.Register("ImagenUno", typeof(ImageBrush), typeof(RegalosControl), new PropertyMetadata(null));

        public ImageBrush ImagenUno
        {
            get => (ImageBrush) GetValue(ImagenUnoProperty);
            set => SetValue(ImagenUnoProperty, value);
        }


        #region Imagenes
        public static DependencyProperty ImagenDosProperty =
            DependencyProperty.Register("ImagenDos", typeof(ImageBrush), typeof(RegalosControl), new PropertyMetadata(null));

        public ImageBrush ImagenDos
        {
            get => (ImageBrush)GetValue(ImagenDosProperty);
            set => SetValue(ImagenDosProperty, value);
        }


        public static DependencyProperty ImagenTresProperty =
            DependencyProperty.Register("ImagenTres", typeof(ImageBrush), typeof(RegalosControl), new PropertyMetadata(null));

        public ImageBrush ImagenTres
        {
            get => (ImageBrush)GetValue(ImagenTresProperty);
            set => SetValue(ImagenTresProperty, value);
        }


        public static DependencyProperty ImagenCuatroProperty =
            DependencyProperty.Register("ImagenCuatro", typeof(ImageBrush), typeof(RegalosControl), new PropertyMetadata(null));

        public ImageBrush ImagenCuatro
        {
            get => (ImageBrush)GetValue(ImagenCuatroProperty);
            set => SetValue(ImagenCuatroProperty, value);
        }
        #endregion

        #region Fondo
        public static DependencyProperty ColorFondoProperty =
          DependencyProperty.Register("ColorFondo", typeof(string), typeof(RegalosControl), new PropertyMetadata(string.Empty));

        public string ColorFondo
        {
            get => (string) GetValue(ColorFondoProperty);
            set => SetValue(ColorFondoProperty, value);
        }
        #endregion 

        public static DependencyProperty TextoProperty =
          DependencyProperty.Register("Texto", typeof(string), typeof(RegalosControl), new PropertyMetadata(string.Empty));

        public string Texto
        {
            get => (string)GetValue(TextoProperty);
            set => SetValue(TextoProperty, value);
        }


        public RegalosControl()
        {
            InitializeComponent();
        }
    }
}
