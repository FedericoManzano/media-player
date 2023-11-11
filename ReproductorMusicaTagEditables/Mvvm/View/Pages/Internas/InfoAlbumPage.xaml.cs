
using ReproductorMusicaTagEditables.Controls.InfoAlbumPagina;
using ReproductorMusicaTagEditables.Controls.InfoArtista;
using ReproductorMusicaTagEditables.Controls.InfoCancionTabla;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas
{
   
    public partial class InfoAlbumPage : Page
    {
        private string nombreAlbum;
        public InfoAlbumPage(string nombreAlbum)
        {
            InitializeComponent();
            this.nombreAlbum = nombreAlbum;
        }


        private void InfoAlbumPaginaControl_IrPaginaArtista(object sender, EventArgs e)
        {
            InfoAlbumPaginaControl i = (InfoAlbumPaginaControl)sender;
            
            if (i.NombreArtista == "Desconocido")
            {
                System.Windows.Forms.MessageBox.Show("El artista que intenta acceder es desconocido, por lo tanto, la metadata de los archivos de audio es inexistente. Puede solucionar esto desde el botón (EDITAR TAGS) de la pestaña 'Inicio' para agregar la información pertinente.", "Artista Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            infoAlbum.Limpiar();
            this.NavigationService.Navigate(new InfoArtistaPage(i.NombreArtista));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                infoAlbum.Limpiar();
                this.NavigationService.GoBack();
            }          
        }

        private void InfoCancionTabla_ArtistaClick(object sender, EventArgs e)
        {
            InfoCancionTabla i = (InfoCancionTabla)sender;
            if (i.ArtistaInfo == "Desconocido")
            {
                System.Windows.Forms.MessageBox.Show("El artista que intenta acceder es desconocido, por lo tanto, la metadata de los archivos de audio es inexistente. Puede solucionar esto desde el botón (EDITAR TAGS) de la pestaña 'Inicio' para agregar la información pertinente.", "Artista Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            infoAlbum.Limpiar();
            this.NavigationService.Navigate(new InfoArtistaPage(i.ArtistaInfo));
        }

        private void infoAlbumPage_Loaded(object sender, RoutedEventArgs e)
        {
            infoAlbum.Limpiar();
            infoAlbum.CargarInfoAlbum(nombreAlbum);
        }

        private void infoAlbumPage_Unloaded(object sender, RoutedEventArgs e)
        {
            infoAlbum.Limpiar();
        }
    }
}
