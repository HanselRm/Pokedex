using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test_Api.Models;

namespace Test_Api
{
      class Api
    {
        Pokemon pokemon = new Pokemon();
        public  async Task<Pokemon> pruebaAsync(String nombre)
        {
            

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage respuesta = await client.GetAsync("https://pokeapi.co/api/v2/pokemon/" + nombre);
                if (respuesta.IsSuccessStatusCode)
                {
                    string respuestaApi = await respuesta.Content.ReadAsStringAsync();
                    pokemon = JsonConvert.DeserializeObject<Pokemon>(respuestaApi);

                }
            }
        return pokemon;
        }
    }
}
