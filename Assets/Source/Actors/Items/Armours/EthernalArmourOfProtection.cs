using DungeonCrawl.Actors.Items.Armours;

namespace Source.Actors.Items.Armours
{
    public class EthernalArmourOfProtection : Armour
    {
        public override int DefaultSpriteId => 83;
        public override string DefaultName => "Ethernal Armour of Protection";
        public override int DefencePoints => 10;
        public override int MaxDurability => 30;
        public override int CurrentDurability => 30;
    }
}