using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace RanSanMoi
{
    class Program
    {
        //Khai báo kích thước màn hình game
        static int width = 20;
        static int height = 40;
        static string[,] display = new string[width,height];        
        //Tạo danh sách chứa cách thành phần của rắn
        static List<(int, int)> snake = new List<(int, int)>();       
        static ConsoleKey direction = ConsoleKey.RightArrow;
        static Random rand = new Random();
        static (int,int) food;
        static int count=0;          
        static void Main(string[]args)
        {
            InitializeGame(); 
            DisplayGame();
            Console.ReadKey();           
            while(true)
            {                
                DisplayGame();
                UpdateSnake();
                Controller();
                TangToc();
            }
        }
        //Tăng tốc game khi ăn được mồi
        static void TangToc()
        {
            int countMinPfs=0;
            int countFPS=170-(count*2);
            if(countFPS<=countMinPfs)
            {
                countFPS=countMinPfs;
            }
            else
            {
                Thread.Sleep(countFPS);
            }
        }
        //Khởi tạo Game, tạo ra rắn và mồi đầu tiên.
        static void InitializeGame()
        {                      
            snake.Add((width/2,5));
            snake.Add((width/2,4));
            snake.Add((width/2,3));                                                                 
            SpawnFood();
        }
        //Điều khiển di chuyển của rắn trong game
        static void Controller()
        {      
            var key1=ConsoleKey.UpArrow; 
            var key2=ConsoleKey.DownArrow;
            var key3=ConsoleKey.LeftArrow;     
            var key4=ConsoleKey.RightArrow;
            if (Console.KeyAvailable==true)
                {
                    var key = Console.ReadKey(true).Key;
                    if ((key==key2&&direction!=key1)||(key==key1&&direction!=key2)||
                       (key==key3&&direction!=key4)||(key==key4&&direction!=key3))
                        {
                            direction=key;                       
                        }
                }
        }
        //In ra viền màn hình, rắn và mồi
        static void DisplayGame()
        {
            Console.Clear();
            string thang ="#";
            string khoangtrong = " ";
            string ran = "O";  
            string moi = "X";      
            for (int i =0;  i< width ; i++)
            {
                for ( int j = 0 ; j< height ; j++)
                {
                    if (i%(width-1)==0||j%(height-1)==0)
                    {                        
                        Console.Write(""+thang,Console.ForegroundColor = ConsoleColor.Red);                     
                    }
                    else if (snake.Contains((i, j)))
                    {                                                
                        Console.Write(""+ran,Console.ForegroundColor = ConsoleColor.Green);
                    }
                    else if (food==(i,j))
                    {                        
                        Console.Write(""+moi,Console.ForegroundColor = ConsoleColor.Yellow);               
                    }
                    else 
                    {                        
                        Console.Write(""+khoangtrong);                       
                    }
                }
                Console.WriteLine();
            }
        }
        //Cập nhật trạng thái rắn
        static void UpdateSnake()
        {        
            //Khai báo biến head là phần tử đầu tiên trong danh sách snake    
            var head = snake.First();
            //Tạo biến newHead là vị trí mới của đầu rắn
            (int,int) newHead = head;
            //Đọc vào phím đã bấm
            switch(direction)
            {
                case ConsoleKey.UpArrow:
                {
                    Thread.Sleep(120);
                    newHead=(head.Item1-1,head.Item2);
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    Thread.Sleep(120);
                    newHead=(head.Item1+1,head.Item2);
                    break;
                }
                case ConsoleKey.LeftArrow:
                {
                    Thread.Sleep(50);
                    newHead=(head.Item1,head.Item2-1);
                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    Thread.Sleep(50);
                    newHead=(head.Item1,head.Item2+1);
                    break;
                }
            }  
            //Rắn ăn mồi sẽ tăng kích thước vào tạo mồi mới          
            if (newHead==food)
            {                
                SpawnFood();               
                snake.Insert(0,newHead);                
                count++;                                                            
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
                Console.WriteLine("Diem Cua Ban: "+count);
                Environment.Exit(0);
            }
        }
        //Tạo mồi ở vị trí ngẫu nhiên
        static void SpawnFood()
        {
            int x,y;
            do
            {
                y = rand.Next(1,width-1);//Hàng
                x = rand.Next(1,height-1);//Cột
            }while(snake.Contains((y,x)));
            food=(y,x);            
        }            
    }    
}