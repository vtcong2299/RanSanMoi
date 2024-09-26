using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace RanSanMoi
{
    class SpawnFood
    {
        public static Random rand = new Random();
        public static (int, int) food;
        public static (int, int) superFood;
        //Tạo mồi nhỏ ở vị trí ngẫu nhiên
        public static void Food()
        {
            try
            {
                SnakeControl snakeControl = new SnakeControl();
                int x, y;
                do
                {
                    y = rand.Next(1, snakeControl.width - 1);
                    x = rand.Next(1, snakeControl.height - 1);
                } while (SnakeControl.snake.Contains((y, x)));
                {food = (y, x);}
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi o phuong thuc Food()"+ ex);
            }
        }
        //Tạo mồi Đặc Biệt ở vị trí ngẫu nhiên
        public static void SuperFood()
        {
            try
            {
                SnakeControl snakeControl = new SnakeControl();
                int x, y;
                do
                {
                    y = rand.Next(1, snakeControl.width - 1);
                    x = rand.Next(1, snakeControl.height - 1);
                } while (SnakeControl.snake.Contains((y, x)) || food == ((y, x)));
                superFood = (y, x);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi o phuong thuc SuperFood()"+ ex);
            }
        }
    }
}