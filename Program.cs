using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace RanSanMoi
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                GameSystem gameSystem = new GameSystem();
                SnakeControl snakeControl = new SnakeControl();
                gameSystem.MenuGame();
                gameSystem.InitializeGame();
                gameSystem.DisplayGame();
                gameSystem.ShowScore();
                Console.WriteLine("Nhan phim [Bat ky] de bat dau Game",Console.ForegroundColor = ConsoleColor.White);
                Console.ReadKey();
                while (true)
                {
                    gameSystem.DisplayGame();
                    snakeControl.Controler();
                    snakeControl.UpdateSnake();
                    gameSystem.ShowScore();
                    if (snakeControl.isDeal==true)
                    {
                        gameSystem.GameOver();
                    }
                    Task.Delay(snakeControl.speed).Wait();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi o phuong thuc Main()"+ ex);
            }
        }
    }
}