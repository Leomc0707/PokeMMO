using System.Collections.Generic;

namespace PokemonMMO
{
    class Player
    {
        public string Name { get; private set; }
        public string Gender { get; private set; }
        public Inventory Inventory { get; private set; }
        public Pokemon StarterPokemon { get; private set; } // O Pokémon inicial do jogador
        public List<Pokemon> PokemonInventory { get; private set; } // Inventário de Pokémon do jogador
        public Battle CurrentBattle { get; set; } // Referência à batalha atual
        public int Money { get; private set; } // Dinheiro do jogador

        public Player(string name, string gender, Pokemon starterPokemon)
        {
            Name = name;
            Gender = gender;
            Inventory = new Inventory(); // Inicializa o inventário de itens
            StarterPokemon = starterPokemon; // Define o Pokémon inicial
            PokemonInventory = new List<Pokemon> { starterPokemon }; // Adiciona o Pokémon inicial ao inventário
            Money = 1000; // Inicializa o jogador com 1000 de dinheiro
        }

        public void AddPokemon(Pokemon pokemon)
        {
            if (PokemonInventory.Count >= 6) // Limite de 6 Pokémon na equipe
            {
                Console.WriteLine("⚠️ Você já tem 6 Pokémon na sua equipe! Não é possível capturar mais.");
                return;
            }

            PokemonInventory.Add(pokemon);
            Console.WriteLine($"🎉 {pokemon.Name} foi adicionado à sua equipe!");
        }

        public void AddMoney(int amount)
        {
            Money += amount;
            Console.WriteLine($"Você ganhou {amount} de dinheiro! Dinheiro atual: {Money}");
        }

        public bool SpendMoney(int amount)
        {
            if (Money >= amount)
            {
                Money -= amount;
                Console.WriteLine($"Você gastou {amount} de dinheiro! Dinheiro restante: {Money}");
                return true;
            }
            else
            {
                Console.WriteLine("⚠️ Você não tem dinheiro suficiente para essa compra.");
                return false;
            }
        }

        public void ShowPokemonInventory()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("           INVENTÁRIO DE POKÉMON");
            Console.WriteLine("========================================");

            if (PokemonInventory.Count == 0)
            {
                Console.WriteLine("Você não possui nenhum Pokémon.");
            }
            else
            {
                for (int i = 0; i < PokemonInventory.Count; i++)
                {
                    Pokemon p = PokemonInventory[i];
                    Console.WriteLine($"{i + 1} - {p.Name} (Nível: {p.Level}, Saúde: {p.Health}/{p.MaxHealth})");
                }
            }

            Console.WriteLine("========================================");
        }
    }
}