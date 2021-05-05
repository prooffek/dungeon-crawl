using DungeonCrawl.Actors.Characters;
using static DungeonCrawl.Utilities;

namespace Assets.Source.Items.Foods
{
    public class Fish : Food
    {
        private bool randomBoolian = GetRandomBoolean();
        public override int DefaultSpriteId => 800;
        public override string DefaultName => "Fish";
        public override  int NutritiousPoints => randomBoolian ? 15 : -5;
        public override int MaxDurability => 1;
        public override int CurrentDurability => 1;
        
        
        public override void ActionOnUse(Player player)
        {
            player.StaminaPoints += this.NutritiousPoints;
        }
    }
}