using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_maze
{
    class Program
    {
        static int[,] initializeMaze()
        {
            int[,] sampleMaze = new int[,]
            {
                {1, 1, 1, 0, 1, 1, 1, 1, 1},
                {1, 0, 0, 0, 0, 0, 0, 0, 1},
                {1, 0, 1, 1, 1, 0, 1, 0, 1},
                {1, 0, 0, 0, 1, 0, 1, 0, 1},
                {1, 0, 1, 0, 1, 0, 1, 1, 1},
                {1, 0, 0, 0, 1, 0, 0, 1, 1},
                {1, 1, 1, 0, 0, 1, 0, 0, 1},
                {1, 1, 1, 1, 1, 1, 1, 0, 1}
            };

            return sampleMaze;
        }

        static void Main(string[] args)
        {
            //Initilaze maze
            int[,] newMaze = initializeMaze();
            int mazeLength = newMaze.GetLength(1); //y
            int mazeWidth = newMaze.GetLength(0); //x
            //Start and end positon
            int[] startPos = new int[2];
            int[] endPos = new int[2];
            // Solution path
            List<int[]> solution = new List<int[]>();

            Console.WriteLine("Maze instatiated");

            //Start and end point (0, y) (l, y) (cntr k cntr c)
            for (int i = 0; i <= mazeWidth-1; i++)
            {
                int firstrow = newMaze[0, i];
                int lastrow = newMaze[i, mazeLength-1];
                if (newMaze[0, i] == 0)
                {
                    startPos[0] = i;
                    startPos[1] = 0;
                }
                else if (newMaze[mazeLength-2, i] == 0) 
                {
                    endPos[0] = i;
                    endPos[1] = mazeLength - 3; // one row up
                }
                else continue;
            }

            Console.WriteLine("Length:{0} Width:{1} " +
                "\n Initial Pos{2},{3} End Pos{4},{5}", mazeLength, mazeWidth, startPos[0], startPos[1], endPos[0], endPos[1]);

           Search firstSearch = new Search(newMaze, startPos, endPos);
           solution = firstSearch.DFS_search(newMaze, startPos, endPos, mazeLength, mazeWidth);
        }
    }
}
