using Assets.Source.Core;
using UnityEngine;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     Loads the initial map and can be used for keeping some important game variables
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            MapLoader.LoadMap(0);          
        }

        //public void LoadNextMap(int id)
        //{
        //    MapLoader.LoadMap(id);
        //}

        /// to ciekawe:

        //public void OnLevelWasLoaded(int level)
        //{
            
        //}


        //private void Update()
        //{
        //    GameObject player = GameObject.Find("Player");

        //}

    }
}
