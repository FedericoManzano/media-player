
using System.Windows;
using System.Windows.Controls;


namespace ReproductorMusicaTagEditables.Controls.ManejadorVentana
{

    public partial class ManejadorVentana : UserControl
    {
        public ManejadorVentana()
        {
            InitializeComponent();
        }


        public static readonly RoutedEvent CerrarEvent = 
            EventManager.RegisterRoutedEvent("Cerrar",RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ManejadorVentana));  
    
    
        public event RoutedEventHandler Cerrar
        {
            add => AddHandler(CerrarEvent, value);
            remove => RemoveHandler(CerrarEvent, value);
        }

        public void OnCerrar (object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(CerrarEvent));
        }



        public static readonly RoutedEvent MaximizarEvent =
            EventManager.RegisterRoutedEvent("Maximizar", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ManejadorVentana));


        public event RoutedEventHandler Maximizar
        {
            add => AddHandler(MaximizarEvent, value);
            remove => RemoveHandler(MaximizarEvent, value);
        }

        public void OnMaximizar(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(MaximizarEvent));
        }



        public static readonly RoutedEvent MinimizarEvent =
            EventManager.RegisterRoutedEvent("Minimizar", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ManejadorVentana));

        public event RoutedEventHandler Minimizar
        {
            add => AddHandler(MinimizarEvent, value);
            remove => RemoveHandler(MinimizarEvent, value);
        }

        public void OnMinimizar(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(MinimizarEvent));
        }

       
    }
}
