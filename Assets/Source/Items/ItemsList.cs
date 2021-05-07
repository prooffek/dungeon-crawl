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
                new Food(FoodEnum.apple.ToString()),
                new Food(FoodEnum.fish.ToString()),
                new Food(FoodEnum.meat.ToString()),
                new Mushroom(),
            },

            new List<Item>()
            {
                new Book(BooksEnum.PoemOfTheFeudalism.ToString()),
                new Book(BooksEnum.PeasantsAndMasters.ToString()),
                new KnightsTraining(),
                new AncientMedicine(),
            },

            new List<Item>()
            {
                new Sword(SwordsEnum.SoldiersSword.ToString()),
                new Sword(SwordsEnum.KnightSword.ToString()),
                new Sword(SwordsEnum.KingsSwordOfPower.ToString()),
                new Sword(SwordsEnum.EthernalSwordOfDestruction.ToString()),
            },

            new List<Item>()
            {
                new Wand(WandsEnum.AdeptsWand.ToString()),
                new Wand(WandsEnum.DruidsWand.ToString()),
                new Wand(WandsEnum.ArchmagesWandOfWisdom.ToString()),
                new Wand(WandsEnum.GreatWandOfAnnihilation.ToString()),
                new Wand(WandsEnum.GreatWandOfAnnihilation.ToString()),
            },

            new List<Item>()
            {
                new Armour(ArmourEnum.BasicArmour.ToString()),
                new Armour(ArmourEnum.KnightArmour.ToString()),
                new Armour(ArmourEnum.KingsArmourOfJustice.ToString()),
                new Armour(ArmourEnum.EthernalArmourOfProtection.ToString()),
            },

            new List<Item>()
            {
                new Potion(PotionsEnum.healthPotion.ToString()),
            }

        };
    }
}