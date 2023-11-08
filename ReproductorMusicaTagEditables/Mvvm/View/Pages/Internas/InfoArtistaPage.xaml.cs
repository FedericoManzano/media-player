﻿
using ReproductorMusicaTagEditables.Controls.InfoAlbum;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas
{
    public partial class InfoArtistaPage : Page
    {
        public InfoArtistaPage(string artista)
        {
            InitializeComponent();
            infoArtista.CargarInfoArtista(artista);
            
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            if(this.NavigationService.CanGoBack)
            {
                infoArtista.Irg.Partes.Clear();
                infoArtista.Irg.AgregarElementosAlFiltro();
                this.NavigationService.GoBack();
            }
            
        }

        private void InfoAlbumControl_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            InfoAlbumControl i = (InfoAlbumControl)sender;
            if (i.NombreAlbum == "Desconocido")
            {
                System.Windows.Forms.MessageBox.Show("El álbum al que intenta acceder es desconocido, por lo tanto, la metadata de los archivos de audio es inexistente. Puede solucionar esto desde el botón (EDITAR TAGS) de la pestaña 'Inicio' para agregar la información pertinente.", "Álbum Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.NavigationService.Navigate(new InfoAlbumPage(i.NombreAlbum));
            
        }
    }
}
