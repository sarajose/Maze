using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Program
    {
        static int [,] initializeMaze ()
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
        // Check if cell is free (0) or there is a block (1)
        static int CheckCell(int currentPosX, int currentPosY, int newPosX, int newPosY, int[,] Maze)
        {
            newPosX += currentPosX;
            newPosY += currentPosY;
            if ((newPosX >= 0 && newPosY >= 0) && (Maze[newPosY, newPosX] == 0))
            {
                //Console.WriteLine("Position : {0}, {1} New position: {2}, {3}. There is a 0", currentPosX, currentPosY, newPosX, newPosY); (Check)
                return 0;
            }
            else
            {
                //Console.WriteLine("Position : {0}, {1} New position: {2}, {3}. There is a 1 or out of maze", currentPosX, currentPosY, newPosX, newPosY); (Check)
                return 1;
            }

        }

        static void Main(string[] args)
        {
            //Initilaze maze and its variables
            int[,] newMaze = initializeMaze();
            int mazeLength = newMaze.GetLength(1);
            int mazeWidth = newMaze.GetLength(0);
            int[,] visitedPos = new int[mazeLength * mazeWidth, 2];
            int[] currentPos = new int[2];
            //Visited intersections dictionary (x,y): (intersections, used)
            Dictionary<int[], bool> Intersections = new Dictionary<int[], bool>();   
            List<int[,]> path = new List<int[,]>();

            //Look for initial point (0, y+1)
            for (int i = 0; i < mazeLength; i++)
            {
                int firstRow = newMaze[0, i];
                if (firstRow == 0)
                {
                    currentPos[0] = i;
                    currentPos[1] = 1;
                }
            }

            //Check possible free positions
            int isLeftFree = CheckCell(currentPos[0], currentPos[1], -1, 0, newMaze);
            int isRightFree = CheckCell(currentPos[0], currentPos[1], 1, 0, newMaze);
            int isUpFree = CheckCell(currentPos[0], currentPos[1], 0, -1, newMaze);
            int isDownFree = CheckCell(currentPos[0], currentPos[1], 0, 1, newMaze);

            // Number of possible intersections 1-3 (no moving diagonally allowed)
            // If 3 intersections save position, and used= false in dict
            if(isLeftFree + isRightFree + isUpFree+ isDownFree < 2)
            {
                Intersections.Add(currentPos, false);
                //it has been properly added (check)
                foreach (var value in Intersections.Values)
                {
                    Console.WriteLine("Value is: {0}", value);
                }
                foreach (var key in Intersections.Keys)
                {
                    Console.WriteLine("Value x: {0} and y: {1}", key[0], key[1]);
                }
            }
        }
    }
}
