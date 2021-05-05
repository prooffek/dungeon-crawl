using Assets.Source.Items;

namespace Assets.Source.Items.Books
{
    public class PeasantsAndMasters : Book
    {
        public override int DefaultSpriteId => 751;
        public override string DefaultName => "Peasants and Masters";
        public int Inteligence => 2;
        public override int MaxDurability => 1;
        public override int CurrentDurability => 1;
    }
}