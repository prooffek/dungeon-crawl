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

        public Inventory()
        {
            foreach (int value in Enum.GetValues(typeof(ItemType)))
            {
                _items.Add((ItemType)value, new List<Item>());
            }
        }

        public void Add(Item item)
        {
            _items[item.ItemType].Add(item);
        }

        public void Equip(Player player, Item item)
        {
            item.ActionOnUse(player);
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
    }
}
