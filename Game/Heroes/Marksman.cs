using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Heroes
{
    class Marksman : Chars
    {
        public int Damage { get; set; }
        public int HP { get; set; }
        public int Range { get; set; }
        public int AttSpeed { get; set; }

        public Marksman()
        {
            Random r = new Random();

            HP = 50;
            Damage = r.Next(1, 10);
            AttSpeed = r.Next(1, 5);
            Range = 10;
        }
        public int hit()
        {
            return Damage;
        }

        public bool isAlive()
        {
            return HP > 0 ? true : false; 
        }
        public void HpDecrease(int hitPower) => HP -= hitPower;
        public void scan()
        {
            Console.WriteLine("\n" +
                "*************************");
            Console.WriteLine($"Enemy: Marksman\n" +
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
