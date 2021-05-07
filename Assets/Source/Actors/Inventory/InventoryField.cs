using System.Numerics;
using Assets.Source.Items;
using DungeonCrawl.Actors;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Source.Actors.Inventory
{
    public class InventoryField : Actor
    {
        public override int DefaultSpriteId { get; }
        public override string DefaultName => "InventoryField";
        public override int Z => -2;
        public Vector3 vector;
    }
}