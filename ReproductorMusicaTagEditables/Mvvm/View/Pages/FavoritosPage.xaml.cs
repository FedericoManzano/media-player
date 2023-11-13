using ReproductorMusicaTagEditables.Controls.ListaAvatar;
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
    public partial class FavoritosPage : Page
    {
        public FavoritosPage()
        {
            InitializeComponent();
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            favoritosViewModel.CrearAvatarFavoritos();
            ListaAvatarControl l = new ListaAvatarControl()
            {
                Nombre = favoritosViewModel.ListaRep.Nombre,
                Cantidad = favoritosViewModel.ListaRep.CantidadCanciones,
                ImagenUno = favoritosViewModel.ListaRep.Imagen1,
                ImagenDos = favoritosViewModel.ListaRep.Imagen2,
                ImagenTres = favoritosViewModel.ListaRep.Imagen3,
                ImagenCuatro = favoritosViewModel.ListaRep.Imagen4,
            };
            this.NavigationService.Navigate(new InfoListasPage(l));
        }
    }
}
