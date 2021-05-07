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
            MarkSelected();
            CreateInventoryItems();
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
                SpawnInventory<InventoryFrame>(position);
                SpawnInventory<InventoryBackground>(position);
            }
        }

        private static void MarkSelected()
        {
            SpawnInventory<SelectedInventoryField>(_positionsList[_selectedField]);
            
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

        private static bool AddToInventoryDict(Item item)
        {
            if (_itemsInInventoryCounter.Keys.Contains(item))
            {
                _itemsInInventoryCounter[item]++;
                return true;
            }
            _itemsInInventoryCounter[item] = 1;
            return false;
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
            
            ManageItemsToSpawn(component, item, position, go);

            _itemsList.Add(component);
        }

        private static void ManageItemsToSpawn(Actor component, Item item, (int x, int y) position, GameObject go)
        {
            if (component is ItemActor itemActor) // && item != null)
            {
                itemActor.Item = item;
                itemActor.SetSprite(itemActor.Item.DefaultSpriteId);
                itemActor.transform.localPosition = new Vector3(position.x, position.y, -2.5f);
                go.transform.localScale = new Vector3(2f, 2f, 0f);
            }
            else if (component is InventoryBackground actor)
            {
                go.transform.localScale = actor.vector;
                go.transform.localPosition = new Vector3(position.x, position.y, -1.9f);
            }
            else if (component is InventoryFrame field)
                go.transform.localScale = field.vector;
            else if (component is SelectedInventoryField selectedField)
                go.transform.localScale = selectedField.vector;
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