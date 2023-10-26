
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Controls.PanelControlTrack
{
    
    public partial class PanelControlMusica : UserControl
    {
        public bool visibilidadSliderVolumen = false;
        
        public PanelControlMusica()
        {
            InitializeComponent();
        }


        #region EventoAnterior Definición
        public static readonly RoutedEvent AnteriorEvent = 
            EventManager.RegisterRoutedEvent("AnteriorClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PanelControlMusica));  


        public event RoutedEventHandler AnteriorClick
        {
            add => AddHandler(AnteriorEvent,value);
            remove => RemoveHandler(AnteriorEvent,value);
        }

        public void OnClickAnterior (object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(AnteriorEvent));
        }
        #endregion


        #region EventoSiguiente Definición
        public static readonly RoutedEvent SiguienteEvent =
           EventManager.RegisterRoutedEvent("SiguienteClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PanelControlMusica));


        public event RoutedEventHandler SiguienteClick
        {
            add => AddHandler(SiguienteEvent, value);
            remove => RemoveHandler(SiguienteEvent, value);
        }
        

        public void OnClickSiguiente(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SiguienteEvent));
        }
        #endregion


        #region EventoPlay Definición
        public static readonly RoutedEvent PlayEvent =
           EventManager.RegisterRoutedEvent("PlayClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PanelControlMusica));
        public event RoutedEventHandler PlayClick
        {
            add => AddHandler(PlayEvent, value);
            remove => RemoveHandler(PlayEvent, value);
        }

        public void OnClickPlay(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(PlayEvent));
        }
        #endregion


        #region Volumen Value
        public static DependencyProperty ValorVolumenProperty =
            DependencyProperty.Register("ValorVolumen", typeof(double), typeof(PanelControlMusica));


        public double ValorVolumen
        {
            get => (double) GetValue(ValorVolumenProperty);
            set => SetValue(ValorVolumenProperty, value);
        }
        #endregion


        #region Play Command
        public static readonly DependencyProperty PlayCommandProperty =
            DependencyProperty.Register("PlayCommand",typeof(ICommand),typeof(PanelControlMusica));

        public ICommand PlayCommand
        {
            get => GetValue(PlayCommandProperty) as ICommand;
            set => SetValue(PlayCommandProperty, value);    
        }
        #endregion


        #region Siguiente Command
        public static readonly DependencyProperty SiguienteCommandProperty =
            DependencyProperty.Register("SiguienteCommand", typeof(ICommand), typeof(PanelControlMusica));

        public ICommand SiguienteCommand
        {
            get => GetValue(SiguienteCommandProperty) as ICommand;
            set => SetValue(SiguienteCommandProperty, value);
        }
        #endregion

        #region Atras Command
        public static readonly DependencyProperty AtrasCommandProperty =
                    DependencyProperty.Register("AtrasCommand", typeof(ICommand), typeof(PanelControlMusica));

        public ICommand AtrasCommand
        {
            get => GetValue(AtrasCommandProperty) as ICommand;
            set => SetValue(AtrasCommandProperty, value);
        }
        #endregion


        public static RoutedEvent ValueChangeEvent = 
            EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PanelControlMusica));

        public event RoutedEventHandler ValueChanged
        {
            add => AddHandler(ValueChangeEvent,value);
            remove => RemoveHandler(ValueChangeEvent,value);
        }


        public void OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RaiseEvent(new RoutedEventArgs(ValueChangeEvent));
        }

        private void Mostrar_Slider_Volumen(object sender, RoutedEventArgs e)
        {
            if(contenedorVolumen.Visibility == Visibility.Visible)
            {
                contenedorVolumen.Visibility = Visibility.Collapsed;
                btnVolumen.Foreground = Brushes.White;
            }
            else
            {
                contenedorVolumen.Visibility = Visibility.Visible;
                btnVolumen.Foreground = Brushes.Orange;
            }
        }

        private void sliderVolumen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
