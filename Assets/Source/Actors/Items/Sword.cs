using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Items.Weapons
{
    public abstract class Sword : Item
    {
        public override int DefaultSpriteId { get; }
        public override string DefaultName { get; }
        public override int MaxDurability { get; }
        public override int CurrentDurability { get; set; }
        public abstract int DamagePoints { get; }
        
    
        // Increase players Attack
        public override void ActionOnUse(Player player)
        {
            player.AttackPoints += DamagePoints;
            DecreaseItemDurability();
            DestroyIffJunk(player);
        }

        
        public override void DestroyIffJunk(Player player)
        {
            if (CurrentDurability <= 0)
            {
                ActorManager am = new ActorManager();
                am.DestroyActor(this);
                player.AttackPoints -= DamagePoints;
            }
        }
    }
}