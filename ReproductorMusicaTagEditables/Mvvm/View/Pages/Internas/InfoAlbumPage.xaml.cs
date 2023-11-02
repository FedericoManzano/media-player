using ReproductorMusicaTagEditables.Controls.InfoAlbum;
using ReproductorMusicaTagEditables.Controls.InfoAlbumPagina;
using ReproductorMusicaTagEditables.Controls.InfoCancionTabla;
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

namespace ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas
{
   
    public partial class InfoAlbumPage : Page
    {
        public InfoAlbumPage(string nombreAlbum)
        {
            InitializeComponent();
            infoAlbum.CargarInfoAlbum(nombreAlbum);
        }

        private void InfoAlbumPaginaControl_IrPaginaArtista(object sender, EventArgs e)
        {
            InfoAlbumPaginaControl i = (InfoAlbumPaginaControl)sender;
            this.NavigationService.Navigate(new InfoArtistaPage(i.NombreArtista));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.NavigationService.CanGoBack)
            {  
                this.NavigationService.GoBack();
            }
           
        }

        private void InfoCancionTabla_ArtistaClick(object sender, EventArgs e)
        {
            InfoCancionTabla i = (InfoCancionTabla) sender;
            this.NavigationService.Navigate(new InfoArtistaPage(i.ArtistaInfo));
        }
    }
}
