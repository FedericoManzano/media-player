﻿
using System;
using System.Windows.Controls;

namespace ReproductorMusicaTagEditables.Mvvm.View.Pages
{
    public partial class TodasLasCanciones : Page
    {

        public TodasLasCanciones()
        {
            InitializeComponent();
            panelPrincipal.AgregarElementosAlFiltro();
            scrollCanciones.ScrollToVerticalOffset(panelPrincipal.ScrollVertical);
        }

        private void InfoCancionTabla_PlayClick(object sender, EventArgs e)
        {
            panelPrincipal.ScrollVertical = scrollCanciones.VerticalOffset;
        }

        private void Actualiza_El_Listado_Canciones(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            panelPrincipal.AgregarElementosAlFiltro();
        }

        private void Cargar_Archivos_Directorio(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }
    }
}
