using DungeonCrawl.Actors.Characters;
using static DungeonCrawl.Utilities;

namespace Assets.Source.Items.ItemClasses
{
    enum FoodEnum
    {
        apple,
        fish,
        meat,
        mushroom
    }
    public class Food : Item
    {
        public override ItemType ItemType => ItemType.Consumable;
        public override bool IsEquippable => false;
        public override int DefaultSpriteId { get; }
        public override string DefaultName { get; }
        public int NutritiousPoints { get; protected set; }
        public override int MaxDurability { get; }
        public override int CurrentDurability { get; set; }


        public Food(string type)
        {
            switch (type)
            {
                case "apple":
                    DefaultSpriteId = 896;
                    DefaultName = "Apple";
                    NutritiousPoints = 5;
                    MaxDurability = 1;
                    CurrentDurability = 1;
                    break;
                case "fish":
                    DefaultSpriteId = 848;
                    DefaultName = "Fish";
                    NutritiousPoints = GetRandomBoolean() ? 15 : -5;
                    MaxDurability = 1;
                    CurrentDurability = 1;
                    break;
                case "meat":
                    DefaultSpriteId = 800;
                    DefaultName = "Meat";
                    NutritiousPoints = 10;
                    MaxDurability = 1;
                    CurrentDurability = 1;
                    break;
                case "mushroom":
                    DefaultSpriteId = 973;
                    DefaultName = "Mushroom";
                    MaxDurability = 1;
                    CurrentDurability = 1;
                    break;
            }
        }

        // Increase players Attack
        public override void ActionOnUse(Player player)
        {
            player.StaminaPoints += this.NutritiousPoints;
            CurrentDurability = 0;
        }
    }
}