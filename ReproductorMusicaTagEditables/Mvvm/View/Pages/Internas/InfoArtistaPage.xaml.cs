
using System.Windows.Controls;


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
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }
    }
}
