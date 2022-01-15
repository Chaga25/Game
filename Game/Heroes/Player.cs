using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Heroes
{
    class Player : Chars
    {
        readonly private int maxHealth = 500;
        public string Name { get; set; }
        public int Damage { get; set; }
        public int HP { get; set; }
        public int Range { get; set; }
        public int AttSpeed { get; set ; }

        public Player() 
        {
            Random r = new Random();

            HP = maxHealth;
            Damage = r.Next(1, 30);
            AttSpeed = r.Next(1, 7);
            Range = 1;
        }
        public Player(string _name):this()
        {
            Name = _name;
        }
        public  bool isAlive()
        {
            return HP > 0 ? true : false;
        }

        public int hit()
        {
            return Damage * AttSpeed;
        }

        public void Heart() 
        {
            if (canBeHealed())
            {
                HP = maxHealth;
            }
        } 

        public void HpDecrease(int hitPower) => HP -= hitPower;
        public void scan()
        {
            Console.WriteLine("\n" +
                "\n" +
                "####################");
            Console.WriteLine($"Player: {Name}\n" +
                $"HP: {HP}\n" +
                $"Damage: {Damage}\n" +
                $"Range: {Range}\n" +
                $"AttSpeed: {AttSpeed}");
            Console.WriteLine("####################"+
                "\n" +
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

        public bool canBeHealed()
        {
            return HP < maxHealth ? true : false;
        }
    }
}
