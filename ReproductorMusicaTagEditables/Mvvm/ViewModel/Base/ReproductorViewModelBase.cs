using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base
{
    public abstract class ReproductorViewModelBase : ViewModelBase
    {

        #region Miembros Protected
        protected CargarMusica cargarMusica;
        protected static List<string> _paths = new List<string>();
        protected static List<Cancion> _canciones = new List<Cancion>();
        protected static List<Cancion> _cancionesFiltradas = new List<Cancion>();
        protected string _titulo;
        protected static CancionActual cancionActual;
        protected static MediaElement REPRODUCTOR_MEDIA;
        #endregion

        #region Propiedades
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
        #endregion


        public static void CargarReproductor(MediaElement me)
        {
            REPRODUCTOR_MEDIA = me;
        }

        public ICommand CargarArchivosCommand { get; }
        public ICommand PlayCommand { get; }

        public ReproductorViewModelBase ()
        {
            cancionActual = new CancionActual();
            CargarArchivosCommand = new RelayCommand(CargarArchivosAction);
            PlayCommand = new RelayCommand(DarPlayAction);
        }

        private void DarPlayAction(object obj)
        {
            if(CancionesFiltradas != null && CancionesFiltradas.Count > 0)
            {
                if(cancionActual.Index == -1 || cancionActual.Cancion == null)
                {
                    MessageBox.Show("entra");
                    cancionActual.Index = 0;
                    cancionActual.Cancion = CancionesFiltradas[cancionActual.Index];
                    REPRODUCTOR_MEDIA.Source = new Uri(cancionActual.Cancion.Path);
                    REPRODUCTOR_MEDIA.Play();
                }
            }
        }

        private async void CargarArchivosAction(object obj)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                this.cargarMusica = new CargarMusicaDesdeDirectorio();
                Paths = await this.cargarMusica.IniciarCargaReproductor(dialog.SelectedPath);
                Canciones = await this.cargarMusica.CargarListadoDeCancionesAsync(Paths);
                CancionesFiltradas = Canciones;
            }
        }
    }
}
