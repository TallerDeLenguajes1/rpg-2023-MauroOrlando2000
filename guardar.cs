using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Personajes
{
    public class PersonajesJson
    {
        public void GuardarPersonajes(List<FabricaDePersonajes> lista, string archivo)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(lista, options) + "\n\n";
            File.WriteAllText(archivo, json);
        }

        public List<FabricaDePersonajes> LeerPersonajes(string archivo)
        {
            var lista = new List<FabricaDePersonajes>();
            StreamReader SR = new StreamReader(archivo);
            string json = SR.ReadToEnd();
            lista = JsonSerializer.Deserialize<List<FabricaDePersonajes>>(json);
            return lista;
        }

        public bool Existe(string archivo)
        {
            bool datos = false;
            if(File.Exists(archivo))
            {
                var Aux = new FileInfo(archivo);
                datos = Aux.Length != 0? true : false;
            }
            return datos;
        }
    }
}