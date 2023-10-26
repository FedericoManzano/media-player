using ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos.IMusica;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos
{
    public class CargarMusicaDesdeDragDrop:CargarMusicaAdapter
    {
        public override async Task<List<string>> IniciarCargaReproductor(string[] paths)
        {
            List<string> listaPath = new List<string>();
            if (paths.Length == 1 && System.IO.Directory.Exists(paths[0]))
            {
                RAIZ_SELECCIONADA = paths[0];
                await Task.Run(() => CargarPathDirectoriosYSubdirectorios(RAIZ_SELECCIONADA, listaPath));
            }
            else if (paths.Length > 1 && TieneSubDir(paths))
            {
                RAIZ_SELECCIONADA = System.IO.Path.GetDirectoryName(paths[0]);

                foreach (string p in paths)
                {
                    if (System.IO.Directory.Exists(p))
                    {
                        await Task.Run(() => CargarPathDirectoriosYSubdirectorios(p, listaPath));
                    }
                    else if (System.IO.File.Exists(p)) listaPath.Add(p);
                }
            }
            else if (paths.Length >= 1 && System.IO.File.Exists(paths[0]))
            {
                RAIZ_SELECCIONADA = System.IO.Path.GetDirectoryName(paths[0]);
                listaPath.AddRange(paths);

            }
            else
            {
                return listaPath;
            }

            return FiltrarPorExtension(listaPath);
        }
    }
}
