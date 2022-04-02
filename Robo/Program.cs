using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Robo.File;

namespace Robo
{
    internal class Program
    {
        static readonly HttpClient postVoo = new HttpClient();

        static async Task Main(string[] args)
        {

            string pathFile = @"C:\Users\matheus\Downloads\GenerateDados(1).json";
            var voo = LerArquivoJson.GetDataVoo(pathFile);
            try
            {
                postVoo.BaseAddress = new Uri("https://localhost:44302/");
                postVoo.DefaultRequestHeaders.Accept.Clear();
                postVoo.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await postVoo.GetAsync("api/Voos");
                response.EnsureSuccessStatusCode();
                voo.ForEach(p => postVoo.PostAsJsonAsync("api/Voos", p));
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExceprion Caught!");
                Console.WriteLine("Message: {0}", e.Message);
            }
        }
    }
}

