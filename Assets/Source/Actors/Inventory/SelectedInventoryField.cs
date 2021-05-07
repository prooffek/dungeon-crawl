using DungeonCrawl.Actors;
using UnityEngine;

namespace Source.Actors.Inventory
{
    public class SelectedInventoryField : InventoryField
    {
        public override int DefaultSpriteId => 710;
        public Vector3 vector = new Vector3(3.5f, 3.5f, 0f);
    }
}