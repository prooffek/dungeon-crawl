using Assets.Source.Items;

namespace Assets.Source.Items.Armours
{
    public class KingsArmourOfJustice : Armour
    {
        public override int DefaultSpriteId => 91;
        public override string DefaultName => "King's Armour of Justice";
        public override  int DefencePoints => 5;
        public override int MaxDurability => 27;
        public override int CurrentDurability => 27;
    }
}