using DungeonCrawl.Actors.Characters;
using static DungeonCrawl.Utilities;

namespace Assets.Source.Items.ItemClasses
{
    public class Mushroom : Food
    {
        private readonly bool _randomBoolean = GetRandomBoolean();
        public int Inteligence { get; }

        public Mushroom() : base(FoodEnum.Mushroom)
        {
            NutritiousPoints = _randomBoolean ? 7 : -5;
            Inteligence = _randomBoolean ? 3 : -2;
        }

        public override void ActionOnUse(Player player)
        {
            player.StaminaPoints += NutritiousPoints;
            player.IntelligencePoints += Inteligence;
        }
    }
}