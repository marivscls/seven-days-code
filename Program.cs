using RestSharp;
using System.Text.Json;
using seven_days_of_code.models;
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


            var mascotPokemon = JsonSerializer.Deserialize<MascotPokemon>(response.Content);

            Console.WriteLine(mascotPokemon.name);
            Console.WriteLine(mascotPokemon.height);
            Console.WriteLine(mascotPokemon.weight);


            Console.WriteLine("Habilidades:");

            foreach (var ability in mascotPokemon.abilities)
            {
                Console.WriteLine(ability.ability.name);
            }
        }
        else
        {
            Console.WriteLine($"Erro na requisição: {response.ErrorMessage}");
        }

    }

}

