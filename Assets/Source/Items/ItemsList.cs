using System.Collections.Generic;
using Assets.Source.Items.ItemClasses;
using Assets.Source.Items.ItemClasses.Books;

namespace Assets.Source.Items
{
    public class ItemsList
    {
        public List<List<Item>> ListOfItemsList { get; } = new List<List<Item>>()

        {
            new List<Item>()
            {
                new Food(FoodEnum.Apple),
                new Food(FoodEnum.Fish),
                new Food(FoodEnum.Meat),
                new Mushroom(),
            },

            new List<Item>()
            {
                new Book(BooksEnum.PoemOfTheFeudalism),
                new Book(BooksEnum.PeasantsAndMasters),
                new KnightsTraining(),
                new AncientMedicine(),
            },

            new List<Item>()
            {
                new Sword(SwordsEnum.SoldiersSword),
                new Sword(SwordsEnum.KnightSword),
                new Sword(SwordsEnum.KingsSwordOfPower),
                new Sword(SwordsEnum.EthernalSwordOfDestruction),
            },

            new List<Item>()
            {
                new Wand(WandsEnum.AdeptsWand),
                new Wand(WandsEnum.DruidsWand),
                new Wand(WandsEnum.ArchmagesWandOfWisdom),
                new Wand(WandsEnum.GreatWandOfAnnihilation),
                new Wand(WandsEnum.GreatWandOfAnnihilation),
            },

            new List<Item>()
            {
                new Armour(ArmourEnum.BasicArmour),
                new Armour(ArmourEnum.KnightArmour),
                new Armour(ArmourEnum.KingsArmourOfJustice),
                new Armour(ArmourEnum.EthernalArmourOfProtection),
            },

            new List<Item>()
            {
                new Potion(PotionsEnum.HealthPotion),
            }

        };
    }
}