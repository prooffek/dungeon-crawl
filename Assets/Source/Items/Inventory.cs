using Assets.Source.Actors;
using DungeonCrawl;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Items
{
    [Serializable] // TODO Serialize _items and _equipment
    public class Inventory
    {
        Dictionary<ItemType, List<Item>> _items;
        Equipment _equipment;

        public Inventory()
        {
            ConfigureInventory();
        }

        public void Add(Item item)
        {
            _items[item.ItemType].Add(item);
        }

        /// <summary>
        /// Equips and uses the item if it's equippable, otherwise just uses it
        /// </summary>
        /// <param name="player"></param>
        /// <param name="item"></param>
        public void Use(Player player, Item item)
        {
            if (item.IsEquippable)
            {
                _equipment.EquipItem(player, item);
            }
            else
            {
                item.ActionOnUse(player);
            }
        }

        /// <summary>
        /// Returns true if there is free space at player's position and drops the item if so
        /// </summary>
        /// <param name="player"></param>
        /// <param name="item">Item to drop</param>
        /// <returns></returns>
        public bool TryDrop(Player player, Item item)
        {
            var playerPosition = player.Position;
            var itemAtPlayerPosition = ActorManager.Singleton.GetActorAt<ItemActor>(playerPosition);

            if (itemAtPlayerPosition is null) return Drop(item, playerPosition);

            return false;
        }

        /// <summary>
        /// Removes the item from inventory
        /// </summary>
        /// <param name="item"></param>
        public void Delete(Item item)
        {
            _items[item.ItemType].Remove(item);
        }
        public bool IsKeyPresent()
        {
            foreach (Item item in _items[ItemType.Miscellaneous])
            {
                if (item.DefaultName.StartsWith("Key")) return true;
            }
            return false;
        }

        bool Drop(Item item, (int x, int y) playerPosition)
        {
            Delete(item);
            ItemActor itemActor = ActorManager.Singleton.Spawn<ItemActor>(playerPosition, item.DefaultName); // TODO refactor this to Spawn overload
            itemActor.Item = item;
            itemActor.SetSprite(item.DefaultSpriteId);
            return true;
        }

        /// <summary>
        /// Initializes data structures needed for this class to work
        /// </summary>
        void ConfigureInventory()
        {
            _items = new Dictionary<ItemType, List<Item>>();
            _equipment = new Equipment();
            var itemTypes = Utilities.GetEnumMembers<ItemType>();

            foreach (ItemType type in itemTypes)
            {
                _items.Add(type, new List<Item>());
            }

            _equipment.Configure(itemTypes);
        }

        public Dictionary<ItemType, List<Item>> GetInventoryDict()
        {
            return _items;
        }
    }
}
