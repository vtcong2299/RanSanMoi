using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace RanSanMoi
{
    class GameSystem
    {
        //Khởi tạo Game, tạo ra rắn và mồi đầu tiên.
        public static void InitializeGame()
        {
            SnakeControl.snake.Add((SnakeControl.width/2,5));
            SnakeControl.snake.Add((SnakeControl.width/2,4));
            SnakeControl.snake.Add((SnakeControl.width/2,3));                                                                 
            SpawnFood.Food();
        }  
        //Hiển thị điểm số
        public static void ShowScore()
        {
            Console.WriteLine("Score: {0}",SnakeControl.score);
        } 
        //In ra màn hình Game
        public static void DisplayGame()
        {
            Console.Clear();
            for (int i= 0; i< SnakeControl.width; i++)
            {
                for (int j=0; j<SnakeControl.height; j++)
                {
                    if (i==0||j==0||i==SnakeControl.width-1||j==SnakeControl.height-1)
                    {
                        Console.Write("#",Console.ForegroundColor = ConsoleColor.Red);
                    }
                    else if (SnakeControl.snake.First()==((i,j)))
                    {
                        Console.Write("@",Console.ForegroundColor = ConsoleColor.Green);
                    }
                    else if (SnakeControl.snake.Contains((i,j))&&SnakeControl.snake.First()!=((i,j)))
                    {
                        Console.Write("O",Console.ForegroundColor = ConsoleColor.Green);
                    }
                    else if (SpawnFood.food==(i,j))
                    {
                        Console.Write("X",Console.ForegroundColor = ConsoleColor.Yellow);
                    }
                    else if (SpawnFood.superFood==(i,j))
                    {
                        Console.Write("S",Console.ForegroundColor = ConsoleColor.Yellow);
                    }
                    else 
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }                
    }    
}