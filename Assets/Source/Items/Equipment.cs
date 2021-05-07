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

        public void EquipOrTakeOffItem(Player player, Item item) // TODO how to use whitespace inside this function to make it most readable?
        {

            ref var slot = ref GetEmptyOrFirstSlot(item.ItemType);
            slot = OverwriteIfAlreadyEquipped(ref slot, item);

            if (IsEmpty(slot))
            {
                slot = item;
                slot.ActionOnUse(player);
            }
            else
            {
                slot.ActionOnUse(player);
                if (ReferenceEquals(slot, item))
                    slot = null;
                else
                {
                    slot = item;
                    slot.ActionOnUse(player);
                }
            }
        }

        private ref Item OverwriteIfAlreadyEquipped(ref Item slot, Item item)
        {
            var array = _items[item.ItemType];

            if (array.ToList().Contains(item))
                return ref array[Array.IndexOf(array, item)];
            return ref slot;
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

        bool IsEmpty(Item item) => (item is null);

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
