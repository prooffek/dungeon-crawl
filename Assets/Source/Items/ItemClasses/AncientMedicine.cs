using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Items.ItemClasses
{
    public class AncientMedicine : Book
    {
        private int bonusPoints = 5;

        public AncientMedicine() : base("medicine")
        {
        }
        
        public override void ActionOnUse(Player player)
        {
            player.IntelligencePoints += InteligencePoints;
            player.HealthPoints += bonusPoints;
            DecreaseItemDurability();
        }
    }
}