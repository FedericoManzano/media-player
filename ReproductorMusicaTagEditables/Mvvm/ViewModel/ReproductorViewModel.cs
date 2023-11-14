using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.View;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System.Windows.Input;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class ReproductorViewModel : ReproductorViewModelBase
    {
        private ReproductorViewModelBase _currentView;
        

        public bool CAMBIO_PAGINA
        {
            get => EstadosControl.CAMBIO_PAGINA;
            set
            {
                EstadosControl.CAMBIO_PAGINA = value;
                OnPropertyChanged(nameof( CAMBIO_PAGINA ));
            }
        }

        public ICommand PrincipalCommand { get; }
        public ICommand ArtistasCommand { get; }
        public ICommand AlbumesCommand { get; }
        public ICommand ListasCommand { get; }
        public ICommand FavoritosCommand { get; }


        public ReproductorViewModelBase CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public ReproductorViewModel ()
        {
            PrincipalCommand = new RelayCommand(MostrarPrincipalViewAction);
            ArtistasCommand = new RelayCommand(MostrarAristasViewAction);
            AlbumesCommand = new RelayCommand (MostrarAlbumesView);
            ListasCommand = new RelayCommand(MostrarListasView);
            FavoritosCommand = new RelayCommand(MostrarFavoritosView);
            this.CurrentView = new PrincipalViewModel();
        }

        private void MostrarFavoritosView(object obj)
        {
            if (InfoReproductor.PAGINA_ACTUAL != InfoReproductor.FAVORITOS)
            {
                InfoReproductor.PAGINA_ACTUAL = InfoReproductor.FAVORITOS;
                LimpiarInfoDePaginas();
                if (!Irg.Preloader)
                {
                    Irg.Partes.Clear();
                    this.CurrentView = new FavoritosViewModel();
                }
            }
        }

        private void MostrarListasView(object obj)
        {
            if(InfoReproductor.PAGINA_ACTUAL != InfoReproductor.LISTAS)
            {
                InfoReproductor.PAGINA_ACTUAL = InfoReproductor.LISTAS;
                LimpiarInfoDePaginas();
                if (!Irg.Preloader)
                {
                    Irg.Partes.Clear();
                    this.CurrentView = new ListasViewModel();
                }
            }
        }

        private void MostrarAlbumesView(object obj)
        {
            if(InfoReproductor.PAGINA_ACTUAL != InfoReproductor.ALBUMES)
            {
                InfoReproductor.PAGINA_ACTUAL = InfoReproductor.ALBUMES;
                LimpiarInfoDePaginas();
                if (!Irg.Preloader)
                {
                    Irg.Partes.Clear();
                    this.CurrentView = new AlbumesViewModel();
                }
            }

            
        }

        private void MostrarAristasViewAction(object obj)
        {
            if(InfoReproductor.PAGINA_ACTUAL != InfoReproductor.ARTISTAS)
            {
                InfoReproductor.PAGINA_ACTUAL = InfoReproductor.ARTISTAS;
                LimpiarInfoDePaginas();
                if (!Irg.Preloader)
                {
                    Irg.Partes.Clear();
                    this.CurrentView = new ArtistaViewModel();
                }
            }
            
            
        }

        private void MostrarPrincipalViewAction(object obj)
        {
            if(InfoReproductor.PAGINA_ACTUAL != InfoReproductor.PRINCIPAL)
            {
                InfoReproductor.PAGINA_ACTUAL = InfoReproductor.PRINCIPAL;
                LimpiarInfoDePaginas();
                if (!Irg.Preloader)
                    this.CurrentView = new PrincipalViewModel();
            }
        }


        private void LimpiarInfoDePaginas()
        {
            PrincipalView.myFrame.NavigationService.RemoveBackEntry();
            PrincipalView.myFrame.Content = null;
            TodosLosArtistasViewModel._diccionadioArtistas.Clear();
            TodosLosArtistasViewModel.paginador.Clear();
            TodosLosArtistasViewModel._artistas.Clear();
            TodosLosAlbumesViewModel.paginacion.Clear();
            TodosLosAlbumesViewModel.diccionarioalbumes.Clear();
            TodosLosAlbumesViewModel._avatarAlbums.Clear();

            System.GC.Collect();
        }
    }
}
