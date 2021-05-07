using System.Collections.Generic;
using Assets.Source.Items.Books;
using Assets.Source.Items.Foods;

namespace Assets.Source.Items
{
    public class ItemsList
    {
        public List<List<Item>> ListOfItemsList { get; } = new List<List<Item>>()

        {
            new List<Item>()
            {
                new Food("apple"),
                new Food("fish"),
                new Food("meat"),
                new Mushroom(),
            },

            new List<Item>()
            {
                new Book("poem"),
                new KnightsTraining(),
                new AncientMedicine(),
                new Book("peasant"),
            },

            new List<Item>()
            {
                new Sword("soldier"),
                new Sword("knight"),
                new Sword("kings"),
                new Sword("ethernal"),
            },

            new List<Item>()
            {
                new Wand("adept"),
                new Wand("druid"),
                new Wand("aechmage"),
                new Wand("great"),
                new Wand("sailor moon"),
            },

            new List<Item>()
            {
                new Armour("basic"),
                new Armour("knight"),
                new Armour("king"),
                new Armour("ethernal"),
            },

            new List<Item>()
            {
                new Potion("health"),
            }

        };
    }
}