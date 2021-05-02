using DungeonCrawl.Actors.Items.Weapons;

namespace Source.Actors.Items.Wands
{
    public class ArchmagesWandOfWisdom : Wand
    {
        public override int DefaultSpriteId => 271;
        public override string DefaultName => "Archmage's Wand of Wisdom";
        public override int Inteligence => 10;
        public override int MaxDurability => 15;
        public override int CurrentDurability => 15;
    }
}