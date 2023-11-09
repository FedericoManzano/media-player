using MahApps.Metro.IconPacks;
using Reproductor_Musica.Core;
using System.Windows;
using System.Windows.Controls;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info
{
    public partial class InfoReproductor:ViewModelBase
    {

        public static readonly int PRINCIPAL = 0;
        public static readonly int ARTISTAS = 1;
        public static readonly int ALBUMES = 2;
        public static readonly int GENERO = 3;
        public static readonly int LISTAS = 4;

        public static int PAGINA_ACTUAL = PRINCIPAL;


        private  string _titutloVentana;
        private  CancionActual _cancionActual;
        private  MediaElement _reproductor;
        private  string _raiz;
        private  bool _estadoCarga = true;

        private  MahApps.Metro.IconPacks.PackIconFontAwesomeKind _iconoPlay;
        private  bool _preloader;


        private  Visibility _isMensajeVisible = Visibility.Visible;
        private  Visibility _islistadoVisible = Visibility.Collapsed;


        public Visibility IsMensajeVisible
        {
            get => _isMensajeVisible;
            set { _isMensajeVisible = value; OnPropertyChanged(nameof(IsMensajeVisible)); }
        }
        public Visibility IslistadoVisible
        {
            get => _islistadoVisible;
            set { _islistadoVisible = value; OnPropertyChanged(nameof(IslistadoVisible)); }
        }

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
