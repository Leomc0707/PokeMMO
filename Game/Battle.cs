using System;
using PokemonMMO.Items; // Adicionado para reconhecer a classe Item

namespace PokemonMMO
{
    class Battle
    {
        private Player Player { get; set; }
        private Pokemon Opponent { get; set; }
        private bool CurrentBattleOngoing { get; set; } // Torna a propriedade uma instância

        public Battle(Player player, Pokemon opponent)
        {
            Player = player;
            Opponent = opponent;
            Player.CurrentBattle = this; // Define a batalha atual no jogador
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine($"⚔️ Batalha Iniciada! ⚔️");
            Console.WriteLine($"Você está enfrentando um {Opponent.Name}!");
            Console.WriteLine("========================================");

            CurrentBattleOngoing = true; // Define a batalha como ativa
            while (CurrentBattleOngoing)
            {
                // Exibe o estado atual da batalha
                Console.WriteLine("\nEstado da batalha:");
                Console.WriteLine($"🟢 {Player.StarterPokemon.Name}: {Player.StarterPokemon.Health}/{Player.StarterPokemon.MaxHealth}");
                Console.WriteLine($"🔴 {Opponent.Name}: {Opponent.Health}/{Opponent.MaxHealth}");
                Console.WriteLine("========================================");

                // Exibe as opções do jogador
                Console.WriteLine("\nO que você deseja fazer?");
                Console.WriteLine("1 - Atacar");
                Console.WriteLine("2 - Usar Item");
                Console.WriteLine("3 - Fugir");
                Console.Write("\nDigite sua escolha: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            PlayerAttack();
                            if (Opponent.Health <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("========================================");
                                Console.WriteLine($"🎉 Parabéns! Você derrotou o {Opponent.Name}! 🎉");
                                Console.WriteLine("========================================");
                                EndBattle();
                            }
                            else
                            {
                                OpponentAttack();
                                if (Player.StarterPokemon.Health <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("========================================");
                                    Console.WriteLine($"💀 Seu Pokémon {Player.StarterPokemon.Name} foi derrotado!");
                                    Console.WriteLine("========================================");
                                    EndBattle();
                                }
                            }
                            break;
                        case 2:
                            UseItem();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("🏃 Você fugiu da batalha!");
                            EndBattle();
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
            }
        }

        private void PlayerAttack()
        {
            Console.Clear(); // Limpa o console antes de exibir o ataque
            int damage = new Random().Next(10, 20); // Dano aleatório entre 10 e 20
            Opponent.TakeDamage(damage);
            Console.WriteLine($"⚔️ {Player.StarterPokemon.Name} atacou {Opponent.Name} e causou {damage} de dano!");
        }

        private void OpponentAttack()
        {
            int damage = new Random().Next(5, 15); // Dano aleatório entre 5 e 15
            Player.StarterPokemon.TakeDamage(damage); // O Pokémon inicial do jogador recebe o dano
        }

        private void UseItem()
        {
            Console.WriteLine("📦 Acessando o inventário...");
            Program.AccessInventory(Player.Inventory, Player); // Remove o `Opponent`
        }

        public void EndBattle()
        {
            CurrentBattleOngoing = false; // Marca a batalha como encerrada
            Player.CurrentBattle = null; // Remove a referência à batalha atual no jogador
            Console.WriteLine("A batalha terminou!");
            Console.WriteLine("========================================");
            Console.WriteLine("Voltando para a exploração...");
            Console.WriteLine("========================================");
            Console.ReadKey(); // Aguarda o jogador pressionar uma tecla
            Console.Clear(); // Limpa o console após a batalha
        }
    }
}