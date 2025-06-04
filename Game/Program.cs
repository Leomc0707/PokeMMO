using System;
using System.Collections.Generic;
using PokemonMMO;
using PokemonMMO.Items; // Adicionado para reconhecer a classe Item

namespace PokemonMMO
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("       Bem-vindo ao Pokémon MMO!");
            Console.WriteLine("========================================");

            // Criação do jogador
            Player player = CriarPlayer.CreateCharacter();

            // Exibe os detalhes do personagem criado
            Console.WriteLine("\n========================================");
            Console.WriteLine("Personagem criado com sucesso!");
            Console.WriteLine($"Nome: {player.Name}");
            Console.WriteLine($"Gênero: {player.Gender}");
            Console.WriteLine("========================================");

            // Inicializa as regiões
            List<RegionDetails> regionDetailsList = RegionDetails.InitializeRegions();
            if (regionDetailsList.Count < 3)
            {
                Console.WriteLine("Erro: O método InitializeRegions não retornou regiões suficientes.");
                return;
            }

            List<Region> regions = new List<Region>
            {
                new Region("Floresta Verde", "Uma floresta densa cheia de Pokémon selvagens e recursos valiosos.",
                    regionDetailsList[0]),
                new Region("Caminho Rochoso", "Um caminho árido com pedras e Pokémon do tipo terrestre.",
                    regionDetailsList[1]),
                new Region("Lago Cristalino", "Um lago tranquilo onde vivem Pokémon aquáticos.",
                    regionDetailsList[2])
            };

            // Loop principal do jogo
            bool isPlaying = true;
            while (isPlaying)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("               🏡MENU PRINCIPAL🏡");
                Console.WriteLine("========================================");
                Console.WriteLine("Escolha uma das opções abaixo:");
                Console.WriteLine("1 - Viajar para uma região");
                Console.WriteLine("0 - Sair do jogo");
                Console.WriteLine("========================================");

                Console.Write("\nDigite sua escolha: ");
                if (int.TryParse(Console.ReadLine(), out int mainChoice))
                {
                    switch (mainChoice)
                    {
                        case 0:
                            Console.WriteLine("\nObrigado por jogar! Até a próxima aventura!");
                            isPlaying = false; // Sai do loop e encerra o jogo
                            break;
                        case 1:
                            HandleRegionSelection(player, regions, ref isPlaying);
                            break;
                        default:
                            Console.WriteLine("\nOpção inválida. Por favor, escolha uma das opções disponíveis.");
                            Pause();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nEntrada inválida. Por favor, digite um número.");
                    Pause();
                }
            }
        }

        private static void Pause(string message = "Pressione qualquer tecla para continuar...")
        {
            Console.WriteLine($"\n{message}");
            Console.ReadKey();
        }

        public static void AccessInventory(Inventory inventory, Player player)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("               INVENTÁRIO");
            Console.WriteLine("========================================");

            if (inventory.Items.Count == 0)
            {
                Console.WriteLine("Seu inventário está vazio.");
            }
            else
            {
                Console.WriteLine("Itens no inventário:");
                for (int i = 0; i < inventory.Items.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {inventory.Items[i].Name}: {inventory.Items[i].Description}");
                }

                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Usar um item");
                Console.WriteLine("0 - Voltar");
                Console.Write("\nDigite sua escolha: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("\nDigite o número do item que deseja usar: ");
                            if (int.TryParse(Console.ReadLine(), out int itemIndex) && itemIndex > 0 && itemIndex <= inventory.Items.Count)
                            {
                                Item selectedItem = inventory.Items[itemIndex - 1];

                                if (selectedItem.Type == "Cura")
                                {
                                    Console.WriteLine("\nEscolha o Pokémon que deseja curar:");
                                    for (int i = 0; i < player.PokemonInventory.Count; i++)
                                    {
                                        Pokemon p = player.PokemonInventory[i];
                                        Console.WriteLine($"{i + 1} - {p.Name} (Saúde: {p.Health}/{p.MaxHealth})");
                                    }

                                    Console.Write("\nDigite o número do Pokémon que deseja curar: ");
                                    if (int.TryParse(Console.ReadLine(), out int pokemonIndex) && pokemonIndex > 0 && pokemonIndex <= player.PokemonInventory.Count)
                                    {
                                        Pokemon selectedPokemon = player.PokemonInventory[pokemonIndex - 1];
                                        selectedItem.Use(selectedPokemon, player); // Usa o item no Pokémon selecionado
                                    }
                                    else
                                    {
                                        Console.WriteLine("Número inválido. Por favor, escolha um Pokémon válido.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Este item não pode ser usado fora de batalha.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Número inválido. Por favor, escolha um número válido.");
                            }
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida.");
                }
            }

            Console.WriteLine("========================================");
            Pause("Pressione qualquer tecla para continuar...");
        }
    }
}