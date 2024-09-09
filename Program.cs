using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace RanSanMoi
{
    class Program
    {
        public static void Main (string[] args)
        {
            GameSystem.InitializeGame(); 
            GameSystem.DisplayGame();
            GameSystem.ShowScore();
            Console.ReadKey(); 
            while(true)
            {
                GameSystem.DisplayGame();
                SnakeControl.Controler();
                SnakeControl.UpdateSnake(); 
                GameSystem.ShowScore();               
                Task.Delay(SnakeControl.speed).Wait();
            }
        }          
    }    
}