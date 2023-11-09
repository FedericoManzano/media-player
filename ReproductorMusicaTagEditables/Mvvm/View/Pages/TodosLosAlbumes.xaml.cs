using ReproductorMusicaTagEditables.Controls.AvatarAlbum;
using ReproductorMusicaTagEditables.Controls.Paginador;
using ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
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
            if(i.NombreAlbum == "Desconocido")
            {
                System.Windows.Forms.MessageBox.Show("El álbum al que intenta acceder es desconocido, por lo tanto, la metadata de los archivos de audio es inexistente. Puede solucionar esto desde el botón (EDITAR TAGS) de la pestaña 'Inicio' para agregar la información pertinente.", "Álbum Desconocido",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            
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
