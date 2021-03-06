using Assets.Source.Actors;
using Assets.Source.Items;
using DungeonCrawl.Actors;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Source.Actors.Inventory
{
    public class InventoryFrame : InventoryField
    {
        public override int DefaultSpriteId => 710;
        public Vector3 vector = new Vector3(3f, 3f, 0f);
        
        public override void ManageItemsToSpawn(Actor component, Item item, (int x, int y) position, GameObject go)
        {
            go.transform.localScale = vector;
        }
    }
}