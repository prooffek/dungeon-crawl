using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Gate : Actor
    {
        public override int DefaultSpriteId => 919;
        public override string DefaultName => "Gate";

        public override bool OnCollision(Actor anotherActor)
        {
            bool isKeyPresent;          
            isKeyPresent = anotherActor.HasKey();
            
            if (isKeyPresent) anotherActor.IsNextMap();

            anotherActor.KeyNeededInfo();
            return isKeyPresent;
        }

        

        
    }

}
