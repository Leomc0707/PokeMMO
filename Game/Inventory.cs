using System.Collections.Generic;
using PokemonMMO.Items;

namespace PokemonMMO
{
    class Inventory
    {
        private const int MaxItems = 7; // Limite máximo de itens no inventário
        public List<Item> Items { get; private set; }

        public Inventory()
        {
            Items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (Items.Count >= MaxItems)
            {
                Console.WriteLine("⚠️ O inventário está cheio! Não é possível adicionar mais itens.");
                return;
            }

            Items.Add(item);
            Console.WriteLine($"Item '{item.Name}' foi adicionado ao inventário.");
        }

        public void RemoveItem(Item item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                Console.WriteLine($"Item '{item.Name}' foi removido do inventário.");
            }
            else
            {
                Console.WriteLine($"O item '{item.Name}' não está no inventário.");
            }
        }

        public void UseItem(string itemName, Pokemon pokemon, Player player)
        {
            Item item = Items.Find(i => i.Name == itemName);
            if (item != null)
            {
                item.Use(pokemon, player);
                RemoveItem(item); // Remove o item após o uso
            }
            else
            {
                Console.WriteLine($"O item '{itemName}' não está no inventário.");
            }
        }
    }
}