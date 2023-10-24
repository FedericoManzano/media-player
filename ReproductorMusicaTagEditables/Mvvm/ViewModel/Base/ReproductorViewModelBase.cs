using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base
{
    public abstract class ReproductorViewModelBase : ViewModelBase
    {

        private List<string> _paths = new List<string>();
        private List<Cancion> _canciones = new List<Cancion>();
        private List<Cancion> _cancionesFiltradas = new List<Cancion>();

        public List<string> Paths 
        { 
            get => _paths; 
            set 
            {
                _paths = value;
                OnPropertyChanged(nameof(Paths));
            } 
        }
        public List<Cancion> Canciones 
        { 
            get => _canciones;
            set 
            { 
                _canciones = value;
                OnPropertyChanged(nameof(Canciones));
            }
        }
        public List<Cancion> CancionesFiltradas 
        {
            get => _cancionesFiltradas; 
            set 
            {
                _cancionesFiltradas = value; 
                OnPropertyChanged(nameof(CancionesFiltradas));
            } 
        }



    }
}
