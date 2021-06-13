using System;
using System.Threading;

namespace CGOL
{
    public class GameOfLife
    {

        public int X { get; }
        public int Y { get; }
        public int[,] CurGen { get; set; }

        public int[,] NexGen { get; set; }

        public GameOfLife(int x, int y)
        {
            X = x;
            Y = y;
            CurGen = new int[X, Y];
            NexGen = new int[X, Y];


            var rand = new Random();           
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    if (rand.Next(0, 100) < 50)
                        CurGen[i, j] = 0;
                    else
                        CurGen[i, j] = 1;
                }
            }
        }

        public void Draw() {

            string output = "";
            for (int i = 0; i < X; i++)
            {
                for (int j =0; j< Y; j++)
                {
                    if (CurGen[i, j] == 1)
                        output += "X";
                    else
                        output += "O";
                }
                output += "\n";
            }
            Console.WriteLine(output);
        }

        public int getAlive(int x, int y)
        {

            int aliveCount = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (x + i < 0 || x + i >= X)   
                        continue;
                    if (y + j < 0 || y + j >= Y)   
                        continue;
                    if (x + i == x && y + j == y)     
                        continue;

                    aliveCount += CurGen[x + i, y + j];
                }
            }

            return aliveCount;
        }
  
        public void growNext()
        {
            for (int x = 0; x < X; x++)
            {
                for (int y = 0; y < Y; y++)
                {
                    int live = getAlive(x, y);

                    if (CurGen[x, y] == 1 && live < 2)
                        NexGen[x, y] = 0;

                    else if (CurGen[x, y] == 1 && live > 3)
                        NexGen[x, y] = 0;

                    else if (CurGen[x, y] == 0 && live == 3)
                        NexGen[x, y] = 1;

                    else
                        NexGen[x, y] = CurGen[x, y];

                }
            }

            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    CurGen[i, j] = NexGen[i, j];
                }
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
            GameOfLife gameOfLife = new GameOfLife(10,10);
            GoLTest g = new GoLTest();
            Console.SetCursorPosition(0, 0);
            int runs = 10;
            int i = 0;
            while (i < runs)
            {
                //g.DrawTest();
                //g.growNextTest();
                gameOfLife.Draw();
                gameOfLife.growNext();
                Thread.Sleep(125);
                i++;
            }
        }
    }
        

    }
}