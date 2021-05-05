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
        public string CharacterName { get; private set; }

        public int CharacterLevel { get; private set; }
        [SerializeField]
        int _attackPoints;
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
        int _healthPoints;
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
        [SerializeField]
        int _intelligencePoints;
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
        int _manaPoints;
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
        int _defencePoints;
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
        int _staminaPoints;
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
        int _experiencePoints;
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
