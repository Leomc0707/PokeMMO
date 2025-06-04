using System;
using System.Collections.Generic;
using PokemonMMO.Items; // Adicionado para reconhecer a classe Item


namespace PokemonMMO
{
    class CentroPokemon
    {
        private static List<Item> LojaItens = new List<Item>
        {
            new Item("Poção", "Restaura 20 pontos de saúde.", "Cura", 20),
            new Item("Super Poção", "Restaura 50 pontos de saúde.", "Cura", 50),
            new Item("Pokébola", "Usada para capturar Pokémon.", "Captura", 0),
            new Item("Revive", "Revive um Pokémon desmaiado.", "Revive", 0)
        };

        private static Dictionary<string, int> Precos = new Dictionary<string, int>
        {
            { "Poção", 200 },
            { "Super Poção", 500 },
            { "Pokébola", 300 },
            { "Revive", 1000 }
        };

        public static void CurarPokemon(Player player)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("🏥 Bem-vindo ao Centro Pokémon! 🏥");
            Console.WriteLine("========================================");

            if (player.PokemonInventory.Count == 0)
            {
                Console.WriteLine("Você não possui nenhum Pokémon para curar.");
                return;
            }

            foreach (var pokemon in player.PokemonInventory)
            {
                pokemon.Heal(pokemon.MaxHealth); // Cura o Pokémon para a saúde máxima
            }

            Console.WriteLine("Todos os seus Pokémon foram curados com sucesso!");
            Console.WriteLine("========================================");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        public static void Loja(Player player)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("🛒 Bem-vindo à Loja do Centro Pokémon! 🛒");
            Console.WriteLine("========================================");
            Console.WriteLine($"Seu dinheiro atual: {player.Money}");
            Console.WriteLine("Itens disponíveis para compra:");

            for (int i = 0; i < LojaItens.Count; i++)
            {
                Item item = LojaItens[i];
                if (Precos.ContainsKey(item.Name)) // Verifica se o preço do item existe no dicionário
                {
                    Console.WriteLine($"{i + 1} - {item.Name} ({item.Description}) - Preço: {Precos[item.Name]}");
                }
                else
                {
                    Console.WriteLine($"⚠️ Erro: O item '{item.Name}' não possui um preço definido.");
                }
            }
            Console.WriteLine("0 - Voltar");
            Console.WriteLine("========================================");

            Console.Write("\nDigite o número do item que deseja comprar: ");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= LojaItens.Count)
            {
                Item itemEscolhido = LojaItens[escolha - 1];
                if (Precos.TryGetValue(itemEscolhido.Name, out int preco)) // Obtém o preço do item
                {
                    if (player.SpendMoney(preco))
                    {
                        player.Inventory.AddItem(itemEscolhido);
                        Console.WriteLine($"🎉 Você comprou {itemEscolhido.Name} por {preco}!");
                    }
                }
                else
                {
                    Console.WriteLine($"⚠️ Erro: O item '{itemEscolhido.Name}' não possui um preço definido.");
                }
            }
            else if (escolha == 0)
            {
                Console.WriteLine("Voltando ao menu do Centro Pokémon...");
            }
            else
            {
                Console.WriteLine("Opção inválida. Por favor, escolha um item válido.");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        public static void MenuCentroPokemon(Player player)
        {
            bool noCentro = true;

            while (noCentro)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("🏥 Bem-vindo ao Centro Pokémon! 🏥");
                Console.WriteLine("========================================");
                Console.WriteLine("1 - Curar Pokémon");
                Console.WriteLine("2 - Entrar na Loja de Itens");
                Console.WriteLine("0 - Sair do Centro Pokémon");
                Console.WriteLine("========================================");

                Console.Write("\nDigite sua escolha: ");
                if (int.TryParse(Console.ReadLine(), out int escolha))
                {
                    switch (escolha)
                    {
                        case 1:
                            CurarPokemon(player); // Chama o método para curar os Pokémon
                            break;
                        case 2:
                            Loja(player); // Chama o método para acessar a loja
                            break;
                        case 0:
                            Console.WriteLine("Saindo do Centro Pokémon...");
                            noCentro = false; // Sai do loop
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número.");
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}