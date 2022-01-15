using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Heroes
{
    class Fighter : Chars
    {
        public int Damage { get; set; }
        public int HP { get; set; }
        public int Range { get; set; }
        public int AttSpeed { get; set; }

        public Fighter()
        {
            Random r = new Random();

            HP = 100;
            Damage = r.Next(1, 20);
            AttSpeed = r.Next(1, 5);
            Range = 1;
        }
        public int hit()
        {
            return Damage * AttSpeed;
        }

        public void HpDecrease(int hitPower) => HP -= hitPower;

        public bool isAlive()
        {
            return HP > 0 ? true : false;
        }

        public void scan()
        {
            Console.WriteLine("\n" +
                "*************************");
            Console.WriteLine($"Enemy: Fighter\n" +
                $"HP: {HP}\n" +
                $"Damage: {Damage}\n" +
                $"Range: {Range}\n" +
                $"AttSpeed: {AttSpeed}");
            Console.WriteLine("*************************" +
                "\n"
                );
        }

        public bool CanDamage(Chars c)
        {
            return this.Range >= c.Range ? true : false;
        }

        public bool CanTakeDamage(Chars c)
        {
            return this.Range <= c.Range ? true : false;
        }
    }
}
