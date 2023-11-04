using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.ArchivoImagen;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class TodosLosArtistasViewModel:ReproductorViewModelBase
    {

        public Dictionary<string, Dictionary<string, Cancion>> _diccionadioArtistas;
        private Dictionary<string, bool> paginador;


        public ObservableCollection<Cancion> _artistas;

        public ObservableCollection<Cancion> Avatars 
        { 
            get => _artistas;
            set
            {
                _artistas = value;
                OnPropertyChanged(nameof(Avatars));

            }
        }

        public Dictionary<string, bool> Paginador 
        {
            get => paginador;
            set { paginador = value; OnPropertyChanged(nameof(Paginador)); } 
        }

        public TodosLosArtistasViewModel() { 
            Avatars = new ObservableCollection<Cancion>();
            _diccionadioArtistas = new Dictionary<string, Dictionary<string, Cancion>>();
            Paginador = new Dictionary<string, bool>();
        }

        public  void CargarListaDeAvataresArtistas()
        {

            List<Cancion> canciones = Irg.Canciones;

            foreach (var c in canciones)
            {
                if (_diccionadioArtistas.ContainsKey(c.Artista.PrimeraLetraMayuscula()))
                {
                    _diccionadioArtistas[c.Artista.PrimeraLetraMayuscula()][c.Artista] = c;
                }
                else
                {
                    _diccionadioArtistas[c.Artista.PrimeraLetraMayuscula()] = new Dictionary<string, Cancion>
                    {
                        [c.Artista] = c
                    };
                }
                Paginador[c.Artista.PrimeraLetraMayuscula()] = false;
            }

            if (_diccionadioArtistas.Count > 0)
            {
                Paginador = Paginador.OrdenarPorClave();
                Paginador = Paginador.MarcarClave(Paginador.Keys.First());
                Avatars = _diccionadioArtistas.CargarImagenes(Paginador.Keys.First());
            }
        }

        public void BuscarPorNombre(string artista)
        {
            Paginador = Paginador.DesmarcarTodos();
            Paginador = Paginador.MarcarClave(artista);
            Avatars = _diccionadioArtistas.CargarImagenes(artista);
        }

    }
}
