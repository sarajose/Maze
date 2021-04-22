using System;
using System.Collections.Generic;
using System.Text;

namespace New_maze
{
    class Search
    {
        static int length;
        static int width;
        int[,] maze = new int[length, width];
        int[] start = new int[2];
        int[] end = new int[2];

        public Search(int[,] maze, int[] start, int[] end)
        {
            this.maze = maze;
            this.start = start;
            this.end = end;
        }

        public List<int[]> DFS_search(int[,] maze, int[] start, int[] end, int length, int width)
        {
            int[] pos = start;
            int[] newPos = { 0, 0 };
            int[] node = new int[6]; // x, y, l, f, u, d
            //Visited intersections stack (x,y) 
            Stack<int[]> visited = new Stack<int[]>();
            Queue<int[]> nodes = new Queue<int[]>();
            //Current path (x,y)
            List<int[]> path = new List<int[]>();
            int left = 0, right = 0, up = 0, down = 0;
            while (pos != end)
            {   
                if (!visited.Contains(pos))
                {
                    visited.Push(pos);
                    Console.WriteLine("Position visited");
                }

                newPos[1] = maze[pos[0],pos[1]--];
                if (newPos[1] == 0 && !visited.Contains(newPos))
                {
                    left = 1;
                }

                newPos[1] = maze[pos[0], pos[1]++];
                if (newPos[1]++ == 0 && !visited.Contains(newPos))
                {
                    right = 1;
                }

                newPos[0] = maze[pos[0]++, pos[1]];
                if (newPos[0] == 0 && !visited.Contains(newPos))
                {
                    up = 1;
                }

                newPos[0] = maze[pos[0]--, pos[1]];
                if (newPos[0] == 0 && !visited.Contains(newPos))
                {
                    down = 1;
                }
                
                else continue;

                //Save as node
                if(left + right + up + down >= 3)
                {
                    node[0] = pos[0]; node[1] = pos[1];
                    node[2] = left; node[2] = right; node[3] = up; node[4] = down;
                    nodes.Enqueue(node);
                    Console.WriteLine("Node enqueued");
                }

                //Move left unit the end
                if(left==1)
                {
                    pos[1]--;
                    left = 0;

                }

                else if (right == 1)
                {
                    pos[0]++;
                    right = 0;
                }

                else if (up == 1)
                {
                    pos[1]++;
                    up = 0;
                }

                else if (down == 1)
                {
                    pos[1]--;
                    down = 0;
                }

                else
                {
                    //All options in node have been used. Pull last node.
                    node = nodes.Dequeue();
                    pos[0] = node[0];
                    pos[1] = node[1];
                    Console.WriteLine("Node dequeued");
                }

                // Reset parameters
                left = 0; right = 0; up = 0; down = 0;
            }

            return path;
        }


    }
}
