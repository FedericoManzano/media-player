using ReproductorMusicaTagEditables.Controls.AvatarArtista;
using ReproductorMusicaTagEditables.Controls.Paginador;
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
    /// Lógica de interacción para TodosLosArtistas.xaml
    /// </summary>
    public partial class TodosLosArtistas : Page
    {
        public TodosLosArtistas()
        {
            InitializeComponent();
            todosLosArtistas.CargarListaDeAvataresArtistas();
        }

        private void AvatarArtistaControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AvatarArtistaControl i = (AvatarArtistaControl)sender;
            this.NavigationService.Navigate(new InfoArtistaPage(i.NombreArtista));
        }

        private void CampoBuscadorControl_TextChange(object sender, RoutedEventArgs e)
        {
            ///todosLosArtistas.BuscarPorNombre(txtBusqueda.Texto);
        }

        private void BotonPaginador_DarClick(object sender, EventArgs e)
        {
            BotonPaginador botonPaginador = (BotonPaginador)sender;
            todosLosArtistas.BuscarPorNombre(botonPaginador.Inicial);
        }
    }
}
