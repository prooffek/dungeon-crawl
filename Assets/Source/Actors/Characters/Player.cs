using Assets.Source.Actors.Items;
using DungeonCrawl.Actors.Items;
using DungeonCrawl.Core;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public List<Item> Inventory { get; set; } = new List<Item>();
        protected override void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Move up
                TryMove(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Move down
                TryMove(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                // Move left
                TryMove(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                // Move right
                TryMove(Direction.Right);
            }

            //this.StaminaPoints -= 1;
        }

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        protected override void OnDeath()
        {
            Debug.Log("Oh no, I'm dead!");
        }

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";

        public override void HandleItem(Item item)
        {
            PickUpItem(item);
        }

        public void PickUpItem(Item item)
        {
            Inventory.Add(item);
            ActorManager.Singleton.DestroyActor(item.Actor);
        }
    }
}
