using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class ReproductorViewModel : ReproductorViewModelBase
    {
        private ReproductorViewModelBase _currentView;
        

        public ICommand PrincipalCommand { get; }
        public ICommand ArtistasCommand { get; }
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
            this.CurrentView = new PrincipalViewModel();
        }

        private void MostrarAristasViewAction(object obj)
        {
            this.CurrentView = new ArtistaViewModel();
        }

        private void MostrarPrincipalViewAction(object obj)
        {
            this.CurrentView = new PrincipalViewModel();
        }
    }
}
