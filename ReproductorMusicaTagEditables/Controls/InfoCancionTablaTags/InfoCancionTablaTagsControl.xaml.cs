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
        public bool Seleccionado { get; set; } = false;
        public InfoCancionTablaTagsControl()
        {
            InitializeComponent();
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
            Seleccionado = !Seleccionado;
            if(Seleccionado) 
            {
                iconSelector.Kind = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.CheckSquareSolid;
            }
            else
            {
                iconSelector.Kind = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.SquareRegular;
            }
        }
    }
}
