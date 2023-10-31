
using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info
{

    public  partial class InfoReproductor : ViewModelBase
    {
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
                    CancionesFiltradas = new ObservableCollection<Cancion>(Canciones);
                    if(Canciones.Count > 50)
                    {
                        Partes = new ObservableCollection<Cancion>(Canciones.GetRange(0, 50));
                    }
                    else
                    {
                        Partes = new ObservableCollection<Cancion>(Canciones);
                    }
                    AgregarElementosAlFiltro();
                    Preloader = false;
                }
            }
        }


        public async void AgregarElementosAlFiltro()
        {
            int diferencia = Canciones.Count - Partes.Count;
            if (diferencia <= 0)
                return;

            Preloader = true;
            await Task.Run(() =>
            { 
                if (Canciones.Count < 50)
                {
                    
                    Partes = new ObservableCollection<Cancion>(Canciones);
                }
                else if (Partes.Count == 0 && Canciones.Count > 50)
                {
                    Partes = new ObservableCollection<Cancion>(Canciones.GetRange(0, 50));
                }
                Preloader = false;
            });

            if(Partes.Count > 0)
            {
                if (diferencia > 20 && Partes.Count < Canciones.Count)
                {
                    foreach (Cancion can in Canciones.GetRange(Partes.Count, 20))
                    {
                        Partes.Add(can);
                    }
                }
                else
                {
                    for (int i = Partes.Count; i < Canciones.Count; i++)
                    {
                        Partes.Add(Canciones[i]);
                    }
                }
            }
        }
    }
}
