namespace seven_days_of_code.models
{
    public class catalogPokemon
    {
        public List<Results>? results
        {
            get; set;
        }

        public class Results
        {
            public string name { get; set; }
            public string url { get; set; }

        }
    }
}