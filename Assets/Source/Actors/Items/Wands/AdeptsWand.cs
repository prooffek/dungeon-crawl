using DungeonCrawl.Actors.Items.Weapons;

namespace Source.Actors.Items.Wands
{
    public class AdeptsWand : Wand
    {
        public override int DefaultSpriteId => 233;
        public override string DefaultName => "Adept's Wand";
        public override int Inteligence => 1;
        public override int MaxDurability => 120;
        public override int CurrentDurability => 120;
    }
}