using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Source.Actors;
using Assets.Source.Core;
using Assets.Source.Items;
using DungeonCrawl.Actors;
using DungeonCrawl.Core;
using UnityEngine;

namespace Source.Actors.Inventory
{
    public static class DisplayInventory
    {
        private static List<Actor> _itemsList = new List<Actor>();
        private static List<(int x, int y)> _positionsList = new List<(int x, int y)>();
        private static Dictionary<Item, int> _itemsInInventoryCounter = new Dictionary<Item, int>();
        private static int _selectedField = 0;

        public static void InventoryDesplayManagement(bool isInventoryOpen)
        {
            HideInventory();
            if (isInventoryOpen)
                ShowInventory();
            else
                _selectedField = 0;
        }

        public static void ShowInventory()
        {
            GetPositionsList();
            GenerateItemsDict();
            CreateInventoryFields();
            CreateInventoryItems();
            MarkSelectedField();
            DescribeSelectedItem();
        }

        public static void HideInventory()
        {
            RemoveItemsFromInventory();
            _itemsList.Clear();
            _positionsList.Clear();
            _itemsInInventoryCounter.Clear();
            
        }

        private static void RemoveItemsFromInventory()
        {
            foreach (Actor item in _itemsList.ToArray())
            {
                ActorManager.Singleton.DestroyActor(item);
            }
        }

        private static void CreateInventoryFields()
        {
            foreach (var position in _positionsList)
            {
                SpawnInventory<InventoryBackground>(position);
                SpawnInventory<InventoryFrame>(position);
            }
        }

        private static void MarkSelectedField()
        {
            SpawnInventory<SelectedInventoryField>(_positionsList[_selectedField]);
        }

        private static void DescribeSelectedItem()
        {
            if (_itemsInInventoryCounter.Count > _selectedField )
            {
                Item selectedItem = _itemsInInventoryCounter.ElementAt(_selectedField).Key;
                string text = $"{selectedItem.DefaultName} x {_itemsInInventoryCounter[selectedItem]}";
                UserInterface.Singleton.SetText(text, UserInterface.TextPosition.BottomRight);
            }
        }

        private static void CreateInventoryItems()
        {
            int counter = 0;
            foreach (var dictEntry in _itemsInInventoryCounter)
            {
                (int x, int y) position = _positionsList[counter];
                SpawnInventory<ItemActor>(position, dictEntry.Key);
                counter++;
            }
        }

        private static void GenerateItemsDict()
        {
            foreach (var itemsList in ActorManager.Singleton.Player.GetItemsInInventory())
            {
                foreach (var item in itemsList)
                {
                    AddToInventoryDict(item);
                }
            }
        }

        private static void AddToInventoryDict(Item item)
        {
            if (_itemsInInventoryCounter.Keys.Contains(item))
            {
                _itemsInInventoryCounter[item]++;
            }
            _itemsInInventoryCounter[item] = 1;
        }
        
        private static void GetPositionsList()
        {
            for (int i = 7; i > -23; i -= 3)
            {
                int x = ActorManager.Singleton.Player.Position.x - i;
                int y = ActorManager.Singleton.Player.Position.y - 7;
                _positionsList.Add((x, y));
            }
        }
        
        private static void SpawnInventory<T>((int x, int y) position, Item item = null, string actorName = null) where T : Actor
        {
            var go = new GameObject();
            go.AddComponent<SpriteRenderer>();

            var component = go.AddComponent<T>();

            go.name = component.DefaultName;
            component.Position = position;
            
            component.ManageItemsToSpawn(component, item, position, go);

            _itemsList.Add(component);
        }

        public static void MoveThroughInventory()
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                // Move left
                _selectedField--;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                // Move right
                _selectedField++;
            }
            
            _selectedField = _selectedField >= 0 ? _selectedField % 10 : 9;
        }
        
    }
}