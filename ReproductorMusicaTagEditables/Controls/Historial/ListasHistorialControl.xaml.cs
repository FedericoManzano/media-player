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

namespace ReproductorMusicaTagEditables.Controls.Historial
{
    /// <summary>
    /// Lógica de interacción para ListasHistorialControl.xaml
    /// </summary>
    public partial class ListasHistorialControl : UserControl
    {
        public ListasHistorialControl()
        {
            InitializeComponent();
        }

        #region Imagen1
        public static DependencyProperty ImagenUnoProperty =
            DependencyProperty.Register("ImagenUno", typeof(ImageBrush), typeof(ListasHistorialControl));

        public ImageBrush ImagenUno
        {
            get => (ImageBrush)GetValue(ImagenUnoProperty);
            set => SetValue(ImagenUnoProperty, value);
        }
        #endregion

        #region Imagen2
        public static DependencyProperty ImagenDosProperty =
            DependencyProperty.Register("ImagenDos", typeof(ImageBrush), typeof(ListasHistorialControl));

        public ImageBrush ImagenDos
        {
            get => (ImageBrush)GetValue(ImagenDosProperty);
            set => SetValue(ImagenDosProperty, value);
        }
        #endregion

        #region Imagen3
        public static DependencyProperty ImagenTresProperty =
            DependencyProperty.Register("ImagenTres", typeof(ImageBrush), typeof(ListasHistorialControl));

        public ImageBrush ImagenTres
        {
            get => (ImageBrush)GetValue(ImagenTresProperty);
            set => SetValue(ImagenTresProperty, value);
        }
        #endregion

        #region Imagen4
        public static DependencyProperty ImagenCuatroProperty =
            DependencyProperty.Register("ImagenCuatro", typeof(ImageBrush), typeof(ListasHistorialControl));

        public ImageBrush ImagenCuatro
        {
            get => (ImageBrush)GetValue(ImagenCuatroProperty);
            set => SetValue(ImagenCuatroProperty, value);
        }
        #endregion



        public static DependencyProperty NombreProperty =
            DependencyProperty.Register("Nombre", typeof(string), typeof(ListasHistorialControl), new PropertyMetadata(string.Empty));

        public string Nombre
        {
            get => (string)GetValue(NombreProperty);
            set => SetValue(NombreProperty, value);
        }



        public static DependencyProperty CantidadProperty =
            DependencyProperty.Register("Cantidad", typeof(string), typeof(ListasHistorialControl), new PropertyMetadata(string.Empty));

        public string Cantidad
        {
            get => (string)GetValue(CantidadProperty);
            set => SetValue(CantidadProperty, value);
        }
    }
}
