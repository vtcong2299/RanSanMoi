// using System;


// class Program
// {
//     static int width = 30;
//     static int height = 50;
//     static char[,] screen = new char[width, height];
//     static List<(int, int)> snake = new List<(int, int)>();
//     static (int, int) food;
//     static Random random = new Random();
//     static ConsoleKey direction = 0;

//     static void Main()
//     {
//         InitializeGame();
//         while (true)
//         {
//             DrawScreen();
//             UpdateSnake();
//             Thread.Sleep(150);
//             if (Console.KeyAvailable)
//             {
//                 var key = Console.ReadKey(true).Key;
//                 if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
//                 {
//                     direction = key;
//                 }
//             }
//         }
//     }

//     static void InitializeGame()
//     {
//         // for (int i = 0; i < width; i++)
//         // {
//         //     for (int j = 0; j < height; j++)
//         //     {
//         //         screen[i, j] = ' ';
//         //     }
//         // }

//         snake.Add((width / 2, height / 2));
//         PlaceFood();
//     }

//     static void DrawScreen()
//     {
//         Console.Clear();
//         for (int i = 0; i < width; i++)
//         {
//             for (int j = 0; j < height; j++)
//             {
//                 if (i == 0 || i == width - 1 || j == 0 || j == height - 1)
//                 {
//                     Console.Write("#  ");
//                 }
//                 else if (snake.Contains((i, j)))
//                 {
//                     Console.Write('O');
//                 }
//                 else if (food == (i, j))
//                 {
//                     Console.Write('X');
//                 }
//                 else
//                 {
//                     Console.Write("   ");
//                 }
//             }
//             Console.WriteLine();
//         }
//     }

//     static void UpdateSnake()
//     {
//         var head = snake.First();
//         (int, int) newHead = head;

//         switch (direction)
//         {
//             case ConsoleKey.LeftArrow:
//                 newHead = (head.Item1, head.Item2 - 1);
//                 break;
//             case ConsoleKey.RightArrow:
//                 newHead = (head.Item1, head.Item2 + 1);
//                 break;
//             case ConsoleKey.UpArrow:
//                 newHead = (head.Item1 - 1, head.Item2);
//                 break;
//             case ConsoleKey.DownArrow:
//                 newHead = (head.Item1 + 1, head.Item2);
//                 break;
//         }

//         if (newHead == food)
//         {
//             snake.Insert(0, newHead);
//             PlaceFood();
//         }
//         else
//         {
//             snake.Insert(0, newHead);
//             snake.RemoveAt(snake.Count - 1);
//         }

//         if (newHead.Item1 == 0 || newHead.Item1 == width - 1 || newHead.Item2 == 0 || newHead.Item2 == height - 1 || snake.Skip(1).Contains(newHead))
//         {
//             Console.Clear();
//             Console.WriteLine("Game Over!");
//             Environment.Exit(0);
//         }
//     }

//     static void PlaceFood()
//     {
//         int x, y;
//         do
//         {
//             x = random.Next(1, width - 1);
//             y = random.Next(1, height - 1);
//         } while (snake.Contains((x, y)));// Kiểm tra xem toạ độ (x,y) có nằm trong danh sách snake không

//         food = (x, y);
//     }
// }
