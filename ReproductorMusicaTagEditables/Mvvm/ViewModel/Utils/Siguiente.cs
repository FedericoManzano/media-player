﻿using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System.Collections.ObjectModel;
using System.Windows;

namespace ReproductorMusicaTagEditables.Mvvm.ViewModel.Utils
{
    public class Siguiente : AccionReproductor
    {
        public override void Ejecutar(InfoReproductor Irg, Cancion c = null)
        {
            
            Irg.Deseleccionar();
            if (EstadosControl.RANDOM)
            {
                Irg.CancionActual.Index = IndexRandom(Irg.CancionesFiltradas);
                Irg.CancionActual.Cancion = Irg.CancionesFiltradas[Irg.CancionActual.Index];

                if (!System.IO.File.Exists(Irg.CancionActual.Cancion.Path))
                {
                    MessageBox.Show($"El Archivo {Irg.CancionActual.Cancion.Path} fué eliminado en tiempo de ejecucion.");
                    return;
                }
                   
                Irg.Seleccionar();
                ReproducirCancion(Irg);
            }
            else if (Irg.CancionesFiltradas.Count > Irg.CancionActual.Index + 1)
            {
                Irg.CancionActual.Index++;
                Irg.CancionActual.Cancion = Irg.CancionesFiltradas[Irg.CancionActual.Index];
                if (!System.IO.File.Exists(Irg.CancionActual.Cancion.Path))
                {
                    MessageBox.Show($"El Archivo {Irg.CancionActual.Cancion.Path} fué eliminado en tiempo de ejecucion.");
                    return;
                }
                Irg.Seleccionar();
                ReproducirCancion(Irg);
            }
        }
    }
}
