
using ReproductorMusicaTagEditables.Controls.InfoCancionTabla;
using ReproductorMusicaTagEditables.Controls.ListaAvatar;
using ReproductorMusicaTagEditables.Mvvm.Model;
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
    
    public partial class InfoListasPage : Page
    {
       
      
        public InfoListasPage(ListaAvatarControl listaAvatarControl)
        {
            
            InitializeComponent();
            listaRepViewModel.CargarInfoLista(listaAvatarControl);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void InfoCancionTabla_AlbumClick(object sender, EventArgs e)
        {
            
        }

        private void InfoCancionTabla_ArtistaClick(object sender, EventArgs e)
        {
            
        }
    }
}
