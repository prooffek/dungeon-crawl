using DungeonCrawl.Actors.Characters;
using System;
using System.Collections.Generic;
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

        public void EquipItem(Player player, Item item) // TODO how to use whitespace inside this function to make it most readable?
        {
            ref var slot = ref GetEmptyOrFirstSlot(item.ItemType);

            if (IsNotEmpty(slot)) slot.ActionOnUse(player);
            slot = item;
            slot.ActionOnUse(player);
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
