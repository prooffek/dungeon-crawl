namespace Assets.Source.Items.Foods
{
    public class Meat : Food
    {
        public override int DefaultSpriteId => 848;
        public override string DefaultName => "Meat";
        public override int NutritiousPoints => 1;
        public override int MaxDurability => 1;
        public override int CurrentDurability => 1;
    }
}