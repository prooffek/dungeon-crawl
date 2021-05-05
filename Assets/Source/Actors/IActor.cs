namespace DungeonCrawl.Actors
{
    public interface IActor
    {
        string DefaultName { get; }
        int DefaultSpriteId { get; }
        bool Detectable { get; }
        int Z { get; }

        bool OnCollision(Actor anotherActor);
    }
}