using System;
using System.Collections.Generic;

namespace PokemonMMO
{
    class PokemonDatabase
    {
        private static Random random = new Random(); // Instância de Random para gerar valores aleatórios

        // Método para retornar todos os Pokémon iniciais
        public static List<Pokemon> GetStarterPokemon()
        {
            return new List<Pokemon>
            {
                CreatePokemon("Pikachu", "Elétrico", 35),
                CreatePokemon("Charmander", "Fogo", 40),
                CreatePokemon("Bulbasaur", "Grama", 45),
                CreatePokemon("Squirtle", "Água", 40)
            };
        }

        // Método genérico para criar Pokémon
        public static Pokemon CreatePokemon(string name, string type, int maxHealth)
        {
            int level = 5; // Define o nível inicial como 5
            return new Pokemon(name, type, level, maxHealth);
        }
    }
}