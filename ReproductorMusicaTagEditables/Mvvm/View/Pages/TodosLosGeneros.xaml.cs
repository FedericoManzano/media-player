using ReproductorMusicaTagEditables.Controls.ListaAvatar;
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
    /// Lógica de interacción para TodosLosGeneros.xaml
    /// </summary>
    public partial class TodosLosGeneros : Page
    {
        public TodosLosGeneros()
        {
            InitializeComponent();
            
        }

        private void BotonPaginador_DarClick(object sender, EventArgs e)
        {
            BotonPaginador botonPaginador = (BotonPaginador)sender;
            todosLosGeneros.ActualizarListas(botonPaginador.Inicial);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            todosLosGeneros.Limpiar();
            todosLosGeneros.CargarListasReproduccion();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            todosLosGeneros.Limpiar();
        }

        private void ListaAvatarControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListaAvatarControl i = (ListaAvatarControl) sender;
            todosLosGeneros.Limpiar();
            this.NavigationService.Navigate(new InfoGeneroPage(i.Nombre));
        }
    }
}
