using DungeonCrawl.Actors.Items.Books;

namespace Source.Actors.Items.Books
{
    public class PoemOfTheFeudalism : Book
    {
        public override int DefaultSpriteId => 751;
        public override string DefaultName => "Poem of the Feudalism";
        public int Inteligence => 1;
        public override int MaxDurability => 1;
        public override int CurrentDurability => 1;
    }
}