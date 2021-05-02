using DungeonCrawl.Actors.Items.Weapons;

namespace Source.Actors.Items.Swords
{
    public class KnightSword : Sword
    {
        public override int DefaultSpriteId => 416;
        public override string DefaultName => "Knight Sword";
        public override int DamagePoints => 4;
        public override int MaxDurability => 30;
        public override int CurrentDurability => 30;
    }
}