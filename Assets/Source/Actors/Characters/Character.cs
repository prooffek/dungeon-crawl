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

        public int AttackPoints { get; set; }

        public int HealthPoints { get; set; }
        public int Inteligence { get; set; }

        public int ManaPoints { get; set; }

        public int DeffencePoints { get; set; }

        public int StaminaPoints { get; set; }

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
