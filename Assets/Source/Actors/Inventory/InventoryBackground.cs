using DungeonCrawl.Actors;
using UnityEngine;

namespace Source.Actors.Inventory
{
    public class InventoryBackground : InventoryField
    {
        public override int DefaultSpriteId => 247;
        public Vector3 vector = new Vector3(2.5f, 2.5f, 0f);
        public override int Z => -1;
    }
}