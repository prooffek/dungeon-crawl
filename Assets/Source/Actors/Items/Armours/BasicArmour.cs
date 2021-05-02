using DungeonCrawl.Actors.Items.Armours;

namespace Source.Actors.Items.Armours
{
    public class BasicArmour : Armour
    {
        public override int DefaultSpriteId => 84;
        public override string DefaultName => "BasicArmour";
        public override int DefencePoints => 1;
        public override int MaxDurability => 20;
        public override int CurrentDurability => 20;
    }
}