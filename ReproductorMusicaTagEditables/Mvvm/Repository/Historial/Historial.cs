using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace ReproductorMusicaTagEditables.Mvvm.Repository.Historial
{
    public class Historial
    {
        public static readonly string PATH_HISTORIAL = Environment.CurrentDirectory + @"/Historial/";
        

        public static readonly string ARCHIVO_HISTORIAL_LISTAS = PATH_HISTORIAL + "HistorialListas.json";
        public static readonly string ARCHIVO_HISTORIAL_ALBUMES = PATH_HISTORIAL +"HistorialAlbumes.json";


        public static void CrearHistorial()
        {
            if (!Directory.Exists(PATH_HISTORIAL))
            {
                Directory.CreateDirectory(PATH_HISTORIAL);
            }
            if(!File.Exists(ARCHIVO_HISTORIAL_LISTAS))
            {
                File.Create(ARCHIVO_HISTORIAL_LISTAS);
            }
            if(!File.Exists(ARCHIVO_HISTORIAL_ALBUMES))
            {
                File.Create(ARCHIVO_HISTORIAL_ALBUMES);
            }
        }


        public static bool ExisteHistorialListas()
        {
            return File.Exists(ARCHIVO_HISTORIAL_LISTAS);
        }

        public static bool ExisteHistorialAlbumes()
        {
            return File.Exists(ARCHIVO_HISTORIAL_ALBUMES);
        }


        public static bool AgregarAHistorialListas(string nombreLista)
        {
            if (ExisteHistorialListas())
            {
                List<string> listadoHistorialListas = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(ARCHIVO_HISTORIAL_LISTAS));
                if(listadoHistorialListas != null)
                {
                    if (!listadoHistorialListas.Contains(nombreLista))
                    {
                        listadoHistorialListas.Insert(0, nombreLista);
                        string ser = JsonConvert.SerializeObject(listadoHistorialListas, Formatting.Indented);
                        using (StreamWriter sw = new StreamWriter(ARCHIVO_HISTORIAL_LISTAS))
                        {
                            sw.Write(ser);
                            return true;
                        }
                    }
                } else
                {
                    listadoHistorialListas = new List<string>
                    {
                        nombreLista
                    };
                    string ser = JsonConvert.SerializeObject(listadoHistorialListas, Formatting.Indented);
                    using (StreamWriter sw = new StreamWriter(ARCHIVO_HISTORIAL_LISTAS))
                    {
                        sw.Write(ser);
                        return true;
                    }
                }
                
            }
            return false;
        }


        public static bool AgregarAHistorialAlbumes(string nombreAlbum)
        {
            if (ExisteHistorialAlbumes())
            {
                
                List<string> listadoNombresAlbumes = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(ARCHIVO_HISTORIAL_ALBUMES));
                
                if(listadoNombresAlbumes != null)
                {
                    if (!listadoNombresAlbumes.Contains(nombreAlbum))
                    {
                        listadoNombresAlbumes.Insert(0, nombreAlbum);
                        string ser = JsonConvert.SerializeObject(listadoNombresAlbumes, Formatting.Indented);
                        using (StreamWriter sw = new StreamWriter(ARCHIVO_HISTORIAL_ALBUMES))
                        {
                            sw.Write(ser);
                            return true;
                        }
                    }
                } else
                {
                    listadoNombresAlbumes = new List<string>()
                    {
                        nombreAlbum
                    };
                    string ser = JsonConvert.SerializeObject(listadoNombresAlbumes, Formatting.Indented);
                    using (StreamWriter sw = new StreamWriter(ARCHIVO_HISTORIAL_ALBUMES))
                    {
                        sw.Write(ser);
                        return true;
                    }
                }
                
            }
            return false;
        }
    }
}
