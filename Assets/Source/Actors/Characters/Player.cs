using Assets.Source.Actors;
using Assets.Source.Core;
using Assets.Source.Items;
using DungeonCrawl.Core;
using System.Collections.Generic;
using Source.Actors.Inventory;
using UnityEngine;
using static Source.Actors.Inventory.DisplayInventory;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        [SerializeField]
        ItemActor _currentItemActor;

        // do zmiany - roboczo
        Inventory Inventory { get; set; } = new Inventory();

        private bool WentToNextMap;

        public int CurrentWorldNumber { get; private set; } = 1;

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";

        protected override void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                _isInventoryOpen = !_isInventoryOpen;
            }

            if (_isInventoryOpen)
            {
                MoveThroughInventory();
            }
            else
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

                if (_currentItemActor != null && Input.GetKeyDown(KeyCode.E))
                {
                    HidePickUpInfo();
                    PickUpItem(_currentItemActor);
                    ClearCurrentItemActor();
                }
            }

            InventoryDesplayManagement(_isInventoryOpen);

            GoToNextMap();

        }

        public override void TryMove(Direction direction)
        {
            var vector = direction.ToVector();
            (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);

            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);

            if (actorAtTargetPosition == null)
            {
                // No obstacle found, just move
                ClearCurrentItemActor();
                HidePickUpInfo();
                Position = targetPosition;
                CameraController.Singleton.CenterCameraOnPlayer();
                if (this is Player player)
                {
                    AudioSource audioSource = player.GetComponent<AudioSource>();
                    audioSource.Play();
                }
            }
            else
            {
                if (actorAtTargetPosition.OnCollision(this))
                {
                    // Allowed to move
                    Position = targetPosition;
                    CameraController.Singleton.CenterCameraOnPlayer();
                }
            }

            if (this.StaminaPoints <= 0)
            {
                this.HealthPoints -= 1;
            }
            else
            {
                this.StaminaPoints -= 1;
            }


        }

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        protected override void OnDeath()
        {
            Debug.Log("Oh no, I'm dead!");
        }



        public override bool HasKey() => Inventory.IsKeyPresent();

        public override void HandleItem(ItemActor itemActor)
        {
            DisplayPickUpInfo(itemActor.Item.DefaultName);
            _currentItemActor = itemActor;
        }

        public void Use(Item item)
        {
            Inventory.Use(this, item);
        }

        public void DeleteFromInventory(Item item)
        {
            Inventory.Delete(item);
        }

        public void DropItemFromInventory(Item item)
        {
            Inventory.TryDrop(this, item);
        }

        // item pick up
        void PickUpItem(ItemActor itemActor)
        {

            itemActor.HandlePickUp(this);
            Inventory.Add(itemActor.Item);
            // Inventory.Use(this, itemActor.Item); // TODO can use this to debug equipment and inventory
            ActorManager.Singleton.DestroyActor(itemActor);
        }
        void ClearCurrentItemActor()
        {
            _currentItemActor = null;
        }

        void DisplayPickUpInfo(string itemName)
        {
            UserInterface.Singleton.SetText($"Press 'E' to pick up {itemName}", UserInterface.TextPosition.BottomRight);
        }

        void HidePickUpInfo()
        {
            UserInterface.Singleton.SetText("", UserInterface.TextPosition.BottomRight);
        }

        void GoToNextMap()
        {
            if (this.WentToNextMap == true)
            {
                this.WentToNextMap = false;
                int nextWorldNumber = CurrentWorldNumber + 1;

                // PASSING PLAYER DATA THROUGH WORLDS
                //

                Inventory inventory = ActorManager.Singleton.Player.Inventory;

                MapLoader.LoadMap(nextWorldNumber);

                ActorManager.Singleton.Player.CurrentWorldNumber += 1;
                ActorManager.Singleton.Player.Inventory = inventory;
                //
                // 


            }
        }

        public override void IsNextMap()
        {
            this.WentToNextMap = true;
        }

        public Dictionary<ItemType, List<Item>>.ValueCollection GetItemsInInventory()
        {
            return Inventory.Items.Values;
        }
    }
}
