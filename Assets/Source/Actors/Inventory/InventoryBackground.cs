using Assets.Source.Actors;
using Assets.Source.Items;
using DungeonCrawl.Actors;
using UnityEngine;

namespace Source.Actors.Inventory
{
    public class InventoryBackground : InventoryField
    {
        public override int DefaultSpriteId => 247;
        public Vector3 vector = new Vector3(2.5f, 2.5f, 0f);
        public override int Z => -1;
        
        public override void ManageItemsToSpawn(Actor component, Item item, (int x, int y) position, GameObject go)
        {
            go.transform.localScale = vector; 
            go.transform.localPosition = new Vector3(position.x, position.y, -1.9f);
        }
    }
}