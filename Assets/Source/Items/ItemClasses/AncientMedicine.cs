using Assets.Source.Items;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Items.Books
{
    public class AncientMedicine : Book
    {
        private int bonusPoints = 5;

        public AncientMedicine() : base(BooksEnum.AncientMedicine.ToString())
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