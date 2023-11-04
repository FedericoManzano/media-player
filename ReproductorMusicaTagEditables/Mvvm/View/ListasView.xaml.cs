
using ReproductorMusicaTagEditables.Mvvm.View.Pages;
using System.Windows.Controls;


namespace ReproductorMusicaTagEditables.Mvvm.View
{
    public partial class ListasView : UserControl
    {
        public ListasView()
        {
            InitializeComponent();
            paginacion.NavigationService.Navigate(new ListasPage());
        }



    }
}
