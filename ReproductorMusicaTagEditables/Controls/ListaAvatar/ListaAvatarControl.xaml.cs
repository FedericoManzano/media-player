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

namespace ReproductorMusicaTagEditables.Controls.ListaAvatar
{
    /// <summary>
    /// Lógica de interacción para ListaAvatarControl.xaml
    /// </summary>
    public partial class ListaAvatarControl : UserControl
    {
      
        public ListaAvatarControl()
        {
            InitializeComponent();
        }

        #region Visibilidad
        public static DependencyProperty ImagenDefectoVisibleProperty =
            DependencyProperty.Register("ImagenDefectoVisible", typeof(Visibility), typeof(ListaAvatarControl), new PropertyMetadata(Visibility.Visible));

        public Visibility ImagenDefectoVisible
        {
            get => (Visibility) GetValue(ImagenDefectoVisibleProperty);
            set => SetValue(ImagenDefectoVisibleProperty, value);
        }


        public static DependencyProperty ImagenesVisibleProperty =
            DependencyProperty.Register("ImagenesVisible", typeof(Visibility), typeof(ListaAvatarControl), new PropertyMetadata(Visibility.Collapsed));

        public Visibility ImagenesVisible
        {
            get => (Visibility)GetValue(ImagenesVisibleProperty);
            set => SetValue(ImagenesVisibleProperty, value);
        }

        #endregion


        public static DependencyProperty ImagenUnoProperty =
            DependencyProperty.Register("ImagenUno", typeof(ImageBrush), typeof(ListaAvatarControl), new PropertyMetadata(null));

        public ImageBrush ImagenUno
        {
            get => (ImageBrush) GetValue(ImagenUnoProperty);
            set => SetValue(ImagenUnoProperty, value);
        }

        public static DependencyProperty ImagenDosProperty =
            DependencyProperty.Register("ImagenDos", typeof(ImageBrush), typeof(ListaAvatarControl), new PropertyMetadata(null));

        public ImageBrush ImagenDos
        {
            get => (ImageBrush)GetValue(ImagenDosProperty);
            set => SetValue(ImagenDosProperty, value);
        }



        public static DependencyProperty ImagenTresProperty =
            DependencyProperty.Register("ImagenTres", typeof(ImageBrush), typeof(ListaAvatarControl), new PropertyMetadata(null));

        public ImageBrush ImagenTres
        {
            get => (ImageBrush)GetValue(ImagenTresProperty);
            set => SetValue(ImagenTresProperty, value);
        }


        public static DependencyProperty ImagenCuatroProperty =
            DependencyProperty.Register("ImagenCuatro", typeof(ImageBrush), typeof(ListaAvatarControl), new PropertyMetadata(null));

        public ImageBrush ImagenCuatro
        {
            get => (ImageBrush)GetValue(ImagenCuatroProperty);
            set => SetValue(ImagenCuatroProperty, value);
        }
    }
}
