using DungeonCrawl.Actors.Characters;
using static DungeonCrawl.Utilities;

namespace Assets.Source.Items.ItemClasses
{
    public enum BooksEnum
    {
        PoemOfTheFeudalism,
        PeasantsAndMasters,
        AncientMedicine,
        KnightsTraining
    }
    public class Book : Item
    {
        public override ItemType ItemType => ItemType.Consumable;
        public override bool IsEquippable => false;
        public override int DefaultSpriteId { get; }
        public override string DefaultName { get; }
        public int InteligencePoints { get; }
        public override int MaxDurability { get; }
        public override int CurrentDurability { get; set; }

        
        public Book(BooksEnum type)
        {
            switch (type)
            {
                case BooksEnum.PoemOfTheFeudalism:
                    DefaultSpriteId = 751;
                    DefaultName = "Poem of the Feudalism";
                    InteligencePoints = 1;
                    MaxDurability = 1;
                    CurrentDurability = 1;
                    break;
                case BooksEnum.PeasantsAndMasters:
                    DefaultSpriteId = 751;
                    DefaultName = "Peasants and Masters";
                    InteligencePoints = 2;
                    MaxDurability = 1;
                    CurrentDurability = 1;
                    break;
                case BooksEnum.AncientMedicine:
                    DefaultSpriteId = 752;
                    DefaultName = "Ancient Medicine";
                    InteligencePoints = 2;
                    MaxDurability = 1;
                    CurrentDurability = 1;
                    break;
                case BooksEnum.KnightsTraining:
                    DefaultSpriteId = 752;
                    DefaultName = "Knight's Training";
                    InteligencePoints = 2;
                    MaxDurability = 1;
                    CurrentDurability = 1;
                    break;
            }
        }

        // Increase players Attack
        public override void ActionOnUse(Player player)
        {
            player.IntelligencePoints += InteligencePoints;
            DecreaseItemDurability();
        }
    }
}