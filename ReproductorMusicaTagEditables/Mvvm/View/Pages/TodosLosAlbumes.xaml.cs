using ReproductorMusicaTagEditables.Controls.AvatarAlbum;
using ReproductorMusicaTagEditables.Controls.Paginador;
using ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ReproductorMusicaTagEditables.Mvvm.View.Pages
{
    public partial class TodosLosAlbumes : Page
    {
        public TodosLosAlbumes()
        {
            InitializeComponent();
            todosLosAlbumes.CargarAvatarAlbumes();
        }

        

        private void AvatarAlbumControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AvatarAlbumControl i = (AvatarAlbumControl)sender;
            this.NavigationService.Navigate(new InfoAlbumPage(i.NombreAlbum));
        }

        private void BotonPaginador_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        { 
            BotonPaginador i = (BotonPaginador)sender;
            todosLosAlbumes.BuscarPorAlbum(i.Inicial);
        }

        private void BotonPaginador_DarClick(object sender, System.EventArgs e)
        {
            BotonPaginador i = (BotonPaginador)sender;
            todosLosAlbumes.BuscarPorAlbum(i.Inicial);
        }
    }
}
