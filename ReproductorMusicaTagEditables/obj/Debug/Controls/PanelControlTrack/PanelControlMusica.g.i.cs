﻿#pragma checksum "..\..\..\..\Controls\PanelControlTrack\PanelControlMusica.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ABAC31C8C0823D11AB65B301D0403C675131DA2D42B983DCC7F613BE1D781989"
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
using ReproductorMusicaTagEditables.Controls.PanelControlTrack;
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


namespace ReproductorMusicaTagEditables.Controls.PanelControlTrack {
    
    
    /// <summary>
    /// PanelControlMusica
    /// </summary>
    public partial class PanelControlMusica : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Controls\PanelControlTrack\PanelControlMusica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReproductorMusicaTagEditables.Controls.PanelControlTrack.PanelControlMusica panelControl;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Controls\PanelControlTrack\PanelControlMusica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border contenedorVolumen;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Controls\PanelControlTrack\PanelControlMusica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sliderVolumen;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Controls\PanelControlTrack\PanelControlMusica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVolumen;
        
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
            System.Uri resourceLocater = new System.Uri("/ReproductorMusicaTagEditables;component/controls/panelcontroltrack/panelcontrolm" +
                    "usica.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\PanelControlTrack\PanelControlMusica.xaml"
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
            this.panelControl = ((ReproductorMusicaTagEditables.Controls.PanelControlTrack.PanelControlMusica)(target));
            return;
            case 2:
            this.contenedorVolumen = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.sliderVolumen = ((System.Windows.Controls.Slider)(target));
            return;
            case 4:
            
            #line 31 "..\..\..\..\Controls\PanelControlTrack\PanelControlMusica.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClickAnterior);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 34 "..\..\..\..\Controls\PanelControlTrack\PanelControlMusica.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClickPlay);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 37 "..\..\..\..\Controls\PanelControlTrack\PanelControlMusica.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClickSiguiente);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnVolumen = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\Controls\PanelControlTrack\PanelControlMusica.xaml"
            this.btnVolumen.Click += new System.Windows.RoutedEventHandler(this.Mostrar_Slider_Volumen);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

