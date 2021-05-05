using Assets.Source.Actors;
using Assets.Source.Core;
using Assets.Source.Items;
using DungeonCrawl.Core;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        bool _isStandingOnItem = false;
        ItemActor _currentItemActor;
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

            if (_isStandingOnItem && Input.GetKeyDown(KeyCode.E))
            {
                HidePickUpInfo();
                PickUpItem(_currentItemActor);
                _isStandingOnItem = false;
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

        public override void HandleItem(ItemActor itemActor)
        {
            DisplayPickUpInfo(itemActor.Item.DefaultName);
            _isStandingOnItem = true;
            _currentItemActor = itemActor;

        }
        
        void PickUpItem(ItemActor itemActor)
        {
            _currentItemActor = null;
            itemActor.HandlePickUp(this);
            Inventory.Add(itemActor.Item);
            ActorManager.Singleton.DestroyActor(itemActor);
        }

        void DisplayPickUpInfo(string itemName)
        {
            UserInterface.Singleton.SetText($"Press 'E' to pick up {itemName}", UserInterface.TextPosition.BottomRight);
        }

        void HidePickUpInfo()
        {
            UserInterface.Singleton.SetText("", UserInterface.TextPosition.BottomRight);
        }

    }
}
