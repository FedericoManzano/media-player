﻿#pragma checksum "..\..\..\..\Mvvm\VentanasUtilitarias\AgregarCancionesListas.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7A0F1EA17AE6409E297721E5A7FB1E6823C29DF5B8FE4156009CFA1C35E13BA5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace ReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias {
    
    
    /// <summary>
    /// AgregarCancionesListas
    /// </summary>
    public partial class AgregarCancionesListas : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\..\Mvvm\VentanasUtilitarias\AgregarCancionesListas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstListasRepro;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Mvvm\VentanasUtilitarias\AgregarCancionesListas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstAgregar;
        
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
            System.Uri resourceLocater = new System.Uri("/ReproductorMusicaTagEditables;component/mvvm/ventanasutilitarias/agregarcancione" +
                    "slistas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Mvvm\VentanasUtilitarias\AgregarCancionesListas.xaml"
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
            this.lstListasRepro = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.lstAgregar = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            
            #line 80 "..\..\..\..\Mvvm\VentanasUtilitarias\AgregarCancionesListas.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 81 "..\..\..\..\Mvvm\VentanasUtilitarias\AgregarCancionesListas.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

