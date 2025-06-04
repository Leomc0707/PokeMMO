using System;
using System.Collections.Generic;

namespace PokemonMMO
{
    class CriarPlayer
    {
        public static Player CreateCharacter()
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine("Criação de Personagem");
            Console.WriteLine("========================================");

            // Solicita o nome do jogador
            string name = "";
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Digite o nome do seu personagem: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("O nome não pode estar vazio. Por favor, digite um nome válido.");
                }
            }

            // Solicita o gênero do jogador
            string gender = "";
            while (gender != "M" && gender != "F")
            {
                Console.Write("Escolha o gênero (M para Masculino, F para Feminino): ");
                gender = Console.ReadLine()?.ToUpper();
                if (gender != "M" && gender != "F")
                {
                    Console.WriteLine("Opção inválida. Por favor, escolha 'M' ou 'F'.");
                }
            }

            // Exibe a lista de Pokémon iniciais
            Console.WriteLine("\nEscolha seu Pokémon inicial:");
            List<Pokemon> starterPokemon = PokemonDatabase.GetStarterPokemon();
            for (int i = 0; i < starterPokemon.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {starterPokemon[i].Name} ({starterPokemon[i].Type})");
            }

            Pokemon chosenPokemon = null;
            while (chosenPokemon == null)
            {
                Console.Write("\nDigite o número do Pokémon que deseja escolher: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= starterPokemon.Count)
                {
                    chosenPokemon = starterPokemon[choice - 1];
                }
                else
                {
                    Console.WriteLine("Opção inválida. Por favor, escolha um número válido.");
                }
            }

            Console.WriteLine($"\n🎉 Você escolheu {chosenPokemon.Name} como seu Pokémon inicial!");
            Console.WriteLine("========================================");

            // Retorna o personagem criado com o Pokémon inicial
            return new Player(name, gender == "M" ? "Masculino" : "Feminino", chosenPokemon);
        }
    }
}