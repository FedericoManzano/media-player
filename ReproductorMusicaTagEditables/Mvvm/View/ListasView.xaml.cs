
using ReproductorMusicaTagEditables.Mvvm.View.Pages;
using System.Diagnostics;
using System.Windows.Controls;


namespace ReproductorMusicaTagEditables.Mvvm.View
{
    public partial class ListasView : UserControl
    {
        ListasPage listasPage = new ListasPage();
        public ListasView()
        {
            InitializeComponent();
            paginacion.NavigationService.Navigate(listasPage);
        }



    }
}
