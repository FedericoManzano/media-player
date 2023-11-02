using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;


namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base
{
    public abstract class ReproductorViewModelBase : ViewModelBase
    {
        protected readonly static InfoReproductor irg = new InfoReproductor();
        private static double _scrollVertical = 0;
        public  InfoReproductor Irg
        {
            get => irg;  
        }

        public  void CargarReproductor(MediaElement me)
        {
            Irg.Reproductor = me;
        }

        public double ScrollVertical { get => _scrollVertical; set => _scrollVertical = value; }

        public ICommand CargarMusicaCommand { get; }
        public ICommand PlayCommand { get; }
        public ICommand SiguienteCommand { get; }
        public ICommand AnteriorCommand { get; }

        public ReproductorViewModelBase ()
        {
            CargarMusicaCommand = new RelayCommand(CargarMusicaAction);
            SiguienteCommand = new RelayCommand(SiguienteAction, CanSiguienteAction);
            AnteriorCommand = new RelayCommand(AnteriorAction, CanAnteriorAction);
            PlayCommand = new RelayCommand(PlayAction);
            if(irg.Canciones.Count == 0)
                Irg.CargaDesdeElRepositorioCanciones();
        }

        public bool CanAnteriorAction(object arg)
        {
            if (EstadosControl.RANDOM)
            {
                return Irg.CancionesFiltradas.Count > 0;
            }
            return Irg.CancionesFiltradas.Count > 0 && Irg.CancionActual.Index > 0;
        }

        public void AnteriorAction(object obj = null)
        { 
            AccionReproductor.Fabrica(AccionReproductor.ATRAS_ACCION)?.Ejecutar(Irg);
            ScrollVertical = irg.SetScroll();
        }

        private bool CanSiguienteAction(object arg)
        {
            if(EstadosControl.RANDOM)
            {
                return Irg.CancionesFiltradas.Count > 0;
            }
            return Irg.CancionesFiltradas.Count > 0 && Irg.CancionActual.Index < Irg.Canciones.Count - 1;
        }

        public void SiguienteAction(object obj = null)
        {
            AccionReproductor.Fabrica(AccionReproductor.SIGUIENTE_ACCION)?.Ejecutar(Irg);
            ScrollVertical = irg.SetScroll();
        }

        protected void PlayAction(object obj)
        {
            Cancion c = (Cancion)obj;
            AccionReproductor.Fabrica(AccionReproductor.PLAY_ACCION)?.Ejecutar(Irg, c);
            ScrollVertical = irg.SetScroll();
        }

        private void CargarMusicaAction(object obj)
        {
            Irg.CargarMusicaSeleccion();
        }

        public void AgregarElementosAlFiltro()
        {
            Irg.AgregarElementosAlFiltro();
        }

    }
}
