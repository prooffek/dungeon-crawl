using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Items.Varia
{
    public abstract class Potion : Item
    {
        public override int DefaultSpriteId { get; }
        public override string DefaultName { get; }
        public abstract int HealthPoints { get; }
        public override int MaxDurability { get; }
        public override int CurrentDurability { get; set; }

        
        // Increase players Attack
        public override void ActionOnUse(Player player)
        {
            player.HealthPoints += this.HealthPoints;
            DecreaseItemDurability();
            DestroyIffJunk(player);
        }
    }
}