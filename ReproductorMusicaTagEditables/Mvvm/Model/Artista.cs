﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.Model
{
    public class Artista
    {
        public string Nombre { get; set;}
        public string Genero { get; set; }
        public string CantidadAlbumes { get; set; }
        public string TiempoReproduccion {  get; set; }
        public ImageBrush Imagen {  get; set; }
    }
}
