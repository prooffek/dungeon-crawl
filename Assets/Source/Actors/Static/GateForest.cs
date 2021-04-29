namespace DungeonCrawl.Actors.Static
{
    public class GateForest : Actor
    {
        public override int DefaultSpriteId => 919;
        public override string DefaultName => "GateForest";

        public override bool OnCollision(Actor anotherActor)
        {
            // All actors are passable by default
            return true;
        }

    }

}
