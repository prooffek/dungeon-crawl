
namespace Assets.Source.Items.Swords
{
    public class SoldiersSword : Sword
    {
        public override int DefaultSpriteId => 320;
        public override string DefaultName => "Soldier's Sword";
        public override int MaxDurability => 50;
        public override int CurrentDurability => 50;
        public override int DamagePoints => 1;
    }
}