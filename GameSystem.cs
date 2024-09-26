using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;


namespace RanSanMoi
{
    class GameSystem
    {
        public static string? playerName = "player";
        public static int cheDo = 1;
        string BangXepHang = @"C:\Users\admin\Documents\HocLapTrinh\LapTrinhGameUnity\CongTapCode\C#\BaiTapCodeGym\RanSanMoi\BangXepHang.csv";
        //Nhập tên người chơi và chọn chế độ chơi
        public void MenuGame()
        {
            try
            {
                Console.Write("Nhap ten cua ban: ");
                playerName = Console.ReadLine();
                Console.WriteLine("Cac che do choi");
                Console.WriteLine("---------------");
                Console.WriteLine("[1] Che do xuyen tuong ");
                Console.WriteLine("[2] Che do khong xuyen tuong ");
                Console.WriteLine("[0] Thoat Game ");
                while (true)
                {
                    Console.Write("Chon che do choi: ");
                    if (Int32.TryParse(Console.ReadLine(), out cheDo) && (cheDo == 1 || cheDo == 2 || cheDo == 0))
                    {
                        if (cheDo == 0)
                        {
                            Environment.Exit(0);
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi o phuong thuc MenuGame()" + ex);
            }
        }
        //Khởi tạo Game, tạo ra rắn và mồi đầu tiên.
        public void InitializeGame()
        {
            try
            {
                SnakeControl snakeControl = new SnakeControl();
                SnakeControl.snake.Add((snakeControl.width / 2, 5));
                SnakeControl.snake.Add((snakeControl.width / 2, 4));
                SnakeControl.snake.Add((snakeControl.width / 2, 3));
                SpawnFood.Food();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi o phuong thuc InitializeGame()" + ex);
            }
        }
        //Hiển thị điểm số
        public void ShowScore()
        {
            try
            {
                Console.WriteLine("Score: {0}", SnakeControl.score);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi o phuong thuc ShowScore()" + ex);
            }
        }
        //Kết thúc Game
        public void GameOver()
        {
            try
            {
                GameSystem gameSystem = new GameSystem();
                Console.Clear();
                Console.WriteLine("!!!GAME OVER!!!");
                Console.WriteLine("Diem Cua Ban: " + SnakeControl.score);
                gameSystem.WriteScore();
                Console.WriteLine();
                Console.WriteLine("Bang Xep Hang:");
                Console.WriteLine("---------------");
                gameSystem.ReadScore();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi o phuong thuc GameOver()" + ex);
            }
        }
        //Đọc và In ra màn hình bảng xếp hạng điểm số
        public void ReadScore()
        {
            try
            {
                List<string> lines = new List<string>();
                using (StreamReader sr = File.OpenText(BangXepHang))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == "")
                        {
                            lines.Remove(line);
                        }
                        else
                        {
                            lines.Add(line);
                        }
                    }
                    lines.Sort((a, b) =>
                    {
                        int scoreA = int.Parse(a.Split(':')[1]); // Giả sử cột thứ hai là số điểm
                        int scoreB = int.Parse(b.Split(':')[1]);
                        return scoreB.CompareTo(scoreA); // Sắp xếp từ cao xuống thấp
                    });
                    // In danh sách đã sắp xếp
                    foreach (var sortedLine in lines)
                    {
                        Console.WriteLine(sortedLine);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi o phuong thuc ReadScore()" + ex);
            }
        }
        //Ghi tên người chơi và điểm số vào danh sách
        public void WriteScore()
        {
            Program program = new Program();
            try
            {
                using (StreamWriter writer = new StreamWriter(BangXepHang, true))
                {
                    writer.WriteLine("{0}: {1}", playerName, SnakeControl.score);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi o phuong thuc WriteScore()" + ex);
            }
        }
        //In ra màn hình Game
        public void DisplayGame()
        {
            try
            {
                SnakeControl snakeControl = new SnakeControl();
                Console.Clear();
                for (int i = 0; i < snakeControl.width; i++)
                {
                    for (int j = 0; j < snakeControl.height; j++)
                    {
                        if (i == 0 || j == 0 || i == snakeControl.width - 1 || j == snakeControl.height - 1)
                        {
                            Console.Write("#", Console.ForegroundColor = ConsoleColor.Red);
                        }
                        else if (SnakeControl.snake.First() == ((i, j)))
                        {
                            Console.Write("@", Console.ForegroundColor = ConsoleColor.Green);
                        }
                        else if (SnakeControl.snake.Contains((i, j)) && SnakeControl.snake.First() != ((i, j)))
                        {
                            Console.Write("O", Console.ForegroundColor = ConsoleColor.Green);
                        }
                        else if (SpawnFood.food == (i, j))
                        {
                            Console.Write("X", Console.ForegroundColor = ConsoleColor.Yellow);
                        }
                        else if (SpawnFood.superFood == (i, j))
                        {
                            Console.Write("S", Console.ForegroundColor = ConsoleColor.Yellow);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi o phuong thuc DisplayGame()" + ex);
            }
        }
    }
}
