using System;
using System.Collections.Generic;
using Assets.Source.Actors;
using Assets.Source.Items.Armours;
using DungeonCrawl.Core;

namespace Assets.Source.Items
{
    public static class ItemPlacer
    {
        static List<Item> _items = new List<Item>();

        static void PopulateItemsList_Test()
        {
            for (var i = 0; i < 10; i++)
            {
                _items.Add(new BasicArmour());
            }
        }
        public static void PlaceFoodOnMap()
        {
            //place something that you like for testing
            PopulateItemsList_Test();

            foreach (Item item in _items)
            {
                ItemActor actor = ActorManager.Singleton.Spawn<ItemActor>(GetRandomPosition());
                actor.Item = item;
                actor.SetSprite(actor.Item.DefaultSpriteId);
            }
        }

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