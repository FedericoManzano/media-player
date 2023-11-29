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

namespace ReproductorMusicaTagEditables.Controls.InfoCancionTablaTags
{
    


    public partial class InfoCancionTablaTagsControl : UserControl
    {

        public static DependencyProperty SeleccionadoProperty =
            DependencyProperty.Register("Seleccionado", typeof(bool), typeof(InfoCancionTablaTagsControl), new PropertyMetadata(false));
        public bool Seleccionado
        {
            get => (bool) GetValue(SeleccionadoProperty);
            set => SetValue(SeleccionadoProperty, value);
        }

        public static DependencyProperty IconMarcadoProperty =
            DependencyProperty.Register("IconMarcado", typeof(MahApps.Metro.IconPacks.PackIconFontAwesomeKind), typeof(InfoCancionTablaTagsControl), new PropertyMetadata(MahApps.Metro.IconPacks.PackIconFontAwesomeKind.SquareRegular));


        public MahApps.Metro.IconPacks.PackIconFontAwesomeKind IconMarcado
        {
            get => (MahApps.Metro.IconPacks.PackIconFontAwesomeKind) GetValue(IconMarcadoProperty);
            set=> SetValue(IconMarcadoProperty, value); 
        }

        public InfoCancionTablaTagsControl()
        {
            InitializeComponent();
        }

        public InfoCancionTablaTagsControl(bool Seleccionado)
        {
            InitializeComponent();
            this.Seleccionado = Seleccionado;
            if (Seleccionado)
            {
                IconMarcado = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.CheckSquareSolid;
            }
            else
            {
                IconMarcado = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.SquareRegular;
            }
        }

        public static DependencyProperty NumeroProperty =
            DependencyProperty.Register("Numero", typeof(string), typeof(InfoCancionTablaTagsControl), new PropertyMetadata(string.Empty) );


        public string Numero
        {
            get => (string)GetValue(NumeroProperty);
            set => SetValue(NumeroProperty, value);
        }


        public static DependencyProperty TituloProperty =
            DependencyProperty.Register("Titulo", typeof(string), typeof(InfoCancionTablaTagsControl), new PropertyMetadata(string.Empty));


        public string Titulo
        {
            get => (string)GetValue(TituloProperty);
            set => SetValue(TituloProperty, value);
        }



        public static DependencyProperty ArtistaProperty =
            DependencyProperty.Register("Artista", typeof(string), typeof(InfoCancionTablaTagsControl), new PropertyMetadata(string.Empty));


        public string Artista
        {
            get => (string)GetValue(ArtistaProperty);
            set => SetValue(ArtistaProperty, value);
        }


        public static DependencyProperty AlbumProperty =
            DependencyProperty.Register("Album", typeof(string), typeof(InfoCancionTablaTagsControl), new PropertyMetadata(string.Empty));


        public string Album
        {
            get => (string)GetValue(AlbumProperty);
            set => SetValue(AlbumProperty, value);
        }


        public static DependencyProperty GeneroProperty =
            DependencyProperty.Register("Genero", typeof(string), typeof(InfoCancionTablaTagsControl), new PropertyMetadata(string.Empty));


        public string Genero
        {
            get => (string)GetValue(GeneroProperty);
            set => SetValue(GeneroProperty, value);
        }

        public static DependencyProperty AnoProperty =
            DependencyProperty.Register("Ano", typeof(string), typeof(InfoCancionTablaTagsControl), new PropertyMetadata(string.Empty));


        public string Ano
        {
            get => (string)GetValue(AnoProperty);
            set => SetValue(AnoProperty, value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SeleccionarODeseleccionar();
        }

        public void SeleccionarODeseleccionar()
        {
            Seleccionado = !Seleccionado;
            if (Seleccionado)
            {
                IconMarcado = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.CheckSquareSolid;
            }
            else
            {
                IconMarcado = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.SquareRegular;
            }
        }

        public bool Equals(InfoCancionTablaTagsControl other)
        {
            return other.Titulo == this.Titulo && other.Artista == this.Artista && other.Album == this.Album;
        }
    }
}
