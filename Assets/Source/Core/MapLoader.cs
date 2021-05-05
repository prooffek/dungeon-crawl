using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;
using DungeonCrawl.Actors;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using Assets.Source.Core;
using Assets.Source.Items.Swords;
using Assets.Source.Items;
using Assets.Source.Actors;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     MapLoader is used for constructing maps from txt files
    /// </summary>
    public static class MapLoader
    {
        /// <summary>
        ///     Constructs map from txt file and spawns actors at appropriate positions
        /// </summary>
        /// <param name="id"></param>
        public static void LoadMap(int id)
        {
            var lines = Regex.Split(Resources.Load<TextAsset>($"map_{id}").text, "\r\n|\r|\n");

            // Read map size from the first line
            var split = lines[0].Split(' ');
            var width = int.Parse(split[0]);
            var height = int.Parse(split[1]);

            // Create actors
            for (var y = 0; y < height; y++)
            {
                var line = lines[y + 1];
                for (var x = 0; x < width; x++)
                {
                    var character = line[x];

                    SpawnActor(character, (x, -y));
                }
            }
            
            SpawnItems(1);

            // Set default camera size and position

            CameraController.Singleton.Size = 12;
            CameraController.Singleton.Position = (width / 2, -height / 2);



            //may be useful to add initial stats right here
            ///
            //GameObject player = GameObject.Find("Player");



        }

        private static void SpawnActor(char c, (int x, int y) position)
        {
            switch (c)
            {
                case '#':
                    ActorManager.Singleton.Spawn<Wall>(position);
                    break;
                case '.':
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'p':
                    ActorManager.Singleton.Spawn<Player>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 's':
                    ActorManager.Singleton.Spawn<Skeleton>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 't':
                    ActorManager.Singleton.Spawn<Tree1>(position);
                    break;
                case 'y':
                    ActorManager.Singleton.Spawn<Tree2>(position);
                    break;
                case 'r':
                    ActorManager.Singleton.Spawn<River>(position);
                    break;
                case 'g':
                    ActorManager.Singleton.Spawn<Gate>(position);
                    break;
                case 'h':
                    ActorManager.Singleton.Spawn<GateBorder>(position);
                    break;
                case ' ':
                    break;
                case 'k':
                    ActorManager.Singleton.Spawn<Floor>(position);

                    ItemActor keyActor = ActorManager.Singleton.Spawn<ItemActor>(position);
                    keyActor.Item = new Key();
                    keyActor.SetSprite(keyActor.Item.DefaultSpriteId);                  
                    break;              
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void SpawnItems(int level = 1)
        {
            ItemPlacer.PlaceFoodOnMap();
            //ActorManager.Singleton.Spawn<SoldiersSword>(2, -2);
            //PlaceRequiredItems(level);
            //ItemsPlacesIfPlayerIsLucky(level);
        }
    }
}
