using Assets.Source.Items;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Items.Books
{
    public class KnightsTraining : Book
    {
        private int bonusPoints = 5;
        
        public KnightsTraining() : base("knight")
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