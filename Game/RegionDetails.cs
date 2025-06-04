using System.Collections.Generic;
using PokemonMMO.Items;

namespace PokemonMMO
{
    class RegionDetails
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Pokemon> PokemonList { get; private set; }
        public List<Item> Items { get; private set; }
        public List<string> NPCs { get; private set; }

        public RegionDetails(string name, string description, List<Pokemon> pokemonList, List<Item> items, List<string> npcs)
        {
            Name = name;
            Description = description;
            PokemonList = pokemonList;
            Items = items;
            NPCs = npcs;
        }

        public static List<RegionDetails> InitializeRegions()
        {
            return new List<RegionDetails>
            {
                new RegionDetails(
                    "Floresta Verde",
                    "Uma floresta densa cheia de Pokémon selvagens e recursos valiosos.",
                    new List<Pokemon>
                    {
                        new Pokemon("Caterpie", "Inseto", 3, 20),
                        new Pokemon("Pidgey", "Normal/Voador", 5, 30)
                    },
                    new List<Item>
                    {
                        new Item("Poção", "Restaura 20 pontos de saúde.", "Cura", 20),
                        new Item("Pokébola", "Usada para capturar Pokémon.", "Captura", 0)
                    },
                    new List<string> { "Treinador João", "Treinadora Ana" }
                ),
                new RegionDetails(
                    "Caminho Rochoso",
                    "Um caminho árido com pedras e Pokémon do tipo terrestre.",
                    new List<Pokemon>
                    {
                        new Pokemon("Geodude", "Pedra/Terrestre", 7, 40),
                        new Pokemon("Onix", "Pedra/Terrestre", 10, 50)
                    },
                    new List<Item>
                    {
                        new Item("Super Poção", "Restaura 50 pontos de saúde.", "Cura", 50),
                        new Item("Revive", "Revive um Pokémon desmaiado.", "Revive", 0)
                    },
                    new List<string> { "Explorador Carlos" }
                ),
                new RegionDetails(
                    "Lago Cristalino",
                    "Um lago tranquilo onde vivem Pokémon aquáticos.",
                    new List<Pokemon>
                    {
                        new Pokemon("Magikarp", "Água", 5, 20),
                        new Pokemon("Psyduck", "Água", 8, 35)
                    },
                    new List<Item>
                    {
                        new Item("Elixir", "Restaura completamente a saúde e a stamina.", "Cura", 100),
                        new Item("Pokébola Avançada", "Usada para capturar Pokémon mais difíceis.", "Captura", 0)
                    },
                    new List<string> { "Pescador Pedro" }
                )
            };
        }
    }
}