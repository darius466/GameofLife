using System;
using System.Threading;

namespace CGOL {

    public class GameOfLife {

            public static int X = 10;
            public static int Y = 10;

            public static int [ , ] CurGen = new int [X, Y];
            public static int [ , ] NexGen = new int [X, Y];

            public GameOfLife() {
                var rand = new Random();           
                for (int i = 0; i < X; i++) {
                    for (int j = 0; j < Y; j++) {
                    if (rand.Next(0, 10) < 50)
                        CurGen[i, j] = 0;
                    else
                        CurGen[i, j] = 1;
                    }
                }
            }

            public int getAlive(int x, int y) {
                int aliveCount = 0;
                for (int i = -1; i <= 1; i++) {
                    for (int j = -1; j <= 1; j++) {
                        aliveCount += CurGen[x + i, y + j];
                    }
                }
                aliveCount -= CurGen[x, y];
                return aliveCount;
            }

            public void growNext() {
                for (int x = 0; x < X; x++) {
                    for (int y = 0; y < Y; y++) {
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
                for (int i = 0; i < X; i++) {
                    for (int j = 0; j < Y; j++) {
                        CurGen[i,j] = NexGen[i,j];
                        Console.SetCursorPosition(0,0);
                        if (CurGen[i,j] == 1)
                            Console.Write("x");
                        else
                            Console.Write("-");
                    }
                }
            }

            internal class Program {
                static void Main(string [] args) {
                    GameOfLife gof = new GameOfLife();
                    while(true) {
                        gof.growNext();
                    }
                }
            }


    }
}