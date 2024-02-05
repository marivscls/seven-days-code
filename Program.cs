using RestSharp;
using System.Text.Json;
using seven_days_of_code.models;
using System.Data.Common;
class Program
{
    static async Task Main()
    {

        // chamar a api de catalogo
        // deserializar ela
        // mostar lista

        // usuario vai digitar o nome do pokemon que ele quer

        // 

        var options = new RestClientOptions()
        {
            MaxTimeout = -1,
        };

        var client = new RestClient(options);
        var request = new RestRequest("https://pokeapi.co/api/v2/pokemon", Method.Get);

        RestResponse response = await client.ExecuteAsync(request);

        if (!response.IsSuccessful)
        {
            Console.WriteLine($"Erro na requisição: {response.ErrorMessage}");
            return;
        }

        var catalogPokemon = JsonSerializer.Deserialize<catalogPokemon>(response.Content);

        foreach (var pokemon in catalogPokemon.results)
        {
            Console.WriteLine(pokemon.name);
        }

        Console.WriteLine("Digite o nome de um pokemon: ");
        string? pokemonName = Console.ReadLine();

        string urlPokemon = "";

        foreach (var pokemon in catalogPokemon.results)
        {
            if (pokemonName == pokemon.name)
            {
                urlPokemon = pokemon.url;
            }
        }

        if (string.IsNullOrEmpty(urlPokemon))
        {
            Console.WriteLine("Pokemon nao é válido");
            return;
        }

        request = new RestRequest(urlPokemon, Method.Get);
        response = await client.ExecuteAsync(request);

        if (!response.IsSuccessful)
        {
            Console.WriteLine($"Erro na requisição: {response.ErrorMessage}");
            return;
        }

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

}

