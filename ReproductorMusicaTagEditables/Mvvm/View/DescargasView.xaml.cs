﻿using ReproductorMusicaTagEditables.Mvvm.View.Pages;
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

namespace ReproductorMusicaTagEditables.Mvvm.View
{
    /// <summary>
    /// Lógica de interacción para DescargasView.xaml
    /// </summary>
    public partial class DescargasView : UserControl
    {
        public DescargasView()
        {
            InitializeComponent();
            paginacion.NavigationService.Navigate(new DescargasPage());
        }
    }
}