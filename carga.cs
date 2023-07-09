using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Web;

namespace Personajes
{
    public class cargaHttp
    {
        public async Task<FabricaDePersonajes> cargarApi(string url)
        {
            HttpClient cliente = new HttpClient();
            FabricaDePersonajes nuevo = new FabricaDePersonajes();
            HttpResponseMessage respuesta = await cliente.GetAsync(url);
            if(respuesta.IsSuccessStatusCode)
            {
                string json = await respuesta.Content.ReadAsStringAsync();
                string subJson = json.Substring(12,json.IndexOf(']') - 12);
                nuevo = JsonSerializer.Deserialize<FabricaDePersonajes>(subJson);
            }
            else
            {
                Console.WriteLine("ERROR AL CARGAR DEL API");
            }
            return nuevo;
        }
    }
}