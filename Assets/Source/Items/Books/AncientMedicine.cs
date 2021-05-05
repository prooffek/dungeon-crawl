using Assets.Source.Items;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Items.Books
{
    public class AncientMedicine : Book
    {
        public override int DefaultSpriteId => 752;
        public override string DefaultName => "King's Armour of Justice";
        public int Inteligence => 2;
        public override int MaxDurability => 27;
        public override int CurrentDurability => 27;


        public override void ActionOnUse(Player player)
        {
            player.Inteligence += InteligencePoints;
            player.HealthPoints += 5;
            DecreaseItemDurability();
            //DestroyIffJunk(player);
        }
    }
}