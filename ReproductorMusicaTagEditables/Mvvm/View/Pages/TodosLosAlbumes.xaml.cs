using ReproductorMusicaTagEditables.Controls.AvatarAlbum;
using ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas;
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

namespace ReproductorMusicaTagEditables.Mvvm.View.Pages
{
    /// <summary>
    /// Lógica de interacción para TodosLosAlbumes.xaml
    /// </summary>
    public partial class TodosLosAlbumes : Page
    {
        public TodosLosAlbumes()
        {
            InitializeComponent();
            todosLosAlbumes.CargarAvatarAlbumes();
        }

        private void txtBusqueda_TextChange(object sender, RoutedEventArgs e)
        {
            todosLosAlbumes.BuscarPorAlbum(txtBusqueda.Texto);
        }

        private void AvatarAlbumControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AvatarAlbumControl i = (AvatarAlbumControl)sender;
            this.NavigationService.Navigate(new InfoAlbumPage(i.NombreAlbum));
        }
    }
}
