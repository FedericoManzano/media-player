using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.Model;
using System.Collections.Generic;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base
{
    public abstract class ReproductorViewModelBase : ViewModelBase
    {

        protected static List<string> _paths = new List<string>();
        protected static List<Cancion> _canciones = new List<Cancion>();
        protected static List<Cancion> _cancionesFiltradas = new List<Cancion>();
        private static CancionActual cancionActual;
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
        protected CancionActual CancionActual { get => cancionActual; set => cancionActual = value; }
    }
}
