namespace PokemonMMO
{
    class Pokemon
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Level { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }

        public Pokemon(string name, string type, int level, int maxHealth)
        {
            Name = name;
            Type = type;
            Level = level;
            MaxHealth = maxHealth;
            Health = maxHealth; // Inicializa com a saúde máxima
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} recebeu {damage} de dano! Saúde atual: {Health}/{MaxHealth}");
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth) Health = MaxHealth;
            Console.WriteLine($"{Name} foi curado em {amount} pontos! Saúde atual: {Health}/{MaxHealth}");
        }

        public void LevelUp()
        {
            Level++;
            MaxHealth += 10; // Aumenta a saúde máxima ao subir de nível
            Health = MaxHealth; // Restaura a saúde ao máximo
            Console.WriteLine($"{Name} subiu para o nível {Level}! Saúde máxima agora é {MaxHealth}.");
        }

        public void Attack(Pokemon target)
        {
            int damage = new Random().Next(5, 15); // Dano aleatório entre 5 e 15
            target.TakeDamage(damage);
            Console.WriteLine($"{Name} atacou {target.Name} e causou {damage} de dano!");
        }
    }
}