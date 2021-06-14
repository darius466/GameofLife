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

        //constructor
        public GameOfLife(int x, int y)
        {
            X = x;
            Y = y;
            CurGen = new int[X, Y];
            NexGen = new int[X, Y];

            //initialize grid with random seed pattern
            var rand = new Random();           
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    if (rand.Next(0, 100) < 50) //half of the cells in the grid are dead
                        CurGen[i, j] = 0;
                    else
                        CurGen[i, j] = 1;
                }
            }
        }

        //updates game to console every generation
        public void Draw() 
        {
            string output = ""; 
            for (int i = 0; i < X; i++)
            {
                for (int j =0; j< Y; j++)
                {
                    if (CurGen[i, j] == 0)
                        output += "O";
                    else
                        output += "X";
                }
                output += "\n";
            }
            Console.WriteLine(output); //write data structure out to console as string
        }

        //method to get the surrounding cells that are alive
        public int getAlive(int x, int y)
        {
            int aliveCount = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    //handles out of bounds exceptions
                    if (x + i < 0 || x + i >= X)   
                        continue;
                    if (y + j < 0 || y + j >= Y)   
                        continue;
                    if (x + i == x && y + j == y)     
                        continue;

                    aliveCount += CurGen[x + i, y + j]; //add value of each cell to the count. value is either 1 or 0
                }
            }

            return aliveCount;
        }

        //get the next generation of cells
        public void growNext()
        {
            for (int x = 0; x < X; x++)
            {
                for (int y = 0; y < Y; y++)
                {
                    int live = getAlive(x, y);

                    if (CurGen[x, y] == 1 && live < 2) //Any live cell with fewer than two live neighbors dies by underpopulation
                        NexGen[x, y] = 0;

                    else if (CurGen[x, y] == 1 && live > 3) //Any live cell with more than three live neighbors dies by overpopulation
                        NexGen[x, y] = 0;

                    else if (CurGen[x, y] == 0 && live == 3) //Any dead cell with with exactly three live neighbors becomes a live cell by reproduction 
                        NexGen[x, y] = 1;

                    else
                        NexGen[x, y] = CurGen[x, y]; //Any cell thats alive survives and any cell thats dead stays dead

                }
            }

            //next generation becomes current generation 
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
                GoLTest g = new GoLTest(); //testing seed
                Console.SetCursorPosition(0, 0);
                int runs = 10; //number of generations to run
                int test = 2;
                int i = 0;
                int j = 0;
                int slowSlim = 150; //slow down simulation so its easier to see
                while (i < runs)
                {
                    gameOfLife.Draw();
                    gameOfLife.growNext();
                    Thread.Sleep(slowSlim);
                    i++;
                }

                while (j < test) 
                {
                    g.growNextTest(); //working on unit test
                    j++;

                }

                Console.WriteLine("Rule one test " + g.getOne()); //should be 0
                Console.WriteLine("Rule two test " + g.getTwo()); //shold be 1
                Console.WriteLine("Rule three test " + g.getThree()); //should be 0
                Console.WriteLine("Rule four test " + g.getFour()); //should be 1 although the pattern is correct if a draw the test game

            }
        }
    }
}