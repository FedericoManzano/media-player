using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using System;


namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils
{
    public class Play : AccionReproductor
    {
        public override void Ejecutar(InfoReproductor Irg, Cancion c = null)
        {
            if (c != null)
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
                Irg.IconoPlay = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.PauseSolid;
                EstadosControl.PLAY = true;
            }
            else
            {
                if (EstadosControl.PLAY)
                {
                    EstadosControl.PLAY = !EstadosControl.PLAY;
                    Irg.IconoPlay = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.PlaySolid;
                    Irg.Reproductor.Pause();
                }
                else
                {
                    if (Irg.CancionesFiltradas.Count > 0)
                    {
                        if (Irg.CancionActual.Index < 0)
                        {
                            Irg.CancionActual.Index = 0;
                            Irg.CancionActual.Cancion = Irg.CancionesFiltradas[0];
                            Irg.Reproductor.Source = new Uri(Irg.CancionActual.Cancion.Path);
                            Irg.Reproductor.Play();
                            Irg.CancionesFiltradas.Seleccionar(Irg.CancionActual.Index);
                            Irg.IconoPlay = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.PauseSolid;
                            EstadosControl.PLAY = true;
                        }
                        else
                        {
                            Irg.Reproductor.Play();
                            Irg.IconoPlay = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.PauseSolid;
                            EstadosControl.PLAY = true;
                        }
                    }
                }
            }
        }
    }
}
