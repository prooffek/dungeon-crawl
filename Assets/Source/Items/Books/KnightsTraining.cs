using Assets.Source.Items;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Items.Books
{
    public class KnightsTraining : Book
    {
        public override int DefaultSpriteId => 753;
        public override string DefaultName => "King's Armour of Justice";
        public int Inteligence => 2;
        public override int MaxDurability => 27;
        public override int CurrentDurability => 27;
        
        
        public override void ActionOnUse(Player player)
        {
            player.IntelligencePoints += InteligencePoints;
            player.StaminaPoints += 5;
            DecreaseItemDurability();
            //DestroyIffJunk(player);
        }
    }
}