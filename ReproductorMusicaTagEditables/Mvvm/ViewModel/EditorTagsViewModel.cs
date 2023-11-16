using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Controls.InfoCancionTabla;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class EditorTagsViewModel : ViewModelBase
    {

        #region Listados
        private ObservableCollection<Cancion> _canciones = new ObservableCollection<Cancion>();
        private ObservableCollection<Cancion> _cancionesSeleccionadas = new ObservableCollection<Cancion>();

        public ObservableCollection<Cancion> Canciones
        {
            get => _canciones;
            set { _canciones = value; OnPropertyChanged(nameof(Canciones)); }
        }
        public ObservableCollection<Cancion> CancionesSeleccionadas
        {
            get => _cancionesSeleccionadas;
            set { _cancionesSeleccionadas = value; OnPropertyChanged(nameof(CancionesSeleccionadas)); }
        }
        #endregion

        #region Campos
        private string _numero;
        public string Numero
        {
            get => _numero;
            set { _numero = value; OnPropertyChanged(nameof(Numero));}
        }

        private string _titulo;
        private string Titulo
        {
            get => _titulo;
            set { _titulo = value; OnPropertyChanged(nameof(Titulo)); }
        }

        private string _artista;
        private string Artista
        {
            get => _artista;
            set { _artista = value; OnPropertyChanged(nameof(Artista)); }
        }


        private string _album;
        private string Album
        {
            get => _album;
            set { _album = value; OnPropertyChanged(nameof(Album)); }
        }

        private string _genero;
        private string Genero
        {
            get => _genero;
            set { _genero = value; OnPropertyChanged(nameof(Genero)); }
        }

        private string _ano;
        private string Ano
        {
            get => _ano;
            set { _ano = value; OnPropertyChanged(nameof(Ano)); }
        }
        #endregion



        public async void CargarCancionesAEditar()
        {
            FolderBrowserDialog fc = new FolderBrowserDialog();

            if(fc.ShowDialog() == DialogResult.OK)
            {
                CargarMusica cargarMusica = new CargarMusicaDesdeDirectorio();
                List<string> paths = new List<string>(await cargarMusica.IniciarCargaReproductor(fc.SelectedPath));
                Canciones = new ObservableCollection<Cancion>(await cargarMusica.CargarListadoDeCancionesAsync(paths));
                
            }
        }
    }
}