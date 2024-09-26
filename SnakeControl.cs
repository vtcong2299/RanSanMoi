using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
using System.Security;

namespace RanSanMoi
{
    class SnakeControl
    {
        //Khai báo kích thước màn hình game
        public int width = 15;
        public int height = 35;
        public static int score = 0;
        public int speed = 400;
        public int count = 0;
        public bool isDeal = false;
        public ConsoleKey direction = ConsoleKey.RightArrow;
        //Tạo danh sách chứa cách thành phần của rắn
        public static List<(int, int)> snake = new List<(int, int)>();
        //Cập nhật trạng thái rắn
        public void UpdateSnake()
        {
            try
            {
                //Khai báo biến head là phần tử đầu tiên trong danh sách snake    
                var head = snake.First();
                //Tạo biến newHead là vị trí mới của đầu rắn
                (int, int) newHead = head;
                //Đọc vào phím đã bấm
                switch (direction)
                {
                    case ConsoleKey.RightArrow:
                        {
                            Task.Delay(50).Wait();
                            newHead = (head.Item1, head.Item2 + 1);
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            Task.Delay(50).Wait();
                            newHead = (head.Item1, head.Item2 - 1);
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            Task.Delay(120).Wait();
                            newHead = (head.Item1 - 1, head.Item2);
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            Task.Delay(120).Wait();
                            newHead = (head.Item1 + 1, head.Item2);
                            break;
                        }
                }
                //Rắn ăn mồi sẽ tăng kích thước, tạo mồi mới và tăng tốc game
                if (newHead == SpawnFood.food)//Ăn mồi bé
                {
                    score++;
                    count++;
                    snake.Insert(0, newHead);
                    if (count >= 5)
                    {
                        SpawnFood.SuperFood();
                        SpawnFood.food = ((0, 0));
                    }
                    else
                    {
                        SpawnFood.Food();
                    }
                    speed -= 30;
                    if (speed <= 30)
                    {
                        speed = 30;
                    }
                }
                else if (newHead == SpawnFood.superFood)//Ăn mồi lớn
                {
                    score += 5;
                    count = 0;
                    snake.Insert(0, newHead);
                    SpawnFood.superFood = ((0, 0));
                    SpawnFood.Food();
                    speed -= 30;
                    if (speed <= 30)
                    {
                        speed = 30;
                    }
                }
                else
                {
                    if (GameSystem.cheDo == 1)
                    {
                        if (newHead.Item1 == width - 1)
                        {
                            newHead.Item1 = 1;
                        }
                        if (newHead.Item1 == 0)
                        {
                            newHead.Item1 = width - 2;
                        }
                        if (newHead.Item2 == height - 1)
                        {
                            newHead.Item2 = 1;
                        }
                        if (newHead.Item2 == 0)
                        {
                            newHead.Item2 = height - 2;
                        }
                    }
                    snake.Insert(0, newHead);
                    snake.RemoveAt(snake.Count - 1);
                }
                //Rắn chết nếu chạm viền hoặc tự ăn mình
                if (((newHead.Item1 >= width - 1 || newHead.Item1 <= 0 || newHead.Item2 >= height - 1
                    || newHead.Item2 <= 0 || snake.Skip(1).Contains(newHead)) && GameSystem.cheDo == 2) ||
                    ((snake.Skip(1).Contains(newHead)) && GameSystem.cheDo == 1))
                {
                    isDeal = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi o phuong thuc UpDateSnake()" + ex);
            }
        }
        //Điều khiển di chuyển của rắn trong game
        public void Controler()
        {
            try
            {
                var keyUp = ConsoleKey.UpArrow;
                var keyDown = ConsoleKey.DownArrow;
                var keyRight = ConsoleKey.RightArrow;
                var keyLeft = ConsoleKey.LeftArrow;
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey().Key;
                    if ((key == keyDown && direction != keyUp) || (key == keyUp && direction != keyDown)
                        || (key == keyRight && direction != keyLeft) || (key == keyLeft && direction != keyRight))
                    {
                        direction = key;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi o phuong thuc Controler()" + ex);
            }
        }

    }
}
