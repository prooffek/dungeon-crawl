using DungeonCrawl.Actors.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Items
{
    public class Key : Item
    {
        public override int MaxDurability => throw new NotImplementedException();

        public override int CurrentDurability { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string DefaultName => "Key to the Gate";

        public override int DefaultSpriteId => 559;

        public override void ActionOnUse(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
