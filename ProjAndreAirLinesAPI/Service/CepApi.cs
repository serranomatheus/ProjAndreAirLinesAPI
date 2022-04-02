using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjAndreAirLinesAPI.Model;

namespace ProjAndreAirLinesAPI.Service
{
    public class CepApi
    {
        static readonly HttpClient client = new HttpClient();
        public static async Task<Endereco> ViaCepJsonAsync(string cep)
        {

            try
            {
                HttpResponseMessage response = await client.GetAsync("https://viacep.com.br/ws/"+cep+"/json/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var endereco = JsonConvert.DeserializeObject<Endereco>(responseBody);
                return endereco;
                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                throw;
            }
        }
    }
}
