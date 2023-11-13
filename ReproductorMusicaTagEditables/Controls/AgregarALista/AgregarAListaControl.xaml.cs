
using System;
using System.Windows;
using System.Windows.Controls;


namespace ReproductorMusicaTagEditables.Controls.AgregarALista
{
    public partial class AgregarAListaControl : UserControl
    {
        public AgregarAListaControl()
        {
            InitializeComponent();
        }

        public static DependencyProperty VisibilidadProperty =
            DependencyProperty.Register("Visibilidad", typeof(Visibility), typeof(AgregarAListaControl), new PropertyMetadata(Visibility.Hidden));


        public Visibility Visibilidad
        {
            get =>(Visibility) GetValue(VisibilidadProperty);
            set => SetValue(VisibilidadProperty, value);
        }


        public static RoutedEvent AgregarClickEvent =
            EventManager.RegisterRoutedEvent("AgregarClick", RoutingStrategy.Bubble, typeof(EventHandler), typeof(AgregarAListaControl));
        
        public event EventHandler AgregarClick
        {
            add { AddHandler(AgregarClickEvent, value); }
            remove {  RemoveHandler(AgregarClickEvent, value);}
        }

        public void OnAgregarClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(AgregarClickEvent));
        }

        public static RoutedEvent DesmarcarClickEvent =
            EventManager.RegisterRoutedEvent("DesmarcarClick", RoutingStrategy.Bubble, typeof(EventHandler), typeof(AgregarAListaControl));

        public event EventHandler DesmarcarClick
        {
            add { AddHandler(DesmarcarClickEvent, value); }
            remove { RemoveHandler(DesmarcarClickEvent, value); }
        }

        public void OnDesmarcarClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(DesmarcarClickEvent));
        }
    }
}
