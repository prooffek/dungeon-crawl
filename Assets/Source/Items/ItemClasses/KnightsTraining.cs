using Assets.Source.Items;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Items.ItemClasses
{
    public class KnightsTraining : Book
    {
        private readonly int bonusPoints = 5;
        
        public KnightsTraining() : base(BooksEnum.KnightsTraining)
        {
        }
        
        public override void ActionOnUse(Player player)
        {
            player.IntelligencePoints += InteligencePoints;
            player.StaminaPoints += bonusPoints;
            DecreaseItemDurability();
        }
    }
}