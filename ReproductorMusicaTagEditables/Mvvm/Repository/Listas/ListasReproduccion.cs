using Newtonsoft.Json;
using ReproductorMusicaTagEditables.Mvvm.ExtensionMetodos;
using ReproductorMusicaTagEditables.Mvvm.Model;
using ReproductorMusicaTagEditables.Mvvm.ViewModel.Base.Info;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace ReproductorMusicaTagEditables.Mvvm.Repository.Listas
{
    public  class ListasReproduccion
    {

        public static readonly string PATH_LISTAS = Environment.CurrentDirectory +  @"/Listas/";
        public static readonly string EXT = ".json";

        private static void CrearDirectorio()
        {
            try
            {
                Directory.CreateDirectory(PATH_LISTAS);
            }
            catch
            {

            }
        }

        public static bool ValidarNombre(string nombreLista)
        {
            if (string.IsNullOrEmpty(nombreLista)) return false;  
            return Regex.IsMatch(nombreLista, "^([a-zA-Z0-9-_ ]{3,25})$");
        }

        public static bool ExisteLista(string nombreLista)
        {
            try
            {
                if (!Directory.Exists(PATH_LISTAS))
                    CrearDirectorio();
                if (string.IsNullOrEmpty(nombreLista)) { return false; }
            }
            catch
            {

            }
            return File.Exists(nombreLista.Ruta());
        }

        public static bool Crear(string nombreLista)
        {
            try
            {
                if (!Directory.Exists(PATH_LISTAS))
                    CrearDirectorio();
                if (string.IsNullOrEmpty(nombreLista)) return false;
                if (ExisteLista(nombreLista)) return false;
                if (!ValidarNombre(nombreLista)) return false;

                File.Create(nombreLista.Ruta()).Close();
            }
            catch
            {
                return false;
            }
            
            return true;
        }

        public static bool Borrar(string nombreLista)
        {
            try
            {
                if (string.IsNullOrEmpty(nombreLista))
                    if (ExisteLista(nombreLista))
                        return false;
                File.Delete(nombreLista.Ruta());
            }
            catch
            {

            }
            return true;
        }

        public static List<string> ListadoNombres()
        {
            try
            {
                if (!Directory.Exists(PATH_LISTAS))
                    CrearDirectorio();
                string[] archivos = Directory.GetFiles(PATH_LISTAS);
                if (archivos.Length == 0)
                    return new List<string>();
                List<string> nombresListas = archivos.Where(s =>
                {

                    FileInfo fi = new FileInfo(s);
                    if (Path.GetFileNameWithoutExtension(fi.Name) != "FAVORITOS")
                    {
                        string e = fi.Extension;
                        if (e != EXT) return false;
                        return true;
                    }
                    return false;
                }).Select(s => Path.GetFileNameWithoutExtension(s)).ToList();
                return nombresListas;
            }
            catch
            {
                return new List<string>();
            }
        }

        public static bool AgregarCancion(string nombreLista, Cancion c)
        {  
            if(string.IsNullOrEmpty(nombreLista)) return false;
            if(c == null) return false;
            if(c.Artista == "Desconocido" || c.Album == "Desconocido")
            {
                if(nombreLista != "FAVORITOS")
                {
                    System.Windows.Forms.MessageBox.Show($"No puede agregarse la cancion: {c.Titulo} a la lista {nombreLista} porque la canción no posee los metadatos adecuados. Puede editarlos desde el botón tags de la página principal.", "Error", System.Windows.Forms.MessageBoxButtons.OK, (System.Windows.Forms.MessageBoxIcon)MessageBoxImage.Information);
                    return false;
                }
            }

            if(!ExisteLista(nombreLista)) return false;

            try
            {
                List<Cancion> listado = JsonConvert.DeserializeObject<List<Cancion>>(File.ReadAllText(nombreLista.Ruta()))
                                                        ?? new List<Cancion>();
                if (listado.Count > 0)
                {
                    if (listado.Exists(cl => cl.Titulo.Equals(c.Titulo) && cl.Artista.Equals(c.Artista)))
                        return false;
                }

                InfoReproductor i = InfoReproductor.DameInstancia();
                if (c.Equals(i.CancionActual.Cancion))
                {
                    c.EstadoColor = "Red";
                }
                else { c.EstadoColor = "White";  }
                
                listado.Add(c);
                string ser = JsonConvert.SerializeObject(listado, Formatting.Indented);
                using (StreamWriter sw = new StreamWriter(nombreLista.Ruta()))
                {
                    sw.Write(ser);
                }
            }
            catch
            {
                return false;
            }
            

            return true;
        }

        private static bool LaMismaCancion(Cancion c1, Cancion c2)
        {
            return c1.Titulo == c2.Titulo && c1.Artista == c2.Artista && c1.Album == c2.Album;
        }

        public static bool RemoverCancion(string nombreLista, Cancion c)
        {
            if (string.IsNullOrEmpty(nombreLista)) return false;
            if (c == null) return false;
            if (!ExisteLista(nombreLista)) return false;

            List<Cancion> listado = JsonConvert.DeserializeObject<List<Cancion>>(File.ReadAllText(nombreLista.Ruta())) ?? new List<Cancion>();
            listado = listado.Where(cl => !LaMismaCancion(cl,c)).ToList();
          
            try
            {
                string ser = JsonConvert.SerializeObject(listado, Formatting.Indented);
                using (StreamWriter sw = new StreamWriter(nombreLista.Ruta()))
                {
                    sw.Write(ser);
                }
            }
            catch
            {
                return false;
            }

            
            return true;
        }

        public static List<Cancion> DameListadoCanciones (string nombreLista)
        {
            if (string.IsNullOrEmpty(nombreLista)) return new List<Cancion>();
            if (!ExisteLista(nombreLista)) return new List<Cancion>();

            try
            {
                List<Cancion> listado = JsonConvert.DeserializeObject<List<Cancion>>(File.ReadAllText(nombreLista.Ruta())) ?? new List<Cancion>();
                if(listado != null)
                {
                    listado = FiltrarCancionesExistentes(listado);
                    return listado;
                }
                return new List<Cancion>();
            }
            catch
            {
                return new List<Cancion>();
            }
        }

        private static List<Cancion> FiltrarCancionesExistentes(List<Cancion> listado)
        {
            return listado.Where(c => File.Exists(c.Path)).ToList();
        }

        public static string CalcularDuracionLista(string nombreLista)
        {
            List<Cancion> l = DameListadoCanciones(nombreLista);
            return l.DuracionString();
        }

        public static string FechaCreacion(string nombreLista)
        {
            if(ExisteLista(nombreLista))
            {
                return File.GetCreationTime(nombreLista.Ruta()).ToString(@"dd/MM/yyyy");
            }
            return string.Empty;
        }

        public static void CrearListaFavoritos()
        {
            Crear("FAVORITOS");
        }

        public static bool ActualizarListaReproduccion (string nombreLista)
        {
            if(string.IsNullOrEmpty(nombreLista) && !ExisteLista(nombreLista))
                return false;
            List<Cancion> cancions = DameListadoCanciones(nombreLista);
            InfoReproductor i = InfoReproductor.DameInstancia();
            List<Cancion> res = new List<Cancion> ();
            foreach(Cancion c in i.Canciones)
            {
                foreach (Cancion cl in cancions)
                {
                    if(cl.Path == c.Path)
                    {
                        c.Cantidad = cl.Cantidad;
                        c.EstadoColor = "White";
                        res.Add(c);
                    }
                        
                }
            }
            if(nombreLista == "FAVORITOS")
            {
                res.Sort(delegate (Cancion c1, Cancion c2) {
                    return c2.Cantidad.CompareTo(c1.Cantidad);
                });
            }
            GuardarListado(nombreLista, res);
            return true;
        }

        public static bool AgregarCancionAFavoritos(Cancion c)
        {
            if(c == null) return false;
            if(ExisteLista("FAVORITOS") && (c.Artista != "Desconocido" && c.Album != "Desconocido") )
            {
                List<Cancion> listaCanciones = DameListadoCanciones("FAVORITOS");
                
                c.Cantidad++;
                Cancion cc = c.Clone();
             
                int index = 0;
         
                cc.UltimaReproduccion = DateTime.Now;
                if ( (index = listaCanciones.IndexOf(cc)) == -1)
                {  
                    listaCanciones.Add(cc);
                }
                else
                {
                    listaCanciones[index] = cc;
                }

                listaCanciones = listaCanciones.Select(cl =>
                {
                    if (cl.Equals(cc))
                        return cc;
                    cl.EstadoColor = "White";
                    return cl;
                }).ToList();


                listaCanciones.Sort(delegate(Cancion c1, Cancion c2) {
                    return c2.Cantidad.CompareTo(c1.Cantidad);
                });

                try
                {
                    string listaTxt = JsonConvert.SerializeObject(listaCanciones, Formatting.Indented);
                    AgregarCancionRegalo(c);
                    using (StreamWriter sw = new StreamWriter("FAVORITOS".Ruta()))
                    {
                        sw.Write(listaTxt);
                        return true;
                    }
                }
                catch
                {
                    
                }
            }
            return false;
        }

        private static void GuardarListado (string nombreLista, List<Cancion> cancions)
        {
            try
            {
                string listaTxt = JsonConvert.SerializeObject(cancions, Formatting.Indented);
                using (StreamWriter sw = new StreamWriter(nombreLista.Ruta()))
                {
                    sw.Write(listaTxt);
                }
            }
            catch
            {

            }
            
        }

        public static Dictionary<string,List<Cancion>> GenerarListasDinamicasFavoritos ()
        {
            Dictionary<string, List<Cancion>> dicCanciones = new Dictionary<string, List<Cancion>>();
            string[] paths = Directory.GetFiles(PATH_LISTAS + "Regalos");

            foreach(string p in paths)
            {
                string nombre = ExtraerNombreArchivo(p);
                List<Cancion> l = JsonConvert.DeserializeObject<List<Cancion>>(File.ReadAllText(p));
                if(l != null && l.Any())
                {
                    dicCanciones[nombre] = l;
                }
            }
            return dicCanciones;
        }

        public static List<Cancion> DameListadoRegalo(string nombreLista)
        {
            nombreLista = StringAFecha(nombreLista);

            string[] paths = Directory.GetFiles(PATH_LISTAS + "Regalos");
            foreach(var p in paths)
            {
                string nombre = ExtraerNombreArchivo(p);
                
                if(nombreLista == nombre)
                {
                    List<Cancion> l = JsonConvert.DeserializeObject<List<Cancion>>(File.ReadAllText(p));
                    if (l != null)
                    {
                        if(l.Count > 50)
                        {
                            l = l.GetRange(0, 50);
                        }
                        return l;
                    }
                        
                    else return new List<Cancion>();
                }
            }
            return new List<Cancion>();
        }

        public static List<Cancion> DameListatoFavoritos()
        {
            try
            {                
                List<Cancion> listaFav = JsonConvert.DeserializeObject<List<Cancion>>(File.ReadAllText("FAVORITOS".Ruta()));
                if(listaFav != null)
                {
                    return FiltrarCancionesExistentes(listaFav);
                }
                return  new List<Cancion>();
            }
            catch
            {
                return new List<Cancion>();
            }
        }
        
        public static void AgregarCancionRegalo(Cancion c)
        {
            if(!Directory.Exists(PATH_LISTAS + "Regalos"))
            {
                Directory.CreateDirectory(PATH_LISTAS + "Regalos");
            }
            string[] paths = Directory.GetFiles(PATH_LISTAS + "Regalos");


            string nombre = ConvertirFecha(c);
            string nombreArchivoSeleccionado = "";
            string pathSeleccionado = "";
           

            foreach (string p in paths)
            {
                string na = ExtraerNombreArchivo(p);
                if(na == nombre)
                {
                    nombreArchivoSeleccionado = na;
                    pathSeleccionado = p;
                }
            }

            if (!string.IsNullOrEmpty(nombreArchivoSeleccionado))
            {
                List<Cancion> listadoCanciones = JsonConvert.DeserializeObject<List<Cancion>>(File.ReadAllText(pathSeleccionado)) ?? new List<Cancion>();
                listadoCanciones.Add(c);
                listadoCanciones.Sort(delegate (Cancion c1, Cancion c2) {
                    return c2.Cantidad.CompareTo(c1.Cantidad);
                });
                string output = JsonConvert.SerializeObject(listadoCanciones, Formatting.Indented);
                using (StreamWriter sw = new StreamWriter(pathSeleccionado))
                {
                    sw.Write(output);
                }
            }
            else
            {
                File.Create(PATH_LISTAS + "Regalos/" + nombre + ".json");
                List<Cancion> l = new List<Cancion> { c };
                string output = JsonConvert.SerializeObject(l, Formatting.Indented);
                using (StreamWriter sw = new StreamWriter(pathSeleccionado))
                {
                    sw.Write(output);
                    
                }
            }
        }
        
        public static string ExtraerNombreArchivo(string path)
        {
            if (File.Exists(path))
            {
                FileInfo fi = new FileInfo(path);
                return Path.GetFileNameWithoutExtension(fi.FullName);
            }
            return "";
        } 

        public static string ConvertirFecha(Cancion c)
        {
            int ano = c.UltimaReproduccion.Year;
            int mes = c.UltimaReproduccion.Month;
            return mes + "-" + ano;
        }

        public static string StringAFecha(string nombre)
        {
            if (!string.IsNullOrEmpty(nombre))
            {
                if(Regex.IsMatch(nombre, "^([A-Za-z]+ {1}[0-9]{4})$"))
                {
                    string mes = nombre.Split(' ')[0];
                    string ano = nombre.Split(' ')[1];
                    mes = NumeroMes(mes);
                    return mes + "-" + ano;
                }
                return "";
            }
            return "";
        }

        public static string NumeroMes(string mes)
        {
            switch(mes)
            {
                case "Enero": return "1";
                case "Febrero": return "2";
                case "Marzo": return "3";
                case "Abril": return "4";
                case "Mayo": return "5";
                case "Junio": return "6";
                case "Julio": return "7";
                case "Agosto": return "8";
                case "Septiembre": return "9";
                case "Octubre": return "10";
                case "Noviembre": return "11";
                case "Diciembre": return "12";
                default: return "0";
            }
        }

        public static List<string> ConvertirFecha(List<Cancion> cancionesFavoritas)
        {
            List<string> ret = cancionesFavoritas.Select(c =>
            {
                int ano = c.UltimaReproduccion.Year;
                int mes = c.UltimaReproduccion.Month;
                return mes + "-" + ano;
            }).ToList();
            return ret;
        }

        public static bool EsMenorFecha(string fecha)
        {
            if(fecha == null)
                return false;
            if(Regex.IsMatch(fecha, "^([0-9]{2}-[0-9])$"))
            {
                DateTime dateTime = DateTime.Now;
                string mes = fecha.Split(new char[] { '-' })[0];
                string ano = fecha.Split(new char[] { '-' })[1];

                try
                {
                    int anoInt = int.Parse(ano);
                    int mesInt = int.Parse(mes);

                    if (dateTime.Year > anoInt)
                        return true;
                    else if (dateTime.Year == anoInt)
                    {
                        if(dateTime.Month > mesInt) 
                            return true;
                    } 
                    return false;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
    }
}
