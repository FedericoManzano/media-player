using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info
{
    public partial class InfoReproductor:ViewModelBase
    {
        private  List<string> _paths;
        private  List<Cancion> _canciones;
        private  ObservableCollection<Cancion> _cancionesFiltradas;
        private  ObservableCollection<Cancion> _partes;
        private  ObservableCollection<Cancion> _presentacion;

       
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
            set { _canciones = value; OnPropertyChanged(nameof(Canciones)); }
        }

        public ObservableCollection<Cancion> CancionesFiltradas
        {
            get => _cancionesFiltradas;
            set
            {
                _cancionesFiltradas = value;
                OnPropertyChanged(nameof(CancionesFiltradas));
            }
        }

        public ObservableCollection<Cancion> Partes
        {
            get => _partes;
            set
            {
                _partes = value;
                OnPropertyChanged(nameof(Partes));
            }
        }

        public ObservableCollection<Cancion> Presentacion
        {
            get => _presentacion;
            set
            {
                _presentacion = value;
                OnPropertyChanged(nameof(Presentacion));
            }
        }
    }
}
