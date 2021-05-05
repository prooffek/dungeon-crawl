using Assets.Source.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Items
{
    [System.Serializable]
    public class Inventory
    {
        Dictionary<ItemType, List<Item>> _items = new Dictionary<ItemType, List<Item>>();
        Dictionary<ItemType, Item[]> _equipment = new Dictionary<ItemType, Item[]>();

        public Inventory()
        {
            ConfigureInventory();
        }


        public void Add(Item item)
        {
            _items[item.ItemType].Add(item);
        }

        public void Use(Player player, Item item)
        {
            bool isEquipped = false;
            if (item.IsEquippable)
            {
                Item[] itemSlots = _equipment[item.ItemType];
                while (!isEquipped)
                {

                }
                for (var i = 0; i < itemSlots.Length; i++)
                {
                    if (itemSlots[i] is null)
                    {
                        itemSlots[i].ActionOnUse(player);
                        itemSlots[i] = item;
                        item.ActionOnUse(player);
                        isEquipped = true;
                        break;
                    }
                }
                if (!isEquipped)
                {
                    itemSlots[0].ActionOnUse(player);
                    itemSlots[0] = item;
                    item.ActionOnUse(player);
                }
            }
            else
            {
                item.ActionOnUse(player);
            }
        }

        /// <summary>
        /// Returns true if there is free space at player's position
        /// </summary>
        /// <param name="player"></param>
        /// <param name="item">Item to drop</param>
        /// <returns></returns>
        public bool TryDrop(Player player, Item item)
        {
            var playerPosition = player.Position;
            var itemAtPlayerPosition = ActorManager.Singleton.GetActorAt<ItemActor>(playerPosition);

            if (itemAtPlayerPosition is null)
            {
                Delete(item);
                ItemActor itemActor = ActorManager.Singleton.Spawn<ItemActor>(playerPosition, item.DefaultName);
                itemActor.Item = item;
                itemActor.SetSprite(item.DefaultSpriteId);
                return true;
            }

            return false;
        }

        public void Delete(Item item)
        {
            _items[item.ItemType].Remove(item);
        }

        void ConfigureInventory()
        {
            Array itemTypeValues = Enum.GetValues(typeof(ItemType));
            foreach (int value in itemTypeValues)
            {
                _items.Add((ItemType)value, new List<Item>());
            }

            ConfigureEquipment(itemTypeValues);
        }

        /// <summary>
        /// Here you can configure maximum amount of equippable items by type
        /// </summary>
        /// <param name="itemTypeValues"></param>
        private void ConfigureEquipment(Array itemTypeValues)
        {
            foreach (int value in itemTypeValues)
            {
                var enumValue = (ItemType)value;

                switch (enumValue)
                {
                    case ItemType.Armour:
                        _equipment.Add(enumValue, new Item[1]);
                        break;
                    case ItemType.Weapon:
                        _equipment.Add(enumValue, new Item[2]);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
