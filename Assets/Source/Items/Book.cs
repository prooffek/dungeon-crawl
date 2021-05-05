using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Items
{
    public abstract class Book : Item
    {
        public override ItemType ItemType => ItemType.Consumable;
        public override int DefaultSpriteId { get; }
        public override string DefaultName { get; }
        public int InteligencePoints { get; }
        public override int MaxDurability { get; }
        public override int CurrentDurability { get; set; }


        // Increase players Attack
        public override void ActionOnUse(Player player)
        {
            player.IntelligencePoints += InteligencePoints;
            DecreaseItemDurability();
            //DestroyIffJunk(player);
        }
    }
}