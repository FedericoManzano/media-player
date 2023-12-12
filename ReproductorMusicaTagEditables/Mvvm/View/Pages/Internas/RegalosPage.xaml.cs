using ReproductorMusicaTagEditables.Controls.Regalos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ReproductorMusicaTagEditables.Mvvm.View.Pages.Internas
{
    public partial class RegalosPage : Page
    {
        public RegalosPage(Dictionary<string, List<Cancion>> dic)
        {
            InitializeComponent();
            regalosViewModel.CargarRegalos(dic);
        }

        private void BotonPaginador_DarClick(object sender, EventArgs e)
        {
            
        }

        private void RegalosControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegalosControl i = (RegalosControl)sender;
            this.NavigationService.Navigate(new RegaloListaPage(i.Texto));
        }
    }
}
