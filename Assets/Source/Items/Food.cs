using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Items
{
    public abstract class Food : Item
    {
        public override ItemType ItemType => ItemType.Consumable;
        public override bool IsEquippable => false;
        public override int DefaultSpriteId { get; }
        public override string DefaultName { get; }
        public abstract int NutritiousPoints { get; }
        public override int MaxDurability { get; }
        public override int CurrentDurability { get; set; }
        

        // Increase players Attack
        public override void ActionOnUse(Player player)
        {
            player.StaminaPoints += this.NutritiousPoints;
            CurrentDurability = 0;
            //DestroyIffJunk(player);
        }
    }
}