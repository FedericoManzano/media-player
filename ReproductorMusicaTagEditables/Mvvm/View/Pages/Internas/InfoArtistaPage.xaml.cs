
using ReproductorMusicaTagEditables.Controls.InfoAlbum;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas
{
    /// <summary>
    /// Lógica de interacción para InfoArtistaPage.xaml
    /// </summary>
    public partial class InfoArtistaPage : Page
    {
        public InfoArtistaPage(string artista)
        {
            InitializeComponent();
            infoArtista.CargarInfoArtista(artista);
            
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            infoArtista.Irg.Partes.Clear();
            if(this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
            
        }

        private void InfoAlbumControl_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            InfoAlbumControl i = (InfoAlbumControl)sender;
            this.NavigationService.Navigate(new InfoAlbumPage(i.NombreAlbum));
            
        }
    }
}
