using DungeonCrawl.Actors.Characters;
using static DungeonCrawl.Utilities;

namespace Assets.Source.Items.Foods
{
    public class Mushroom : Food
    {
        private bool randomBoolian = GetRandomBoolean();
        public int NutritiousPoints { get; }
        public int Inteligence { get; }

        public Mushroom() : base("mashroom")
        {
            NutritiousPoints = randomBoolian ? 7 : -5;
            Inteligence = randomBoolian ? 3 : -2;
        }

        public override void ActionOnUse(Player player)
        {
            player.StaminaPoints += NutritiousPoints;
            player.IntelligencePoints += Inteligence;
        }
    }
}