
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Controls.InfoListaPagina
{

    public partial class InfoListaPaginaControl : UserControl
    {
        public InfoListaPaginaControl()
        {
            InitializeComponent();
        }

        #region PropertyImagenes
        public static DependencyProperty ImagenUnoProperty =
            DependencyProperty.Register("ImagenUno",typeof(ImageBrush), typeof(InfoListaPaginaControl));

        public ImageBrush ImagenUno
        {
            get => GetValue(ImagenUnoProperty) as ImageBrush; 
            set => SetValue(ImagenUnoProperty, value);  
        }


        public static DependencyProperty ImagenDosProperty =
            DependencyProperty.Register("ImagenDos", typeof(ImageBrush), typeof(InfoListaPaginaControl));

        public ImageBrush ImagenDos
        {
            get => GetValue(ImagenDosProperty) as ImageBrush;
            set => SetValue(ImagenDosProperty, value);
        }

        public static DependencyProperty ImagenTresProperty =
            DependencyProperty.Register("ImagenTres", typeof(ImageBrush), typeof(InfoListaPaginaControl));

        public ImageBrush ImagenTres
        {
            get => GetValue(ImagenTresProperty) as ImageBrush;
            set => SetValue(ImagenTresProperty, value);
        }

        public static DependencyProperty ImagenCuatroProperty =
            DependencyProperty.Register("ImagenCuatro", typeof(ImageBrush), typeof(InfoListaPaginaControl));

        public ImageBrush ImagenCuatro
        {
            get => GetValue(ImagenCuatroProperty) as ImageBrush;
            set => SetValue(ImagenCuatroProperty, value);
        }
        #endregion

        #region PropertyTextoInfo
        public static DependencyProperty NombreProperty =
            DependencyProperty.Register("Nombre", typeof(string), typeof(InfoListaPaginaControl), new PropertyMetadata(string.Empty));


        public string Nombre
        {
            get => GetValue(NombreProperty) as string;
            set => SetValue(NombreProperty, value);
        }


        public static DependencyProperty CantidadCancionesProperty =
           DependencyProperty.Register("CancidadCanciones", typeof(string), typeof(InfoListaPaginaControl), new PropertyMetadata(string.Empty));

        public string CancidadCanciones
        {
            get => GetValue(CantidadCancionesProperty) as string;
            set => SetValue(CantidadCancionesProperty, value);
        }


        public static DependencyProperty DuracionHorasProperty =
           DependencyProperty.Register("DuracionHoras", typeof(string), typeof(InfoListaPaginaControl), new PropertyMetadata(string.Empty));

        public string DuracionHoras
        {
            get => GetValue(DuracionHorasProperty) as string;
            set => SetValue(DuracionHorasProperty, value);
        }

        public static DependencyProperty FechaCreacionProperty =
           DependencyProperty.Register("FechaCreacion", typeof(string), typeof(InfoListaPaginaControl), new PropertyMetadata(string.Empty));

        public string FechaCreacion
        {
            get => GetValue(FechaCreacionProperty) as string;
            set => SetValue(FechaCreacionProperty, value);
        }
        #endregion

        public static DependencyProperty ComandoPlayProperty =
            DependencyProperty.Register("ComandoPlay", typeof(ICommand), typeof(InfoListaPaginaControl));

        public ICommand ComandoPlay
        {
            get => GetValue(ComandoPlayProperty) as ICommand;
            set => SetValue(ComandoPlayProperty, value);
        }
    }
}
