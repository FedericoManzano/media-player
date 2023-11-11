
using ReproductorMusicaTagEditables.Controls.InfoAlbum;
using ReproductorMusicaTagEditables.Controls.InfoArtista;
using ReproductorMusicaTagEditables.Controls.InfoCancionTabla;
using ReproductorMusicaTagEditables.Controls.ListaAvatar;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Forms;


namespace ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas
{
    
    public partial class InfoListasPage : Page
    {


        private ListaAvatarControl _listaAvatarControl;
        public InfoListasPage(ListaAvatarControl listaAvatarControl)
        {
            
            InitializeComponent();
            this._listaAvatarControl = listaAvatarControl;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.NavigationService.CanGoBack)
            {
                listaRepViewModel.Limpiar();
                this.NavigationService.GoBack();
            }
        }

        private void InfoCancionTabla_AlbumClick(object sender, EventArgs e)
        {
            InfoCancionTabla i = (InfoCancionTabla)sender;
            if (i.AlbumInfo == "Desconocido")
            {
                System.Windows.Forms.MessageBox.Show("El álbum al que intenta acceder es desconocido, por lo tanto, la metadata de los archivos de audio es inexistente. Puede solucionar esto desde el botón (EDITAR TAGS) de la pestaña 'Inicio' para agregar la información pertinente.", "Álbum Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            listaRepViewModel.Limpiar();
            this.NavigationService.Navigate(new InfoAlbumPage(i.AlbumInfo));
        }

        private void InfoCancionTabla_ArtistaClick(object sender, EventArgs e)
        {
            InfoCancionTabla i = (InfoCancionTabla)sender;
           
            if (i.ArtistaInfo == "Desconocido")
            {
                System.Windows.Forms.MessageBox.Show("El artista al que intenta acceder es desconocido, por lo tanto, la metadata de los archivos de audio es inexistente. Puede solucionar esto desde el botón (EDITAR TAGS) de la pestaña 'Inicio' para agregar la información pertinente.", "Álbum Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            listaRepViewModel.Limpiar();
            this.NavigationService.Navigate(new InfoArtistaPage(i.ArtistaInfo));
        }

        private void listaRepro_Loaded(object sender, RoutedEventArgs e)
        {
            listaRepViewModel.Limpiar();
            listaRepViewModel.CargarInfoLista(_listaAvatarControl);
        }

        private void listaRepro_Unloaded(object sender, RoutedEventArgs e)
        {
            listaRepViewModel.Limpiar();
        }
    }
}
