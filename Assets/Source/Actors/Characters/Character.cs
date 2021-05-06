using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        /// 
        /// <summary>
        /// Player's stats properties section
        /// </summary>
        ///
        public string CharacterName { get; private set; } = "BaRbarA wojowniczka";

        public int CharacterLevel { get; private set; }
        [SerializeField]
        int _attackPoints = 10;
        public int AttackPoints
        {
            get
            {
                return _attackPoints;
            }
            set
            {
                _attackPoints = value;
            }
        }
        [SerializeField]
        int _healthPoints = 100;
        public int HealthPoints
        {
            get
            {
                return _healthPoints;
            }
            set
            {
                _healthPoints = value;
            }
        }

        int _maxHealthPoints = 100;
        public int MaxHealthPoints
        {
            get
            {
                return _maxHealthPoints;
            }
            set
            {
                _maxHealthPoints = value;
            }
        }

        [SerializeField]
        int _intelligencePoints = 1;
        public int IntelligencePoints
        {
            get
            {
                return _intelligencePoints;
            }
            set
            {
                _intelligencePoints = value;
            }
        }
        [SerializeField]
        int _manaPoints = 10;
        public int ManaPoints
        {
            get
            {
                return _manaPoints;
            }
            set
            {
                _manaPoints = value;
            }
        }
        [SerializeField]
        int _defencePoints = 1;
        public int DefencePoints
        {
            get
            {
                return _defencePoints;
            }
            set
            {
                _defencePoints = value;
            }
        }
        [SerializeField]
        int _staminaPoints = 100;
        public int StaminaPoints
        {
            get
            {
                return _staminaPoints;
            }
            set
            {
                _staminaPoints = value;
            }
        }
        [SerializeField]
        int _experiencePoints = 0;
        public int ExperiencePoints
        {
            get
            {
                return _experiencePoints;
            }
            set
            {
                _experiencePoints = value;
            }
        }

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
