﻿#pragma checksum "..\..\..\..\..\..\Mvvm\View\Pages\HistorialPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EDE7C9C3A589BE20BA55BA0A167B64B73564E6809BDC3A253A04BBCE750A04DD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using ReproductorMusicaTagEditables.Controls.Historial;
using ReproductorMusicaTagEditables.Mvvm.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ReproductorMusicaTagEditables.Mvvm.View.Pages {
    
    
    /// <summary>
    /// HistorialPage
    /// </summary>
    public partial class HistorialPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\..\..\Mvvm\View\Pages\HistorialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReproductorMusicaTagEditables.Mvvm.ViewModel.HistorialViewModel historialViewModel;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\..\..\Mvvm\View\Pages\HistorialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock albumesVacio;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\..\Mvvm\View\Pages\HistorialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer itemsAlbumes;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\..\..\Mvvm\View\Pages\HistorialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock listasVacio;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\..\..\Mvvm\View\Pages\HistorialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer listasRepro;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ReproductorMusicaTagEditables;component/mvvm/view/pages/historialpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Mvvm\View\Pages\HistorialPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 12 "..\..\..\..\..\..\Mvvm\View\Pages\HistorialPage.xaml"
            ((ReproductorMusicaTagEditables.Mvvm.View.Pages.HistorialPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\..\..\..\Mvvm\View\Pages\HistorialPage.xaml"
            ((ReproductorMusicaTagEditables.Mvvm.View.Pages.HistorialPage)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.Page_Unloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.historialViewModel = ((ReproductorMusicaTagEditables.Mvvm.ViewModel.HistorialViewModel)(target));
            return;
            case 3:
            
            #line 30 "..\..\..\..\..\..\Mvvm\View\Pages\HistorialPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Pagina_Anterior);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 43 "..\..\..\..\..\..\Mvvm\View\Pages\HistorialPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Eliminar_Historial);
            
            #line default
            #line hidden
            return;
            case 5:
            this.albumesVacio = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.itemsAlbumes = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 7:
            this.listasVacio = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.listasRepro = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

