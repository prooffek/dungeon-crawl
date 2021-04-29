using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        /// 
        /// <summary>
        /// Player's stats properties section
        /// </summary>
        ///
        public string characterName { get; private set; }

        public int characterLevel { get; private set; }

        public int AttackPoints { get; private set; }

        public int HealthPoints { get; private set; }

        public int ManaPoints { get; private set; }

        public int DeffencePoints { get; private set; }

        public int StaminaPoints { get; private set; }

        public int ExperiencePoints { get; private set; }

        public void ApplyDamage(int damage)
        {
            HealthPoints -= damage;

            if (HealthPoints <= 0)
            {
                // Die
                OnDeath();

                ActorManager.Singleton.DestroyActor(this);
            }
        }

        protected abstract void OnDeath();

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;
    }
}
