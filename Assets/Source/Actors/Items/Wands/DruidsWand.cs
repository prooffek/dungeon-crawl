using DungeonCrawl.Actors.Items.Weapons;

namespace Source.Actors.Items.Wands
{
    public class DruidsWand : Wand
    {
        public override int DefaultSpriteId => 226;
        public override string DefaultName => "Druid's Wand";
        public override int Inteligence => 4;
        public override int MaxDurability => 30;
        public override int CurrentDurability => 30;
    }
}