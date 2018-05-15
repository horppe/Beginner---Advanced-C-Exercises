﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Graph_Loops
{
    class GraphTest
    {
        static void Main(string[] args)
        {
            GraphComponents graph = new GraphComponents();
            List<string> paths = graph.FindLoops();
            Console.ReadKey();
        }
    }
    class GraphComponents
    {
        class Graph
        {
            public List<int>[] childNodes;

            public Graph(int size)
            {
                childNodes = new List<int>[size];
                for (int i = 0; i < childNodes.Length; i++)
                {
                    childNodes[i] = new List<int>();
                }
            }

            public Graph(List<int>[] childNodes)
            {
                this.childNodes = childNodes;
            }
            public int Size
            {
                get { return childNodes.Length; }
            }
            public void AddEdge(int v, int s)
            {
                childNodes[v].Add(s);
            }
            public void RemoveEdge(int v, int s)
            {
                childNodes[v].Remove(s);
            }
            public bool HasEdge(int v, int s)
            {
                bool hasEdge = childNodes[v].Contains(s);
                return hasEdge;
            }
            public bool Contains(int vertex)
            {
                if (childNodes[vertex] != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        Graph graph = new Graph(new List<int>[] {
        new List<int>() {1},
        new List<int>() {2},
        new List<int>() {3},
        new List<int>() {0, 4, 5},
        new List<int>() {6, 5},
        new List<int>() {7},
        new List<int>() {3, 8},
        new List<int>() {6},
        new List<int>() {0}
        });

        bool[] visited;
        public GraphComponents()
        {
            visited = new bool[graph.Size];
        }

        public List<int> FindShortestPath(int x, int y)
        {   //First declare and initiate the needed tools to traverse and store the values
            Queue<int> que = new Queue<int>();  //*que stores the paths we pass through
            Stack<int> stk = new Stack<int>();  //*stk enables DFS Traversal through the graph
            bool[] visitedNode = new bool[visited.Length];  //*visitedNode keeps the record of visited nodes
            List<int> shortestPath = new List<int>();   //List *shortestPath is used to save the current and shortest path to the destination found
            List<int> paths = GetPaths(x);  //*paths contains the successors of the starting vertex
            foreach (int path in paths)
            {   //each Path in *paths is Traversed individually to avoid clashes between different routes.
                stk.Push(x);
                que.Enqueue(x); //values are pushed in *stk and *que to kick off the -Traverse method
                visitedNode[x] = true;  //vertex *x is marked visited before the traversal begins
                stk.Push(path); //one of the *paths of x is pushed into the *stk before traversal
                visitedNode[path] = true;   //the path pushed into *stk is maked visited
                shortestPath = Traverse(stk, que, shortestPath, visitedNode, y);    //The *path is traversed to find the destination *y
                stk.Clear();
                que.Clear();
                visitedNode = new bool[visited.Length];
                //all used variables are cleared of the previous journey before starting the next traversal.
            }

            return shortestPath;
        }
        private List<int> Traverse(Stack<int> stk, Queue<int> que, List<int> shortestPath, bool[] visitedNode, int y)
        {
            int currentPath = stk.Pop();    //the *currentPath is popped out of the stack
            que.Enqueue(currentPath);   //*que keeps a record of the visit to *currentPath
            if (currentPath == y)
            {   //If destination is found
                if (shortestPath.Count <= 0)
                {   //If no path was found before now
                    shortestPath = SavePath(que, shortestPath);
                }
                else if (que.Count < shortestPath.Count)
                {   //If a path was found before the current one
                    shortestPath = SavePath(que, shortestPath);
                }
                return shortestPath;    //End current traversal and return the path
            }
            List<int> paths = GetPaths(currentPath);    //get the successors of the *currentPath
            foreach (int path in paths)
            {   //Traverse each successor of *currentPath
                if (!visitedNode[path])
                {   //check if the vertex is already visted
                    stk.Push(path);
                    visitedNode[path] = true;   //if not visited, push into stack and mark as visited
                    bool[] currentBoolNodes = new bool[visitedNode.Length];
                    visitedNode.CopyTo(currentBoolNodes, 0);
                    Queue<int> currentQueue = new Queue<int>(que);  //Swap the variables sent into the Recursive call, to enable step-back if a *path is not valid
                    Traverse(stk, currentQueue, shortestPath, currentBoolNodes, y);
                }
            }

            return shortestPath;
        }
        public List<int> GetPaths(int vertex)
        {
            return graph.childNodes[vertex];
        }
        private List<int> SavePath(Queue<int> que, List<int> shortPath)
        {
            int[] tmpArray = new int[que.Count];
            que.CopyTo(tmpArray, 0);    //first copy *que into an array
            if (shortPath.Count > 0)
            {
                shortPath = new List<int>();
            }   //and then move into a list
            foreach (int path in tmpArray)
            {
                shortPath.Add(path);
            }
            return shortPath;   //return the list
        }

        public bool IsCyclic()
        {
            int start = graph.childNodes[0][0];
            bool[] cyclicVisited = new bool[visited.Length];
            Stack<int> stk = new Stack<int>();
            stk.Push(start);
            cyclicVisited[start] = true;
            while (stk.Count > 0)
            {
                int currentVertex = stk.Pop();
                List<int> successors = GetPaths(currentVertex);
                foreach (int path in successors)
                {
                    if (cyclicVisited[path] == true)
                    {   //If we visit an already visited vertex, then the Graph is cyclic
                        return true;
                    }
                    stk.Push(path);
                    cyclicVisited[path] = true;
                }
            }

            return false;
        }

        public void DirectedBFS()
        {
            Queue<int> que = new Queue<int>();
            for (int i = 0; i < graph.Size; i++)
            {
                if (!visited[i])
                {
                    que.Enqueue(i);
                    visited[i] = true;
                }
            }

            while (que.Count > 0)
            {
                int currentPath = que.Dequeue();
                Console.Write(currentPath + " ");
            }
        }

        public List<string> FindLoops()
        {
            List<string> loops = new List<string>();
            Queue<int> que = new Queue<int>();
            bool[] tmpVisited = new bool[visited.Length];
            for (int i = 0; i < graph.Size; i++)
            {
                ExploreGraph(1, que, loops, tmpVisited);
            }
            return loops;
        }

        private void ExploreGraph(int path, Queue<int> que, List<string> loops, bool[] currentVisited)
        {
            if (!currentVisited[path])
            {
                que.Enqueue(path);
                currentVisited[path] = true;
                foreach (int vertex in GetPaths(path))
                {
                    Queue<int> tmpQueue = new Queue<int>(que);
                    bool[] tmp = new bool[currentVisited.Length];
                    currentVisited.CopyTo(tmp, 0);
                    ExploreGraph(vertex, tmpQueue, loops, tmp);
                }
            }
            else
            {
                List<int> route = new List<int>(que);
                if (CheckLoops(route, loops, path))
                {
                    SaveLoop(que, loops, path);
                }
            }
        }

        private void SaveLoop(Queue<int> que, List<string> loops, int lastPath)
        {
            StringBuilder str = new StringBuilder();
            List<int> route = new List<int>(que);
            int start = route.IndexOf(lastPath);
            if (start < 0)
            {
                return;
            }
            int count = route.Count - start;
            int[] result = new int[count];
            route.CopyTo(start, result, 0, count);
            route = new List<int>(result);
            foreach (int path in route)
            {
                str.AppendFormat("{0}, ", path);
            }
            str.Append(lastPath.ToString());
            loops.Add(str.ToString());

        }

        private bool CheckLoops(List<int> route, List<string> loops, int lastPath)
        {
            if (loops.Count <= 0)
            {
                return true;
            }
            else
            {
                int state = 0;
                int start = route.IndexOf(lastPath);
                int count = route.Count - start;
                int[] tmp = new int[count];
                route.CopyTo(start, tmp, 0, count);
                route = new List<int>(tmp);
                route.Add(lastPath);
                for (int i = 0; i < loops.Count; i++)
                {
                    string[] tmpList = loops[i].Split(',');
                    int[] tmpIntList = new int[tmpList.Length];
                    for (int j = 0; j < tmpList.Length; j++)
                    {   //Convert each *loop route to an interger array for comparison
                        tmpIntList[j] = int.Parse(tmpList[j].Trim());
                    }
                    for (int a = 0; a < tmpIntList.Length; a++)
                    {
                        if (a >= route.Count)
                        {
                            state = -1;
                            break;
                        }
                        if (route[a] == tmpIntList[a])
                        {
                            state++;
                        }
                        else
                        {
                            state--;
                        }
                    }
                    if (state == tmpIntList.Length)
                    {
                        return false;
                    }
                    state = 0;
                }
                return true;
            }
        }

        
        
    }

}
