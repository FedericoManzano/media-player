
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.Listas;
using ReproductorMusicaTagEditables.Mvvm.Repository.Navegacion;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System;
using System.Windows;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils
{
    public class Play : AccionReproductor
    {
        public override void Ejecutar(InfoReproductor Irg, Cancion c = null)
        {
            
            if (c != null)
            {
                if (!System.IO.File.Exists(c.Path))
                {
                    MessageBox.Show($"El Archivo {c.Path} fué eliminado en tiempo de ejecucion.");
                    return;
                }

                if (Irg.CancionActual.Index >= 0)
                {
                    Irg.Deseleccionar();
                }
                Irg.CancionActual.Index = Irg.CancionesFiltradas.IndexOf(c);
                Irg.CancionActual.Cancion = c;

                Irg.Reproductor.Source = new Uri(c.Path);
                Irg.Reproductor.Play();
                Irg.Seleccionar();
                Irg.IconoPlay = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.PauseSolid;
                EstadosControl.PLAY = true;
                EstadosControl.CANCION_GUARDADA = false;
            }
            else
            {
                
                if (EstadosControl.PLAY)
                {
                    EstadosControl.PLAY = !EstadosControl.PLAY;
                    Irg.IconoPlay = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.PlaySolid;
                    Irg.Reproductor.Pause();
                    return;
                }
                else
                {
                    if (Irg.CancionesFiltradas.Count > 0)
                    {
                        if (Irg.CancionActual.Index < 0)
                        {
                            Irg.CancionActual.Index = 0;
                            Irg.CancionActual.Cancion = Irg.CancionesFiltradas[0];
                            if (!System.IO.File.Exists(Irg.CancionActual.Cancion.Path))
                            {
                                MessageBox.Show($"El Archivo {Irg.CancionActual.Cancion.Path} fué eliminado en tiempo de ejecucion.");
                                return;
                            }
                            Irg.Reproductor.Source = new Uri(Irg.CancionActual.Cancion.Path);
                            Irg.Reproductor.Play();
                            Irg.Seleccionar();
                            Irg.IconoPlay = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.PauseSolid;
                            EstadosControl.PLAY = true;
                            EstadosControl.CANCION_GUARDADA = false;
                        }
                        else
                        {
                            Irg.Seleccionar();
                            if(Irg.Reproductor.Source != null)
                            {
                                Irg.Reproductor.Play();
                            }
                            else
                            {
                                Irg.Reproductor.Source = new Uri(Irg.CancionActual.Cancion.Path);
                                Irg.Reproductor.Play();
                            }
                            
                            Irg.IconoPlay = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.PauseSolid;
                            EstadosControl.PLAY = true;
                            EstadosControl.CANCION_GUARDADA = false;
                            
                        }
                    }
                }
               
                Navegacion.GuardarInfo(ReproductorViewModelBase.infoNavegacion);
            }
        }
    }
}
