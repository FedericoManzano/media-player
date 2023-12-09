using Newtonsoft.Json;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ReproductorMusicaTagEditables.Mvvm.Repository.CargaInicial
{
    public class RepositorioDeCanciones
    {
        public static readonly string PATH_ARCHIVO_CANCIONES = "Canciones.json";
        public RepositorioDeCanciones() 
        {
            CrearArchivo();
        }

        public static void CrearArchivo ()
        {
            if(!System.IO.File.Exists(PATH_ARCHIVO_CANCIONES))
            {
                using(StreamWriter fw = new StreamWriter(File.Create(PATH_ARCHIVO_CANCIONES)))
                {

                }
            }
        }

        public static bool ExisteArchivo ()
        {
            return File.Exists(PATH_ARCHIVO_CANCIONES);
        }

        public static void GuardarCanciones (List<Cancion> canciones)
        {
            if(!ExisteArchivo())
            {
                CrearArchivo ();
            }

            using(StreamWriter sw = new StreamWriter(File.Create(PATH_ARCHIVO_CANCIONES)))
            {
                foreach (Cancion c in canciones)
                {
                    c.EstadoColor = Cancion.COLOR_TEXTO_DEFAULT;
                }
                string output = JsonConvert.SerializeObject(canciones, Formatting.Indented);
                sw.Write(output);   
            }
        }

        public static bool EstaVacio ()
        {
            return File.ReadAllBytes(PATH_ARCHIVO_CANCIONES).Length == 0;   
        } 

        public static List<Cancion> LeerTodasLasCanciones ()
        {
            List<Cancion> listadoLeido = new List<Cancion>();
           
            try
            {
                string input = File.ReadAllText(PATH_ARCHIVO_CANCIONES);
                listadoLeido = JsonConvert.DeserializeObject<List<Cancion>>(input); 
            }
            catch(Exception ex)
            {

            }
            if(listadoLeido != null)
                listadoLeido = listadoLeido.Where(c => File.Exists(c.Path)).ToList();
            
            
            return listadoLeido;
        }
        public static void AgregarCanciones(List<Cancion> canciones)
        {
            if (!ExisteArchivo())
            {
                CrearArchivo();
            }
            List<Cancion> l = LeerTodasLasCanciones();
            l.AddRange(canciones);
            GuardarCanciones(l);
            InfoReproductor.DameInstancia().Canciones = LeerTodasLasCanciones();
        }
    }
}
