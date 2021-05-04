using UnityEngine;

namespace DungeonCrawl.Actors.Items.Foods
{
    public class Apple : Food
    {
        public override int DefaultSpriteId => 896;
        public override string DefaultName => "Apple";
        public override int NutritiousPoints => 5;
        public override int MaxDurability => 1;
        public override int CurrentDurability => 1;
    }
}