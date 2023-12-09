﻿using Newtonsoft.Json;
using ReproductorMusicaTagEditables.Mvvm.Model;
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
                        listadoHistorialListas.Insert(0,nombreLista);
                        
                        if (listadoHistorialListas.Count > 7)
                        {
                            listadoHistorialListas.RemoveAt(7);
                        }
                        string ser = JsonConvert.SerializeObject(listadoHistorialListas, Formatting.Indented);
                        using (StreamWriter sw = new StreamWriter(ARCHIVO_HISTORIAL_LISTAS))
                        {
                            sw.Write(ser);
                            return true;
                        }
                    }
                    else
                    {
                        listadoHistorialListas.Remove(nombreLista);
                        listadoHistorialListas.Insert(0,nombreLista);
                        
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

        public static bool AgregarAHistorialAlbumes(Album album)
        {
            if (ExisteHistorialAlbumes())
            {
                album.Imagen = null;       
                List<Album> listadoNombresAlbumes = JsonConvert.DeserializeObject<List<Album>>(File.ReadAllText(ARCHIVO_HISTORIAL_ALBUMES));
                
                if(listadoNombresAlbumes != null)
                {
                    if (!listadoNombresAlbumes.Contains(album))
                    {
                        listadoNombresAlbumes.Insert(0,album);
                        
                        if(listadoNombresAlbumes.Count > 7)
                        {
                            listadoNombresAlbumes.RemoveAt(7);
                        }
                        string ser = JsonConvert.SerializeObject(listadoNombresAlbumes, Formatting.Indented);
                        using (StreamWriter sw = new StreamWriter(ARCHIVO_HISTORIAL_ALBUMES))
                        {
                            sw.Write(ser);
                            return true;
                        }
                    }
                    else
                    {
                        listadoNombresAlbumes.Remove(album);
                        listadoNombresAlbumes.Insert(0,album);
                        string ser = JsonConvert.SerializeObject(listadoNombresAlbumes, Formatting.Indented);
                        using (StreamWriter sw = new StreamWriter(ARCHIVO_HISTORIAL_ALBUMES))
                        {
                            sw.Write(ser);
                            return true;
                        }
                    }
                } else
                {
                    listadoNombresAlbumes = new List<Album>()
                    {
                        album
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

        public static List<string> DameHistorialListas()
        {
            List<string> listas = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(ARCHIVO_HISTORIAL_LISTAS));

            if (listas != null)
            {
                return listas;
            }
            return new List<string>();
        }

        public static List<Album> DameHistorialAlbum ()
        {
            List<Album> albums = JsonConvert.DeserializeObject<List<Album>>(File.ReadAllText(ARCHIVO_HISTORIAL_ALBUMES));

            if(albums != null)
            {
                return albums;
            }
            return new List<Album>();
        }

        public static void BorrarHistorial()
        {
            using (StreamWriter sw = new StreamWriter(ARCHIVO_HISTORIAL_ALBUMES))
            {
                sw.Write("");
            }

            using (StreamWriter sw = new StreamWriter(ARCHIVO_HISTORIAL_LISTAS))
            {
                sw.Write("");
            }
        }

        public static bool HayHistorial()
        {
            List<Album> albums = JsonConvert.DeserializeObject<List<Album>>(File.ReadAllText(ARCHIVO_HISTORIAL_ALBUMES));
            List<string> listas = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(ARCHIVO_HISTORIAL_LISTAS));

            return listas != null || albums != null;
        }
    }
}