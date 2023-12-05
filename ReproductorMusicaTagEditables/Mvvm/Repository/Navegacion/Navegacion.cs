using Newtonsoft.Json;
using System;
using System.IO;


namespace ReproductorMusicaTagEditables.Mvvm.Repository.Navegacion
{
    public class Navegacion
    {
        public static readonly string INFO_USUARIO = Environment.CurrentDirectory + "/Usuario/Navegacion.json";

        public static void Crear()
        {
            if (!Directory.Exists(Environment.CurrentDirectory + "/Usuario/"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "/Usuario/");
            if (!File.Exists(INFO_USUARIO)) 
                File.Create(INFO_USUARIO);
        }

        public static bool Existe()
        {
            return File.Exists(INFO_USUARIO); 
        }

        public static void GuardarInfo(InfoNavegacion infoNavegacion)
        {
            if (File.Exists(INFO_USUARIO))
            {
                try
                {
                    string output = JsonConvert.SerializeObject(infoNavegacion, Formatting.Indented);
                    using(StreamWriter sw = new StreamWriter(INFO_USUARIO))
                    {
                        sw.Write(output);
                    }
                }
                catch
                {

                }
                
            }
        }

        public static InfoNavegacion LevantarInfo()
        {
            InfoNavegacion ina;
            
            if(Existe()) 
            {
                try
                {
                    ina = JsonConvert.DeserializeObject<InfoNavegacion>(File.ReadAllText(INFO_USUARIO));
                    return ina;
                }
                catch (IOException e)
                {
                    return null;
                }
            }
            return null;

        }
    }
}
