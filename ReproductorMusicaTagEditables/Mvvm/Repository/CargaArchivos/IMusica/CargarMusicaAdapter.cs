using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos.IMusica
{
    public class CargarMusicaAdapter : CargarMusica
    {
        public override Task<List<string>> IniciarCargaReproductor(string path)
        {
            throw new NotImplementedException();
        }

        public override Task<List<string>> IniciarCargaReproductor(string[] path)
        {
            throw new NotImplementedException();
        }
    }
}
