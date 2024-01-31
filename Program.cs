using System;
using System.Threading.Tasks;
using RestSharp;

class Program
{
    static async Task Main()
    {
        var options = new RestClientOptions("https://pokeapi.co/api/v2/")
        {
            MaxTimeout = -1,
        };

        var client = new RestClient(options);
        var request = new RestRequest("pokemon/1/", Method.Get);

        RestResponse response = await client.ExecuteAsync(request);

        if (response.IsSuccessful)
        {
            Console.WriteLine(response.Content);
        }
        else
        {
            Console.WriteLine($"Erro na requisição: {response.ErrorMessage}");
        }
    }
}
