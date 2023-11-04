using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.View;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System;
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
            this.CurrentView = new PrincipalViewModel();
        }

        private void MostrarListasView(object obj)
        {
            if (!Irg.Preloader)
            {
                Irg.Partes.Clear();
                this.CurrentView = new ListasViewModel();
            }
        }

        private void MostrarAlbumesView(object obj)
        {
            if(!Irg.Preloader)
            {
                Irg.Partes.Clear();
                this.CurrentView = new AlbumesViewModel();
            }
        }

        private void MostrarAristasViewAction(object obj)
        {
            if(!Irg.Preloader)
            {
                Irg.Partes.Clear();
                this.CurrentView = new ArtistaViewModel();
            }
            
        }

        private void MostrarPrincipalViewAction(object obj)
        {
            if(!Irg.Preloader)
                this.CurrentView = new PrincipalViewModel();
        }
    }
}
