using ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos.IMusica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos
{
    public class CargarMusicaDesdeDirectorio:CargarMusicaAdapter
    {
        public override async Task<List<string>> IniciarCargaReproductor(string path)
        {
            List<string> listPath = new List<string>();

            if (System.IO.Directory.Exists(path))
            {
                await Task.Run(() => CargarPathDirectoriosYSubdirectorios(path, listPath));
            }
            else return listPath;

            return FiltrarPorExtension(listPath);
        }
    }
}
