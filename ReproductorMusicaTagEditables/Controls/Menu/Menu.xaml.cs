
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReproductorMusicaTagEditables.Controls.Menu
{
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(Menu));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty); 
            set => SetValue(CommandProperty, value);
        }
    }
}
