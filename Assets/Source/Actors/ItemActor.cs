using DungeonCrawl.Actors;
using Assets.Source.Items;

namespace Assets.Source.Actors
{
    public class ItemActor : Actor
    {
        public Item Item { get; set; }

        public override int DefaultSpriteId => Item is null ? 944 : Item.DefaultSpriteId;

        public override string DefaultName => Item is null ? "Item" : Item.DefaultName;

        public override bool Detectable => Item is null ? false : Item.Detectable;

        public override bool OnCollision(Actor anotherActor)
        {
            anotherActor.HandleItem(this);
            return true;
        }

        public virtual void HandlePickUp(Actor anotherActor)
        {
            if (!(Item is null)) Item.HandlePickUp(anotherActor);
        }


        public override int Z => Item is null ? base.Z : Item.Z;


    }
}
