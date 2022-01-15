using Game.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dav
{
    public class GameClass
    {
        int lengthOfRoad = 0;
        List<Chars> Enemies = new List<Chars>();
        Player player;
        int EnemyNumber;
        public GameClass()
        {
            createEnemies();

            createPlayer();
        }

        void createEnemies()
        {
            int n1, n2;
            Console.Write("Enter min number of enemies: ");
            int.TryParse(Console.ReadLine(), out n1);

            Console.Write("Enter max number of enemies: ");
            int.TryParse(Console.ReadLine(), out n2);

            Random r = new Random();
            int numberOfEnemies = r.Next(n1, n2);

            for(int i = 0; i < numberOfEnemies; i++)
            {
                if (i % 3 == 0)
                {
                    Marksman m = new Marksman();
                    Enemies.Add(m);
                    lengthOfRoad += m.Range;
                }
                else 
                {
                    Fighter f = new Fighter();
                    Enemies.Add(f);
                    lengthOfRoad += f.Range;
                }            
            }

            EnemyNumber = Enemies.Count();
        }

        void createPlayer()
        {
            Console.WriteLine("Enter player's name: ");

            player = new Player();
            player.Name = Console.ReadLine();
        }

        void info()
        {
            Console.WriteLine($"Number of enemies: {EnemyNumber}\n" +
                $"size of road: {lengthOfRoad}");
        }

        public void Run()
        {
            foreach (var item in Enemies.ToList())
            {
                
                Thread.Sleep(2000);
                Console.Clear();
                
                drawRoad();

                if (!player.isAlive())
                {
                    Console.WriteLine("U lost, U are dead!");
                    player.scan();
                    break;
                }

                info();
                Console.WriteLine("Current enemy info: ");
                item.scan();


                if (player.CanDamage(item) && item.CanDamage(player))
                {
                    while (player.isAlive() && item.isAlive())
                    {
                        player.HpDecrease(item.hit());
                        if (player.isAlive()) { 
                            item.HpDecrease(player.hit()); 
                        }
                        else
                        {
                            EnemyKilledPlayer();
                            break;
                        }
                        
                        if (!item.isAlive())
                        {
                            playerKilledEnemy();
                            lengthOfRoad -= item.Range;
                            EnemyNumber--;
                            break;
                        }
                    }

                    if (!player.isAlive()) break;
                    if (!item.isAlive() && checkWin()) {
                        Console.WriteLine("U won!!!");
                        break;
                    }
                    else
                    {
                        continue;
                    }
                    
                }
                else if (item.CanDamage(player) && !player.CanDamage(item))
                {
                    while (item.CanDamage(player) && !player.CanDamage(item))
                    {
                        player.HpDecrease(item.hit());
                        item.Range--;
                        lengthOfRoad--;
                        if (!player.isAlive())
                        {
                            EnemyKilledPlayer();
                            break;
                        }
                    }

                    if (!player.isAlive()) break;

                    while (player.isAlive() && item.isAlive())
                    {
                        player.HpDecrease(item.hit());
                        if (player.isAlive())
                        {
                            item.HpDecrease(player.hit());
                        }
                        else
                        {
                            EnemyKilledPlayer();
                            break;
                        }

                        if (!item.isAlive())
                        {
                            playerKilledEnemy();
                            lengthOfRoad -= item.Range;
                            EnemyNumber--;
                            break;
                        }
                    }

                    if (!player.isAlive()) break;
                    if (!item.isAlive() && checkWin())
                    {
                        Console.WriteLine("U won!!!");
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }

            }

            
        }

        bool checkWin()
        {
            return EnemyNumber == 0 ? true : false;
        }

        void playerKilledEnemy()
        {
            Console.WriteLine("U killed the Enemy");
            randHeart();
            player.scan();
        }

        void EnemyKilledPlayer()
        {
            Console.WriteLine("U lost");
            player.scan();
        }
        void randHeart()
        {
            Random r = new Random();
            var randbool = r.Next(2) == 1;

            if (randbool)
            {
                player.Heart();
                Console.WriteLine("<3 <3 U reacived Heart and your hp increased ;ddd");
            }
        }
        
        void drawRoad()
        {
            Console.WriteLine();

            for (int i = 0; i < lengthOfRoad; i++)
            {
                if (i == 0) Console.Write($"{player.Name}");
                else Console.Write(" __ ");
            }

            Console.WriteLine("\n \n \n");
        }
    }
}
