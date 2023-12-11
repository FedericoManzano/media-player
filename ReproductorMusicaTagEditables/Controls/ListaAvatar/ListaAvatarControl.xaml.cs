using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;


namespace ReproductorMusicaTagEditables.Controls.ListaAvatar
{
    public partial class ListaAvatarControl :System.Windows.Controls.UserControl
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




        public static DependencyProperty PlayComandoProperty =
            DependencyProperty.Register("PlayComando", typeof(ICommand), typeof(ListaAvatarControl));



        public ICommand PlayComando
        {
            get => (ICommand) GetValue(PlayComandoProperty);    
            set => SetValue(PlayComandoProperty, value);
        }


        public static DependencyProperty ParametroComandoProperty =
            DependencyProperty.Register("ParametroComando", typeof(object), typeof(ListaAvatarControl));



        public object ParametroComando
        {
            get => GetValue(ParametroComandoProperty);
            set => SetValue(ParametroComandoProperty, value);
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var res =System.Windows.Forms.MessageBox.Show($"Esta seguro que desea eliminar la lista: {Nombre}", "Eliminado de lista", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if(res == DialogResult.Yes)
            {
                ListasReproduccion.Borrar(Nombre);
            }
        }

        private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            bordePrincipal.Background = Brushes.Red;
        }

        private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            bordePrincipal.Background = Brushes.Transparent;
        }
    }
}
