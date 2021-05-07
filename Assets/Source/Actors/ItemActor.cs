using DungeonCrawl.Actors;
using Assets.Source.Items;
using Source.Actors.Inventory;
using UnityEngine;

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
            if (!(Item is null)) Item.OnCollision(anotherActor); // experimental

            anotherActor.HandleItem(this);
            return true;
        }

        public virtual void HandlePickUp(Actor anotherActor)
        {
            if (!(Item is null)) Item.HandlePickUp(anotherActor);
        }


        public override int Z => Item is null ? -1 : Item.Z;

        public override void ManageItemsToSpawn(Actor component, Item item, (int x, int y) position, GameObject go)
        {
            Item = item;
            SetSprite(Item.DefaultSpriteId);
            transform.localPosition = new Vector3(position.x, position.y, -2.5f);
            go.transform.localScale = new Vector3(2f, 2f, 0f);
        }
    }
}
