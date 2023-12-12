using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaInicial;
using ReproductorMusicaTagEditables.Mvvm.Repository.Historial;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel
{
    public class PrincipalViewModel : ReproductorViewModelBase
    {
        private Visibility _hayHistorial = Visibility.Collapsed;

        private string _cantidadCanciones = string.Empty;
    
        private Visibility _regalosVisibilidad = Visibility.Collapsed;

        private Dictionary<string, List<Cancion>> _dicCanciones = new Dictionary<string, List<Cancion>>();


        public ICommand AgregarCommand { get; }


        public PrincipalViewModel()
        {
            Irg.TitutloVentana = "Página Principal";
            CantidadCanciones = " (" + Irg.Canciones.Count + " Canciones)";
            AgregarCommand = new RelayCommand(AgregarAction);
            HayHistorialMusica();
        }

        public void HayHistorialMusica ()
        {
            if (Historial.HayHistorial())
            {
                HayHistorial = Visibility.Visible;
            }
            else
            {
                HayHistorial = Visibility.Collapsed;
            }
        }

        private async void AgregarAction(object obj)
        {
            FolderBrowserDialog fs = new FolderBrowserDialog();
            CargarMusica cargarMusica = new CargarMusicaDesdeDirectorio();
            if (fs.ShowDialog() == DialogResult.OK)
            {
                
                if (Irg.Raiz != fs.SelectedPath)
                {
                    Irg.Preloader = true;
                    Habilitados = false;
                    CapaProtectora = Visibility.Visible;
                    List<string> lp = await cargarMusica.IniciarCargaReproductor(fs.SelectedPath);
                    List<Cancion> lc = await cargarMusica.CargarListadoDeCancionesAsync(lp);
                    RepositorioDeCanciones.AgregarCanciones(lc);
                    if (lc != null)
                    {
                        Irg.Preloader = false;
                        Habilitados = true;
                        CapaProtectora = Visibility.Collapsed;
                        System.Windows.Forms.MessageBox.Show("Las canciones se añadieron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("El directorio que intenta cargar habia sido cargado con anterioridad.", "Info error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Irg.Preloader = false;
                }
            }
        }

        public string CantidadCanciones { get => _cantidadCanciones; set { _cantidadCanciones = value; OnPropertyChanged(nameof(CantidadCanciones)); } }

        public Visibility HayHistorial { get => _hayHistorial; set { _hayHistorial = value; OnPropertyChanged(nameof(HayHistorial)); } }

        public Visibility RegalosVisibilidad 
        { 
            get => _regalosVisibilidad; 
            set 
            { 
                _regalosVisibilidad = value; 
                OnPropertyChanged(nameof(RegalosVisibilidad)); 
            } 
        }

        public Dictionary<string, List<Cancion>> DicCanciones { get => _dicCanciones; set => _dicCanciones = value; }
    }
}
