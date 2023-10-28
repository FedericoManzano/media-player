using Reproductor_Musica.Core;
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Base
{
    public abstract class ReproductorViewModelBase : ViewModelBase
    {
        protected readonly static InfoReproductor irg = new InfoReproductor();

        public  InfoReproductor Irg
        {
            get => irg;  
        }

        public  void CargarReproductor(MediaElement me)
        {
            Irg.Reproductor = me;
        }

        public ICommand CargarMusicaCommand { get; }
        public ICommand PlayCommand { get; }


        public ReproductorViewModelBase ()
        {
            CargarMusicaCommand = new RelayCommand(CargarMusicaAction);
            PlayCommand = new RelayCommand(PlayAction);
        }

        private void PlayAction(object obj)
        {
            Cancion c = (Cancion)obj;
            if(c != null)
            {
                if (Irg.CancionActual.Index >= 0)
                {
                    Irg.CancionesFiltradas.Deseleccionar(Irg.CancionActual.Index);
                }
                Irg.CancionActual.Index = Irg.CancionesFiltradas.IndexOf(c);
                Irg.CancionActual.Cancion = c;
                Irg.Reproductor.Source = new Uri(c.Path);
                Irg.Reproductor.Play();
                Irg.CancionesFiltradas.Seleccionar(Irg.CancionActual.Index);
            }
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
