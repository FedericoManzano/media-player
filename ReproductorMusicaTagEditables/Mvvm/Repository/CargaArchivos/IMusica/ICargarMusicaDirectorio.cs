using ReproductorMusicaTagEditables.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos.IMusica
{
    public interface ICargarMusicaDirectorio
    {
        Task<List<string>> IniciarCargaReproductor(string path);
    }
}
