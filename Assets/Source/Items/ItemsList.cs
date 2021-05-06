using System.Collections.Generic;
using Assets.Source.Items.Armours;
using Assets.Source.Items.Books;
using Assets.Source.Items.Foods;
using Assets.Source.Items.Potions;
using Assets.Source.Items.Swords;
using Assets.Source.Items.Wands;

namespace Assets.Source.Items
{
    public class ItemsList
    {
        public List<List<Item>> ListOfItemsList { get; } = new List<List<Item>>()

        {
            new List<Item>()
            {
                new Apple(),
                new Fish(),
                new Meat(),
                new Mushroom(),
            },

            new List<Item>()
            {
                new PeasantsAndMasters(),
                new KnightsTraining(),
                new AncientMedicine(),
                new PoemOfTheFeudalism(),
            },

            new List<Item>()
            {
                new SoldiersSword(),
                new KnightSword(),
                new KingsSwordOfPower(),
                new EthernalSwordOfDestruction(),
            },

            new List<Item>()
            {
                new AdeptsWand(),
                new DruidsWand(),
                new ArchmagesWandOfWisdom(),
                new GreatWandOfAnnihilation(),
                new SailorMoonWand(),
            },

            new List<Item>()
            {
                new BasicArmour(),
                new KnightArmour(),
                new KingsArmourOfJustice(),
                new EthernalArmourOfProtection(),
            },

            new List<Item>()
            {
                new HealthPotion(),
            }

        };
    }
}