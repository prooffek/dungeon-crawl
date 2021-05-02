using DungeonCrawl.Actors.Items.Armours;

namespace Source.Actors.Items.Armours
{
    public class KnightArmour : Armour
    {
        public override int DefaultSpriteId => 79;
        public override string DefaultName => "Knight Armour";
        public override int DefencePoints => 3;
        public override int MaxDurability => 23;
        public override int CurrentDurability => 23;
    }
}