using System.Collections.Generic;
using Assets.Source.Actors;
using Assets.Source.Items.Armours;
using Assets.Source.Items.Books;
using Assets.Source.Items.Foods;
using Assets.Source.Items.Swords;
using Assets.Source.Items.Wands;
using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;
using Random = System.Random;

namespace Assets.Source.Items
{
    public static class ItemPlacer
    {
        static List<Item> _items = new List<Item>();
        private static Random random = new Random();
        
        public static void ManagePlacingItemsOnMap()
        {
            PopulateItemsList();
            PlaceItemsOnMap();
        }
        
        private static void PlaceItemsOnMap()
        {
            foreach (Item item in _items)
            {
                ItemActor actor = ActorManager.Singleton.Spawn<ItemActor>(GetRandomPosition());
                actor.Item = item;
                actor.SetSprite(actor.Item.DefaultSpriteId);
            }
        }
        
        private static void PopulateItemsList()
        {

            foreach (List<Item> itemsList in new ItemsList().ListOfItemsList)
            {
                int counter = SetCounter(itemsList[0]);
                AddRandomItemToList(counter, itemsList);
            }
        }

        private static int SetCounter(Item item)
        {
            switch (item.ItemType)
            {
                case ItemType.Weapon:
                    return 2;
                case ItemType.Armour:
                    return 2;
                case ItemType.Consumable:
                    if (item is Food) return 20;
                    return 3;
                default:
                    return 10;
            }
        }
        
        private static void AddRandomItemToList(int counter, List<Item> itemsList)
        {
            bool playerIsLucky;
            int i = 0;
            
            do
            {
                
                Item item = ChooseRandomItem(itemsList);
                _items.Add(item);
                i++;
                playerIsLucky = GetRandomBoolean();
                
            } while (playerIsLucky || i < counter);
        }
        
        private static Item ChooseRandomItem(List<Item> itemsList)
        {
            int randomIndex = random.Next(itemsList.Count);
            return itemsList[randomIndex];
        }

        private static (int x, int y) GetRandomPosition()
        {
            List<(int, int)> emptyFields = ActorManager.Singleton.GetEmptyBoardFields();
            int randomIndex = new System.Random().Next(emptyFields.Count);
            (int, int) position = emptyFields[randomIndex];
            return position;
        }
    }
}