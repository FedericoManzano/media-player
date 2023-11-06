using Newtonsoft.Json;
using ReproductorMusicaTagEditables.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReproductorMusicaTagEditables.Mvvm.Repository.Listas
{
    public  class ListasReproduccion
    {

        public static readonly string PATH_LISTAS = Environment.CurrentDirectory +  @"/Listas/";
        public static readonly string EXT = ".json";


        private static void CrearDirectorio()
        {
            Directory.CreateDirectory(PATH_LISTAS);
        }

        public static bool ValidarNombre(string nombreLista)
        {
            if (string.IsNullOrEmpty(nombreLista)) return false;  
            return Regex.IsMatch(nombreLista, "^([a-zA-Z0-9-_ ]{3,25})$");
        }

        public static bool ExisteLista(string nombreLista)
        {
            if (!Directory.Exists(PATH_LISTAS))
                CrearDirectorio();
            if (string.IsNullOrEmpty(nombreLista)) { return false; }
          
            return File.Exists(nombreLista.Ruta());
        }

        public static bool Crear(string nombreLista)
        { 

            if (!Directory.Exists(PATH_LISTAS))
                CrearDirectorio();
            if(string.IsNullOrEmpty(nombreLista)) return false;
            if (ExisteLista(nombreLista)) return false;
            if (!ValidarNombre(nombreLista)) return false;

            File.Create(nombreLista.Ruta()).Close();
            return true;
        }

        public static bool Borrar(string nombreLista)
        {
            if (string.IsNullOrEmpty(nombreLista))
                if (ExisteLista(nombreLista))
                    return false;
            File.Delete(nombreLista.Ruta());
            return true;
        }

        public static List<string> ListadoNombres()
        {
            string[] archivos = Directory.GetFiles(PATH_LISTAS);
            if (archivos.Length == 0)
                return new List<string>();
            List<string> nombresListas = archivos.Where(s =>
            {
                FileInfo fi = new FileInfo(s);
                string e = fi.Extension;
                if (e != EXT) return false;
                return true;
            }).Select(s => Path.GetFileNameWithoutExtension(s)).ToList();
            return nombresListas;
        }

        public static bool AgregarCancion(string nombreLista, Cancion c)
        {  
            if(string.IsNullOrEmpty(nombreLista)) return false;
            if(c == null) return false;

            if(!ExisteLista(nombreLista)) return false;
            List<Cancion> listado = JsonConvert.DeserializeObject<List<Cancion>>(File.ReadAllText(nombreLista.Ruta())) 
                                                        ?? new List<Cancion>();
            if (listado.Count > 0)
            {
                if (listado.Exists(cl => cl.Titulo.Equals(c.Titulo) && cl.Artista.Equals(c.Artista)))
                    return false;
            }
            
            
            listado.Add(c);
            string ser = JsonConvert.SerializeObject(listado, Formatting.Indented);
            using (StreamWriter sw = new StreamWriter(nombreLista.Ruta()))
            {
                sw.Write(ser);
            }

            return true;
        }

        public static bool RemoverCancion(string nombreLista, Cancion c)
        {
            if (string.IsNullOrEmpty(nombreLista)) return false;
            if (c == null) return false;
            if (!ExisteLista(nombreLista)) return false;

            List<Cancion> listado = JsonConvert.DeserializeObject<List<Cancion>>(File.ReadAllText(nombreLista.Ruta())) ?? new List<Cancion>();

            listado = listado.Where(cl => cl.Titulo != c.Titulo).ToList();
            string ser = JsonConvert.SerializeObject(listado, Formatting.Indented);
            using (StreamWriter sw = new StreamWriter(nombreLista.Ruta()))
            {
                sw.Write(ser);
            }
            return true;
        }


        public static List<Cancion> DameListadoCanciones (string nombreLista)
        {
            if (string.IsNullOrEmpty(nombreLista)) return new List<Cancion>();
            if (!ExisteLista(nombreLista)) return new List<Cancion>();

            List<Cancion> listado = JsonConvert.DeserializeObject<List<Cancion>>(File.ReadAllText(nombreLista.Ruta())) ?? new List<Cancion>();
            return listado;
        }
    }
}
