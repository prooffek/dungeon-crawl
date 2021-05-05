using DungeonCrawl.Actors.Characters;
using static DungeonCrawl.Utilities;

namespace Assets.Source.Items.Foods
{
    public class Mushroom : Food
    {
        private bool randomBoolian = GetRandomBoolean();
        public override int DefaultSpriteId => 973;
        public override string DefaultName => "Mushroom";
        public override int NutritiousPoints => randomBoolian ? 7 : -5;
        public override int MaxDurability => 1;
        public override int CurrentDurability => 1;
        public int Inteligence => randomBoolian ? 3 : -2;
        

        public override void ActionOnUse(Player player)
        {
            player.StaminaPoints += this.NutritiousPoints;
            player.IntelligencePoints += this.Inteligence;
        }
    }
}