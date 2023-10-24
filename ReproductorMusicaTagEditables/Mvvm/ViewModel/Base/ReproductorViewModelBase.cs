using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.Model;
using System.Collections.Generic;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base
{
    public abstract class ReproductorViewModelBase : ViewModelBase
    {

        protected List<string> _paths = new List<string>();
        protected List<Cancion> _canciones = new List<Cancion>();
        protected List<Cancion> _cancionesFiltradas = new List<Cancion>();
        protected string _titulo;


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
        public string Titulo { get => _titulo; set => _titulo = value; }




    }
}
