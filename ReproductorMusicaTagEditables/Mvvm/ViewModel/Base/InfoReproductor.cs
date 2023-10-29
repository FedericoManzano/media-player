using MahApps.Metro.IconPacks;
using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base
{
    public class InfoReproductor:ViewModelBase
    {

        #region Campos Informativos
        private static string _titutloVentana;
        private static CancionActual _cancionActual;
        private static MediaElement _reproductor;
        private static string _raiz;
        #endregion


        private static List<string> _paths;
        private static List<Cancion> _canciones;
        private static ObservableCollection<Cancion> _cancionesFiltradas;
        private static MahApps.Metro.IconPacks.PackIconFontAwesomeKind _iconoPlay;
        private static bool _preloader;


        public string TitutloVentana 
        {
            get => _titutloVentana;
            set { _titutloVentana = value; OnPropertyChanged(nameof(TitutloVentana)); } 
        }
        public CancionActual CancionActual 
        { 
            get => _cancionActual;
            set { _cancionActual = value; OnPropertyChanged(nameof(CancionActual)); } 
        }
        public MediaElement Reproductor { get => _reproductor; set => _reproductor = value; }
        public string Raiz { get => _raiz; set => _raiz = value; }
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
            set { _cancionesFiltradas = value; OnPropertyChanged(nameof(CancionesFiltradas)); }
        }

        public PackIconFontAwesomeKind IconoPlay { get => _iconoPlay; set { _iconoPlay = value;OnPropertyChanged(nameof(IconoPlay)); } }

        public bool Preloader { get => _preloader; set { _preloader = value; OnPropertyChanged(nameof(Preloader)); } }

        public InfoReproductor ()
        {
            TitutloVentana = string.Empty;
            CancionActual = new CancionActual { Index = -1, Cancion = new Cancion() };
            Raiz = string.Empty;
            Paths = new List<string>();
            Canciones = new List<Cancion>();
            CancionesFiltradas = new ObservableCollection<Cancion>();
            IconoPlay = PackIconFontAwesomeKind.PlaySolid;
            Preloader = false;
        }

        public void CargarReproductor (MediaElement me)
        {
            Reproductor = me;
        }

        public async void CargarMusicaSeleccion()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            CargarMusica cargarMusica = new CargarMusicaDesdeDirectorio();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Preloader = true;
                if (System.IO.Directory.Exists(folderBrowserDialog.SelectedPath))
                {
                    Raiz = folderBrowserDialog.SelectedPath;
                    Paths = await cargarMusica.IniciarCargaReproductor(Raiz);
                    Canciones = await cargarMusica.CargarListadoDeCancionesAsync(Paths);

                    await Task.Run(() =>
                    {
                        if (Canciones.Count >= 100)
                            CancionesFiltradas = new ObservableCollection<Cancion>(Canciones.GetRange(0, 100));
                        else
                            CancionesFiltradas = new ObservableCollection<Cancion>(Canciones);
                        Preloader = false;
                    });
                }
            }
        }


        public async void AgregarElementosAlFiltro()
        {
            int diferencia = Canciones.Count - CancionesFiltradas.Count;
            if (diferencia <= 0)
                return;

            Preloader = true;
            await Task.Run(() =>
            { 
                if (Canciones.Count <= 100)
                {
                    CancionesFiltradas = new ObservableCollection<Cancion>(Canciones);
                }
                else if (CancionesFiltradas.Count == 0 && Canciones.Count > 100)
                {
                    CancionesFiltradas = new ObservableCollection<Cancion>(Canciones.GetRange(0, 100));
                }
                Preloader = false;
            });

            if(CancionesFiltradas.Count > 0)
            {
                if (diferencia > 20 && CancionesFiltradas.Count < Canciones.Count)
                {
                    foreach (Cancion can in Canciones.GetRange(CancionesFiltradas.Count, 20))
                    {
                        CancionesFiltradas.Add(can);
                    }
                }
                else
                {
                    for (int i = CancionesFiltradas.Count; i < Canciones.Count; i++)
                    {
                        CancionesFiltradas.Add(Canciones[i]);
                    }
                }
            }
        }
    }
}
