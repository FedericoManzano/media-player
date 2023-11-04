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
        private static List<string> _paths;
        private static List<Cancion> _canciones;
        private static ObservableCollection<Cancion> _cancionesFiltradas;
        private static ObservableCollection<Cancion> _partes;
        private static ObservableCollection<Cancion> _presentacion;

        private Dictionary<string, Dictionary<string, Cancion>> _diccionarioPaginado;
        private static Dictionary<string, bool> _paginas;
       
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

        public  Dictionary<string, bool> Paginas 
        { 
            get => _paginas; 
            set 
            {
                _paginas = value; OnPropertyChanged(nameof(Paginas));
            } 
        }
    }
}
