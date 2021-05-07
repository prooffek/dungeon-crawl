using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Items.ItemClasses
{
    public class Armour : Item, IEquippable
    {
        public override ItemType ItemType => ItemType.Armour;
        public override bool IsEquippable => true;
        public bool IsEquipped { get; private set; }
        public override int DefaultSpriteId { get; }
        public override string DefaultName { get; }
        public int DefencePoints { get; }
        public override int MaxDurability { get; }
        public override int CurrentDurability { get; set; }


        public Armour(string type)
        {
            switch (type)
            {
                case "basic":
                    DefaultSpriteId = 84;
                    DefaultName = "Basic Armour";
                    DefencePoints = 1;
                    MaxDurability = 20;
                    CurrentDurability = 20;
                    break;
                case "knight":
                    DefaultSpriteId = 79;
                    DefaultName = "Knight Armour";
                    DefencePoints = 3;
                    MaxDurability = 23;
                    CurrentDurability = 23;
                    break;
                case "kings":
                    DefaultSpriteId = 91;
                    DefaultName = "King's Armour of Justice";
                    DefencePoints = 5;
                    MaxDurability = 27;
                    CurrentDurability = 27;
                    break;
                case "ethernal":
                    DefaultSpriteId = 83;
                    DefaultName = "Ethernal Armour of Protection";
                    DefencePoints = 10;
                    MaxDurability = 30;
                    CurrentDurability = 30;
                    break;
            }
        }

        // Increase players Attack
        public override void ActionOnUse(Player player)
        {
            player.DefencePoints += IsEquipped ? -DefencePoints : DefencePoints;
            IsEquipped = !IsEquipped;
            
            DecreaseItemDurability();
        }
    }
}