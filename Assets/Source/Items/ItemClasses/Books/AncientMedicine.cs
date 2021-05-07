using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Items.ItemClasses.Books
{
    public class AncientMedicine : Book
    {
        private readonly int bonusPoints = 5;

        public AncientMedicine() : base(BooksEnum.AncientMedicine)
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