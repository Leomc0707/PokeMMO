namespace PokemonMMO.Items
{
    class Item
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Type { get; private set; } // Exemplo: "Cura", "Pokébola", etc.
        public int EffectValue { get; private set; } // Valor do efeito (ex.: cura 20 HP)

        public Item(string name, string description, string type, int effectValue)
        {
            Name = name;
            Description = description;
            Type = type;
            EffectValue = effectValue;
        }

        public void Use(Pokemon pokemon, Player player)
        {
            switch (Type)
            {
                case "Cura":
                    if (pokemon.Health == pokemon.MaxHealth)
                    {
                        Console.WriteLine($"⚠️ {pokemon.Name} já está com a saúde cheia! O item {Name} não foi usado.");
                        return; // Sai do método sem usar o item
                    }
                    pokemon.Heal(EffectValue);
                    Console.WriteLine($"{Name} usado! {pokemon.Name} recuperou {EffectValue} pontos de saúde.");
                    break;
                case "Captura":
                    if (TryCapture(pokemon))
                    {
                        Console.WriteLine($"🎉 Parabéns! Você capturou o {pokemon.Name}!");
                        if (player != null)
                        {
                            player.AddPokemon(pokemon); // Adiciona o Pokémon ao inventário do jogador
                            player.Inventory.RemoveItem(this); // Remove a Pokébola após o uso
                        }
                        player.CurrentBattle?.EndBattle(); // Encerra a batalha chamando o método EndBattle
                    }
                    else
                    {
                        Console.WriteLine($"❌ A captura do {pokemon.Name} falhou!");
                    }
                    break;
                default:
                    Console.WriteLine($"O item {Name} não pode ser usado.");
                    break;
            }
        }

        private bool TryCapture(Pokemon pokemon)
        {
            Random random = new Random();
            int captureChance = Math.Max(10, 100 - (pokemon.Health * 100 / pokemon.MaxHealth)); // Quanto menor a saúde, maior a chance
            int roll = random.Next(1, 101); // Gera um número entre 1 e 100
            return roll <= captureChance;
        }
    }
}