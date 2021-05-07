using System.Numerics;
using DungeonCrawl.Actors;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Source.Actors.Inventory
{
    public abstract class InventoryField : Actor
    {
        public override string DefaultName => "InventoryField";
        public override int Z => -1;
        public Vector3 vector;
    }
}