using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Items.Weapons
{
    public abstract class Wand : Item
    {
        public override int DefaultSpriteId { get; }
        public override string DefaultName { get; }
        public abstract int Inteligence { get; }
        public override int MaxDurability { get; }
        public override int CurrentDurability { get; set; }


        // Increase players Attack
        public override void ActionOnUse(Player player)
        {
            player.Inteligence += this.Inteligence;
            DecreaseItemDurability();
            //DestroyIffJunk(player);
        }

        //public override void DestroyIffJunk(Player player)
        //{
        //    if (CurrentDurability <= 0)
        //    {
        //        ActorManager am = new ActorManager();
        //        am.DestroyActor(this);
        //        player.Inteligence -= this.Inteligence;
        //    }
        //}
    }
}