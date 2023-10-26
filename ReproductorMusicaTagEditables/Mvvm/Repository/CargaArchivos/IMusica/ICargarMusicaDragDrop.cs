using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos.IMusica
{
    public interface ICargarMusicaDragDrop
    {
        Task<List<string>> IniciarCargaReproductor(string[] path);
    }
}
