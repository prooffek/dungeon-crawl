using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Items.ItemClasses
{
    public interface IEquippable
    {
        public bool IsEquipped { get; }
    }
}
