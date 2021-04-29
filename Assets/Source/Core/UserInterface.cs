﻿using TMPro;
using UnityEngine;

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
            Display _display = new Display();
            string playerName = "Yezekhiel";
            int hp = 100;
            int mp = 100;
            int att = 1;
            int def = 1;
            int sta = 100;
            int exp = 1;
            int level = 1;
            string text = _display.PrintStats( playerName,  hp,  mp,  att,  def,  sta,  exp,  level);
            SetText(text, TextPosition.BottomLeft);
        }

        /// <summary>
        ///     Changes text at given screen position
        /// </summary>
        /// <param name="text"></param>
        /// <param name="textPosition"></param>

        public void SetText(string text, TextPosition textPosition)
        {

            _textComponents[(int)textPosition].text = text;
        }
    }
}
