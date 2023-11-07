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
    public partial class ListaAvatarControl : UserControl
    {
      
        public ListaAvatarControl()
        {
            InitializeComponent();
        }


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

        public static DependencyProperty NombreProperty =
            DependencyProperty.Register("Nombre", typeof(string), typeof(ListaAvatarControl), new PropertyMetadata(string.Empty) );
        
        public string Nombre
        {
            get => GetValue(NombreProperty) as string;
            set => SetValue(NombreProperty, value); 
        }


        public static DependencyProperty CantidadProperty =
            DependencyProperty.Register("Cantidad", typeof(string), typeof(ListaAvatarControl), new PropertyMetadata(string.Empty));

        public string Cantidad
        {
            get => GetValue(CantidadProperty) as string;
            set => SetValue(CantidadProperty, value);
        }

    }
}
