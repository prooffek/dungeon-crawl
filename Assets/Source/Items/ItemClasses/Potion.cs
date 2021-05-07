using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Items.ItemClasses
{
    public enum PotionsEnum
    {
        HealthPotion
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

        public Potion(PotionsEnum type)
        {
            switch (type)
            {
                case PotionsEnum.HealthPotion:
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