using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Items.Armours
{
    public abstract class Armour : Item
    {
        public override int DefaultSpriteId { get; }
        public override string DefaultName { get; }
        public abstract int DefencePoints { get; }
        public override int MaxDurability { get; }
        public override int CurrentDurability { get; set; }

        
        // Increase players Attack
        public override void ActionOnUse(Player player)
        {
            player.DeffencePoints += this.DefencePoints;
        }
        
        //public override void DestroyIffJunk(Player player)
        //{
        //    if (CurrentDurability <= 0)
        //    {
        //        ActorManager am = new ActorManager();
        //        am.DestroyActor(this);
        //        player.AttackPoints -= this.DefencePoints;
        //    }
        //}
    }
}