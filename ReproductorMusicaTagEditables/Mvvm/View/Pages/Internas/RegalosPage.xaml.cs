using ReproductorMusicaTagEditables.Controls.Paginador;
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
        private Dictionary<string, List<Cancion>> _dic;
        public RegalosPage(Dictionary<string, List<Cancion>> dic)
        {
            InitializeComponent();
            _dic = dic;
        }

        private void BotonPaginador_DarClick(object sender, EventArgs e)
        {
            BotonPaginador botonPaginador = (BotonPaginador)sender;
            regalosViewModel.SeleccionarPagina(botonPaginador.Inicial);
        }

        private void RegalosControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegalosControl i = (RegalosControl)sender;
            this.NavigationService.Navigate(new RegaloListaPage(i.Texto));
        }

        private void Ir_Atras(object sender, RoutedEventArgs e)
        {
            if(this.NavigationService.CanGoBack)
            {
                regalosViewModel.Limpiar();
                this.NavigationService.GoBack();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            regalosViewModel.Limpiar();
            regalosViewModel.CargarRegalos(_dic);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            regalosViewModel.Limpiar();
        }
    }
}
