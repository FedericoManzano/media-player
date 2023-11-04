using MahApps.Metro.IconPacks;
using Reproductor_Musica.Core;
using System.Windows.Controls;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info
{
    public partial class InfoReproductor:ViewModelBase
    {
        private static string _titutloVentana;
        private static CancionActual _cancionActual;
        private static MediaElement _reproductor;
        private static string _raiz;
        private static bool _estadoCarga = true;

        private static MahApps.Metro.IconPacks.PackIconFontAwesomeKind _iconoPlay;
        private static bool _preloader;

        public bool EstadoCarga
        {
            get => _estadoCarga;
            set { _estadoCarga = value; OnPropertyChanged(nameof(EstadoCarga)); }
        }

        public string TitutloVentana
        {
            get => _titutloVentana;
            set { _titutloVentana = value; OnPropertyChanged(nameof(TitutloVentana)); }
        }
        public CancionActual CancionActual
        {
            get => _cancionActual;
            set { _cancionActual = value; OnPropertyChanged(nameof(CancionActual)); }
        }
        public MediaElement Reproductor { get => _reproductor; set => _reproductor = value; }
        public string Raiz { get => _raiz; set => _raiz = value; }

        public PackIconFontAwesomeKind IconoPlay { get => _iconoPlay; set { _iconoPlay = value; OnPropertyChanged(nameof(IconoPlay)); } }

        public bool Preloader { get => _preloader; set { _preloader = value; OnPropertyChanged(nameof(Preloader)); } }

    }
}
