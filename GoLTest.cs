using System;

namespace CGOL
{

    //this class serves as a test seed for the rules of CGOL
    //I seed the grid with live cells and know what their fate should be for the next generation 
    //I'm just returning the value of the cells and manually checking thier values for now
    public class GoLTest
    {

        public int X { get; }
        public int Y { get; }

        public int [ , ]CurGrid = {
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
            };

        public int[,] NexGrid { get; set; }

        public GoLTest()
        {
            X = 10;
            Y = 10;
            CurGrid = new int[X, Y];
            NexGrid = new int[X, Y];
            rulesTest();

        }

        public void rulesTest() {
            
                CurGrid[0,0] = 1; //rule 1

                CurGrid[5,1] = 1;
                CurGrid[5,2] = 1;
                CurGrid[5,3] = 1; //rule 2

                CurGrid[8,3] = 1;
                CurGrid[8,4] = 1;
                CurGrid[8,5] = 1;
                CurGrid[9,4] = 1;
                CurGrid[7,4] = 1; //rule 3

                CurGrid[3,3] = 1;
                CurGrid[2,4] = 1;
                CurGrid[4,4] = 1; //rule 4

        }

        public int getOne() {

            return CurGrid[0,0];
        }

        public int getTwo() {

            return CurGrid[5,2];
        }

        public int getThree() {

            return CurGrid[8,4];
        }

        public int getFour() {

            return CurGrid[3,4];
        }

        public void DrawTest() {

            string output = "";
            for (int i = 0; i < X; i++)
            {
                for (int j =0; j< Y; j++)
                {
                    if (CurGrid[i, j] == 1)
                        output += "X";
                    else
                        output += "O";
                }
                output += "\n";
            }
            Console.WriteLine(output);
        }

        public int getAliveTest(int x, int y)
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

                    aliveCount += CurGrid[x + i, y + j];
                }
            }

            return aliveCount;
        }
  
        public void growNextTest()
        {
            for (int x = 0; x < X; x++)
            {
                for (int y = 0; y < Y; y++)
                {
                    int live = getAliveTest(x, y);

                    if (CurGrid[x, y] == 1 && live < 2)
                        NexGrid[x, y] = 0;

                    else if (CurGrid[x, y] == 1 && live > 3)
                        NexGrid[x, y] = 0;

                    else if (CurGrid[x, y] == 0 && live == 3)
                        NexGrid[x, y] = 1;

                    else
                        NexGrid[x, y] = CurGrid[x, y];

                }
            }

            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    CurGrid[i, j] = NexGrid[i, j];
                }
            }
        }
    }
}