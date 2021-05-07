using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Items
{
    enum PotionsEnum
    {
        healthPotion
    }
    public class Potion : Item
    {
        public override ItemType ItemType => ItemType.Consumable;
        public override bool IsEquippable => false;
        public override int DefaultSpriteId { get; }
        public override string DefaultName { get; }
        public int HealthPoints { get; }
        public override int MaxDurability { get; }
        public override int CurrentDurability { get; set; }

        public Potion(string type)
        {
            switch (type)
            {
                case "healthPotion":
                    DefaultSpriteId = 657;
                    DefaultName = "Health Potion";
                    HealthPoints = 30;
                    MaxDurability = 1;
                    CurrentDurability = 1;
                    break;
            }
        }

        // Increase players Attack
        public override void ActionOnUse(Player player)
        {
            player.HealthPoints += this.HealthPoints;
            DecreaseItemDurability();
        }
    }
}