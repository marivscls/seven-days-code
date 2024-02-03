namespace seven_days_of_code.models
{
    public class MascotPokemon
    {
        public string? name { get; set; }
        public object? height { get; set; }
        public double weight { get; set; }
        public List<Abilities>? abilities
        {
            get; set;
        }
    }

    public class Abilities
    {
        public Ability? ability { get; set; }
        public int slot { get; set; }
        public bool is_hidden { get; set; }
    }

    public class Ability
    {
        public string? name { get; set; }
        public string? url { get; set; }
    }
}
