using System;
using System.Collections.Generic;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Items
{
    public abstract class Item : Actor
    {
        public abstract int MaxDurability { get; }
        public abstract int CurrentDurability { get; set; }
        
        
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player player) this.ActionOnUse(player);
            return true;
        }

        
        public void DecreaseItemDurability()
        {
            CurrentDurability -= 1;
        }
        
        
        public virtual void DestroyIffJunk(Player player)
        {
            if (CurrentDurability <= 0)
            {
                ActorManager am = new ActorManager();
                am.DestroyActor(this);
            }
        }

        //Create a deep copy of the item with difference references
        
 

        //Try taking action specific for the item (add health, deal damage, etc.)
        public abstract void ActionOnUse(Player player);
    }
}