using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Items.Books
{
    public abstract class Book : Item
    {
        public override int DefaultSpriteId { get; }
        public override string DefaultName { get; }
        public int InteligencePoints { get; }
        public override int MaxDurability { get; }
        public override int CurrentDurability { get; set; }
        

        // Increase players Attack
        public override void ActionOnUse(Player player)
        {
            player.Inteligence += InteligencePoints;
            DecreaseItemDurability();
            //DestroyIffJunk(player);
        }
    }
}