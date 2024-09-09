using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace RanSanMoi
{
    class SnakeControl
    {
        //Khai báo kích thước màn hình game
        public static int width = 15;
        public static int height = 35;
        public static int score=0;
        public static int speed=400;
        public static int count = 0;
        public static ConsoleKey direction = ConsoleKey.RightArrow;
        //Tạo danh sách chứa cách thành phần của rắn
        public static List<(int,int)> snake = new List<(int, int)>();  
        //Cập nhật trạng thái rắn
        public static void UpdateSnake()
        {
            //Khai báo biến head là phần tử đầu tiên trong danh sách snake    
            var head = snake.First();
            //Tạo biến newHead là vị trí mới của đầu rắn
            (int,int) newHead = head;
            //Đọc vào phím đã bấm
            switch(direction)
            {
                case ConsoleKey.RightArrow:
                {
                    Task.Delay(50).Wait();
                    newHead=(head.Item1,head.Item2+1);
                    break;
                }
                case ConsoleKey.LeftArrow:
                {
                    Task.Delay(50).Wait();
                    newHead=(head.Item1,head.Item2-1);
                    break;
                }
                case ConsoleKey.UpArrow:
                {
                    Task.Delay(120).Wait();
                    newHead=(head.Item1-1,head.Item2);
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    Task.Delay(120).Wait();
                    newHead=(head.Item1+1,head.Item2);
                    break;
                }                
            }
            //Rắn ăn mồi sẽ tăng kích thước, tạo mồi mới và tăng tốc game
            if (newHead==SpawnFood.food)//Ăn mồi bé
            {
                score ++;
                count ++;
                snake.Insert(0,newHead);
                if(count>=5)
                {
                    SpawnFood.SuperFood();
                    SpawnFood.food=((0,0));
                }
                else
                {
                    SpawnFood.Food();
                }                
                speed-=10;
                if(speed<=30)
                {
                    speed = 30;
                }
            }
            else if (newHead==SpawnFood.superFood)//Ăn mồi lớn
            {
                score+=5;
                count=0;
                snake.Insert(0,newHead);
                SpawnFood.superFood=((0,0));
                SpawnFood.Food();
                speed-=10;
                if(speed<=30)
                {
                    speed = 30;
                }
            }
            else
            {
                snake.Insert(0,newHead);
                snake.RemoveAt(snake.Count -1);
            }
            //Rắn chết nếu chạm viền hoặc tự ăn mình
            if(newHead.Item1>=width-1||newHead.Item1<=0||newHead.Item2>=height-1
                ||newHead.Item2<=0||snake.Skip(1).Contains(newHead))
            {
                Console.Clear();
                Console.WriteLine("!!!GAME OVER!!!");
                Console.WriteLine("Diem Cua Ban: " + score);
                Environment.Exit(0);
            }
        } 
        //Điều khiển di chuyển của rắn trong game
        public static void Controler()
        {
            var keyUp = ConsoleKey.UpArrow;
            var keyDown = ConsoleKey.DownArrow;
            var keyRight = ConsoleKey.RightArrow;
            var keyLeft = ConsoleKey.LeftArrow;
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey().Key;
                if ((key==keyDown&&direction!=keyUp)||(key==keyUp&&direction!=keyDown)
                    ||(key==keyRight&&direction!=keyLeft)||(key==keyLeft&&direction!=keyRight))
                    {
                        direction=key;
                    }
            }            
        }   
        
    }    
}
