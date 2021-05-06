﻿using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using TMPro;
using UnityEngine;
using static DungeonCrawl.Actors.Characters.Character;

namespace Assets.Source.Core
{
    /// <summary>
    ///     Class for handling text on user interface (UI)
    /// </summary>
    public class UserInterface : MonoBehaviour
    {
        public enum TextPosition : byte
        {
            TopLeft,
            TopCenter,
            TopRight,
            MiddleLeft,
            MiddleCenter,
            MiddleRight,
            BottomLeft,
            BottomCenter,
            BottomRight
        }

        /// <summary>
        ///     User Interface singleton
        /// </summary>
        public static UserInterface Singleton { get; private set; }

        private TextMeshProUGUI[] _textComponents;

        private void Awake()
        {
            if (Singleton != null)
            {
                Destroy(this);
                return;
            }

            Singleton = this;

            _textComponents = GetComponentsInChildren<TextMeshProUGUI>();          
        }

        public void Update()
        {           
            UpdatePlayerStats();           
        }

        public void UpdatePlayerStats()
        {
            Display _display = new Display();
            Player player = ActorManager.Singleton.Player;

            string playerName = player.CharacterName;
            int hp = player.HealthPoints;
            int max_hp = player.MaxHealthPoints;
            int mp = player.ManaPoints;
            int att = player.AttackPoints;
            int def = player.DefencePoints;
            int sta = player.StaminaPoints;
            int exp = player.ExperiencePoints;
            int level = player.CharacterLevel;

            

            string text = _display.PrintStats(hp, max_hp, mp, att, def, sta, exp, level);
            SetText(playerName, TextPosition.TopCenter);
            SetText(text, TextPosition.BottomLeft);

            SetText("inventory in development", TextPosition.BottomRight);
        }

        /// <summary>
        ///     Changes text at given screen position
        /// </summary>
        /// <param name="text"></param>
        /// <param name="textPosition"></param>

        public void SetText(string text, TextPosition textPosition)
        {

            _textComponents[(int)textPosition].text = text;
            _textComponents[(int)textPosition].fontSize = (float)50;
            _textComponents[(int)textPosition].characterSpacing = (float)8;
        }
    }
}
