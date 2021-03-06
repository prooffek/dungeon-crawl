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

        //public int CurrentWorldNumber { get; private set; } = 1;

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

            InventoryDisplayManagement(_isInventoryOpen);

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
                HideKeyNeededInfo();
                Position = targetPosition;
                DecreasePlayerStamina();
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
                    DecreasePlayerStamina();
                    CameraController.Singleton.CenterCameraOnPlayer();

                }
            }
        }

        private void DecreasePlayerStamina()
        {
            //Decrease stamina in every movement
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

        public override void HandleItemActor(ItemActor itemActor)
        {
            DisplayPickUpInfo(itemActor.DefaultName);
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
            bool canDrop = Inventory.TryDrop(this, item);
            if (!canDrop) DisplayCantDropItemInfo();
        }

        void PickUpItem(ItemActor itemActor)
        {

            itemActor.HandlePickUp(this);
            Inventory.Add(itemActor.Item);
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

        public override void KeyNeededInfo()
        {
            UserInterface.Singleton.SetText("You need a key \n in order to open this door!", UserInterface.TextPosition.TopLeft);
        }

        void HideKeyNeededInfo()
        {
            UserInterface.Singleton.SetText("", UserInterface.TextPosition.TopLeft);
        }

        void DisplayCantDropItemInfo()
        {
            UserInterface.Singleton.SetText("asdasdasdas", UserInterface.TextPosition.MiddleCenter);
            throw new KeyNotFoundException("use coroutine here");
        }



        void GoToNextMap()
        {
            if (this.WentToNextMap == true)
            {
                GameManager.Singleton.WorldNumber += 1;
                GameManager.Singleton.PlayerInventory = ActorManager.Singleton.Player.Inventory;
                this.WentToNextMap = false;

                // PASSING PLAYER DATA THROUGH WORLDS NEEDS
                // TO BE REFRACTOR TO BE KEPT IN
                // GAME MANAGER
                //

                HideKeyNeededInfo();
                
                MapLoader.LoadMap(GameManager.Singleton.WorldNumber);

                // PASSING PLAYERS INVENTORY TO NEW SPAWNED PLAYER
                ActorManager.Singleton.Player.Inventory = GameManager.Singleton.PlayerInventory;

                //PASSING PLAYERS STATS TO NEW SPAWNED PLAYER
                // to be implemented
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
