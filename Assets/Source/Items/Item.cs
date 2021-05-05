using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors;

namespace Assets.Source.Items
{
    public abstract class Item : IActor
    {
        public abstract ItemType ItemType { get; }
        public abstract int MaxDurability { get; }
        public abstract int CurrentDurability { get; set; }

        public abstract string DefaultName { get; }

        public abstract int DefaultSpriteId { get; }

        public virtual bool Detectable => true;

        public virtual int Z => 0;

        public virtual bool OnCollision(Actor anotherActor)
        {
            anotherActor.HandleItem(this);

            return true;
        }

        // Allows to execute additional code before this is picked up
        public virtual void HandlePickUp(Actor anotherActor)
        {
        }
        
        public virtual void DecreaseItemDurability()
        {
            CurrentDurability -= 1;
        }
        
        
        //public virtual void DestroyIffJunk(Player player)
        //{
        //    if (CurrentDurability <= 0)
        //    {
        //        ActorManager am = new ActorManager();
        //        am.DestroyActor(this);
        //    }
        //}

        //Create a deep copy of the item with difference references
        
 

        //Try taking action specific for the item (add health, deal damage, etc.)
        public abstract void ActionOnUse(Player player);
    }
}