﻿#pragma checksum "..\..\..\..\..\..\Mvvm\View\Pages\TodasLasCanciones.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "328176F70BD1C3B82C39657F42E90A03419BCD6AE8059184E83FBC7ECC8858BF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro;
using MahApps.Metro.Accessibility;
using MahApps.Metro.Actions;
using MahApps.Metro.Automation.Peers;
using MahApps.Metro.Behaviors;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Converters;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using MahApps.Metro.Markup;
using MahApps.Metro.Theming;
using MahApps.Metro.ValueBoxes;
using ReproductorMusicaTagEditables.Controls.AgregarALista;
using ReproductorMusicaTagEditables.Controls.CampoTexto;
using ReproductorMusicaTagEditables.Controls.InfoCancionTabla;
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
    /// TodasLasCanciones
    /// </summary>
    public partial class TodasLasCanciones : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\..\..\Mvvm\View\Pages\TodasLasCanciones.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReproductorMusicaTagEditables.Mvvm.ViewModel.PrincipalViewModel panelPrincipal;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\..\..\..\Mvvm\View\Pages\TodasLasCanciones.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReproductorMusicaTagEditables.Controls.AgregarALista.AgregarAListaControl agregarControl;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\..\..\..\Mvvm\View\Pages\TodasLasCanciones.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtSinCanciones;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\..\..\..\Mvvm\View\Pages\TodasLasCanciones.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scrollCanciones;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\..\..\..\Mvvm\View\Pages\TodasLasCanciones.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl itemList;
        
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
            System.Uri resourceLocater = new System.Uri("/ReproductorMusicaTagEditables;component/mvvm/view/pages/todaslascanciones.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Mvvm\View\Pages\TodasLasCanciones.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.panelPrincipal = ((ReproductorMusicaTagEditables.Mvvm.ViewModel.PrincipalViewModel)(target));
            return;
            case 2:
            
            #line 61 "..\..\..\..\..\..\Mvvm\View\Pages\TodasLasCanciones.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 102 "..\..\..\..\..\..\Mvvm\View\Pages\TodasLasCanciones.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Ver_Historial);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 110 "..\..\..\..\..\..\Mvvm\View\Pages\TodasLasCanciones.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Ver_Regalos);
            
            #line default
            #line hidden
            return;
            case 5:
            this.agregarControl = ((ReproductorMusicaTagEditables.Controls.AgregarALista.AgregarAListaControl)(target));
            return;
            case 6:
            this.txtSinCanciones = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.scrollCanciones = ((System.Windows.Controls.ScrollViewer)(target));
            
            #line 149 "..\..\..\..\..\..\Mvvm\View\Pages\TodasLasCanciones.xaml"
            this.scrollCanciones.IsMouseCaptureWithinChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Actualiza_El_Listado_Canciones);
            
            #line default
            #line hidden
            return;
            case 8:
            this.itemList = ((System.Windows.Controls.ItemsControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

