using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Core
{
    public class Display
    {
        public string PrintStats(int hp, int mp, int att, int def, int sta, int exp, int level)
        {
           string statsTable = $@"

    
    HP : {hp}
    MP : {mp}
    ATT: {att}
    DEF: {def}
    STA: {sta}
    EXP: {exp}

    LEVEL: {level}

";
            return statsTable;
        }
    }
}
