
using ReproductorMusicaTagEditables.Mvvm.View.Pages;
using System.Windows.Controls;


namespace ReproductorMusicaTagEditables.Mvvm.View
{
    /// <summary>
    /// Lógica de interacción para ArtistaView.xaml
    /// </summary>
    public partial class ArtistaView : UserControl
    {
        public ArtistaView()
        {
            InitializeComponent();
            paginacion.NavigationService.Navigate(new TodosLosArtistas());
        }
    }
}
