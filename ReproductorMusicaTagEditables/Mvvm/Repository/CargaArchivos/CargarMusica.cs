using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos.IMusica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaTagEditables.Mvvm.Repository.CargaArchivos
{
    public abstract class CargarMusica:ICargarMusicaDirectorio,ICargarMusicaDragDrop
    {
        public static string RAIZ_SELECCIONADA = "";

        public static readonly string[] Extensiones = new string[]
        {
            ".mp3",
            ".wav",
            ".ACC",
            ".wma",
            ".m4a"
        };

        public async Task<List<Cancion>> CargarListadoDeCancionesAsync(List<string> listPath)
        {
            List<Cancion> listCanciones = new List<Cancion>();
            
            listCanciones = await Task.Run(() => listPath
                .Select(p => Cancion.CrearCancion(p))
                .Where(p => p != null)
                .ToList());
            return listCanciones;
        }
        protected void CargarPathDirectoriosYSubdirectorios(string path, List<string> listPath)
        {
            if (System.IO.Directory.Exists(path))
            {
                listPath.AddRange(System.IO.Directory.GetFiles(path));
                foreach (var p in System.IO.Directory.GetDirectories(path))
                {
                    CargarPathDirectoriosYSubdirectorios(p, listPath);
                }                  
            }
        }
        protected bool TieneSubDir(string[] paths)
        {
            foreach (string path in paths)
            {
                if (System.IO.Directory.Exists(path)) { return true; }
            }
            return false;
        }
        protected List<string> FiltrarPorExtension(List<string> listPath)
        {
            List<string> list = new List<string>();

            foreach (string path in listPath)
            {

                var ext = System.IO.Path.GetExtension(path);
                foreach (string e in Extensiones)
                {
                    if (e.ToUpper() == ext.ToUpper())
                    {
                        list.Add(path);
                    }
                }
            }
            return list;
        }
        public abstract Task<List<string>> IniciarCargaReproductor(string path);
        public abstract Task<List<string>> IniciarCargaReproductor(string[] path);
    }
}
