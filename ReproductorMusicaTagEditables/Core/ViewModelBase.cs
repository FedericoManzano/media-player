
using System.ComponentModel;

namespace Reproductor_Musica.Core
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged (string property)
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (property));
        }
    }
}
