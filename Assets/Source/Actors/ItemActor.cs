using DungeonCrawl.Actors;
using Assets.Source.Items;
using Source.Actors.Inventory;
using UnityEngine;

namespace Assets.Source.Actors
{
    public class ItemActor : Actor
    {
        public Item Item { get; set; }

        public override int DefaultSpriteId => Item?.DefaultSpriteId ?? 944; // null propagation / coalescing operator

        public override string DefaultName => Item == null ? "Item" : Item.DefaultName;

        public override bool Detectable => Item?.Detectable ?? false;

        public override bool OnCollision(Actor anotherActor)
        {
            Item?.OnCollision(anotherActor);
            anotherActor.HandleItemActor(this);
            return true;
        }

        public virtual void HandlePickUp(Actor anotherActor)
        {
            Item?.HandlePickUp(anotherActor);
        }


        public override int Z => Item?.Z ?? -1;

        public override void ManageItemsToSpawn(Actor component, Item item, (int x, int y) position, GameObject go)
        {
            Item = item;
            SetSprite(Item.DefaultSpriteId);
            transform.localPosition = new Vector3(position.x, position.y, -2.5f);
            go.transform.localScale = new Vector3(2f, 2f, 0f);
        }
    }
}
