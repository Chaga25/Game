using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Heroes
{
     interface Chars
    {
        public int Damage { get; set; }
        public int HP { get; set; }
        public int Range { get; set; }
        public int AttSpeed { get; set; }
        public bool isAlive();
        public int hit();
        public void HpDecrease(int hitPower);
        public void scan();
        public bool CanDamage(Chars c);
        public bool CanTakeDamage(Chars c);
    }
}
