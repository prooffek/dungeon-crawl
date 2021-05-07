using DungeonCrawl.Actors.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Items
{
    public class Equipment
    {
        readonly Dictionary<ItemType, Item[]> _items = new Dictionary<ItemType, Item[]>();

        public Item[] this[ItemType type]
        {
            get
            {
                try
                {
                    return _items[type];
                }
                catch (KeyNotFoundException e)
                {
                    Debug.LogError(e);
                    return null;
                }
            }
        }

        /// <summary>
        /// Here you can configure maximum amount of equippable items by type
        /// </summary>
        /// <param name="itemTypeValues"></param>
        public void Configure(IEnumerable<ItemType> itemTypeValues)
        {
            int maxArmours = 1;
            int maxWeapons = 2;
            foreach (int value in itemTypeValues)
            {
                var enumValue = (ItemType)value;

                switch (enumValue)
                {
                    case ItemType.Armour:
                        _items.Add(enumValue, new Item[maxArmours]);
                        break;
                    case ItemType.Weapon:
                        _items.Add(enumValue, new Item[maxWeapons]);
                        break;
                    default:
                        break;
                }
            }
        }

        public void EquipOrTakeOffItem(Player player, Item item) // TODO would you change whitespace or refactor this method?
        {
            ref var slot = ref GetEmptyOrFirstSlot(item.ItemType);

            if (AlreadyEquipped(item))
            {
                slot = ref GetEquippedItemSlot(item);
            }

            if (IsNotEmpty(slot))
            {
                slot.ActionOnUse(player);

                if (ReferenceEquals(slot, item))
                {
                    slot = null;
                }
                else
                {
                    slot = item;
                    slot.ActionOnUse(player);
                }
            }

            else
            {
                slot = item;
                slot.ActionOnUse(player);
            }
        }

        ref Item GetEquippedItemSlot(Item item)
        {
            Item[] items = _items[item.ItemType];
            return ref items[GetItemIndex(item)];
        }

        int GetItemIndex(Item item)
        {
            Item[] items = _items[item.ItemType];
            return Array.IndexOf(items, Array.Find(items, element => ReferenceEquals(element, item))); // TODO is this match necessary?
        }

        bool AlreadyEquipped(Item item)
        {
            return Array.Exists(_items[item.ItemType], element => ReferenceEquals(element, item));
        }


        bool IsNotEmpty(Item item) => !(item is null);

        ref Item GetEmptyOrFirstSlot(ItemType type)
        {
            Item[] itemSlots = _items[type];
            for (var i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i] is null)
                {
                    return ref itemSlots[i];
                }
            }

            return ref itemSlots[0];
        }
    }
}
