using System;
using PokemonMMO.Items; // Adicionado para reconhecer a classe Item

namespace PokemonMMO
{
    class Region
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public RegionDetails Details { get; private set; }

        public Region(string name, string description, RegionDetails details)
        {
            Name = name;
            Description = description;
            Details = details;
        }

        public void EnterRegion(Player player)
        {
            Console.WriteLine($"\n{player.Name} entrou na região: {Name}");
            Console.WriteLine(Description);
        }

        public void ExploreRegion(Player player)
        {
            Console.Clear();
            Console.WriteLine($"Explorando a região: {Name}");
            Console.WriteLine("========================================");

            Random random = new Random();
            int eventType = random.Next(1, 4); // 1: Pokémon, 2: Item, 3: Nada

            if (eventType == 1 && Details.PokemonList.Count > 0)
            {
                int index = random.Next(Details.PokemonList.Count);
                Pokemon originalPokemon = Details.PokemonList[index];

                // Cria uma nova instância do Pokémon com os mesmos atributos
                Pokemon foundPokemon = new Pokemon(
                    originalPokemon.Name,
                    originalPokemon.Type,
                    originalPokemon.Level,
                    originalPokemon.MaxHealth
                );

                Console.WriteLine("✨ Você encontrou um Pokémon selvagem! ✨");
                Console.WriteLine($"🐾 Nome: {foundPokemon.Name}");
                Console.WriteLine($"🌟 Tipo: {foundPokemon.Type}");
                Console.WriteLine($"🔢 Nível: {foundPokemon.Level}");
                Console.WriteLine($"❤️ Saúde: {foundPokemon.Health}/{foundPokemon.MaxHealth}");
                Console.WriteLine("========================================");

                Console.WriteLine("\nDeseja iniciar uma batalha?");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não");
                Console.Write("\nDigite sua escolha: ");

                if (int.TryParse(Console.ReadLine(), out int battleChoice) && battleChoice == 1)
                {
                    Battle battle = new Battle(player, foundPokemon);
                    battle.Start();
                }
                else
                {
                    Console.WriteLine("Você decidiu não lutar.");
                }
            }
            else if (eventType == 2 && Details.Items.Count > 0)
            {
                int index = random.Next(Details.Items.Count);
                Item foundItem = Details.Items[index];
                player.Inventory.AddItem(foundItem);

                // Exibe uma mensagem ao encontrar um item
                Console.WriteLine("🎁 Você encontrou um item!");
                Console.WriteLine("========================================");
                Console.WriteLine($"📦 Nome: {foundItem.Name}");
                Console.WriteLine($"📝 Descrição: {foundItem.Description}");
                Console.WriteLine("========================================");
            }
            else
            {
                // Mensagem caso não encontre nada
                Console.WriteLine("Você explorou a região, mas não encontrou nada.");
            }
        }
    }
}