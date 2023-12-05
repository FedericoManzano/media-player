
using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaInicial;
using ReproductorMusicaTagEditables.Mvvm.Repository.Navegacion;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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

        public async void CargarMusicaSeleccion(ReproductorViewModelBase reproductorViewModelBase)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            CargarMusica cargarMusica = new CargarMusicaDesdeDirectorio();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                reproductorViewModelBase.Habilitados = false;
                reproductorViewModelBase.CapaProtectora = System.Windows.Visibility.Visible;
                if (System.IO.Directory.Exists(folderBrowserDialog.SelectedPath))
                {
                    Preloader = true;
                    EstadoCarga = false;
                    Raiz = folderBrowserDialog.SelectedPath;
                    Paths = await cargarMusica.IniciarCargaReproductor(Raiz);
                    Canciones = await cargarMusica.CargarListadoDeCancionesAsync(Paths);
                    CancionesFiltradas = new ObservableCollection<Cancion>(Canciones);
                    if (Canciones.Count > 50)
                    {
                        Partes = new ObservableCollection<Cancion>(Canciones.GetRange(0, 50));
                    }
                    else
                    {
                        Partes = new ObservableCollection<Cancion>(Canciones);
                    }

                    if (Canciones.Count > 0)
                    {
                        IslistadoVisible = System.Windows.Visibility.Visible;
                        IsMensajeVisible = System.Windows.Visibility.Collapsed;
                        reproductorViewModelBase.Habilitados = true;
                        reproductorViewModelBase.CapaProtectora = System.Windows.Visibility.Collapsed;
                    }

                    Preloader = false;
                    RepositorioDeCanciones.GuardarCanciones(Canciones);
                    EstadoCarga = true;
                    
                }
            }
        }
        public async void CargaDesdeElRepositorioCanciones()
        {
            
            await Task.Run(() => {
                Preloader = true;
                if (RepositorioDeCanciones.ExisteArchivo() && !RepositorioDeCanciones.EstaVacio())
                {
                    Canciones = RepositorioDeCanciones.LeerTodasLasCanciones();
                    Partes = new ObservableCollection<Cancion>(Canciones);

                    if(CancionesFiltradas.Count == 0) { CancionesFiltradas = new ObservableCollection<Cancion>(Canciones); }
          
                    if (Canciones.Count > 50)
                    {
                        Partes = new ObservableCollection<Cancion>(Canciones.GetRange(0, 50));
                    }
                    else
                    {
                        Partes = new ObservableCollection<Cancion>(Canciones);
                    }
                    if(Canciones.Count > 0)
                    {
                        IslistadoVisible = System.Windows.Visibility.Visible;
                        IsMensajeVisible = System.Windows.Visibility.Collapsed;
                    }
                }
                Preloader = false;
            });
        }
        public void AgregarElementosAlFiltro()
        {
            if(Canciones.Count > 0)
            {
                IsMensajeVisible = System.Windows.Visibility.Collapsed;
            }
            int diferencia = Canciones.Count - Partes.Count;
            if (diferencia <= 0)
                return;

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
        public void Seleccionar ()
        {

            if(CancionActual.Index >= 0 && CancionActual.Cancion != null)
            {
                CancionActual.Cancion.EstadoColor = "Red";   
                for(int i = 0; i < CancionesFiltradas.Count; i ++)
                {
                    if (CancionesFiltradas[i].Equals(CancionActual.Cancion))
                    {
                        CancionesFiltradas.RemoveAt(i);
                        CancionesFiltradas.Insert(i, CancionActual.Cancion);
                    }
                }

                for (int i = 0; i < Canciones.Count; i++)
                {
                    if (Canciones[i].Equals(CancionActual.Cancion))
                    {
                        Canciones[i].EstadoColor = "red";
                    }
                }


                for (int i = 0; i < Partes.Count; i++)
                {
                    if (Partes[i].Equals(CancionActual.Cancion))
                    {
                        Partes.RemoveAt(i);
                        Partes.Insert(i, CancionActual.Cancion);
                    }
                }

                for (int i = 0; i < Presentacion.Count; i++)
                {
                    if (Presentacion[i].Equals(CancionActual.Cancion))
                    {
                        Presentacion.RemoveAt(i);
                        Presentacion.Insert(i, CancionActual.Cancion);
                    }
                }
            }
        }
        public void Deseleccionar()
        {

            if (CancionActual.Index >= 0 && CancionActual.Cancion != null)
            {
                CancionActual.Cancion.EstadoColor = "White";
                for (int i = 0; i < CancionesFiltradas.Count; i++)
                {
                    if (CancionesFiltradas[i].Equals(CancionActual.Cancion))
                    {
                        CancionesFiltradas.RemoveAt(i);
                        CancionesFiltradas.Insert(i, CancionActual.Cancion);
                    }
                }

                for (int i = 0; i < Canciones.Count; i++)
                {
                    if (Canciones[i].Equals(CancionActual.Cancion))
                    {
                        Canciones[i].EstadoColor = "White";
                    }
                }


                for (int i = 0; i < Partes.Count; i++)
                {
                    if (Partes[i].Equals(CancionActual.Cancion))
                    {
                        Partes.RemoveAt(i);
                        Partes.Insert(i, CancionActual.Cancion);
                    }
                }

                for (int i = 0; i < Presentacion.Count; i++)
                {
                    if (Presentacion[i].Equals(CancionActual.Cancion))
                    {
                        Presentacion.RemoveAt(i);
                        Presentacion.Insert(i, CancionActual.Cancion);
                    }
                }
            }
        }
        public async void BuscarCancion(string inicialCancion)
        {
            List<Cancion> l = await Task<List<Cancion>>.Run(() =>
            {
                return Canciones.Where(c =>
                {
                    return c.Titulo.ToUpper().Contains(inicialCancion.ToUpper());
                }).ToList();
            });
            Partes.Clear();
            foreach(var c in l)
            {
                Partes.Add(c);
            }
        }
        public double SetScroll()
        {
            for(int i = 0; i < Canciones.Count; i ++)
            {
                if (Canciones[i].Equals(CancionActual.Cancion))
                {
                    return (double) i * 45;
                }
            }
            return 0;
        }
    }
}
