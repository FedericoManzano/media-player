﻿#pragma checksum "..\..\..\..\..\Controls\InfoCancionTabla\InfoCancionTabla.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "38D6E7645486DE48E412A278D33AE205B45FDD698971449050E7B2D2A72E45C4"
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


namespace ReproductorMusicaTagEditables.Controls.InfoCancionTabla {
    
    
    /// <summary>
    /// InfoCancionTabla
    /// </summary>
    public partial class InfoCancionTabla : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\..\Controls\InfoCancionTabla\InfoCancionTabla.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReproductorMusicaTagEditables.Controls.InfoCancionTabla.InfoCancionTabla infoCancion;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\Controls\InfoCancionTabla\InfoCancionTabla.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCheck;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\Controls\InfoCancionTabla\InfoCancionTabla.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.IconPacks.PackIconFontAwesome iconCheck;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\..\Controls\InfoCancionTabla\InfoCancionTabla.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContextMenu menuContexto;
        
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
            System.Uri resourceLocater = new System.Uri("/ReproductorMusicaTagEditables;component/controls/infocanciontabla/infocanciontab" +
                    "la.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Controls\InfoCancionTabla\InfoCancionTabla.xaml"
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
            this.infoCancion = ((ReproductorMusicaTagEditables.Controls.InfoCancionTabla.InfoCancionTabla)(target));
            return;
            case 2:
            this.btnCheck = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\..\Controls\InfoCancionTabla\InfoCancionTabla.xaml"
            this.btnCheck.Click += new System.Windows.RoutedEventHandler(this.Check_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.iconCheck = ((MahApps.Metro.IconPacks.PackIconFontAwesome)(target));
            return;
            case 4:
            
            #line 42 "..\..\..\..\..\Controls\InfoCancionTabla\InfoCancionTabla.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnPlayClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 63 "..\..\..\..\..\Controls\InfoCancionTabla\InfoCancionTabla.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnArtistaClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 69 "..\..\..\..\..\Controls\InfoCancionTabla\InfoCancionTabla.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnAlbumClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.menuContexto = ((System.Windows.Controls.ContextMenu)(target));
            return;
            case 8:
            
            #line 104 "..\..\..\..\..\Controls\InfoCancionTabla\InfoCancionTabla.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 111 "..\..\..\..\..\Controls\InfoCancionTabla\InfoCancionTabla.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

