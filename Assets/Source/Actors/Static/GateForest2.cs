namespace DungeonCrawl.Actors.Static
{
    public class GateForest2 : Actor
    {
        public override int DefaultSpriteId => 917;
        public override string DefaultName => "GateForest2";

        public override bool OnCollision(Actor anotherActor)
        {
            // All actors are passable by default
            return true;
        }

    }

}
