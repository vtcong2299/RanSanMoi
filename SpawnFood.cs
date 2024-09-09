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
            int x,y;
            do
            {
                y= rand.Next(1,SnakeControl.width-1);
                x= rand.Next(1,SnakeControl.height -1);
            }while(SnakeControl.snake.Contains((y,x)));
            food=(y,x);
        }
        //Tạo mồi lớn ở vị trí ngẫu nhiên
        public static void SuperFood()
        {
            int x,y;
            do
            {
                y= rand.Next(1,SnakeControl.width-1);
                x= rand.Next(1,SnakeControl.height -1);
            }while(SnakeControl.snake.Contains((y,x))&&food!=((y,x)));
            superFood=(y,x);
        }         
    }    
}