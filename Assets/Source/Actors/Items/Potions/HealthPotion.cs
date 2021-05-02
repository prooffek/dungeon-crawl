using DungeonCrawl.Actors.Items.Varia;

namespace Source.Actors.Items.Potions
{
    public class HealthPotion : Potion
    {
        public override int DefaultSpriteId => 655;
        public override string DefaultName => "Health Potion";
        public override int HealthPoints => 30;
        public override int MaxDurability => 1;
        public override int CurrentDurability => 1;
    }
}