using Assets.Resources;
using Assets.Source.Core;
using UnityEngine;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     Loads the initial map and can be used for keeping some important game variables
    /// </summary>
    public class GameManager : MonoBehaviour
    {

        public static GameManager Singleton { get; private set; }

        private GameManager _gameManager;

        public int WorldNumber = 1;

        private void Awake()
        {
            if (Singleton != null)
            {
                Destroy(this);
                return;
            }

            Singleton = this;

            _gameManager = GetComponent<GameManager>();
        }

        private void Start()
        {
            MapLoader.LoadMap(WorldNumber);          
        }

        
        // TODO ASK ABOUT THESE USEFUL METHODS !

        //public void LoadNextMap(int id)
        //{
        //    MapLoader.LoadMap(id);
        //}

        /// to ciekawe:
        //public void OnLevelWasLoaded(int level)
        //{          
        //}

    }
}
