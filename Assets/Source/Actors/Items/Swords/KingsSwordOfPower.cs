using DungeonCrawl.Actors.Items.Weapons;

namespace Source.Actors.Items.Swords
{
    public class KingsSwordOfPower : Sword
    {
        public override int DefaultSpriteId => 417;
        public override string DefaultName => "King's Sword of Power";
        public override int DamagePoints => 10;
        public override int MaxDurability => 15;
        public override int CurrentDurability => 15;
        
    }
}