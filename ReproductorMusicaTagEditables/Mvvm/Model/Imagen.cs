using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ReproductorMusicaTagEditables.Mvvm.Model
{
    public struct Imagen
    {
        ImageBrush ima;

        public ImageBrush Ima { get => ima; set => ima = value; }
    }
}
