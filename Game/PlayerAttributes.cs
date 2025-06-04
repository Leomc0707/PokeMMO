namespace PokemonMMO
{
    class PlayerAttributes
    {
        public int Level { get; private set; }
        public int Experience { get; private set; }
        public int Health { get; private set; }
        public int Stamina { get; private set; }

        public PlayerAttributes()
        {
            // Inicializa os atributos com valores padrão
            Level = 1;
            Experience = 0;
            Health = 100;
            Stamina = 100;
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > 100) Health = 100; // Limita a saúde ao máximo de 100
            Console.WriteLine($"Você foi curado em {amount} pontos! Saúde atual: {Health}/100.");
        }

        public void RestoreStamina(int amount)
        {
            Stamina += amount;
            if (Stamina > 100) Stamina = 100; // Limita a stamina ao máximo de 100
            Console.WriteLine($"Você recuperou {amount} de stamina! Stamina atual: {Stamina}/100.");
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0; // Garante que a saúde não fique negativa
            Console.WriteLine($"Você recebeu {damage} de dano! Saúde atual: {Health}/100.");
        }
    }
}