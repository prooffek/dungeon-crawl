using DungeonCrawl.Actors.Characters;
using static DungeonCrawl.Utilities;

namespace Assets.Source.Items.ItemClasses
{
    public class Mushroom : Food
    {
        private bool _randomBoolian = GetRandomBoolean();
        public int NutritiousPoints { get; }
        public int Inteligence { get; }

        public Mushroom() : base(FoodEnum.mushroom.ToString())
        {
            NutritiousPoints = _randomBoolian ? 7 : -5;
            Inteligence = _randomBoolian ? 3 : -2;
        }

        private readonly bool _randomBoolean = GetRandomBoolean();

        public override void ActionOnUse(Player player)
        {
            player.StaminaPoints += NutritiousPoints;
            player.IntelligencePoints += Inteligence;
        }
    }
}