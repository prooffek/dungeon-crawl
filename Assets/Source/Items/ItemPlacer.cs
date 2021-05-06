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
        

        /*
        private static Item ChooseBookForLevel(int level)
        {
            switch (level)
            {
                case 2:
                    return new PeasantsAndMasters();
                case 3:
                    return new KnightsTraining();
                case 4:
                    return new AncientMedicine();
                default:
                    return new PoemOfTheFeudalism();
            }
        }
        */

        //    //place fish
        //    for (int i = 0; i < fish; i++)
        //    {
        //        ActorManager.Singleton.Spawn<Meat>(GetRandomPosition());
        //    }

        //    //place meat
        //    for (int i = 0; i < meat; i++)
        //    {
        //        ActorManager.Singleton.Spawn<Fish>(GetRandomPosition());
        //    }

        //    //place mushrooms
        //    for (int i = 0; i < mushrooms; i++)
        //    {
        //        ActorManager.Singleton.Spawn<Mushroom>(GetRandomPosition());
        //    }
        //}

        //public static void PlaceRequiredItems(int level)
        //{
        //    switch (level)
        //    {
        //        case 1:
        //            ActorManager.Singleton.Spawn<BasicArmour>(GetRandomPosition());
        //            ActorManager.Singleton.Spawn<SoldiersSword>(GetRandomPosition());
        //            ActorManager.Singleton.Spawn<AdeptsWand>(GetRandomPosition());
        //            ActorManager.Singleton.Spawn<PoemOfTheFeudalism>(GetRandomPosition());
        //            break;
        //        case 2:
        //            ActorManager.Singleton.Spawn<KnightArmour>(GetRandomPosition());
        //            ActorManager.Singleton.Spawn<KnightSword>(GetRandomPosition());
        //            ActorManager.Singleton.Spawn<DruidsWand>(GetRandomPosition());
        //            ActorManager.Singleton.Spawn<PeasantsAndMasters>(GetRandomPosition());
        //            break;
        //        case 3:
        //            ActorManager.Singleton.Spawn<KingsArmourOfJustice>(GetRandomPosition());
        //            ActorManager.Singleton.Spawn<KingsSwordOfPower>(GetRandomPosition());
        //            ActorManager.Singleton.Spawn<ArchmagesWandOfWisdom>(GetRandomPosition());
        //            ActorManager.Singleton.Spawn<AncientMedicine>(GetRandomPosition());
        //            break;
        //    }
        //}

        //public static void ItemsPlacesIfPlayerIsLucky(int level)
        //{
        //    switch (level)
        //    {
        //        case 1:
        //            RandomItemsLvl1();
        //            break;
        //        case 2:
        //            RandomItemsLvl2();
        //            break;
        //        case 3:
        //            RandomItemsLvl3();
        //            break;
        //        case 4:
        //            RandomItemsLvl4();
        //            break;
        //    }

        //}

        //private static void RandomItemsLvl1()
        //{
        //    if (GetRandomBoolean())ActorManager.Singleton.Spawn<KnightArmour>(GetRandomPosition());
        //    if (GetRandomBoolean()) ActorManager.Singleton.Spawn<KnightSword>(GetRandomPosition());
        //    if (GetRandomBoolean()) ActorManager.Singleton.Spawn<DruidsWand>(GetRandomPosition());
        //    if (GetRandomBoolean()) ActorManager.Singleton.Spawn<PeasantsAndMasters>(GetRandomPosition());
        //}

        //private static void RandomItemsLvl2()
        //{
        //    if (!GetRandomBoolean())
        //        ActorManager.Singleton.Spawn<BasicArmour>(GetRandomPosition());
        //    else
        //        ActorManager.Singleton.Spawn<KingsArmourOfJustice>(GetRandomPosition());

        //    if (!GetRandomBoolean())
        //        ActorManager.Singleton.Spawn<SoldiersSword>(GetRandomPosition());
        //    else
        //        ActorManager.Singleton.Spawn<KingsSwordOfPower>(GetRandomPosition());

        //    if (!GetRandomBoolean())
        //        ActorManager.Singleton.Spawn<AdeptsWand>(GetRandomPosition());
        //    else
        //        ActorManager.Singleton.Spawn<ArchmagesWandOfWisdom>(GetRandomPosition());

        //    if (!GetRandomBoolean())
        //        ActorManager.Singleton.Spawn<PoemOfTheFeudalism>(GetRandomPosition());
        //    else
        //        ActorManager.Singleton.Spawn<AncientMedicine>(GetRandomPosition());
        //}

        //private static void RandomItemsLvl3()
        //{
        //    if (!GetRandomBoolean())
        //        ActorManager.Singleton.Spawn<BasicArmour>(GetRandomPosition());
        //    else
        //        ActorManager.Singleton.Spawn<EthernalArmourOfProtection>(GetRandomPosition());

        //    if (!GetRandomBoolean())
        //        ActorManager.Singleton.Spawn<KnightSword>(GetRandomPosition());
        //    else
        //        ActorManager.Singleton.Spawn<EthernalSwordOfDestruction>(GetRandomPosition());

        //    if (!GetRandomBoolean())
        //        ActorManager.Singleton.Spawn<DruidsWand>(GetRandomPosition());
        //    else
        //        ActorManager.Singleton.Spawn<GreatWandOfAnnihilation>(GetRandomPosition());

        //    if (GetRandomBoolean()) ActorManager.Singleton.Spawn<SailorMoonWand>(GetRandomPosition());

        //    if (!GetRandomBoolean())
        //        ActorManager.Singleton.Spawn<PoemOfTheFeudalism>(GetRandomPosition());
        //    else
        //        ActorManager.Singleton.Spawn<KnightsTraining>(GetRandomPosition());
        //}

        //private static void RandomItemsLvl4()
        //{
        //    if (GetRandomBoolean()) ActorManager.Singleton.Spawn<EthernalArmourOfProtection>(GetRandomPosition());
        //    if (GetRandomBoolean()) ActorManager.Singleton.Spawn<EthernalSwordOfDestruction>(GetRandomPosition());
        //    if (GetRandomBoolean()) ActorManager.Singleton.Spawn<GreatWandOfAnnihilation>(GetRandomPosition());
        //    if (GetRandomBoolean()) ActorManager.Singleton.Spawn<SailorMoonWand>(GetRandomPosition());
        //    if (GetRandomBoolean()) ActorManager.Singleton.Spawn<KnightsTraining>(GetRandomPosition());
        //}

        private static (int x, int y) GetRandomPosition()
        {
            List<(int, int)> emptyFields = ActorManager.Singleton.GetEmptyBoardFields();
            int randomIndex = new System.Random().Next(emptyFields.Count);
            (int, int) position = emptyFields[randomIndex];
            return position;
        }
    }
}