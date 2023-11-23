using System;

using System.Windows;
using System.Windows.Controls;


namespace ReproductorMusicaTagEditables.Controls.DescargarCancion
{
    /// <summary>
    /// Lógica de interacción para DescargarCancionControl.xaml
    /// </summary>
    public partial class DescargarCancionControl : UserControl
    {

        public static DependencyProperty TextoProperty =
            DependencyProperty.Register("Texto", typeof(string), typeof(DescargarCancionControl), new PropertyMetadata(string.Empty));


        public string Texto
        {
            get => (string)GetValue(TextoProperty); set => SetValue(TextoProperty, value);
        }


        public static DependencyProperty EsVisibleProperty =
           DependencyProperty.Register("EsVisible", typeof(bool), typeof(DescargarCancionControl), new PropertyMetadata(false));


        public bool EsVisible
        {
            get => (bool)GetValue(EsVisibleProperty); set => SetValue(EsVisibleProperty, value);
        }


        public static DependencyProperty OkVisibilidadProperty =
           DependencyProperty.Register("Ok", typeof(Visibility), typeof(DescargarCancionControl), new PropertyMetadata(Visibility.Collapsed));


        public Visibility Ok
        {
            get => (Visibility)GetValue(OkVisibilidadProperty); set => SetValue(OkVisibilidadProperty, value);
        }


        public static DependencyProperty HibilitadoProperty =
           DependencyProperty.Register("Habilitado", typeof(bool), typeof(DescargarCancionControl), new PropertyMetadata(true));


        public bool Habilitado
        {
            get => (bool)GetValue(HibilitadoProperty); set => SetValue(HibilitadoProperty, value);
        }


        public static DependencyProperty ColorEstadoProperty =
           DependencyProperty.Register("ColorEstado", typeof(string), typeof(DescargarCancionControl), new PropertyMetadata(string.Empty));


        public string ColorEstado
        {
            get => (string)GetValue(ColorEstadoProperty); set => SetValue(ColorEstadoProperty, value);
        }

        public static DependencyProperty IconoEstadoProperty =
           DependencyProperty.Register("IconoEstado", typeof(MahApps.Metro.IconPacks.PackIconFontAwesomeKind), typeof(DescargarCancionControl));


        public MahApps.Metro.IconPacks.PackIconFontAwesomeKind IconoEstado
        {
            get => (MahApps.Metro.IconPacks.PackIconFontAwesomeKind)GetValue(IconoEstadoProperty); set => SetValue(IconoEstadoProperty, value);
        }

        private static RoutedEvent ClickEvent =
            EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(EventHandler), typeof(DescargarCancionControl));

        public event EventHandler Click
        {
            add => AddHandler(ClickEvent, value);   
            remove => RemoveHandler(ClickEvent, value); 
        }

        public void OnClick (object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ClickEvent));
        }
        public DescargarCancionControl()
        {
            InitializeComponent();
        }
    }
}
