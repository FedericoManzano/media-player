﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "68AF8144A5CC5A8EC81283FCDF76A879AF530A74F094783A250FDF2E251EEE83"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ReproductorMusicaTagEditables.Controls.InfoArtista;
using ReproductorMusicaTagEditables.Controls.ManejadorVentana;
using ReproductorMusicaTagEditables.Controls.Menu;
using ReproductorMusicaTagEditables.Controls.PanelControlTrack;
using ReproductorMusicaTagEditables.Controls.TiempoTrack;
using ReproductorMusicaTagEditables.Mvvm.View;
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


namespace ReproductorMusicaTagEditables {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReproductorMusicaTagEditables.Mvvm.ViewModel.ReproductorViewModel reproViewModel;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReproductorMusicaTagEditables.Controls.InfoArtista.InfoArtista infoArtista;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReproductorMusicaTagEditables.Controls.PanelControlTrack.PanelControlMusica panelControlMusica;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sliderLineTime;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReproductorMusicaTagEditables.Controls.TiempoTrack.TiempoTrack controlTiempo;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement mediaReproductor;
        
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
            System.Uri resourceLocater = new System.Uri("/ReproductorMusicaTagEditables;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 19 "..\..\MainWindow.xaml"
            ((ReproductorMusicaTagEditables.MainWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Arrastrar_Ventana);
            
            #line default
            #line hidden
            return;
            case 2:
            this.reproViewModel = ((ReproductorMusicaTagEditables.Mvvm.ViewModel.ReproductorViewModel)(target));
            return;
            case 3:
            this.infoArtista = ((ReproductorMusicaTagEditables.Controls.InfoArtista.InfoArtista)(target));
            return;
            case 4:
            this.panelControlMusica = ((ReproductorMusicaTagEditables.Controls.PanelControlTrack.PanelControlMusica)(target));
            return;
            case 5:
            this.sliderLineTime = ((System.Windows.Controls.Slider)(target));
            
            #line 126 "..\..\MainWindow.xaml"
            this.sliderLineTime.AddHandler(System.Windows.Controls.Primitives.Thumb.DragStartedEvent, new System.Windows.Controls.Primitives.DragStartedEventHandler(this.Comenzar_Arrastre_Slider_TimeLineSlider));
            
            #line default
            #line hidden
            
            #line 127 "..\..\MainWindow.xaml"
            this.sliderLineTime.AddHandler(System.Windows.Controls.Primitives.Thumb.DragCompletedEvent, new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.Finalizar_Arrastre_Slider_TimeLineSlider));
            
            #line default
            #line hidden
            
            #line 128 "..\..\MainWindow.xaml"
            this.sliderLineTime.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.sliderLineTime_MouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 129 "..\..\MainWindow.xaml"
            this.sliderLineTime.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.sliderLineTime_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.controlTiempo = ((ReproductorMusicaTagEditables.Controls.TiempoTrack.TiempoTrack)(target));
            return;
            case 7:
            this.mediaReproductor = ((System.Windows.Controls.MediaElement)(target));
            
            #line 144 "..\..\MainWindow.xaml"
            this.mediaReproductor.MediaOpened += new System.Windows.RoutedEventHandler(this.Inicio_Track);
            
            #line default
            #line hidden
            
            #line 145 "..\..\MainWindow.xaml"
            this.mediaReproductor.MediaEnded += new System.Windows.RoutedEventHandler(this.Final_Track);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

